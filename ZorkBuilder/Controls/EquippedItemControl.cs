using System;
using System.Windows.Forms;
using InventoryManager.Data;

namespace ZorkBuilder.Controls
{
    public partial class EquippedItemControl : UserControl
    {
        public EquipLocations EquipLocation
        {
            get => mEquipLocation;
            set
            {
                mEquipLocation = value;
                equipLocationTextBox.Text = mEquipLocation.ToString();
            }
        }
        public EquippedItemControl()
        {
            InitializeComponent();
        }

        private EquipLocations mEquipLocation;
    }
}
