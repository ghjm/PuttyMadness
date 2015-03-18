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
            this.textUsername.Location = new System.Drawing.Point(89, 64);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(310, 20);
            this.textUsername.TabIndex = 5;
            this.textUsername.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(133, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(214, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // textRequiredKey
            // 
            this.textRequiredKey.Location = new System.Drawing.Point(89, 90);
            this.textRequiredKey.Name = "textRequiredKey";
            this.textRequiredKey.Size = new System.Drawing.Size(281, 20);
            this.textRequiredKey.TabIndex = 7;
            this.textRequiredKey.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Required Key:";
            // 
            // textJumpCmd
            // 
            this.textJumpCmd.Location = new System.Drawing.Point(89, 142);
            this.textJumpCmd.Name = "textJumpCmd";
            this.textJumpCmd.Size = new System.Drawing.Size(310, 20);
            this.textJumpCmd.TabIndex = 12;
            this.textJumpCmd.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Jump Cmd:";
            // 
            // textJumpHost
            // 
            this.textJumpHost.Location = new System.Drawing.Point(89, 116);
            this.textJumpHost.Name = "textJumpHost";
            this.textJumpHost.Size = new System.Drawing.Size(310, 20);
            this.textJumpHost.TabIndex = 10;
            this.textJumpHost.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Jump Host:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 21);
            this.button1.TabIndex = 8;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnJustConnect
            // 
            this.btnJustConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnJustConnect.Location = new System.Drawing.Point(295, 175);
            this.btnJustConnect.Name = "btnJustConnect";
            this.btnJustConnect.Size = new System.Drawing.Size(104, 23);
            this.btnJustConnect.TabIndex = 15;
            this.btnJustConnect.Text = "Just &Connect";
            this.btnJustConnect.UseVisualStyleBackColor = true;
            this.btnJustConnect.Click += new System.EventHandler(this.btnJustConnect_Click);
            // 
            // textOverrideIP
            // 
            this.textOverrideIP.Location = new System.Drawing.Point(89, 38);
            this.textOverrideIP.Name = "textOverrideIP";
            this.textOverrideIP.Size = new System.Drawing.Size(310, 20);
            this.textOverrideIP.TabIndex = 3;
            this.textOverrideIP.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Override IP:";
            // 
            // HostDetailForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 210);
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
            this.Name = "HostDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Host Detail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textHostname;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textRequiredKey;
        private System.Windows.Forms.TextBox textJumpCmd;
        private System.Windows.Forms.TextBox textJumpHost;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnJustConnect;
        private System.Windows.Forms.TextBox textOverrideIP;
        private System.Windows.Forms.Label label6;
    }
}