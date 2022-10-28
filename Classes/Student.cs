using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Classes
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }//prop shortcut + tab
        public int Semester { get; set; }
        public void GoToNextSemester()
        {
            if(this.Semester<12)this.Semester++;
        }
        public string StudentInfo()
        {
            return $"First Name: {this.FirstName}, Last Name: {this.LastName}, Faculty: {this.Faculty}, Semester: {this.Semester}";
        }
        public Student(string firstname, string lastname, string faculty)//ctor shortcut
        {
            FirstName = firstname;
            LastName = lastname;
            Faculty = faculty;
        }
        public Student(string firstname,string lastname, string faculty, int semester)//ctor shortcut
        {
            FirstName = firstname;
            LastName=lastname;
            Faculty = faculty;
            Semester = semester;
        }
    }
}
