namespace PuttyMadness
{
    partial class KeyHookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyHookForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxCapture = new System.Windows.Forms.CheckBox();
            this.puttySelectorPanel1 = new PuttyMadness.PuttySelectorPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem1.Text = "Launch";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // cbxCapture
            // 
            this.cbxCapture.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbxCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCapture.Location = new System.Drawing.Point(154, 231);
            this.cbxCapture.Name = "cbxCapture";
            this.cbxCapture.Size = new System.Drawing.Size(206, 40);
            this.cbxCapture.TabIndex = 7;
            this.cbxCapture.Text = "Keyboard Capture";
            this.cbxCapture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbxCapture.UseVisualStyleBackColor = true;
            this.cbxCapture.CheckedChanged += new System.EventHandler(this.cbxCapture_CheckedChanged);
            // 
            // puttySelectorPanel1
            // 
            this.puttySelectorPanel1.AvailableItemsTitle = "Open Putty Windows";
            this.puttySelectorPanel1.Location = new System.Drawing.Point(5, 2);
            this.puttySelectorPanel1.Name = "puttySelectorPanel1";
            this.puttySelectorPanel1.RecognizedWindowsOnly = false;
            this.puttySelectorPanel1.SelectedItemsTitle = "Windows To Control";
            this.puttySelectorPanel1.Size = new System.Drawing.Size(506, 223);
            this.puttySelectorPanel1.TabIndex = 9;
            // 
            // KeyHookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 280);
            this.Controls.Add(this.puttySelectorPanel1);
            this.Controls.Add(this.cbxCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "KeyHookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Putty Keyboard Hook Controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KeyHookForm_FormClosed);
            this.Load += new System.EventHandler(this.KeyHookForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbxCapture;
        private PuttySelectorPanel puttySelectorPanel1;
    }
}