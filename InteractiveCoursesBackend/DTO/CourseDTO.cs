using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveCoursesBackend.DTO
{
    public class CourseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CourseStageDTO> Stages { get; set; }
    }
}
