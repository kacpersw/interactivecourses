using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveCoursesBackend.DTO
{
    public class AddCourseDTO
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public IEnumerable<AddStageDTO> Stages { get; set; }
        public IEnumerable<long> CategoriesIds { get; set; }
    }
}