//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace stranicaFE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Museums
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Museums()
        {
            this.Artifacts = new HashSet<Artifacts>();
        }
    
        public int museum_id { get; set; }
        public string museum_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string contact_phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artifacts> Artifacts { private get; set; }
    }
}