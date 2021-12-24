using System;
using System.Windows;

namespace CareTaker_V2
{
    public partial class EditWindow : Window
    {
        public EditWindow() {
            InitializeComponent();
        }

        private void EditItemButton_Click(object sender, RoutedEventArgs e) {
            if(CareTaker.EditItem(CreateItem())) {
                MessageBox.Show("Produkt erfolgreich bearbeitet!");
                Close();
            } else {
                MessageBox.Show("Produkt bearbeiten fehlgeschagen!\nPrüfe deine Eingaben.");
            }
        }

        private void Window_Initialized(object sender, EventArgs e) {
            NameTextBox.Text = CareTaker.SelectedItem.NAME;
            CategoryComboBox.Text = CareTaker.SelectedItem.CATEGORY;
            TagsTextBox.Text = CombineTags();
            PlaceTextBox.Text = CareTaker.SelectedItem.PLACE;
        }

        string CombineTags() {
            string result = null;
            foreach(var tag in CareTaker.SelectedItem.TAGS) {
                result += $"{tag} ";
            }
           
            return result;
        }

        Item CreateItem() {
            return new Item {
                NAME = NameTextBox.Text,
                CATEGORY = CategoryComboBox.Text,
                TAGS = SplitTags(),
                PLACE = PlaceTextBox.Text
            };
        }

        string[] SplitTags() {
            return TagsTextBox.Text.Split(' ');
        }
    }
}
