using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace PuttyMadness
{
    class PuttySearch
    {
        // This method searches for Putty or Pageant
        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            string fullPath;

            // If the user previously told us where to look, look there
            var hkcu = Microsoft.Win32.Registry.CurrentUser;
            var rk = hkcu.OpenSubKey(@"Software\PuttyMadness");
            if (rk != null)
            {
                fullPath = Path.Combine(rk.GetValue("PuttyExeDir", "-!-!-!-").ToString(), fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }

            // If it exists on the path, return it
            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }

            // Or maybe we can find it by looking for the .ppk handler
            var hkcr = Registry.ClassesRoot;
            rk = hkcr.OpenSubKey(@"PuTTYPrivateKey\shell\open\command");
            if (rk != null)
            {
                string cmd = rk.GetValue(null, "").ToString();
                if (cmd != "")
                {
                    var first_tok = cmd.Split('"')
                        .Select((element, index) => index % 2 == 0  // If even index
                        ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
                        : new string[] { element })  // Keep the entire item
                        .SelectMany(element => element)
                        .First();
                    fullPath = Path.Combine(Path.GetDirectoryName(first_tok), fileName);
                    if (File.Exists(fullPath))
                        return fullPath;
                }
            }

            // Or maybe we can just take a wild guess
            string[] possiblePaths = { 
                Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles), "PuTTY"), 
                System.Environment.SpecialFolder.DesktopDirectory.ToString() };
            foreach (string tryPath in possiblePaths)
            {
                fullPath = Path.Combine(tryPath, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }

            // No luck - so we just have to ask the user what to do
            var pedf = new PuttyExeDirForm();
            if (pedf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fullPath = Path.Combine(pedf.lblPath.Text, fileName);
                if (File.Exists(fullPath))
                {
                    rk = hkcu.CreateSubKey(@"Software\PuttyMadness");
                    rk.SetValue("PuttyExeDir", pedf.lblPath.Text);
                    return fullPath;
                }
            }

            return null;
        }
    }
}
