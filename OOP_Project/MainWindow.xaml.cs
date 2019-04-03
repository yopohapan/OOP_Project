using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OOP_Project.Person;
using OOP_Project.Product;
using OOP_Project.History;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataStorage data = new DataStorage();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        public static Random randomizer = new Random();

        string[] JewelryType = { "Bracelet", "Rings", "Necklace", "Earrings" };
        string[] JewelryQuality = { "10K", "18K", "21K" };
        string[] Interest = { "0.02", "0.05", "0.09" };
        string[] Discount = { "0", "0.05", "0.10" };

        public int transactionNum = 0;
        public int arbitraryCodex;

        public MainWindow()
        {
            InitializeComponent();

            foreach (string type in JewelryType)
                cmbJewelryType.Items.Add(type);

            foreach (string quality in JewelryQuality)
                cmbJewelryQuality.Items.Add(quality);

            foreach (string interest in Interest)
                cmbInterest.Items.Add(interest);

            foreach (string discount in Discount)
                cmbDiscount.Items.Add(discount);

            
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime Date = DateTime.Now;
            timeCheckBlock.Text = Date.ToShortDateString() + "   " + Date.ToLongTimeString();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            lstViewGridData.Items.Clear();
            for (int num = 0; num < data.transactionHistories.Count; num++)
            {
                lstViewGridData.Items.Add(data.transactionHistories[num]);
            }
        }

        private void BtnSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            if (!data.settings.Any() && (Rate10K.Text == string.Empty && Rate18K.Text == string.Empty && Rate21K.Text == string.Empty))
            {
                ProductClass initialProductRate = new ProductClass(0, 0, 0);
                data.settings.Insert(0, initialProductRate);
            }

            else if (Rate10K.Text == string.Empty || Rate18K.Text == string.Empty || Rate21K.Text == string.Empty)
            {
                MessageBox.Show("Please Complete the fields");
            }
              
            else
            {
                ProductClass changeProductRate = new ProductClass(Convert.ToDecimal(Rate10K.Text), Convert.ToDecimal(Rate18K.Text), Convert.ToDecimal(Rate21K.Text));
                data.settings.Insert(0, changeProductRate);
            }

            //ClearStackPanelFields(BottomDrawerStackPanel);
            OnActivated(e);
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchData(searchTextBox.Text);
        }

        private void SearchData(string searchName)
        {
            if (data.transactionHistories.Any())
            { 
                lstViewGridData.Items.Clear();
                for (int num = 0; num < data.transactionHistories.Count; num++)
                {
                    bool included = data.transactionHistories[num].PersonsFullName.Split().Any(w => w.StartsWith(searchName));

                    if (included)
                    lstViewGridData.Items.Add(data.transactionHistories[num]);
                }
            }
        }

        private void BtnSavePerson_Click(object sender, RoutedEventArgs e)
        {
            PersonClass customer = new PersonClass(txtLastName.Text, txtFirstName.Text, dpBirthdate.Text, txtAddress.Text, txtcontactNumber.Text, txtMiddleName.Text);

            bool existOrEmpty = false;

            if (txtLastName.Text == string.Empty || txtFirstName.Text == string.Empty || dpBirthdate.Text == string.Empty || txtAddress.Text == string.Empty || txtMiddleName.Text == string.Empty)
                existOrEmpty = true;

            if (!existOrEmpty)
            {
                foreach (PersonClass customerScan in data.customers)
                {
                    if (customer.GetFullName() == customerScan.GetFullName() || customer == null)
                    {
                        existOrEmpty = true;
                    }
                    else
                        existOrEmpty = false;

                }
            }
            if (!existOrEmpty)
            {
                data.customers.Add(customer);
            }
            else
                MessageBox.Show("This name already exists / Some fields are empty");

            ClearGridStackPanelFields(TopDrawerGridInStackPanel);

            cmbCustomer.Items.Clear();
            foreach (PersonClass customerX in data.customers)
                cmbCustomer.Items.Add(customerX.GetFullName());

        }

        private void CheckAllTop()
        {
            if (CheckGridFields(TopDrawerGridInStackPanel))
                BtnSave.IsEnabled = true;

            else
                BtnSave.IsEnabled = false;
        }

        private void TxtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckAllTop();
        }

        private void TxtMiddleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckAllTop();
        }

        private void TxtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckAllTop();
        }

        private void TxtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckAllTop();
        }

        private void TxtcontactNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckAllTop();
        }

        private void DpBirthdate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckAllTop();
        }

        private void BtnAddLoanTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (!data.settings.Any())
            {
                ProductClass initialProductRate = new ProductClass(0, 0, 0);
                data.settings.Insert(0, initialProductRate);
            }

            int generateCode;
            do
            {
                generateCode = randomizer.Next(00000000, 99999999);
            } while (data.randomIntList.Contains(generateCode));

            ProductClass chosenProducts = new ProductClass(Convert.ToString(cmbJewelryType.SelectedItem),
                                                           Convert.ToString(txtJewelryCondition.Text),
                                                           Convert.ToString(cmbJewelryQuality.SelectedItem),
                                                           Convert.ToDecimal(txtWeight.Text),
                                                           data.settings[0].Rate10K,
                                                           data.settings[0].Rate18K,
                                                           data.settings[0].Rate21K,
                                                           Convert.ToDecimal(cmbInterest.Text),
                                                           Convert.ToDecimal(cmbDiscount.Text), Convert.ToDateTime(dpPromisedDate.Text));

            for (int numCheck = 0; data.customers.Count >= numCheck; numCheck++)
            {
                if (data.customers[numCheck].GetFullName() == Convert.ToString(cmbCustomer.SelectedItem))
                {
                    TransactionHistory newTransactionHistory = new TransactionHistory(data.customers[numCheck], chosenProducts, generateCode);
                    data.transactionHistories.Add(newTransactionHistory);

                    data.randomIntList.Add(generateCode);

                    break;
                }
            }

            data.counter++;

            ClearStackPanelFields(LeftDrawerStackPanel);
            ClearGridStackPanelFields(LeftDrawerGridInStackPanel);
            ClearStackPanelFields(LeftDrawerSubStackPanel);
            OnActivated(e);
        }

        private bool CheckAllLeft()
        {
            if (CheckPanelFields(LeftDrawerStackPanel) && CheckGridFields(LeftDrawerGridInStackPanel) && CheckPanelFields(LeftDrawerSubStackPanel))
            {
                BtnAddLoanTransaction.IsEnabled = true;
                return true;
            }

            else
            {
                BtnAddLoanTransaction.IsEnabled = false;
                return false;
            }
        }

        private void CmbJewelryType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckAllLeft())
                UpdatePrice();
        }

        private void CmbJewelryQuality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckAllLeft())
                UpdatePrice();
        }

        private void TxtWeight_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (CheckAllLeft())
                UpdatePrice();
        }

        private void CmbInterest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckAllLeft())
                UpdatePrice();
        }

        private void CmbDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckAllLeft())
                UpdatePrice();
        }

        private void TxtJewelryCondition_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CheckAllLeft())
                UpdatePrice();
        }

        private void DpPromisedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckAllLeft())
                UpdatePrice();
        }

        private void UpdatePrice()
        {
            if (!data.settings.Any())
            {
                ProductClass initialProductRate = new ProductClass(0, 0, 0);
                data.settings.Insert(0, initialProductRate);
            }

            ProductClass arbitrary = new ProductClass(Convert.ToString(cmbJewelryType.SelectedItem),
                                           Convert.ToString(txtJewelryCondition.Text),
                                           Convert.ToString(cmbJewelryQuality.SelectedItem),
                                           Convert.ToDecimal(txtWeight.Text),
                                           data.settings[0].Rate10K,
                                           data.settings[0].Rate18K,
                                           data.settings[0].Rate21K,
                                           Convert.ToDecimal(cmbInterest.Text),
                                           Convert.ToDecimal(cmbDiscount.Text), Convert.ToDateTime(dpPromisedDate.Text));

            txtPriceBlock.Text = arbitrary.AccruedAmountDueWithDiscount.ToString();
        }

        private void LstViewGridData_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (lstViewGridData.SelectedItem != null)
            {
                TransactionHistory selectedFromSearch = lstViewGridData.SelectedItem as TransactionHistory;
                arbitraryCodex = selectedFromSearch.UniqueCode;
            }
        }

        private void BtnPaymentTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (lstViewGridData.SelectedItem != null)
            {
                Codex.Text = arbitraryCodex.ToString();
                ShowToPayDetails();
            }

        }

        private void BtnCodexHook_Click(object sender, RoutedEventArgs e)
        {
            ShowToPayDetails();
        }

        private void ShowToPayDetails()
        {
            for (int num = 0; num < data.transactionHistories.Count; num++)
            {
                if (Convert.ToInt32(Codex.Text) == data.transactionHistories[num].UniqueCode)
                {
                    transactionNum = num;
                    break;
                }
            }

            payName.Text = data.transactionHistories[transactionNum].PersonsFullName;
            payDate.Text = data.transactionHistories[transactionNum].HistoryDate;
            payJewelry.Text = data.transactionHistories[transactionNum].ProductJewelry;
            payWeight.Text = data.transactionHistories[transactionNum].ProductWeight.ToString();
            payInterest.Text = data.transactionHistories[transactionNum].ProductInterest.ToString();
            payDiscount.Text = data.transactionHistories[transactionNum].ProductDiscount.ToString();
            payBalance.Text = data.transactionHistories[transactionNum].ProductBalance.ToString();
            payStatus.Text = data.transactionHistories[transactionNum].HistoryStatus;
        }

        private void BtnPayAmount_Click(object sender, RoutedEventArgs e)
        {
            data.transactionHistories[transactionNum].ProductBalance = data.transactionHistories[transactionNum].ProductBalance - Convert.ToDecimal(txtAmountToPay.Text);

            ClearStackPanelFields(RightDrawerStackPanel);
            ClearGridStackPanelFields(RightDrawerGridInStackPanel);
            OnActivated(e);
        }

        private void Codex_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Codex.Text.Length <= 8 && Codex.Text.Length >= 1)
                Details.IsEnabled = true;
            else
                Details.IsEnabled = false;
        }

        private void TxtAmountToPay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAmountToPay.Text != string.Empty)
                BtnPayAmount.IsEnabled = true;
            else
                BtnPayAmount.IsEnabled = false;

        }

        private void ClearStackPanelFields(StackPanel panelName)
        {
            foreach (FrameworkElement frameworkElement in panelName.Children)
            {
                {
                    if (frameworkElement is TextBox )
                        ((TextBox)frameworkElement).Text = string.Empty;

                    if (frameworkElement is DatePicker)
                        ((DatePicker)frameworkElement).Text = string.Empty;

                    if (frameworkElement is ComboBox)
                        ((ComboBox)frameworkElement).Text = string.Empty;

                    if (frameworkElement is TextBlock)
                        ((TextBlock)frameworkElement).Text = string.Empty;
                }
            }
        }

        private void ClearGridStackPanelFields(Grid gridName)
        {
            foreach (FrameworkElement frameworkElement in gridName.Children)
            {
                {
                    if (frameworkElement is TextBox)
                        ((TextBox)frameworkElement).Text = string.Empty;

                    if (frameworkElement is DatePicker)
                        ((DatePicker)frameworkElement).Text = string.Empty;

                    if (frameworkElement is ComboBox)
                        ((ComboBox)frameworkElement).Text = string.Empty;

                    if (frameworkElement is TextBlock)
                        ((TextBlock)frameworkElement).Text = string.Empty;
                }
            }
        }

        private bool CheckPanelFields(StackPanel panelName)
        {
            bool txtBoxCheck = true;
            bool txtDatePickerCheck = true;
            bool txtComboBoxCheck = true;

            foreach (FrameworkElement frameworkElement in panelName.Children)
            {
                {
                    if (frameworkElement is TextBox)
                        if (((TextBox)frameworkElement).Text == string.Empty)
                        {
                            txtBoxCheck = false;
                            break;
                        }

                    if (frameworkElement is DatePicker)
                        if (((DatePicker)frameworkElement).Text == string.Empty)
                        {
                            txtDatePickerCheck = false;
                            break;
                        }

                    if (frameworkElement is ComboBox)
                        if (((ComboBox)frameworkElement).Text == string.Empty)
                        {
                            txtComboBoxCheck = false;
                            break;
                        }
                }
            }

            if (txtBoxCheck && txtDatePickerCheck && txtComboBoxCheck)
                return true;
                
            else
                return false;
        }

        private bool CheckGridFields(Grid gridName)
        {
            bool txtBoxCheck = true;
            bool txtDatePickerCheck = true;
            bool txtComboBoxCheck = true;

            foreach (FrameworkElement frameworkElement in gridName.Children)
            {
                {
                    if (frameworkElement is TextBox)
                        if (((TextBox)frameworkElement).Text == string.Empty)
                        {
                            txtBoxCheck = false;
                            break;
                        }

                    if (frameworkElement is DatePicker)
                        if (((DatePicker)frameworkElement).Text == string.Empty)
                        {
                            txtDatePickerCheck = false;
                            break;
                        }

                    if (frameworkElement is ComboBox)
                        if (((ComboBox)frameworkElement).Text == string.Empty)
                        {
                            txtComboBoxCheck = false;
                            break;
                        }
                }
            }

            if (txtBoxCheck && txtDatePickerCheck && txtComboBoxCheck)
                return true;

            else
                return false;
        }

        private void LeftCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearStackPanelFields(LeftDrawerStackPanel);
            ClearGridStackPanelFields(LeftDrawerGridInStackPanel);
            ClearStackPanelFields(LeftDrawerSubStackPanel);
            OnActivated(e);
        }

        private void RightCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearStackPanelFields(RightDrawerStackPanel);
            ClearGridStackPanelFields(RightDrawerGridInStackPanel);
            OnActivated(e);
        }

        private void TopCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearGridStackPanelFields(TopDrawerGridInStackPanel);

            cmbCustomer.Items.Clear();
            foreach (PersonClass customer in data.customers)
                cmbCustomer.Items.Add(customer.GetFullName());

        }

        private void BtnLoanTransaction_Click(object sender, RoutedEventArgs e)
        {
            cmbCustomer.Items.Clear();
            foreach (PersonClass customer in data.customers)
                cmbCustomer.Items.Add(customer.GetFullName());
        }

    }

    public class DataStorage
    {
        public List<PersonClass> customers = new List<PersonClass>();
        public List<ProductClass> settings = new List<ProductClass>();
        public List<TransactionHistory> transactionHistories = new List<TransactionHistory>();
        public int counter = 0;
        public int lstCounter = 0;
        public List<int> randomIntList = new List<int>();
    }
}
