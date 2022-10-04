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
using Тортуга_3исп11_17_Маханов.Pages;

namespace Тортуга_3исп11_17_Маханов.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCartWindow.xaml
    /// </summary>
    public partial class ShoppingCartWindow : Window
    {
        OrderPagesWindow win;
        List<OrderItemEntry> Entries;
        bool card = true;
        Brush BgOn;
        Brush BgOff;
        Brush FgOn;
        Brush FgOff;
        public ShoppingCartWindow(OrderPagesWindow parent)
        {
            InitializeComponent();
            win = parent;
            Entries = OrderItemEntry.Transform(ShoppingCart.Cart.ToList());
            LVOrderItemEntity.ItemsSource = Entries;
            TxtTotalPrice.Text = OrderItemEntry.Sum(Entries).ToString() + " руб";
            BgOn = BtnCard.Background;
            BgOff = BtnCash.Background;
            FgOn = TxtCard.Foreground;
            FgOff = TxtCash.Foreground;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            List<OrderFood> OF = ShoppingCart.Cart.ToList();
            win.Show();
            Close();
        }


        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            foreach (OrderFood orderfood in ShoppingCart.Cart.ToList())
            {
                AppData.Context.OrderFood.Add(orderfood);
            }
            AppData.Context.SaveChanges();
            win.Close();
            Close();
        }

        private void LVOrderItemEntity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LVOrderItemEntity.SelectedItem != null)
            {
                OrderFood orderFood = ((OrderItemEntry)e.AddedItems[0]).orderFood;
                LVOrderItemEntity.SelectedItem = null;
                win.OrderPage.Content = new FoodItemPage(orderFood, win, this);
                win.Show();
                Hide();
            }
        }

        public void Update()
        {
            Entries = OrderItemEntry.Transform(ShoppingCart.Cart.ToList());
            LVOrderItemEntity.ItemsSource = Entries;
            TxtTotalPrice.Text = OrderItemEntry.Sum(Entries).ToString() + " руб";
        }

        private void BtnCard_Click(object sender, RoutedEventArgs e)
        {
            if (!card)
            {
                card = true;
                BtnCard.Background = BgOn;
                TxtCard.Foreground = FgOn;
                BtnCash.Background = BgOff;
                TxtCash.Foreground = FgOff;
            }
        }

        private void BtnCash_Click(object sender, RoutedEventArgs e)
        {
            if (card)
            {
                card = false;
                BtnCash.Background = BgOn;
                TxtCash.Foreground = FgOn;
                BtnCard.Background = BgOff;
                TxtCard.Foreground = FgOff;
            }
        }
    }
}
