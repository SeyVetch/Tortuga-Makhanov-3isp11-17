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
using Тортуга_3исп11_17_Маханов.Windows;

namespace Тортуга_3исп11_17_Маханов.Windows
{
    /// <summary>
    /// Логика взаимодействия для TableChoiceWindow.xaml
    /// </summary>
    public partial class TableChoiceWindow : Window
    {
        int IdTable;
        int IdStaff;
        public TableChoiceWindow()
        {
            InitializeComponent();
            List<FurnitureTable> furnitureTables = AppData.Context.FurnitureTable.ToList();
            LVTables.ItemsSource = furnitureTables;
            List<Staff> staff = AppData.Context.Staff.ToList();
            LVStaff.ItemsSource = staff;
        }

        private void LVCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FurnitureTable FT = (FurnitureTable)e.AddedItems[0];
            IdTable = FT.IdFTable;
            LVTables.Visibility = Visibility.Hidden;
            LVStaff.Visibility = Visibility.Visible;
            FooterText.Text = "Выберите официанта";
        }

        private void LVStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Staff staff = (Staff)e.AddedItems[0];
            IdStaff = staff.IdStaff;
            Window OrdWin = new OrderPagesWindow(IdTable, IdStaff);
            OrdWin.Show();
            Close();
        }
    }
}
