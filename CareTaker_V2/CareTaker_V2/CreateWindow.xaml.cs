using System.Windows;

namespace CareTaker_V2
{
    public partial class CreateWindow : Window
    {
        public CreateWindow() {
            InitializeComponent();
        }

        private void CreateItemButton_Click(object sender, RoutedEventArgs e) {
            if(CareTaker.CreateItem(new Item { NAME = NameTextBox.Text, CATEGORY = CategoryComboBox.Text, TAGS = SplitTags(), PLACE = PlaceTextBox.Text })) {
                MessageBox.Show("Produkt erfolgreich erstellt!");
                Close();
            } else {
                MessageBox.Show("Produkt erstellen fehlgeschlagen!\nPrüfe deine Eingaben.");
            }
        }

        string[] SplitTags() {
            return TagsTextBox.Text.Split(' ');
        }
    }
}
