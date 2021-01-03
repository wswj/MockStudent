using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockStudentManager.Models.EnumTypes;

namespace MockStudentManager.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 主修科目
        /// </summary>
        public MajorEnum? Major { get; set; }
        public string Email { get; set; }
    }
}
