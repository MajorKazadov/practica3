namespace esoft
{
    partial class Zadachi
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Zagolovok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managerFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executorFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusFilter = new System.Windows.Forms.ComboBox();
            this.ExecutorFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Zagolovok,
            this.Status,
            this.managerFIO,
            this.executorFIO});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(645, 323);
            this.dataGridView1.TabIndex = 0;
            // 
            // Zagolovok
            // 
            this.Zagolovok.HeaderText = "Заголовок";
            this.Zagolovok.Name = "Zagolovok";
            this.Zagolovok.ReadOnly = true;
            this.Zagolovok.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "Статус";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // managerFIO
            // 
            this.managerFIO.HeaderText = "ФИО менеджера";
            this.managerFIO.Name = "managerFIO";
            this.managerFIO.ReadOnly = true;
            this.managerFIO.Width = 150;
            // 
            // executorFIO
            // 
            this.executorFIO.HeaderText = "ФИО исполнителя";
            this.executorFIO.Name = "executorFIO";
            this.executorFIO.ReadOnly = true;
            this.executorFIO.Width = 150;
            // 
            // StatusFilter
            // 
            this.StatusFilter.FormattingEnabled = true;
            this.StatusFilter.Location = new System.Drawing.Point(123, 378);
            this.StatusFilter.Name = "StatusFilter";
            this.StatusFilter.Size = new System.Drawing.Size(121, 21);
            this.StatusFilter.TabIndex = 1;
            // 
            // ExecutorFilter
            // 
            this.ExecutorFilter.FormattingEnabled = true;
            this.ExecutorFilter.Location = new System.Drawing.Point(123, 405);
            this.ExecutorFilter.Name = "ExecutorFilter";
            this.ExecutorFilter.Size = new System.Drawing.Size(121, 21);
            this.ExecutorFilter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фильтры:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "По статусу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "По исполнителю";
            // 
            // Zadachi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExecutorFilter);
            this.Controls.Add(this.StatusFilter);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Zadachi";
            this.Text = "Zadachi";
            this.Load += new System.EventHandler(this.Zadachi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zagolovok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn executorFIO;
        private System.Windows.Forms.ComboBox StatusFilter;
        private System.Windows.Forms.ComboBox ExecutorFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}