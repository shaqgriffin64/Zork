
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
            this.directionTextBox = new System.Windows.Forms.TextBox();
            this.directionComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // directionTextBox
            // 
            this.directionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directionTextBox.Location = new System.Drawing.Point(1, 1);
            this.directionTextBox.Name = "directionTextBox";
            this.directionTextBox.ReadOnly = true;
            this.directionTextBox.Size = new System.Drawing.Size(120, 20);
            this.directionTextBox.TabIndex = 0;
            this.directionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // directionComboBox
            // 
            this.directionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directionComboBox.DisplayMember = "Name";
            this.directionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionComboBox.FormattingEnabled = true;
            this.directionComboBox.Location = new System.Drawing.Point(0, 27);
            this.directionComboBox.Name = "directionComboBox";
            this.directionComboBox.Size = new System.Drawing.Size(121, 21);
            this.directionComboBox.TabIndex = 1;
            this.directionComboBox.SelectedIndexChanged += new System.EventHandler(this.EquippedItemComboBox_SelectedIndexChanged);
            // 
            // EquippedItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.directionComboBox);
            this.Controls.Add(this.directionTextBox);
            this.Name = "EquippedItemControl";
            this.Size = new System.Drawing.Size(122, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox directionTextBox;
        private System.Windows.Forms.ComboBox directionComboBox;
    }
}
