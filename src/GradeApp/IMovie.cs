using System;
namespace GradeApp
{
    public delegate void GradeAddedDelegate(object sender, MovieGradeAddedEventArgs args);
    public interface IMovie
    {
        string Tittle { get; set; }
        string Genre { get; set; }

        void AddGrade(string grade);
        Statistics GetStatistics();
        event GradeAddedDelegate GradeAdded;
    }
}

