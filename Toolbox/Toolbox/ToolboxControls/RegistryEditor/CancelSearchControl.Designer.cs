﻿namespace NetOffice.DeveloperToolbox.ToolboxControls.RegistryEditor
{
    partial class CancelSearchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // CancelLinkLabel
            // 
            this.CancelLinkLabel.AutoSize = true;
            this.CancelLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelLinkLabel.Location = new System.Drawing.Point(65, 7);
            this.CancelLinkLabel.Name = "CancelLinkLabel";
            this.CancelLinkLabel.Size = new System.Drawing.Size(96, 16);
            this.CancelLinkLabel.TabIndex = 0;
            this.CancelLinkLabel.TabStop = true;
            this.CancelLinkLabel.Text = "Cancel Search";
            // 
            // CancelSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(227)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.CancelLinkLabel);
            this.Name = "CancelSearchControl";
            this.Size = new System.Drawing.Size(230, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel CancelLinkLabel;
    }
}
