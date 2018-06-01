using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveCoursesBackend.DTO
{
    public class AddCategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}