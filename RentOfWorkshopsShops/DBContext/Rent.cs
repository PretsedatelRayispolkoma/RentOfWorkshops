//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentOfWorkshopsShops.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rent
    {
        public int Id { get; set; }
        public int SpaceId { get; set; }
        public int ClientId { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int RentHours { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Space Space { get; set; }
    }
}
