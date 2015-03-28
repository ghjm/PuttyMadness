namespace PuttyMadness
{
    partial class KnownKeysForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KnownKeysForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lstKeys = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbnPPK = new System.Windows.Forms.RadioButton();
            this.rbnRemoteKey = new System.Windows.Forms.RadioButton();
            this.txtPPK = new System.Windows.Forms.TextBox();
            this.btnPPKOpen = new System.Windows.Forms.Button();
            this.txtRemoteHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemoteCommand = new System.Windows.Forms.TextBox();
            this.txtAddKey = new System.Windows.Forms.TextBox();
            this.btnAddKey = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(295, 262);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(376, 262);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "ppk";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Putty Keys|*.ppk|All Files|*.*";
            this.openFileDialog1.Title = "Select Putty Keys";
            // 
            // lstKeys
            // 
            this.lstKeys.ContextMenuStrip = this.contextMenuStrip1;
            this.lstKeys.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstKeys.FormattingEnabled = true;
            this.lstKeys.Location = new System.Drawing.Point(15, 25);
            this.lstKeys.Name = "lstKeys";
            this.lstKeys.Size = new System.Drawing.Size(193, 212);
            this.lstKeys.TabIndex = 1;
            this.lstKeys.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstKeys_DrawItem);
            this.lstKeys.SelectedIndexChanged += new System.EventHandler(this.lstKeys_SelectedIndexChanged);
            this.lstKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstKeys_KeyDown);
            this.lstKeys.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstKeys_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key Names:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selected Key Details:";
            // 
            // rbnPPK
            // 
            this.rbnPPK.AutoSize = true;
            this.rbnPPK.Location = new System.Drawing.Point(229, 25);
            this.rbnPPK.Name = "rbnPPK";
            this.rbnPPK.Size = new System.Drawing.Size(68, 17);
            this.rbnPPK.TabIndex = 5;
            this.rbnPPK.TabStop = true;
            this.rbnPPK.Text = "PPK File:";
            this.rbnPPK.UseVisualStyleBackColor = true;
            this.rbnPPK.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.rbnPPK.Click += new System.EventHandler(this.KeyDetailTextChanged);
            // 
            // rbnRemoteKey
            // 
            this.rbnRemoteKey.AutoSize = true;
            this.rbnRemoteKey.Location = new System.Drawing.Point(229, 86);
            this.rbnRemoteKey.Name = "rbnRemoteKey";
            this.rbnRemoteKey.Size = new System.Drawing.Size(86, 17);
            this.rbnRemoteKey.TabIndex = 8;
            this.rbnRemoteKey.TabStop = true;
            this.rbnRemoteKey.Text = "Remote Key:";
            this.rbnRemoteKey.UseVisualStyleBackColor = true;
            this.rbnRemoteKey.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.rbnRemoteKey.Click += new System.EventHandler(this.KeyDetailTextChanged);
            // 
            // txtPPK
            // 
            this.txtPPK.Enabled = false;
            this.txtPPK.Location = new System.Drawing.Point(238, 48);
            this.txtPPK.Name = "txtPPK";
            this.txtPPK.Size = new System.Drawing.Size(192, 20);
            this.txtPPK.TabIndex = 6;
            this.txtPPK.TextChanged += new System.EventHandler(this.KeyDetailTextChanged);
            // 
            // btnPPKOpen
            // 
            this.btnPPKOpen.Enabled = false;
            this.btnPPKOpen.Location = new System.Drawing.Point(427, 45);
            this.btnPPKOpen.Name = "btnPPKOpen";
            this.btnPPKOpen.Size = new System.Drawing.Size(24, 23);
            this.btnPPKOpen.TabIndex = 7;
            this.btnPPKOpen.Text = "...";
            this.btnPPKOpen.UseVisualStyleBackColor = true;
            this.btnPPKOpen.Click += new System.EventHandler(this.btnPPKOpen_Click);
            // 
            // txtRemoteHost
            // 
            this.txtRemoteHost.Enabled = false;
            this.txtRemoteHost.Location = new System.Drawing.Point(238, 128);
            this.txtRemoteHost.Name = "txtRemoteHost";
            this.txtRemoteHost.Size = new System.Drawing.Size(192, 20);
            this.txtRemoteHost.TabIndex = 10;
            this.txtRemoteHost.TextChanged += new System.EventHandler(this.KeyDetailTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Remote Host:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Key Load Command:";
            // 
            // txtRemoteCommand
            // 
            this.txtRemoteCommand.Enabled = false;
            this.txtRemoteCommand.Location = new System.Drawing.Point(238, 170);
            this.txtRemoteCommand.Name = "txtRemoteCommand";
            this.txtRemoteCommand.Size = new System.Drawing.Size(192, 20);
            this.txtRemoteCommand.TabIndex = 12;
            this.txtRemoteCommand.TextChanged += new System.EventHandler(this.KeyDetailTextChanged);
            // 
            // txtAddKey
            // 
            this.txtAddKey.AcceptsReturn = true;
            this.txtAddKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddKey.Location = new System.Drawing.Point(16, 243);
            this.txtAddKey.Name = "txtAddKey";
            this.txtAddKey.Size = new System.Drawing.Size(154, 20);
            this.txtAddKey.TabIndex = 2;
            this.txtAddKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddKey_KeyPress);
            // 
            // btnAddKey
            // 
            this.btnAddKey.Location = new System.Drawing.Point(170, 241);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(38, 23);
            this.btnAddKey.TabIndex = 3;
            this.btnAddKey.Text = "Add";
            this.btnAddKey.UseVisualStyleBackColor = true;
            this.btnAddKey.Click += new System.EventHandler(this.btnAddKey_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(13, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "(Name must match Pageant \"comment\" field.)";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(238, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 59);
            this.label6.TabIndex = 16;
            this.label6.Text = "(Key load command is typically a script that runs something like \"sudo ssh-add\" t" +
    "o add a key to Pageant from a remote host.)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // KnownKeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(463, 296);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddKey);
            this.Controls.Add(this.txtAddKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemoteCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemoteHost);
            this.Controls.Add(this.btnPPKOpen);
            this.Controls.Add(this.txtPPK);
            this.Controls.Add(this.rbnRemoteKey);
            this.Controls.Add(this.rbnPPK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstKeys);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KnownKeysForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Known Keys";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox lstKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbnPPK;
        private System.Windows.Forms.RadioButton rbnRemoteKey;
        private System.Windows.Forms.TextBox txtPPK;
        private System.Windows.Forms.Button btnPPKOpen;
        private System.Windows.Forms.TextBox txtRemoteHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemoteCommand;
        private System.Windows.Forms.TextBox txtAddKey;
        private System.Windows.Forms.Button btnAddKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}