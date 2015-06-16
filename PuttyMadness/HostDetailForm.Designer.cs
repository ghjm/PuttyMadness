namespace PuttyMadness
{
    partial class HostDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostDetailForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textHostname = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textRequiredKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textJumpCmd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textJumpHost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnJustConnect = new System.Windows.Forms.Button();
            this.textOverrideIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textNote = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hostname:";
            // 
            // textHostname
            // 
            this.textHostname.Location = new System.Drawing.Point(89, 12);
            this.textHostname.Name = "textHostname";
            this.textHostname.Size = new System.Drawing.Size(310, 20);
            this.textHostname.TabIndex = 1;
            this.textHostname.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(89, 96);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(310, 20);
            this.textUsername.TabIndex = 7;
            this.textUsername.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(133, 318);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(214, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // textRequiredKey
            // 
            this.textRequiredKey.Location = new System.Drawing.Point(89, 138);
            this.textRequiredKey.Name = "textRequiredKey";
            this.textRequiredKey.Size = new System.Drawing.Size(281, 20);
            this.textRequiredKey.TabIndex = 10;
            this.textRequiredKey.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Required Key:";
            // 
            // textJumpCmd
            // 
            this.textJumpCmd.Location = new System.Drawing.Point(89, 222);
            this.textJumpCmd.Name = "textJumpCmd";
            this.textJumpCmd.Size = new System.Drawing.Size(310, 20);
            this.textJumpCmd.TabIndex = 17;
            this.textJumpCmd.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Jump Cmd:";
            // 
            // textJumpHost
            // 
            this.textJumpHost.Location = new System.Drawing.Point(89, 180);
            this.textJumpHost.Name = "textJumpHost";
            this.textJumpHost.Size = new System.Drawing.Size(310, 20);
            this.textJumpHost.TabIndex = 14;
            this.textJumpHost.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Jump Host:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 21);
            this.button1.TabIndex = 11;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnJustConnect
            // 
            this.btnJustConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnJustConnect.Location = new System.Drawing.Point(295, 318);
            this.btnJustConnect.Name = "btnJustConnect";
            this.btnJustConnect.Size = new System.Drawing.Size(104, 23);
            this.btnJustConnect.TabIndex = 24;
            this.btnJustConnect.Text = "Just &Connect";
            this.btnJustConnect.UseVisualStyleBackColor = true;
            this.btnJustConnect.Click += new System.EventHandler(this.btnJustConnect_Click);
            // 
            // textOverrideIP
            // 
            this.textOverrideIP.Location = new System.Drawing.Point(89, 54);
            this.textOverrideIP.Name = "textOverrideIP";
            this.textOverrideIP.Size = new System.Drawing.Size(310, 20);
            this.textOverrideIP.TabIndex = 4;
            this.textOverrideIP.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Override IP:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(88, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Name that you will use to connect to this host.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(88, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Specify the IP, if the above name is not resolvable in DNS.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(88, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Username to connect to the host with.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(88, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(278, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "If specified, load this key into Pageant before connecting.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(88, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(316, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Connect Putty to this host, then from there, ssh to the above host.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(88, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(306, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Command to run on the jump host. Default: ssh -A $user@$host";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(88, 285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(220, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Note to pop up when connecting to this host.";
            // 
            // textNote
            // 
            this.textNote.Location = new System.Drawing.Point(89, 264);
            this.textNote.Name = "textNote";
            this.textNote.Size = new System.Drawing.Size(310, 20);
            this.textNote.TabIndex = 20;
            this.textNote.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 267);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Note:";
            // 
            // HostDetailForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 354);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textNote);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textOverrideIP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnJustConnect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textJumpCmd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textJumpHost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textRequiredKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textHostname);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HostDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Host Detail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textHostname;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textRequiredKey;
        private System.Windows.Forms.TextBox textJumpCmd;
        private System.Windows.Forms.TextBox textJumpHost;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textOverrideIP;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnJustConnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textNote;
        private System.Windows.Forms.Label label14;
    }
}