//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Тортуга_3исп11_17_Маханов.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderFood = new HashSet<OrderFood>();
        }
    
        public int IdOrder { get; set; }
        public int IdFTable { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int IdStaff { get; set; }
    
        public virtual FurnitureTable FurnitureTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderFood> OrderFood { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
