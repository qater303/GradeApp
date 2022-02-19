using System;
namespace GradeApp
{
    public class MovieGradeAddedEventArgs : EventArgs
    {
        public double Grade { get; set; }
        public MovieGradeAddedEventArgs(double grade)
        {
            this.Grade = grade;
        }
    }
}