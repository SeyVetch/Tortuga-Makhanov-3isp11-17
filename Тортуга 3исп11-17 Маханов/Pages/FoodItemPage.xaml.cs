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
using Тортуга_3исп11_17_Маханов.ClassHelper;
using Тортуга_3исп11_17_Маханов.EF;
using Тортуга_3исп11_17_Маханов.Windows;

namespace Тортуга_3исп11_17_Маханов.Pages
{
    /// <summary>
    /// Логика взаимодействия для FoodItemPage.xaml
    /// </summary>
    public partial class FoodItemPage : Page
    {
        FoodItem foodItem;
        int count = 1;
        OrderPagesWindow win;
        public FoodItemPage(int IdFood, OrderPagesWindow parent)
        {
            InitializeComponent();
            foodItem = AppData.Context.FoodItem.FirstOrDefault(i => i.IdFood == IdFood);
            FooterText.Text = foodItem.Name;
            BitmapImage img = new BitmapImage(new Uri(foodItem.LocalImagePath, UriKind.Relative));
            FoodImage.Source = img;
            //TxtDesc.Text = foodItem.Description;
            TxtPrice.Text = (count * foodItem.Price).ToString();
            win = parent;
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            count++;
            TxtCount.Text = count.ToString();
            TxtPrice.Text = (count * foodItem.Price).ToString();
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            count--;
            if (count < 1)
            {
                count = 1;
            }
            TxtCount.Text = count.ToString();
            TxtPrice.Text = (count * foodItem.Price).ToString();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            int IdOrd = win.CurOrd.IdOrder;
            OrderFood orderFood = new OrderFood
            {
                IdOrder = IdOrd,
                IdFood = foodItem.IdFood,
                Qty = count
            };
            AppData.Context.OrderFood.Add(orderFood);
            AppData.Context.SaveChanges();
            win.OrderPage.Content = win.CatPage;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            win.OrderPage.Content = win.CatPage;
        }
    }
}
