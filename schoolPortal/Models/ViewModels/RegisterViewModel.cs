using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolPortal.Models.ViewModels
{
    public class RegisterViewModel
    {
        public int StudentId { get; set; }
        public IEnumerable<Courses> Courses { get; set; }
        public int[] courseIds { get; set; }
    }
}
