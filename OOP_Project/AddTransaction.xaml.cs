﻿using System;
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
using System.Windows.Shapes;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {
        public DataStorage data;

        public MainWindow mainWindow;
        //public AddTransaction addTransactionWindow;
        public AddTransaction()
        {
            InitializeComponent();
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer addCustomerWindow = new AddCustomer();
            //addCustomerWindow.data = data;
            addCustomerWindow.Show();
        }

        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
