//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nol_Adin_Sabirov.Misc
{
    using System;
    using System.Collections.Generic;
    
    public partial class Spravochnaya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spravochnaya()
        {
            this.Ychetnaya = new HashSet<Ychetnaya>();
        }
    
        public int IdReys { get; set; }
        public string NameReys { get; set; }
        public Nullable<int> KolVoSeat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ychetnaya> Ychetnaya { get; set; }
    }
}
