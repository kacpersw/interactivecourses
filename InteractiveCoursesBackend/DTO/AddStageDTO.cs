using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveCoursesBackend.DTO
{
    public class AddStageDTO
    {
        public int Nr { get; set; }
        public string Name { get; set; }
        public string HtmlContent { get; set; }
    }
}