using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> Students { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.Students.Count; } }
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.Students = new List<Student>();
        }
        public string RegisterStudent(Student student)
        {
            if (this.Students.Count + 1 <= this.Capacity)
            {
                this.Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            foreach (var student in this.Students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    this.Students.Remove(student);
                    return $"Dismissed student {firstName} {lastName}";
                }
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            bool areAnyStudents = this.Students.Exists(student => student.Subject == subject);
            if (areAnyStudents)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (var student in this.Students.Where(student => student.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }
        public int GetStudentsCount()
        {
            return this.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return this.Students.Where(student => student.FirstName == firstName && student.LastName == lastName).First();
        }
    }
}
