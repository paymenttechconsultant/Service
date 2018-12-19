namespace TestPaymentService
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnTender = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(250, 10);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(124, 42);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(242, 112);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(133, 20);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnTender
            // 
            this.btnTender.Enabled = false;
            this.btnTender.Location = new System.Drawing.Point(242, 193);
            this.btnTender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTender.Name = "btnTender";
            this.btnTender.Size = new System.Drawing.Size(132, 28);
            this.btnTender.TabIndex = 2;
            this.btnTender.Text = "Tender";
            this.btnTender.UseVisualStyleBackColor = true;
            this.btnTender.Click += new System.EventHandler(this.btnTender_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Amount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTender);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnConnect);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnTender;
        private System.Windows.Forms.Label label1;
    }
}

