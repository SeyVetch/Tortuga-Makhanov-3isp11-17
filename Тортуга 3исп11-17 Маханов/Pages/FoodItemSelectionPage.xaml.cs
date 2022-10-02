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

namespace Тортуга_3исп11_17_Маханов.Pages
{
    /// <summary>
    /// Логика взаимодействия для FoodItemSelectionPage.xaml
    /// </summary>
    public partial class FoodItemSelectionPage : Page
    {
        public FoodItemSelectionPage()
        {
            InitializeComponent();
            List<FoodItem> foodItems = NewMethod();
            LVFoods.ItemsSource = foodItems;

        }

        List<FoodItem> NewMethod()
        {
            return AppData.Context.FoodItem.ToList();
        }
    }
}
