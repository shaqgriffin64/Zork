using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using ZorkBuilder.ViewModels;
using ZorkBuilder.Controls;
using Newtonsoft.Json.Linq;
using ZorkGame;

namespace ZorkBuilder.Forms
{
    public partial class MainForm1 : Form
    {
        public MainForm1()
        {
            InitializeComponent();
        }

        private void roomsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteRoomsButton.Enabled = roomsListBox.SelectedItem != null;

            Room selectedRoom = roomsListBox.SelectedItem as Room;
            foreach (var control in mEquippedItemControlMap.Values)
            {
                control.Room = selectedRoom;
            }
        }


        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                ViewModel.NewWorld();
                mIsWorldLoaded = true;
                ViewModel.World = JsonConvert.DeserializeObject<World>(File.ReadAllText(saveFileDialog.FileName));
            }
        }

        private void OpenGameToolStripMenuItem_Click(object sender, EventArgs e)
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


            }
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) => ViewModel.SaveWorld();

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                ViewModel.SaveWorld();
            }
        }

        private WorldViewModel ViewModel;
        private bool mIsWorldLoaded;
        private readonly Dictionary<Directions, EquippedItemControl> mEquippedItemControlMap;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
