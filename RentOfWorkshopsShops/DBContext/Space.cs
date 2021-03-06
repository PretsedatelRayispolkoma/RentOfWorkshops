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
    
    public partial class Space
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Space()
        {
            this.Rent = new HashSet<Rent>();
            this.SecondaryPictures = new HashSet<SecondaryPictures>();
        }
    
        public int Id { get; set; }
        public int TypeOfSpaceId { get; set; }
        public int HouseId { get; set; }
        public decimal AmountPerHour { get; set; }
        public int Square { get; set; }
        public int StatusId { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual House House { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rent> Rent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecondaryPictures> SecondaryPictures { get; set; }
        public virtual Status Status { get; set; }
        public virtual TypeOfSpace TypeOfSpace { get; set; }
    }
}
