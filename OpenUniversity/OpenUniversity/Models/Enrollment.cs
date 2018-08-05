using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

      //  [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }  //? grade property is nukkable different from zero.has not been assign yet

        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}
