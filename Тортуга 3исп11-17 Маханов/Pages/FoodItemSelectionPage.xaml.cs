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
    /// Логика взаимодействия для FoodItemSelectionPage.xaml
    /// </summary>
    public partial class FoodItemSelectionPage : Page
    {
        OrderPagesWindow win;
        public FoodItemSelectionPage(int IdCategory, OrderPagesWindow parent)
        {
            InitializeComponent();
            List<FoodItem> foodItems = AppData.Context.FoodItem.Where(i => i.IdCategory == IdCategory).ToList();
            LVFoods.ItemsSource = foodItems;
            FooterText.Text = AppData.Context.CategoryFood.FirstOrDefault(i => i.IdCategory == IdCategory).Name;
            win = parent;
        }
        private void LVFoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVFoods.SelectedItem != null)
            {
                FoodItem F = (FoodItem)e.AddedItems[0];
                int IdFood = F.IdFood;
                LVFoods.SelectedItem = null;
                win.OrderPage.Content = new FoodItemPage(IdFood, win);
            }
        }



        private void BtnShopptingCart_Click(object sender, RoutedEventArgs e)
        {
            win.OrderPage.Content = win.CatPage;
        }
    }
}
