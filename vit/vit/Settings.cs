using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vit
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            gridWidthComboBox.SelectedIndex = gridWidthComboBox.Items.IndexOf(GridSettings.width.ToString());
            gridHeightComboBox.SelectedIndex = gridHeightComboBox.Items.IndexOf(GridSettings.height.ToString());
            enemyCountComboBox.SelectedIndex = enemyCountComboBox.Items.IndexOf(GridSettings.enemyCount.ToString());
            cellSizeTextBox.Text = GridSettings.cellSize.ToString();
        }
        

        private void cancelSettingsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            GridSettings.width = Convert.ToInt32(gridWidthComboBox.SelectedItem);
            GridSettings.height = Convert.ToInt32(gridHeightComboBox.SelectedItem);
            GridSettings.cellSize = Convert.ToInt32(cellSizeTextBox.Text);
            GridSettings.enemyCount = Convert.ToInt32(enemyCountComboBox.SelectedItem);
            this.Close();

        }

        private void cellSizeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
