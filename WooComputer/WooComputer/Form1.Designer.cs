namespace WooComputer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtARegister = new System.Windows.Forms.TextBox();
            this.txtDRegister = new System.Windows.Forms.TextBox();
            this.txtInstructionAddress = new System.Windows.Forms.TextBox();
            this.txtMemoryValue = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A Register: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "D Register:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instruction Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Memory Value:";
            // 
            // txtARegister
            // 
            this.txtARegister.Location = new System.Drawing.Point(120, 18);
            this.txtARegister.Name = "txtARegister";
            this.txtARegister.Size = new System.Drawing.Size(100, 20);
            this.txtARegister.TabIndex = 4;
            // 
            // txtDRegister
            // 
            this.txtDRegister.Location = new System.Drawing.Point(119, 49);
            this.txtDRegister.Name = "txtDRegister";
            this.txtDRegister.Size = new System.Drawing.Size(100, 20);
            this.txtDRegister.TabIndex = 5;
            // 
            // txtInstructionAddress
            // 
            this.txtInstructionAddress.Location = new System.Drawing.Point(119, 80);
            this.txtInstructionAddress.Name = "txtInstructionAddress";
            this.txtInstructionAddress.Size = new System.Drawing.Size(100, 20);
            this.txtInstructionAddress.TabIndex = 6;
            // 
            // txtMemoryValue
            // 
            this.txtMemoryValue.Location = new System.Drawing.Point(119, 111);
            this.txtMemoryValue.Name = "txtMemoryValue";
            this.txtMemoryValue.Size = new System.Drawing.Size(100, 20);
            this.txtMemoryValue.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(16, 164);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtMemoryValue);
            this.Controls.Add(this.txtInstructionAddress);
            this.Controls.Add(this.txtDRegister);
            this.Controls.Add(this.txtARegister);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtARegister;
        private System.Windows.Forms.TextBox txtDRegister;
        private System.Windows.Forms.TextBox txtInstructionAddress;
        private System.Windows.Forms.TextBox txtMemoryValue;
        private System.Windows.Forms.Button btnReset;
    }
}

