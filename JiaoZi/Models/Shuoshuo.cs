//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JiaoZi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shuoshuo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shuoshuo()
        {
            this.ShuoshuoComment = new HashSet<ShuoshuoComment>();
        }
    
        public int ShuoshuoID { get; set; }
        public string Shuoshuo_Content { get; set; }
        public Nullable<System.DateTime> Shuoshuo_Time { get; set; }
        public Nullable<int> Thumb_Num { get; set; }
        public int UserID { get; set; }
    
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShuoshuoComment> ShuoshuoComment { get; set; }
    }
}
