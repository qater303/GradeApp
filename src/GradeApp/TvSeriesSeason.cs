using System.Collections.Generic;
namespace GradeApp
{
    public class TvSeriesSeason
    {
        public int Season { get; set; }
        public List<double> Grades;
        public TvSeriesSeason(int season)
        {
            this.Season = season;
            this.Grades = new List<double>();
        }
    }
}

