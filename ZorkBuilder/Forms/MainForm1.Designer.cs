
namespace ZorkBuilder.Forms
{
    partial class MainForm1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.worldGame = new System.Windows.Forms.TabPage();
            this.equippedItemControl3 = new ZorkBuilder.Controls.EquippedItemControl();
            this.equippedItemControl2 = new ZorkBuilder.Controls.EquippedItemControl();
            this.equippedItemControl1 = new ZorkBuilder.Controls.EquippedItemControl();
            this.neighborNorth = new ZorkBuilder.Controls.EquippedItemControl();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.roomDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteRoomsButton = new System.Windows.Forms.Button();
            this.addRoomsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.roomsListBox = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.startingLocationLabel = new System.Windows.Forms.Label();
            this.gameTabPage = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.roomsDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.worldGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "&Run";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.worldGame);
            this.mainTabControl.Controls.Add(this.gameTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(0, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(590, 502);
            this.mainTabControl.TabIndex = 1;
            // 
            // worldGame
            // 
            this.worldGame.Controls.Add(this.equippedItemControl3);
            this.worldGame.Controls.Add(this.equippedItemControl2);
            this.worldGame.Controls.Add(this.equippedItemControl1);
            this.worldGame.Controls.Add(this.neighborNorth);
            this.worldGame.Controls.Add(this.descriptionLabel);
            this.worldGame.Controls.Add(this.roomDescriptionRichTextBox);
            this.worldGame.Controls.Add(this.nameLabel);
            this.worldGame.Controls.Add(this.roomNameTextBox);
            this.worldGame.Controls.Add(this.deleteRoomsButton);
            this.worldGame.Controls.Add(this.addRoomsButton);
            this.worldGame.Controls.Add(this.label1);
            this.worldGame.Controls.Add(this.roomsListBox);
            this.worldGame.Controls.Add(this.comboBox1);
            this.worldGame.Controls.Add(this.startingLocationLabel);
            this.worldGame.Location = new System.Drawing.Point(4, 22);
            this.worldGame.Name = "worldGame";
            this.worldGame.Padding = new System.Windows.Forms.Padding(3);
            this.worldGame.Size = new System.Drawing.Size(582, 476);
            this.worldGame.TabIndex = 0;
            this.worldGame.Text = "World";
            this.worldGame.UseVisualStyleBackColor = true;
            // 
            // equippedItemControl3
            // 
            this.equippedItemControl3.ChosenDirection = ZorkGame.Directions.SOUTH;
            this.equippedItemControl3.ChosenRoom = null;
            this.equippedItemControl3.Location = new System.Drawing.Point(321, 384);
            this.equippedItemControl3.Name = "equippedItemControl3";
            this.equippedItemControl3.Room = null;
            this.equippedItemControl3.Size = new System.Drawing.Size(122, 49);
            this.equippedItemControl3.TabIndex = 14;
            // 
            // equippedItemControl2
            // 
            this.equippedItemControl2.ChosenDirection = ZorkGame.Directions.EAST;
            this.equippedItemControl2.ChosenRoom = null;
            this.equippedItemControl2.Location = new System.Drawing.Point(452, 308);
            this.equippedItemControl2.Name = "equippedItemControl2";
            this.equippedItemControl2.Room = null;
            this.equippedItemControl2.Size = new System.Drawing.Size(122, 49);
            this.equippedItemControl2.TabIndex = 13;
            // 
            // equippedItemControl1
            // 
            this.equippedItemControl1.ChosenDirection = ZorkGame.Directions.WEST;
            this.equippedItemControl1.ChosenRoom = null;
            this.equippedItemControl1.Location = new System.Drawing.Point(196, 308);
            this.equippedItemControl1.Name = "equippedItemControl1";
            this.equippedItemControl1.Room = null;
            this.equippedItemControl1.Size = new System.Drawing.Size(122, 49);
            this.equippedItemControl1.TabIndex = 12;
            // 
            // neighborNorth
            // 
            this.neighborNorth.ChosenDirection = ZorkGame.Directions.NORTH;
            this.neighborNorth.ChosenRoom = null;
            this.neighborNorth.Location = new System.Drawing.Point(321, 233);
            this.neighborNorth.Name = "neighborNorth";
            this.neighborNorth.Room = null;
            this.neighborNorth.Size = new System.Drawing.Size(122, 49);
            this.neighborNorth.TabIndex = 11;
            this.neighborNorth.Load += new System.EventHandler(this.neighborNorth_Load);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(212, 92);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 10;
            this.descriptionLabel.Text = "Description:";
            // 
            // roomDescriptionRichTextBox
            // 
            this.roomDescriptionRichTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Description", true));
            this.roomDescriptionRichTextBox.Location = new System.Drawing.Point(212, 108);
            this.roomDescriptionRichTextBox.Name = "roomDescriptionRichTextBox";
            this.roomDescriptionRichTextBox.Size = new System.Drawing.Size(362, 118);
            this.roomDescriptionRichTextBox.TabIndex = 9;
            this.roomDescriptionRichTextBox.Text = "";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(212, 46);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Name:";
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Name", true));
            this.roomNameTextBox.Location = new System.Drawing.Point(212, 65);
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(362, 20);
            this.roomNameTextBox.TabIndex = 6;
            // 
            // deleteRoomsButton
            // 
            this.deleteRoomsButton.Location = new System.Drawing.Point(115, 440);
            this.deleteRoomsButton.Name = "deleteRoomsButton";
            this.deleteRoomsButton.Size = new System.Drawing.Size(75, 23);
            this.deleteRoomsButton.TabIndex = 5;
            this.deleteRoomsButton.Text = "Delete";
            this.deleteRoomsButton.UseVisualStyleBackColor = true;
            // 
            // addRoomsButton
            // 
            this.addRoomsButton.Location = new System.Drawing.Point(11, 440);
            this.addRoomsButton.Name = "addRoomsButton";
            this.addRoomsButton.Size = new System.Drawing.Size(75, 23);
            this.addRoomsButton.TabIndex = 4;
            this.addRoomsButton.Text = "Add";
            this.addRoomsButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rooms:";
            // 
            // roomsListBox
            // 
            this.roomsListBox.DataSource = this.roomsBindingSource;
            this.roomsListBox.DisplayMember = "Description";
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.Location = new System.Drawing.Point(11, 65);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(179, 368);
            this.roomsListBox.TabIndex = 2;
            this.roomsListBox.ValueMember = "ChosenNeighbors";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // startingLocationLabel
            // 
            this.startingLocationLabel.AutoSize = true;
            this.startingLocationLabel.Location = new System.Drawing.Point(6, 3);
            this.startingLocationLabel.Name = "startingLocationLabel";
            this.startingLocationLabel.Size = new System.Drawing.Size(90, 13);
            this.startingLocationLabel.TabIndex = 0;
            this.startingLocationLabel.Text = "Starting Location:";
            // 
            // gameTabPage
            // 
            this.gameTabPage.Location = new System.Drawing.Point(4, 22);
            this.gameTabPage.Name = "gameTabPage";
            this.gameTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.gameTabPage.Size = new System.Drawing.Size(582, 476);
            this.gameTabPage.TabIndex = 1;
            this.gameTabPage.Text = "Game";
            this.gameTabPage.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(212, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(362, 20);
            this.textBox1.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(212, 108);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(362, 118);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // roomsDescriptionRichTextBox
            // 
            this.roomsDescriptionRichTextBox.Location = new System.Drawing.Point(212, 108);
            this.roomsDescriptionRichTextBox.Name = "roomsDescriptionRichTextBox";
            this.roomsDescriptionRichTextBox.Size = new System.Drawing.Size(362, 118);
            this.roomsDescriptionRichTextBox.TabIndex = 9;
            this.roomsDescriptionRichTextBox.Text = "";
            // 
            // roomsBindingSource
            // 
            this.roomsBindingSource.DataSource = typeof(ZorkGame.Room);
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 529);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm1";
            this.Text = "MainForm1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.worldGame.ResumeLayout(false);
            this.worldGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage worldGame;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.RichTextBox roomDescriptionRichTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.Button deleteRoomsButton;
        private System.Windows.Forms.Button addRoomsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox roomsListBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label startingLocationLabel;
        private System.Windows.Forms.TabPage gameTabPage;
        private Controls.EquippedItemControl neighborNorth;
        private Controls.EquippedItemControl equippedItemControl3;
        private Controls.EquippedItemControl equippedItemControl2;
        private Controls.EquippedItemControl equippedItemControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox roomsDescriptionRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.BindingSource roomsBindingSource;
    }
}