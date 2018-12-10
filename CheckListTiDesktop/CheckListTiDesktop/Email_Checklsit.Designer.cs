namespace CheckListTiDesktop
{
    partial class Email
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Email));
            this.to = new System.Windows.Forms.Label();
            this.inputTo = new System.Windows.Forms.TextBox();
            this.inputSubject = new System.Windows.Forms.TextBox();
            this.subject = new System.Windows.Forms.Label();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // to
            // 
            this.to.AutoSize = true;
            this.to.Location = new System.Drawing.Point(12, 31);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(29, 13);
            this.to.TabIndex = 0;
            this.to.Text = "Para";
            this.to.Click += new System.EventHandler(this.label1_Click);
            // 
            // inputTo
            // 
            this.inputTo.Location = new System.Drawing.Point(15, 47);
            this.inputTo.Name = "inputTo";
            this.inputTo.Size = new System.Drawing.Size(283, 20);
            this.inputTo.TabIndex = 1;
            this.inputTo.TextChanged += new System.EventHandler(this.inputTo_TextChanged);
            this.inputTo.VisibleChanged += new System.EventHandler(this.inputTo_Leave);
            this.inputTo.Leave += new System.EventHandler(this.inputTo_Leave);
            // 
            // inputSubject
            // 
            this.inputSubject.Location = new System.Drawing.Point(15, 86);
            this.inputSubject.Name = "inputSubject";
            this.inputSubject.Size = new System.Drawing.Size(283, 20);
            this.inputSubject.TabIndex = 3;
            this.inputSubject.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // subject
            // 
            this.subject.AutoSize = true;
            this.subject.Location = new System.Drawing.Point(12, 70);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(45, 13);
            this.subject.TabIndex = 2;
            this.subject.Text = "Assunto";
            this.subject.Click += new System.EventHandler(this.label2_Click);
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(15, 137);
            this.msgBox.Multiline = true;
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(283, 268);
            this.msgBox.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(42, 454);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "Enviar";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(205, 454);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 507);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.inputSubject);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.inputTo);
            this.Controls.Add(this.to);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Email";
            this.Text = "Envio Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label to;
        private System.Windows.Forms.TextBox inputTo;
        private System.Windows.Forms.TextBox inputSubject;
        private System.Windows.Forms.Label subject;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_cancel;
    }
}