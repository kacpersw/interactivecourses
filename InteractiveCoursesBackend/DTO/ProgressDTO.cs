using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveCoursesBackend.DTO
{
    public class ProgressDTO
    {
        public string CategoryName { get; set; }
        public IEnumerable<CourseProgressDTO> Progresses { get; set; }
    }
}
