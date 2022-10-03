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
    /// Логика взаимодействия для CategorySelectionPage.xaml
    /// </summary>
    public partial class CategorySelectionPage : Page
    {
        OrderPagesWindow win;
        public CategorySelectionPage(OrderPagesWindow parent)
        {
            InitializeComponent();
            List<CategoryFood> CategoryFood = AppData.Context.CategoryFood.ToList();
            LVCategories.ItemsSource = CategoryFood;
            win = parent;
        }

        private void LVCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVCategories.SelectedItem != null)
            {
                CategoryFood C = (CategoryFood)e.AddedItems[0];
                int IdCategory = C.IdCategory;
                LVCategories.SelectedItem = null;
                win.OrderPage.Content = new FoodItemSelectionPage(IdCategory, win);
            }
        }
    }
}
