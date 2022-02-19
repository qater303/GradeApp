using System;
using System.Collections.Generic;
namespace GradeApp
{
    public class Movie : TittleObject, IMovie
    {
        public string Genre { get; set; }
        public Movie(string tittle, string genre) : base(tittle)
        {
            this.Genre = genre;
        }

        private List<double> grades = new List<double>();
        private ArgumentException wrongGrade = new ArgumentException("Błędna ocena");
        public event GradeAddedDelegate GradeAdded;
        protected virtual void OnGradeAdded(double grade)
        {
            if (GradeAdded != null)
            {
                GradeAdded(this, new MovieGradeAddedEventArgs(grade));
            }
        }

        public void AddGrade(string grade)
        {
            if (double.TryParse(grade, out double result))
            {
                if (result >= 1 && result <= 10)
                {
                    this.grades.Add(result);
                    OnGradeAdded(result);
                }
                else
                {
                    throw wrongGrade;
                }
            }
            else
            {
                throw wrongGrade;
            }
        }

        public Statistics GetStatistics()
        {
            var stat = new Statistics();
            if (grades.Count != 0)
            {
                foreach (double g in grades)
                {
                    stat.Add(g);
                }
                return stat;
            }
            else
            {
                throw new Exception("Brak ocen");
            }
        }
    }
}

