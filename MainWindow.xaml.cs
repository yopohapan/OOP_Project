using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataStorage data = new DataStorage();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            AddTransaction addTransactionWindow = new AddTransaction();
            addTransactionWindow.data = data;
            addTransactionWindow.Show();
            Hide();
        }
    }

    public class DataStorage
    {
        public List<Person.PersonClass> customers = new List<Person.PersonClass>();
        public List<Product.ProductClass> jewelries = new List<Product.ProductClass>();
    }
}
