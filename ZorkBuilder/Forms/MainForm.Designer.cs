
namespace ZorkBuilder.Forms
{
    partial class MainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.worldViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.itemsTabPage = new System.Windows.Forms.TabPage();
            this.playersTabPage = new System.Windows.Forms.TabPage();
            this.roomsListBox = new System.Windows.Forms.ListBox();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomDeleteButton = new System.Windows.Forms.Button();
            this.roomAddButton = new System.Windows.Forms.Button();
            this.roomsListBoxLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.startingRoomLabel = new System.Windows.Forms.Label();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.roomDescriptionLabel = new System.Windows.Forms.Label();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.equippedItemsGroupBox = new System.Windows.Forms.GroupBox();
            this.feetEquippedItemControl = new ZorkBuilder.Controls.EquippedItemControl();
            this.rightHandEquippedItemControl = new ZorkBuilder.Controls.EquippedItemControl();
            this.leftHandEquippedItemControl = new ZorkBuilder.Controls.EquippedItemControl();
            this.headEquippedItemControl = new ZorkBuilder.Controls.EquippedItemControl();
            this.inventoryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            this.playersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.equippedItemsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource1)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(561, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWorldToolStripMenuItem,
            this.openWorldToolStripMenuItem,
            this.closeWorldToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newWorldToolStripMenuItem
            // 
            this.newWorldToolStripMenuItem.Name = "newWorldToolStripMenuItem";
            this.newWorldToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newWorldToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.newWorldToolStripMenuItem.Text = "&New World...";
            this.newWorldToolStripMenuItem.Click += new System.EventHandler(this.NewWorldToolStripMenuItem_Click);
            // 
            // openWorldToolStripMenuItem
            // 
            this.openWorldToolStripMenuItem.Name = "openWorldToolStripMenuItem";
            this.openWorldToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openWorldToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openWorldToolStripMenuItem.Text = "&Open World...";
            this.openWorldToolStripMenuItem.Click += new System.EventHandler(this.OpenWorldToolStripMenuItem_Click);
            // 
            // closeWorldToolStripMenuItem
            // 
            this.closeWorldToolStripMenuItem.Name = "closeWorldToolStripMenuItem";
            this.closeWorldToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.closeWorldToolStripMenuItem.Text = "&Close World";
            this.closeWorldToolStripMenuItem.Click += new System.EventHandler(this.CloseWorldToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "World Files (*json)|*json";
            // 
            // worldViewModelBindingSource
            // 
            this.worldViewModelBindingSource.DataSource = typeof(ZorkBuilder.ViewModels.WorldViewModel);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.worldViewModelBindingSource;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Worldfiles(*.json)|*.json";
            this.saveFileDialog.Title = "Save world file";
            // 
            // itemsTabPage
            // 
            this.itemsTabPage.Location = new System.Drawing.Point(4, 22);
            this.itemsTabPage.Name = "itemsTabPage";
            this.itemsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.itemsTabPage.Size = new System.Drawing.Size(553, 455);
            this.itemsTabPage.TabIndex = 1;
            this.itemsTabPage.Text = "Game";
            this.itemsTabPage.UseVisualStyleBackColor = true;
            // 
            // playersTabPage
            // 
            this.playersTabPage.Controls.Add(this.roomsListBox);
            this.playersTabPage.Controls.Add(this.roomDeleteButton);
            this.playersTabPage.Controls.Add(this.roomAddButton);
            this.playersTabPage.Controls.Add(this.roomsListBoxLabel);
            this.playersTabPage.Controls.Add(this.comboBox1);
            this.playersTabPage.Controls.Add(this.startingRoomLabel);
            this.playersTabPage.Controls.Add(this.playerNameTextBox);
            this.playersTabPage.Controls.Add(this.groupBox1);
            this.playersTabPage.Location = new System.Drawing.Point(4, 22);
            this.playersTabPage.Name = "playersTabPage";
            this.playersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.playersTabPage.Size = new System.Drawing.Size(553, 455);
            this.playersTabPage.TabIndex = 0;
            this.playersTabPage.Text = "World";
            this.playersTabPage.UseVisualStyleBackColor = true;
            // 
            // roomsListBox
            // 
            this.roomsListBox.DataSource = this.roomsBindingSource;
            this.roomsListBox.DisplayMember = "Name";
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.Location = new System.Drawing.Point(3, 60);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(155, 355);
            this.roomsListBox.TabIndex = 17;
            this.roomsListBox.ValueMember = "Description";
            this.roomsListBox.SelectedIndexChanged += new System.EventHandler(this.RoomsListBox_SelectedIndexChanged);
            // 
            // roomsBindingSource
            // 
            this.roomsBindingSource.DataMember = "Rooms";
            this.roomsBindingSource.DataSource = this.worldViewModelBindingSource;
            // 
            // roomDeleteButton
            // 
            this.roomDeleteButton.Location = new System.Drawing.Point(84, 421);
            this.roomDeleteButton.Name = "roomDeleteButton";
            this.roomDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.roomDeleteButton.TabIndex = 16;
            this.roomDeleteButton.Text = "&Delete";
            this.roomDeleteButton.UseVisualStyleBackColor = true;
            this.roomDeleteButton.Click += new System.EventHandler(this.RoomDeleteButton_Click);
            // 
            // roomAddButton
            // 
            this.roomAddButton.Location = new System.Drawing.Point(2, 421);
            this.roomAddButton.Name = "roomAddButton";
            this.roomAddButton.Size = new System.Drawing.Size(75, 23);
            this.roomAddButton.TabIndex = 15;
            this.roomAddButton.Text = "&Add...";
            this.roomAddButton.UseVisualStyleBackColor = true;
            this.roomAddButton.Click += new System.EventHandler(this.RoomAddButton_Click);
            // 
            // roomsListBoxLabel
            // 
            this.roomsListBoxLabel.AutoSize = true;
            this.roomsListBoxLabel.Location = new System.Drawing.Point(3, 44);
            this.roomsListBoxLabel.Name = "roomsListBoxLabel";
            this.roomsListBoxLabel.Size = new System.Drawing.Size(43, 13);
            this.roomsListBoxLabel.TabIndex = 14;
            this.roomsListBoxLabel.Text = "Rooms:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // startingRoomLabel
            // 
            this.startingRoomLabel.AutoSize = true;
            this.startingRoomLabel.Location = new System.Drawing.Point(0, 0);
            this.startingRoomLabel.Name = "startingRoomLabel";
            this.startingRoomLabel.Size = new System.Drawing.Size(90, 13);
            this.startingRoomLabel.TabIndex = 13;
            this.startingRoomLabel.Text = "Starting Location:";
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Name", true));
            this.playerNameTextBox.Location = new System.Drawing.Point(167, 30);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(183, 20);
            this.playerNameTextBox.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.roomDescriptionLabel);
            this.groupBox1.Controls.Add(this.roomNameLabel);
            this.groupBox1.Controls.Add(this.equippedItemsGroupBox);
            this.groupBox1.Location = new System.Drawing.Point(162, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 440);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Description", true));
            this.richTextBox1.Location = new System.Drawing.Point(5, 66);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(372, 159);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // roomDescriptionLabel
            // 
            this.roomDescriptionLabel.AutoSize = true;
            this.roomDescriptionLabel.Location = new System.Drawing.Point(3, 50);
            this.roomDescriptionLabel.Name = "roomDescriptionLabel";
            this.roomDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.roomDescriptionLabel.TabIndex = 15;
            this.roomDescriptionLabel.Text = "Description";
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.AutoSize = true;
            this.roomNameLabel.Location = new System.Drawing.Point(5, 7);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(35, 13);
            this.roomNameLabel.TabIndex = 14;
            this.roomNameLabel.Text = "Name";
            // 
            // equippedItemsGroupBox
            // 
            this.equippedItemsGroupBox.Controls.Add(this.feetEquippedItemControl);
            this.equippedItemsGroupBox.Controls.Add(this.rightHandEquippedItemControl);
            this.equippedItemsGroupBox.Controls.Add(this.leftHandEquippedItemControl);
            this.equippedItemsGroupBox.Controls.Add(this.headEquippedItemControl);
            this.equippedItemsGroupBox.Location = new System.Drawing.Point(5, 231);
            this.equippedItemsGroupBox.Name = "equippedItemsGroupBox";
            this.equippedItemsGroupBox.Size = new System.Drawing.Size(374, 203);
            this.equippedItemsGroupBox.TabIndex = 2;
            this.equippedItemsGroupBox.TabStop = false;
            this.equippedItemsGroupBox.Text = "Neighbors";
            // 
            // feetEquippedItemControl
            // 
            this.feetEquippedItemControl.EquipLocation = InventoryManager.Data.EquipLocations.Feet;
            this.feetEquippedItemControl.EquippedItem = null;
            this.feetEquippedItemControl.Location = new System.Drawing.Point(127, 149);
            this.feetEquippedItemControl.Name = "feetEquippedItemControl";
            this.feetEquippedItemControl.Player = null;
            this.feetEquippedItemControl.Size = new System.Drawing.Size(122, 49);
            this.feetEquippedItemControl.TabIndex = 3;
            // 
            // rightHandEquippedItemControl
            // 
            this.rightHandEquippedItemControl.EquipLocation = InventoryManager.Data.EquipLocations.RightHand;
            this.rightHandEquippedItemControl.EquippedItem = null;
            this.rightHandEquippedItemControl.Location = new System.Drawing.Point(251, 74);
            this.rightHandEquippedItemControl.Name = "rightHandEquippedItemControl";
            this.rightHandEquippedItemControl.Player = null;
            this.rightHandEquippedItemControl.Size = new System.Drawing.Size(122, 49);
            this.rightHandEquippedItemControl.TabIndex = 2;
            // 
            // leftHandEquippedItemControl
            // 
            this.leftHandEquippedItemControl.EquipLocation = InventoryManager.Data.EquipLocations.LeftHand;
            this.leftHandEquippedItemControl.EquippedItem = null;
            this.leftHandEquippedItemControl.Location = new System.Drawing.Point(2, 74);
            this.leftHandEquippedItemControl.Name = "leftHandEquippedItemControl";
            this.leftHandEquippedItemControl.Player = null;
            this.leftHandEquippedItemControl.Size = new System.Drawing.Size(122, 49);
            this.leftHandEquippedItemControl.TabIndex = 1;
            // 
            // headEquippedItemControl
            // 
            this.headEquippedItemControl.EquipLocation = InventoryManager.Data.EquipLocations.Head;
            this.headEquippedItemControl.EquippedItem = null;
            this.headEquippedItemControl.Location = new System.Drawing.Point(127, 10);
            this.headEquippedItemControl.Name = "headEquippedItemControl";
            this.headEquippedItemControl.Player = null;
            this.headEquippedItemControl.Size = new System.Drawing.Size(122, 49);
            this.headEquippedItemControl.TabIndex = 0;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.playersTabPage);
            this.mainTabControl.Controls.Add(this.itemsTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(0, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(561, 481);
            this.mainTabControl.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 508);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Manager";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.worldViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            this.playersTabPage.ResumeLayout(false);
            this.playersTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.equippedItemsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource1)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.BindingSource worldViewModelBindingSource;
        private System.Windows.Forms.ToolStripMenuItem openWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private System.Windows.Forms.ToolStripMenuItem closeWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWorldToolStripMenuItem;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.TabPage itemsTabPage;
        private System.Windows.Forms.TabPage playersTabPage;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox equippedItemsGroupBox;
        private Controls.EquippedItemControl feetEquippedItemControl;
        private Controls.EquippedItemControl rightHandEquippedItemControl;
        private Controls.EquippedItemControl leftHandEquippedItemControl;
        private Controls.EquippedItemControl headEquippedItemControl;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.BindingSource inventoryBindingSource1;
        private System.Windows.Forms.Label startingRoomLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label roomsListBoxLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label roomDescriptionLabel;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.Button roomDeleteButton;
        private System.Windows.Forms.Button roomAddButton;
        private System.Windows.Forms.ListBox roomsListBox;
        private System.Windows.Forms.BindingSource roomsBindingSource;
    }
}

