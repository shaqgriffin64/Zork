
namespace ZorkBuilder.Controls
{
    partial class EquippedItemControl
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
            this.equipLocationTextBox = new System.Windows.Forms.TextBox();
            this.equipLocationComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // equipLocationTextBox
            // 
            this.equipLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equipLocationTextBox.Location = new System.Drawing.Point(1, 1);
            this.equipLocationTextBox.Name = "equipLocationTextBox";
            this.equipLocationTextBox.ReadOnly = true;
            this.equipLocationTextBox.Size = new System.Drawing.Size(120, 20);
            this.equipLocationTextBox.TabIndex = 0;
            this.equipLocationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // equipLocationComboBox
            // 
            this.equipLocationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.equipLocationComboBox.FormattingEnabled = true;
            this.equipLocationComboBox.Location = new System.Drawing.Point(0, 27);
            this.equipLocationComboBox.Name = "equipLocationComboBox";
            this.equipLocationComboBox.Size = new System.Drawing.Size(121, 21);
            this.equipLocationComboBox.TabIndex = 1;
            // 
            // EquippedItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.equipLocationComboBox);
            this.Controls.Add(this.equipLocationTextBox);
            this.Name = "EquippedItemControl";
            this.Size = new System.Drawing.Size(122, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox equipLocationTextBox;
        private System.Windows.Forms.ComboBox equipLocationComboBox;
    }
}
