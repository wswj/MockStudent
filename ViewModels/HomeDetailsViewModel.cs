using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockStudentManager.Models;

namespace MockStudentManager.ViewModels
{
    public class HomeDetailsViewModel
    {
        public string PageTitle { get; set; }
        public Student StudentInfo { get; set; }
    }
}
