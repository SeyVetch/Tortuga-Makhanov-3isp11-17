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
using System.Windows.Shapes;
using Тортуга_3исп11_17_Маханов.Pages;
using Тортуга_3исп11_17_Маханов.ClassHelper;

namespace Тортуга_3исп11_17_Маханов.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderPagesWindow.xaml
    /// </summary>
    public partial class OrderPagesWindow : Window
    {
        public OrderPagesWindow()
        {
            InitializeComponent(); 
            OrderPage.Content = new FoodItemSelectionPage();
        }

        private void BtnShopptingCart_Click(object sender, RoutedEventArgs e)
        {
            Window ShopCart = new ShoppingCartWindow();
            ShopCart.Show();
            Close();
        }
    }
}
