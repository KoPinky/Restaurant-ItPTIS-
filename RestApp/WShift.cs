//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class WShift
    {
        public int ID { get; set; }
        public int UserFK { get; set; }
        public System.DateTime TimeStart { get; set; }
        public System.DateTime TimeEnd { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
