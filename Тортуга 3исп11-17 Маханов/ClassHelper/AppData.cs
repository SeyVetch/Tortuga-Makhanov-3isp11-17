using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тортуга_3исп11_17_Маханов.ClassHelper
{
    class AppData
    {
        public static EF.Entities Context { get; } = new EF.Entities();
    }
}
