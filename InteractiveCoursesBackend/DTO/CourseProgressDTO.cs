using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveCoursesBackend.DTO
{
    public class CourseProgressDTO
    {
        public string CourseName { get; set; }
        public IEnumerable<string> StageNames { get; set; }
        public int LastCompletedStage { get; set; }
    }
}
