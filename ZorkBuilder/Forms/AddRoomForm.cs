using System;
using System.Windows.Forms;

namespace ZorkBuilder.Forms
{
    public partial class AddRoomForm : Form
    {
        public string RoomName
        {
            get => roomNameTextBox.Text;
            set => roomNameTextBox.Text = value;
        }
        public AddRoomForm()
        {
            InitializeComponent();
        }

        private void roomNameTextBox_TextChanged(object sender, EventArgs e)
        {
            //use this method to enable the OK button when there is a proper value (an actual name in this case) entered into the text box
            okButton.Enabled = !string.IsNullOrEmpty(RoomName);
        }
    }
}
