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
    
    public partial class EmploymentContracts
    {
        public int ID { get; set; }
        public int UserFK { get; set; }
        public string EmplContractSource { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
