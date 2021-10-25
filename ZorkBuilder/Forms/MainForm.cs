using System.Windows.Forms;
using System.IO;
using System;
using InventoryManager.Data;
using ZorkBuilder.ViewModels;
using Newtonsoft.Json;

namespace ZorkBuilder
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

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new WorldViewModel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(openFileDialog.FileName));

                ViewModel.Filename = openFileDialog.FileName;
            }
        }

        private WorldViewModel m_ViewModel;

        private void filenameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
