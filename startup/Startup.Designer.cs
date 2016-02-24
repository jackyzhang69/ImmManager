namespace ImmManager
{
    partial class Startup
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pNPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCPNPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pNPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pNPToolStripMenuItem
            // 
            this.pNPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bCPNPToolStripMenuItem});
            this.pNPToolStripMenuItem.Name = "pNPToolStripMenuItem";
            this.pNPToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.pNPToolStripMenuItem.Text = "PNP";
            // 
            // bCPNPToolStripMenuItem
            // 
            this.bCPNPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skillWorkerToolStripMenuItem,
            this.eIToolStripMenuItem});
            this.bCPNPToolStripMenuItem.Name = "bCPNPToolStripMenuItem";
            this.bCPNPToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.bCPNPToolStripMenuItem.Text = "BCPNP";
            // 
            // skillWorkerToolStripMenuItem
            // 
            this.skillWorkerToolStripMenuItem.Name = "skillWorkerToolStripMenuItem";
            this.skillWorkerToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.skillWorkerToolStripMenuItem.Text = "SW";
            this.skillWorkerToolStripMenuItem.Click += new System.EventHandler(this.skillWorkerToolStripMenuItem_Click);
            // 
            // eIToolStripMenuItem
            // 
            this.eIToolStripMenuItem.Name = "eIToolStripMenuItem";
            this.eIToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.eIToolStripMenuItem.Text = "EI";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 487);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pNPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bCPNPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skillWorkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eIToolStripMenuItem;
    }
}

