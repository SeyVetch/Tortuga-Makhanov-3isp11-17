using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Тортуга_3исп11_17_Маханов.EF;

namespace Тортуга_3исп11_17_Маханов.ClassHelper
{
    class AppData
    {
        public static Entities Context { get; } = new Entities();
    }
}
