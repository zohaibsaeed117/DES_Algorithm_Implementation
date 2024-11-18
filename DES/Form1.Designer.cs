namespace DES
{
    partial class Form1
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
            this.heading_lbl = new System.Windows.Forms.Label();
            this.UploadFileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.file_lbl = new System.Windows.Forms.Label();
            this.Action_btn = new System.Windows.Forms.Button();
            this.radio_encrypt = new System.Windows.Forms.RadioButton();
            this.radio_decrypt = new System.Windows.Forms.RadioButton();
            this.key_input = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // heading_lbl
            // 
            this.heading_lbl.AutoSize = true;
            this.heading_lbl.Font = new System.Drawing.Font("Academic M54", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heading_lbl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.heading_lbl.Location = new System.Drawing.Point(259, 9);
            this.heading_lbl.Name = "heading_lbl";
            this.heading_lbl.Size = new System.Drawing.Size(472, 47);
            this.heading_lbl.TabIndex = 0;
            this.heading_lbl.Text = "Welcome to DES Portal";
            // 
            // UploadFileBtn
            // 
            this.UploadFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UploadFileBtn.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadFileBtn.ForeColor = System.Drawing.Color.Black;
            this.UploadFileBtn.Location = new System.Drawing.Point(170, 397);
            this.UploadFileBtn.Name = "UploadFileBtn";
            this.UploadFileBtn.Size = new System.Drawing.Size(172, 54);
            this.UploadFileBtn.TabIndex = 1;
            this.UploadFileBtn.Text = "Select File";
            this.UploadFileBtn.UseVisualStyleBackColor = true;
            this.UploadFileBtn.Click += new System.EventHandler(this.UploadFileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Selected:";
            // 
            // file_lbl
            // 
            this.file_lbl.AutoSize = true;
            this.file_lbl.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_lbl.Location = new System.Drawing.Point(334, 130);
            this.file_lbl.Name = "file_lbl";
            this.file_lbl.Size = new System.Drawing.Size(63, 28);
            this.file_lbl.TabIndex = 3;
            this.file_lbl.Text = "none";
            // 
            // Action_btn
            // 
            this.Action_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Action_btn.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Action_btn.ForeColor = System.Drawing.Color.Black;
            this.Action_btn.Location = new System.Drawing.Point(569, 397);
            this.Action_btn.Name = "Action_btn";
            this.Action_btn.Size = new System.Drawing.Size(172, 54);
            this.Action_btn.TabIndex = 4;
            this.Action_btn.Text = "Encrypt";
            this.Action_btn.UseVisualStyleBackColor = true;
            this.Action_btn.Click += new System.EventHandler(this.Action_btn_Click);
            // 
            // radio_encrypt
            // 
            this.radio_encrypt.AutoSize = true;
            this.radio_encrypt.Checked = true;
            this.radio_encrypt.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_encrypt.Location = new System.Drawing.Point(328, 312);
            this.radio_encrypt.Name = "radio_encrypt";
            this.radio_encrypt.Size = new System.Drawing.Size(111, 32);
            this.radio_encrypt.TabIndex = 5;
            this.radio_encrypt.TabStop = true;
            this.radio_encrypt.Text = "Encrypt";
            this.radio_encrypt.UseVisualStyleBackColor = true;
            this.radio_encrypt.CheckedChanged += new System.EventHandler(this.radio_encrypt_CheckedChanged);
            // 
            // radio_decrypt
            // 
            this.radio_decrypt.AutoSize = true;
            this.radio_decrypt.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_decrypt.Location = new System.Drawing.Point(463, 312);
            this.radio_decrypt.Name = "radio_decrypt";
            this.radio_decrypt.Size = new System.Drawing.Size(112, 32);
            this.radio_decrypt.TabIndex = 6;
            this.radio_decrypt.Text = "Decrypt";
            this.radio_decrypt.UseVisualStyleBackColor = true;
            this.radio_decrypt.CheckedChanged += new System.EventHandler(this.radio_decrypt_CheckedChanged);
            // 
            // key_input
            // 
            this.key_input.Font = new System.Drawing.Font("Titr", 8.25F);
            this.key_input.Location = new System.Drawing.Point(178, 262);
            this.key_input.Name = "key_input";
            this.key_input.Size = new System.Drawing.Size(548, 32);
            this.key_input.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(178, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Enter Secret Key:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(979, 589);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.key_input);
            this.Controls.Add(this.radio_decrypt);
            this.Controls.Add(this.radio_encrypt);
            this.Controls.Add(this.Action_btn);
            this.Controls.Add(this.file_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UploadFileBtn);
            this.Controls.Add(this.heading_lbl);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label heading_lbl;
        private System.Windows.Forms.Button UploadFileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label file_lbl;
        private System.Windows.Forms.Button Action_btn;
        private System.Windows.Forms.RadioButton radio_encrypt;
        private System.Windows.Forms.RadioButton radio_decrypt;
        private System.Windows.Forms.TextBox key_input;
        private System.Windows.Forms.Label label2;
    }
}

