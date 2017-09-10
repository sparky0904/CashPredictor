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
            this.fldCurrentDayLabel = new System.Windows.Forms.Label();
            this.btnPredictBalance = new System.Windows.Forms.Button();
            this.fldPayDayText = new System.Windows.Forms.Label();
            this.btnChangePayDay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fldPredictedBalanceLabel = new System.Windows.Forms.Label();
            this.btnUpdateOutgoings = new System.Windows.Forms.Button();
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
            // fldCurrentDayLabel
            // 
            this.fldCurrentDayLabel.AutoSize = true;
            this.fldCurrentDayLabel.Location = new System.Drawing.Point(26, 105);
            this.fldCurrentDayLabel.Name = "fldCurrentDayLabel";
            this.fldCurrentDayLabel.Size = new System.Drawing.Size(26, 13);
            this.fldCurrentDayLabel.TabIndex = 4;
            this.fldCurrentDayLabel.Text = "Day";
            // 
            // btnPredictBalance
            // 
            this.btnPredictBalance.Location = new System.Drawing.Point(12, 301);
            this.btnPredictBalance.Name = "btnPredictBalance";
            this.btnPredictBalance.Size = new System.Drawing.Size(110, 37);
            this.btnPredictBalance.TabIndex = 5;
            this.btnPredictBalance.Text = "Predict Balance";
            this.btnPredictBalance.UseVisualStyleBackColor = true;
            this.btnPredictBalance.Click += new System.EventHandler(this.btnPredictBalance_Click);
            // 
            // fldPayDayText
            // 
            this.fldPayDayText.AutoSize = true;
            this.fldPayDayText.Location = new System.Drawing.Point(19, 144);
            this.fldPayDayText.Name = "fldPayDayText";
            this.fldPayDayText.Size = new System.Drawing.Size(45, 13);
            this.fldPayDayText.TabIndex = 6;
            this.fldPayDayText.Text = "Pay day";
            // 
            // btnChangePayDay
            // 
            this.btnChangePayDay.Location = new System.Drawing.Point(13, 190);
            this.btnChangePayDay.Name = "btnChangePayDay";
            this.btnChangePayDay.Size = new System.Drawing.Size(109, 38);
            this.btnChangePayDay.TabIndex = 7;
            this.btnChangePayDay.Text = "Change Pay Day";
            this.btnChangePayDay.UseVisualStyleBackColor = true;
            this.btnChangePayDay.Click += new System.EventHandler(this.btnChangePayDay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Predicted Balance is";
            // 
            // fldPredictedBalanceLabel
            // 
            this.fldPredictedBalanceLabel.AutoSize = true;
            this.fldPredictedBalanceLabel.Location = new System.Drawing.Point(29, 397);
            this.fldPredictedBalanceLabel.Name = "fldPredictedBalanceLabel";
            this.fldPredictedBalanceLabel.Size = new System.Drawing.Size(35, 13);
            this.fldPredictedBalanceLabel.TabIndex = 9;
            this.fldPredictedBalanceLabel.Text = "label3";
            // 
            // btnUpdateOutgoings
            // 
            this.btnUpdateOutgoings.Location = new System.Drawing.Point(12, 445);
            this.btnUpdateOutgoings.Name = "btnUpdateOutgoings";
            this.btnUpdateOutgoings.Size = new System.Drawing.Size(110, 34);
            this.btnUpdateOutgoings.TabIndex = 10;
            this.btnUpdateOutgoings.Text = "Update Outgoings";
            this.btnUpdateOutgoings.UseVisualStyleBackColor = true;
            this.btnUpdateOutgoings.Click += new System.EventHandler(this.btnUpdateOutgoings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 562);
            this.Controls.Add(this.btnUpdateOutgoings);
            this.Controls.Add(this.fldPredictedBalanceLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChangePayDay);
            this.Controls.Add(this.fldPayDayText);
            this.Controls.Add(this.btnPredictBalance);
            this.Controls.Add(this.fldCurrentDayLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fldBalance);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.onActivated);
            this.Load += new System.EventHandler(this.eventFormLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fldBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label fldCurrentDayLabel;
        private System.Windows.Forms.Button btnPredictBalance;
        private System.Windows.Forms.Label fldPayDayText;
        private System.Windows.Forms.Button btnChangePayDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fldPredictedBalanceLabel;
        private System.Windows.Forms.Button btnUpdateOutgoings;
    }
}

