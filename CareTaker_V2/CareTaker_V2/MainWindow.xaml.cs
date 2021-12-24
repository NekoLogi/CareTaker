using System;
using System.Windows;
using System.Windows.Controls;

namespace CareTaker_V2
{
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }
        private void Window_Initialized(object sender, EventArgs e) {
            if(CareTaker.Startup()) {
                AddProductsToList(CareTaker.Sort(null, null));
            } else {
                MessageBox.Show("Laden von Produkten fehlgeschlagen!");
            }
        }

        public void AddProductsToList(Item[] items) {
            ItemList.Items.Clear();
            ItemList.Items.Refresh();

            foreach(var item in items) {
                ItemList.Items.Add(item);
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e) {
            CreateWindow createWindow = new CreateWindow();
            createWindow.ShowDialog();
            Window_Initialized(null, null);
        }

        private void EditContextMenu_Click(object sender, RoutedEventArgs e) {
            CareTaker.SelectedItem = GetSelectedItem();

            EditWindow editWindow = new EditWindow();
            editWindow.ShowDialog();
            Window_Initialized(null, null);
        }

        Item GetSelectedItem() {
            return (Item)ItemList.SelectedItem;
        }

        private void DeleteContextMenu_Click(object sender, RoutedEventArgs e) {
            CareTaker.SelectedItem = GetSelectedItem();
            CareTaker.DeleteItem();
            Window_Initialized(null, null);
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            AddProductsToList(CareTaker.Sort(NameTextBox.Text, CheckComboBox()));
        }

        string CheckComboBox() {
            if(CategoryComboBox.Text != "") {
                return CategoryComboBox.Text;
            }
            return null;
        }

        private void CategoryComboBox_DropDownClosed(object sender, EventArgs e) {
            AddProductsToList(CareTaker.Sort(NameTextBox.Text, CheckComboBox()));
        }

        private void PlaceTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            AddProductsToList(CareTaker.SortByPlace(PlaceTextBox.Text));
        }
    }
}