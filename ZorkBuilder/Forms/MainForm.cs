using System.Windows.Forms;
using System;
using System.IO;
using Newtonsoft.Json;
using InventoryManager.Data;

//Ask Varcholik if there's a quick and easy way to just change the namespace for all the scripts at once without breaking anything

using ZorkBuilder.ViewModels;

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
