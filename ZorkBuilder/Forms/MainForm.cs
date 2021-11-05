using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using InventoryManager.Data;
using ZorkBuilder.ViewModels;
using ZorkBuilder.Controls;

//-----------------------------------------------------------------------------//
//TO DO:
//  - Add rooms + neighbors (cardinal directions and all that)
//  - Add binding source for the player's starting location
//  -
//  - Finish DataBinding videos 3 & 4



//Use lightning symbol to remove accidental functions

namespace ZorkBuilder.Forms

{
    public partial class MainForm : Form
    {
        public static string AssemblyTitle = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;

        private WorldViewModel ViewModel
        {
            get => m_ViewModel;
            set
            {
                if (m_ViewModel != value)
                {
                    m_ViewModel = value;
                    worldViewModelBindingSource.DataSource = m_ViewModel;
                }
            }
        }

        private bool IsWorldLoaded 
        {
            get => mIsWorldLoaded;
            set
            {
                mIsWorldLoaded = value;
                mainTabControl.Enabled = mIsWorldLoaded;
                saveToolStripMenuItem.Enabled = mIsWorldLoaded;
                saveAsToolStripMenuItem.Enabled = mIsWorldLoaded;
                closeWorldToolStripMenuItem.Enabled = mIsWorldLoaded;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new WorldViewModel();
            IsWorldLoaded = false;

            mEquippedItemControlMap = new Dictionary<EquipLocations, EquippedItemControl>
            {
                { EquipLocations.LeftHand, leftHandEquippedItemControl },
                { EquipLocations.RightHand, rightHandEquippedItemControl },
                { EquipLocations.Head, headEquippedItemControl },
                { EquipLocations.Feet, feetEquippedItemControl }
            };
        }

        #region Add / Delete Player
        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            using (AddPlayerForm addPlayerForm = new AddPlayerForm())
            {
                if (addPlayerForm.ShowDialog() == DialogResult.OK)
                {
                    Player player = new Player { Name = addPlayerForm.PlayerName };
                    ViewModel.Players.Add(player);
                }
            }
        }

        private void PlayersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deletePlayerButton.Enabled = playersListBox.SelectedItem != null;

            Player selectedPlayer = playersListBox.SelectedItem as Player;
            foreach (var control in mEquippedItemControlMap.Values)
            {
                control.Player = selectedPlayer;
            }
        }

        private void DeletePlayerButton_Click(object sender, EventArgs e)
        {
            //MAKE THIS FUNCTIONAL || CANNOT SUBMIT WITHOUT THIS || (Data binding Part 2 @ 31:31)
            if (MessageBox.Show("Delete this player?", AssemblyTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ViewModel.Players.Remove((Player)playersListBox.SelectedItem);
                playersListBox.SelectedItem = ViewModel.Players.FirstOrDefault();
            }
        }

        #endregion Add / Delete Player


        //--------------------------------------------------------------------------------//


        #region Add / Delete Item
        private void AddItemButton_Click(object sender, EventArgs e)
        {
            using (AddItemForm addItemForm = new AddItemForm())
            {
                if (addItemForm.ShowDialog() == DialogResult.OK)
                {
                    Item item = new Item {Name = addItemForm.ItemName };
                    ViewModel.Items.Add(item);
                }
            }
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteItemButton.Enabled = itemsListBox.SelectedItem != null;
        }

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this item?", AssemblyTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ViewModel.Items.Remove((Item)itemsListBox.SelectedItem);
                itemsListBox.SelectedItem = ViewModel.Items.FirstOrDefault();
            }
        }

        #endregion Add / Delete Item

        #region Main Menu
        private void OpenWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;

                Player selectedPlayer = playersListBox.SelectedItem as Player;
                foreach (var control in mEquippedItemControlMap.Values)
                {
                    control.Player = selectedPlayer;
                }

                IsWorldLoaded = true;
            }
        }
        private void NewWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                ViewModel.NewWorld();
                IsWorldLoaded = true;
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(saveFileDialog.FileName));
            }
        }

        private void CloseWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewModel.World = null;

            IsWorldLoaded = false;
        }

        //Expression Bodied Member
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) => ViewModel.SaveWorld();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                ViewModel.SaveWorld();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Main Menu


        private WorldViewModel m_ViewModel;
        private bool mIsWorldLoaded;
        private readonly Dictionary<EquipLocations, EquippedItemControl> mEquippedItemControlMap;
    }
}
