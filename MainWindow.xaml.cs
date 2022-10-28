using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolProject.Classes;

namespace SchoolProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> studentList = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
        }
        void AddStudent(string firstname, string lastname, string faculty, int semester)
        {
            Student s = new Student(firstname, lastname, faculty,semester);
            studentList.Add(s);

            string data = string.Empty;
            foreach (var std in studentList)
            {
                data += std.StudentInfo()+$"{Environment.NewLine}";
            }
            MessageBox.Show(data);

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            int semester;
            if (int.TryParse(TextBoxSemester.Text, out semester) == false)
            {
                MessageBox.Show("Semester must be an integer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (semester > 12 || semester < 1)
            {
                MessageBox.Show("Semester must be between 1 and 12", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                AddStudent(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxFaculty.Text, semester);
            }

        }

        private void ButtonGet_Click(object sender, RoutedEventArgs e)
        {
            int index;
            if (int.TryParse(TextBoxIndex.Text, out index) == false)
            {
                MessageBox.Show("Index must be an integer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (index < studentList.Count)
            {
                Student std = studentList[index];
                string data = std.StudentInfo();
                MessageBox.Show(data);
            }
            else
            {
                MessageBox.Show("There aren't that much elements!");
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            int index;
            if (int.TryParse(TextBoxIndex.Text, out index) == false)
            {
                MessageBox.Show("Index must be an integer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (index < studentList.Count)
            {
                studentList.RemoveAt(index);
                string data = string.Empty;
                foreach (var std in studentList)
                {
                    data += std.StudentInfo()+$"{Environment.NewLine}";
                }
                MessageBox.Show(data);
            }
            else
            {
                MessageBox.Show("There aren't that much elements!");
            }
        }

        private void ButtonInsert_Click(object sender, RoutedEventArgs e)
        {
            int index;
            int semester;
            if (int.TryParse(TextBoxIndex.Text, out index)==false)
            {
                MessageBox.Show("Index must be an integer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (int.TryParse(TextBoxSemester.Text, out semester) == false)
            {
                MessageBox.Show("Semester must be an integer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (semester > 12 || semester < 1)
            {
                MessageBox.Show("Semester must be between 1 and 12", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(int.TryParse(TextBoxIndex.Text, out index) != false)
            {
                if (index < studentList.Count)
                {
                    Student s = new Student(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxFaculty.Text, semester);
                    studentList.Insert(index, s);
                    string data = string.Empty;
                    foreach (var std in studentList)
                    {
                        data += std.StudentInfo() + $"{Environment.NewLine}";
                    }
                    MessageBox.Show(data);
                }
                else
                {
                    MessageBox.Show("There aren't that much elements!");
                }
            }
        }

        private void NextSemesterButton_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<studentList.Count;i++)
            {
                studentList[i].GoToNextSemester();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult sure =MessageBox.Show("Are you sure you want to clear all students ?", "Confirmation", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if(sure == MessageBoxResult.Yes)
            {
                studentList.Clear();
            }
        }

        private void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            string data = "";
            foreach (var std in studentList)
            {
                data += std.StudentInfo() + $"{Environment.NewLine}";
            }
            MessageBox.Show(data);
        }

        private void GetStudentByNameButton_Click(object sender, RoutedEventArgs e)
        {
            bool isinlist = true;
            foreach (var std in studentList)
            {
                if(TextBoxFindStudentByName.Text==std.LastName)
                {
                    MessageBox.Show(std.StudentInfo());
                    isinlist = false;
                }
            }
            if(isinlist)
            {
                MessageBox.Show("User not found");
            }
        }
    }
}
