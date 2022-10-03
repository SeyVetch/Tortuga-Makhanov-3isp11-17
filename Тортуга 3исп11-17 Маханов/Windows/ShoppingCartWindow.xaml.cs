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
using Тортуга_3исп11_17_Маханов.ClassHelper;
using Тортуга_3исп11_17_Маханов.EF;

namespace Тортуга_3исп11_17_Маханов.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCartWindow.xaml
    /// </summary>
    public partial class ShoppingCartWindow : Window
    {
        OrderPagesWindow win;
        List<OrderItemEntry> Entries;
        public ShoppingCartWindow(OrderPagesWindow parent)
        {
            InitializeComponent();
            win = parent;
            Entries = OrderItemEntry.Transform(AppData.Context.OrderFood.Where(i => i.IdOrder == win.CurOrd.IdOrder).ToList());
            LVOrderItemEntity.ItemsSource = Entries;
            TxtTotalPrice.Text = OrderItemEntry.Sum(Entries).ToString() + " руб";
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            List<OrderFood> OF = AppData.Context.OrderFood.ToList();
            win.Show();
            Close();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            win.Close();
            Close();
        }
    }
}
