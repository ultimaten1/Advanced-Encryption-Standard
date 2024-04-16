namespace Group7_Module2
{
    partial class frmAES
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
            this.lblAES = new System.Windows.Forms.Label();
            this.txtInputText = new System.Windows.Forms.TextBox();
            this.lblInputText = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblEncryptText = new System.Windows.Forms.Label();
            this.txtEncryptText = new System.Windows.Forms.TextBox();
            this.lblDecryptText = new System.Windows.Forms.Label();
            this.txtDecryptText = new System.Windows.Forms.TextBox();
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAES
            // 
            this.lblAES.AutoSize = true;
            this.lblAES.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAES.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAES.Location = new System.Drawing.Point(336, 25);
            this.lblAES.Name = "lblAES";
            this.lblAES.Size = new System.Drawing.Size(522, 32);
            this.lblAES.TabIndex = 1;
            this.lblAES.Text = "Advanced Encryption Standard (AES)";
            // 
            // txtInputText
            // 
            this.txtInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputText.Location = new System.Drawing.Point(170, 104);
            this.txtInputText.Multiline = true;
            this.txtInputText.Name = "txtInputText";
            this.txtInputText.Size = new System.Drawing.Size(379, 62);
            this.txtInputText.TabIndex = 2;
            // 
            // lblInputText
            // 
            this.lblInputText.AutoSize = true;
            this.lblInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputText.Location = new System.Drawing.Point(53, 104);
            this.lblInputText.Name = "lblInputText";
            this.lblInputText.Size = new System.Drawing.Size(97, 25);
            this.lblInputText.TabIndex = 3;
            this.lblInputText.Text = "Input text:";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(687, 101);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(53, 25);
            this.lblKey.TabIndex = 5;
            this.lblKey.Text = "Key:";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(761, 101);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(379, 65);
            this.txtKey.TabIndex = 4;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(275, 408);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(145, 57);
            this.btnEncrypt.TabIndex = 7;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(872, 408);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(145, 57);
            this.btnDecrypt.TabIndex = 8;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblEncryptText
            // 
            this.lblEncryptText.AutoSize = true;
            this.lblEncryptText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncryptText.Location = new System.Drawing.Point(30, 314);
            this.lblEncryptText.Name = "lblEncryptText";
            this.lblEncryptText.Size = new System.Drawing.Size(120, 25);
            this.lblEncryptText.TabIndex = 10;
            this.lblEncryptText.Text = "Encrypt text:";
            // 
            // txtEncryptText
            // 
            this.txtEncryptText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncryptText.Location = new System.Drawing.Point(170, 314);
            this.txtEncryptText.Multiline = true;
            this.txtEncryptText.Name = "txtEncryptText";
            this.txtEncryptText.Size = new System.Drawing.Size(379, 62);
            this.txtEncryptText.TabIndex = 9;
            // 
            // lblDecryptText
            // 
            this.lblDecryptText.AutoSize = true;
            this.lblDecryptText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecryptText.Location = new System.Drawing.Point(619, 317);
            this.lblDecryptText.Name = "lblDecryptText";
            this.lblDecryptText.Size = new System.Drawing.Size(121, 25);
            this.lblDecryptText.TabIndex = 12;
            this.lblDecryptText.Text = "Decrypt text:";
            // 
            // txtDecryptText
            // 
            this.txtDecryptText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptText.Location = new System.Drawing.Point(761, 314);
            this.txtDecryptText.Multiline = true;
            this.txtDecryptText.Name = "txtDecryptText";
            this.txtDecryptText.Size = new System.Drawing.Size(379, 62);
            this.txtDecryptText.TabIndex = 11;
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateKey.Location = new System.Drawing.Point(872, 191);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(145, 57);
            this.btnGenerateKey.TabIndex = 15;
            this.btnGenerateKey.Text = "Generate key";
            this.btnGenerateKey.UseVisualStyleBackColor = true;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // frmAES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 545);
            this.Controls.Add(this.btnGenerateKey);
            this.Controls.Add(this.lblDecryptText);
            this.Controls.Add(this.txtDecryptText);
            this.Controls.Add(this.lblEncryptText);
            this.Controls.Add(this.txtEncryptText);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.txtInputText);
            this.Controls.Add(this.lblAES);
            this.Name = "frmAES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAES;
        private System.Windows.Forms.TextBox txtInputText;
        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblEncryptText;
        private System.Windows.Forms.TextBox txtEncryptText;
        private System.Windows.Forms.Label lblDecryptText;
        private System.Windows.Forms.TextBox txtDecryptText;
        private System.Windows.Forms.Button btnGenerateKey;
    }
}

