using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveCoursesBackend.DTO
{
    public class StageDTO
    {
        public long Id { get; set; }
        public int Stage { get; set; }
        public string Name { get; set; }
        public string HtmlContent { get; set; }
    }
}
