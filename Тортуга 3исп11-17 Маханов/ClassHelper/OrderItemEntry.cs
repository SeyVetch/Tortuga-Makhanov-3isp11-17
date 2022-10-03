using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Тортуга_3исп11_17_Маханов.EF;


namespace Тортуга_3исп11_17_Маханов.ClassHelper
{
    class OrderItemEntry
    {
        public FoodItem foodItem;
        public OrderFood orderFood;
        public OrderItemEntry(FoodItem FI, OrderFood OF)
        {
            foodItem = FI;
            orderFood = OF;
        }

        public string Name { get { return foodItem.Name; } }
        public int Qty { get { return orderFood.Qty; } }
        public string ImagePath { get { return foodItem.ImagePath; } }
        public string LocalImagePath { get { return foodItem.LocalImagePath; } }
        public decimal Price { get { return orderFood.Qty * foodItem.Price; } }
        public string PriceRub { get { return Price.ToString() + " руб"; } }
        public int IdOrderFood { get { return orderFood.IdOrderFood; } }
        public int IdFoodItem { get { return foodItem.IdFood; } }
        static FoodItem GetFoodItem(OrderFood OF)
        {
            return AppData.Context.FoodItem.FirstOrDefault(i => OF.IdFood == i.IdFood);
        }
        public static List<OrderItemEntry> Transform(List<OrderFood> OF)
        {
            List<OrderItemEntry> res = new List<OrderItemEntry>();
            foreach (OrderFood of in OF)
            {
                res.Add(new OrderItemEntry(GetFoodItem(of), of));
            }
            return res;
        }
        public static decimal Sum(List<OrderItemEntry> entries)
        {
            decimal res = 0;
            foreach (OrderItemEntry entry in entries)
            {
                res += entry.Price;
            }
            return res;
        }
    }
}
