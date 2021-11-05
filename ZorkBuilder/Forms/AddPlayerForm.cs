using System;
using System.Windows.Forms;

namespace ZorkBuilder.Forms
{
    public partial class AddPlayerForm : Form
    {
        public string PlayerName
        {
            get => playerNameTextBox.Text;
            set => playerNameTextBox.Text = value;
        }

        public AddPlayerForm()
        {
            InitializeComponent();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            //use this method to enable the OK button when there is a proper value (an actual name in this case) entered into the text box
            okButton.Enabled = !string.IsNullOrEmpty(PlayerName);
        }


        //No data tied to these
        #region redundancies

        #endregion redundancies

    }
}
