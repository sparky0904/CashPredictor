namespace CashPredictor
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
            this.fldBalance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fldCurrentDay = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPredictBalance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fldBalance
            // 
            this.fldBalance.Location = new System.Drawing.Point(13, 62);
            this.fldBalance.Name = "fldBalance";
            this.fldBalance.Size = new System.Drawing.Size(109, 20);
            this.fldBalance.TabIndex = 0;
            this.fldBalance.Text = "325";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Balance";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(148, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(606, 538);
            this.dataGridView1.TabIndex = 2;
            // 
            // fldCurrentDay
            // 
            this.fldCurrentDay.FormattingEnabled = true;
            this.fldCurrentDay.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.fldCurrentDay.Location = new System.Drawing.Point(29, 121);
            this.fldCurrentDay.Name = "fldCurrentDay";
            this.fldCurrentDay.Size = new System.Drawing.Size(36, 108);
            this.fldCurrentDay.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Day";
            // 
            // btnPredictBalance
            // 
            this.btnPredictBalance.Location = new System.Drawing.Point(22, 319);
            this.btnPredictBalance.Name = "btnPredictBalance";
            this.btnPredictBalance.Size = new System.Drawing.Size(100, 25);
            this.btnPredictBalance.TabIndex = 5;
            this.btnPredictBalance.Text = "Predict Balance";
            this.btnPredictBalance.UseVisualStyleBackColor = true;
            this.btnPredictBalance.Click += new System.EventHandler(this.btnPredictBalance_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 562);
            this.Controls.Add(this.btnPredictBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fldCurrentDay);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fldBalance);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.eventFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fldBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox fldCurrentDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPredictBalance;
    }
}

