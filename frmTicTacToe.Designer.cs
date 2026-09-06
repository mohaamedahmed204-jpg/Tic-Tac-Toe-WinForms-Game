namespace Fifth_project
{
    partial class frmMainForm
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
            this.pnlPanelContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlPanelContainer
            // 
            this.pnlPanelContainer.BackColor = System.Drawing.Color.White;
            this.pnlPanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPanelContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlPanelContainer.Name = "pnlPanelContainer";
            this.pnlPanelContainer.Size = new System.Drawing.Size(814, 423);
            this.pnlPanelContainer.TabIndex = 0;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 423);
            this.Controls.Add(this.pnlPanelContainer);
            this.DoubleBuffered = true;
            this.Name = "frmMainForm";
            this.Text = "Tic-Tac-Toe";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanelContainer;
    }
}

