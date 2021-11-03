using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using InventoryManager.Data;
using ZorkBuilder.ViewModels;

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
            }
        }

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new WorldViewModel();
            IsWorldLoaded = false;
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

        #region Add / Delete Item
        private void AddItemButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {

        }
        #endregion Add / Delete Item

        #region Main Menu
        private void OpenWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;
                IsWorldLoaded = true;
            }
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


        //private void SaveWorld()
        //{
        //    if (string.IsNullOrEmpty(ViewModel.Filename))
        //    {
        //        throw new InvalidProgramException("Filename expected.");
        //    }

        //    JsonSerializer serializer = new JsonSerializer
        //    { 
        //        Formatting = Formatting.Indented
        //    };
        //    using (StreamWriter streamWriter = new StreamWriter(ViewModel.Filename))
        //    using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
        //    {
        //        serializer.Serialize(jsonWriter, ViewModel.World)
        //    }
        //}
            
        private WorldViewModel m_ViewModel;
        private bool mIsWorldLoaded;


        private void MainForm_Load(object sender, EventArgs e)
        {

        }


    }
}
