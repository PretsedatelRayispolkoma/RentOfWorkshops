//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentOfWorkshopsCore.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class SecondaryPictures
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public Nullable<int> SpaceId { get; set; }
    
        public virtual Space Space { get; set; }
    }
}
