using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using InventoryManager.Data;
using ZorkBuilder.ViewModels;
using Newtonsoft.Json;

namespace ZorkBuilder.Forms

{
    public partial class MainForm : Form
    {
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
            }
        }

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new WorldViewModel();
            IsWorldLoaded = false;
        }


        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;
                IsWorldLoaded = true;
            }
        }

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
        }

        private void DeletePlayerButton_Click(object sender, EventArgs e)
        {
            ViewModel.Players.Remove((Player)playersListBox.SelectedItem);
            playersListBox.SelectedItem = ViewModel.Players.FirstOrDefault();


            //MAKE THIS FUNCTIONAL || CANNOT SUBMIT WITHOUT THIS || (Data binding Part 2 @ 31:31)
            //if (MessageBox.Show("Delete this player?", ))
            //{

            //}
        }


        private WorldViewModel m_ViewModel;
        private bool mIsWorldLoaded;






        private void filenameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

    }
}
