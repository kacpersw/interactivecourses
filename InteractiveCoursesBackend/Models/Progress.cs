//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InteractiveCoursesBackend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Progress
    {
        public long UserId { get; set; }
        public long CategoryId { get; set; }
        public long CourseId { get; set; }
        public long StageId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Course Course { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual User User { get; set; }
    }
}
