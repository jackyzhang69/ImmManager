namespace ImmManager
{
    partial class Top100
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
            this.gbTop100 = new System.Windows.Forms.GroupBox();
            this.dgvTop100 = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbTop100.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop100)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTop100
            // 
            this.gbTop100.Controls.Add(this.dgvTop100);
            this.gbTop100.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTop100.Location = new System.Drawing.Point(0, 0);
            this.gbTop100.Name = "gbTop100";
            this.gbTop100.Size = new System.Drawing.Size(1177, 1375);
            this.gbTop100.TabIndex = 0;
            this.gbTop100.TabStop = false;
            this.gbTop100.Text = "View and double click to pick one from the list";
            // 
            // dgvTop100
            // 
            this.dgvTop100.AllowUserToAddRows = false;
            this.dgvTop100.AllowUserToDeleteRows = false;
            this.dgvTop100.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTop100.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTop100.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTop100.Location = new System.Drawing.Point(3, 22);
            this.dgvTop100.MultiSelect = false;
            this.dgvTop100.Name = "dgvTop100";
            this.dgvTop100.ReadOnly = true;
            this.dgvTop100.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTop100.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTop100.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Navy;
            this.dgvTop100.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTop100.RowTemplate.Height = 28;
            this.dgvTop100.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTop100.Size = new System.Drawing.Size(1171, 1350);
            this.dgvTop100.TabIndex = 0;
            this.dgvTop100.ColumnHeadersHeightSizeModeChanged += new System.Windows.Forms.DataGridViewAutoSizeModeEventHandler(this.r);
            this.dgvTop100.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvTop100_MouseDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(865, 1422);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 37);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Top100
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 1474);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbTop100);
            this.Name = "Top100";
            this.Text = "Top100 BC Occupations";
            this.gbTop100.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop100)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTop100;
        private System.Windows.Forms.DataGridView dgvTop100;
        private System.Windows.Forms.Button btnClose;
    }
}