using OpenUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenUniversity.Data
{
    public static class DBInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }

            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 1050, Title = "Chemistry", Credits = 3  },
                new Course {CourseID = 4022, Title = "Microeconomics",Credits = 3  },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3 },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4 },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4 },

                new Course {CourseID = 2021, Title = "Composition",    Credits = 3 },

                new Course {CourseID = 2042, Title = "Literature",     Credits = 4 }
             };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
            var enrollments = new Enrollment[]
            {
                new Enrollment { StudentID=1,CourseID=100,Grade = Grade.A },
                 new Enrollment { StudentID=1,CourseID=200,Grade = Grade.C },
                  new Enrollment { StudentID=2,CourseID=300,Grade = Grade.B },
                   new Enrollment { StudentID=1,CourseID=400,Grade = Grade.A },
                    new Enrollment { StudentID=3,CourseID=100,Grade = Grade.A },
            };

            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
