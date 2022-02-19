using System;
using System.Collections.Generic;
using System.IO;
namespace GradeApp
{
    public class InFileMovie : TittleObject, IMovie
    {
        public string Genre { get; set; }
        public InFileMovie(string tittle, string genre) : base(tittle)
        {
            this.Genre = genre;
            using (File.Create($"Movie {Tittle}.txt")) ;
        }

        //private List<double> grades = new List<double>();
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
                    using (var grades = File.AppendText($"Movie {Tittle}.txt"))
                    {
                        grades.WriteLine(result);
                    }
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
            if (new FileInfo($"Movie {Tittle}.txt").Exists != true || new FileInfo($"Movie {Tittle}.txt").Length == 0)
            {
                throw new Exception("Brak ocen");
            }
            else
            {
                using (var grades = File.OpenText($"Movie {Tittle}.txt"))
                {
                    var line = grades.ReadLine();

                    while (line != null)
                    {
                        var result = double.Parse(line);
                        stat.Add(result);
                        line = grades.ReadLine();
                    }
                }
                return stat;
            }

        }
    }
}

