namespace CashPredictor
{
    partial class frmOutgoings
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
            this.fldOutgoings = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fldDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fldDayPaid = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fldAmount = new System.Windows.Forms.TextBox();
            this.fldReoccuring = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fldDayOfWeekPaid = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.fldFrequency = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fldOutgoings
            // 
            this.fldOutgoings.FormattingEnabled = true;
            this.fldOutgoings.Location = new System.Drawing.Point(27, 33);
            this.fldOutgoings.Name = "fldOutgoings";
            this.fldOutgoings.Size = new System.Drawing.Size(141, 394);
            this.fldOutgoings.TabIndex = 0;
            this.fldOutgoings.SelectedIndexChanged += new System.EventHandler(this.onSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description";
            // 
            // fldDescription
            // 
            this.fldDescription.Location = new System.Drawing.Point(181, 50);
            this.fldDescription.Name = "fldDescription";
            this.fldDescription.Size = new System.Drawing.Size(194, 20);
            this.fldDescription.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date payment leaves account";
            // 
            // fldDayPaid
            // 
            this.fldDayPaid.BackColor = System.Drawing.Color.White;
            this.fldDayPaid.FormattingEnabled = true;
            this.fldDayPaid.Location = new System.Drawing.Point(181, 93);
            this.fldDayPaid.Name = "fldDayPaid";
            this.fldDayPaid.Size = new System.Drawing.Size(121, 21);
            this.fldDayPaid.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount";
            // 
            // fldAmount
            // 
            this.fldAmount.Location = new System.Drawing.Point(181, 139);
            this.fldAmount.Name = "fldAmount";
            this.fldAmount.Size = new System.Drawing.Size(100, 20);
            this.fldAmount.TabIndex = 6;
            // 
            // fldReoccuring
            // 
            this.fldReoccuring.AutoSize = true;
            this.fldReoccuring.Location = new System.Drawing.Point(181, 165);
            this.fldReoccuring.Name = "fldReoccuring";
            this.fldReoccuring.Size = new System.Drawing.Size(81, 17);
            this.fldReoccuring.TabIndex = 8;
            this.fldReoccuring.Text = "Reoccuring";
            this.fldReoccuring.UseVisualStyleBackColor = true;
            this.fldReoccuring.CheckedChanged += new System.EventHandler(this.fldReoccuring_OnCheckedChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Day Each Week";
            // 
            // fldDayOfWeekPaid
            // 
            this.fldDayOfWeekPaid.FormattingEnabled = true;
            this.fldDayOfWeekPaid.Location = new System.Drawing.Point(181, 206);
            this.fldDayOfWeekPaid.Name = "fldDayOfWeekPaid";
            this.fldDayOfWeekPaid.Size = new System.Drawing.Size(121, 21);
            this.fldDayOfWeekPaid.TabIndex = 10;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(174, 313);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 34);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(244, 313);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 34);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(384, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 34);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(314, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 34);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Frequency (No of Days)";
            // 
            // fldFrequency
            // 
            this.fldFrequency.Location = new System.Drawing.Point(181, 251);
            this.fldFrequency.Name = "fldFrequency";
            this.fldFrequency.Size = new System.Drawing.Size(32, 20);
            this.fldFrequency.TabIndex = 17;
            // 
            // frmOutgoings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 446);
            this.Controls.Add(this.fldFrequency);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.fldDayOfWeekPaid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fldReoccuring);
            this.Controls.Add(this.fldAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fldDayPaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fldDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fldOutgoings);
            this.Name = "frmOutgoings";
            this.Text = "frmOutgoings";
            this.Activated += new System.EventHandler(this.onActiviated);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fldOutgoings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fldDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fldDayPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fldAmount;
        private System.Windows.Forms.CheckBox fldReoccuring;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox fldDayOfWeekPaid;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fldFrequency;
    }
}