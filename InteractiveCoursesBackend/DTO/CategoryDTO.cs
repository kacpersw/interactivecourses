using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveCoursesBackend.DTO
{
    public class CategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public IEnumerable<CategoryCourseDTO> CategoryCourse { get; set; }
    }
}
