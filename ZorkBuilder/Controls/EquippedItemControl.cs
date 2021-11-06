using System.Collections.Generic;
using System.Windows.Forms;
using InventoryManager.Data;
using ZorkGame;

namespace ZorkBuilder.Controls
{
    public partial class EquippedItemControl : UserControl
    {
        public Room Room
        {
            get => mRoom;
            set
            {
                if (mRoom != value)
                {
                    mRoom = value;
                    if (mRoom != null)
                    {
                        var inventory = new List<Room>(mRoom.ChosenNeighbors);
                        inventory.Insert(0, NoNeighbor);

                        //prevents everything from being made null despite preexisting equipped locations
                        directionComboBox.SelectedIndexChanged -= EquippedItemComboBox_SelectedIndexChanged;

                        //No fancy stuff needed since the user won't be altering the inventory with this
                        directionComboBox.DataSource = inventory;
                        ChosenRoom = mRoom.ChosenNeighbors.TryGetValue(ChosenDirection, out Item equippedItem) ? equippedItem: NoNeighbor;

                        directionComboBox.SelectedIndexChanged += EquippedItemComboBox_SelectedIndexChanged;
                    }
                    else
                    {
                        directionComboBox.DataSource = null;
                    }
                }
            }
        }
        public Directions ChosenDirection
        {
            get => mChosenDirections;
            set
            {
                mChosenDirections = value;
                directionTextBox.Text = mChosenDirections.ToString();
            }
        }

        public Room ChosenRoom 
        { 
            //Cast Value
            get => (Room)directionComboBox.SelectedItem; 
            set => directionComboBox.SelectedItem = value; 
        }

        public void SetEquippedItem(Room value)
        {
            directionComboBox.SelectedItem = value;
        }

        public EquippedItemControl()
        {
            InitializeComponent();
        }
        private void EquippedItemComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (mRoom != null)
            {
                Room room = ChosenRoom;
                if (room == NoNeighbor)
                {
                    mRoom.EquippedItems.Remove(ChosenDirection);
                }
                else
                {
                    mRoom.EquippedItems[ChosenDirection] = room;
                }

            }
        }

        private static readonly Room NoNeighbor = new Room() { Name = "None" };

        private Room mRoom;
        private Directions mChosenDirections;

    }
}
