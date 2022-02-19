using System;
using System.Collections.Generic;
using System.IO;

namespace GradeApp
{
    public class TvSeries : TittleObject, IMovie
    {
        public string Genre { get; set; }
        public List<TvSeriesSeason> Seasons { get; set; }
        public int ActualSeason { get; set; }
        private List<TvSeriesSeason> seasons = new List<TvSeriesSeason>();

        public TvSeries(string tittle, string genre) : base(tittle)
        {
            this.Genre = genre;
            this.Seasons = seasons;
            this.Seasons.Add(new TvSeriesSeason(1));
            ActualSeason = 1;
            using (File.Create($"TvSeries {Tittle}.txt")) ;
        }

        private ArgumentException wrongGrade = new ArgumentException("Błędna ocena");
        public event GradeAddedDelegate GradeAdded;
        public delegate void SeasonDelegate(object sender, EventArgs args);
        public event SeasonDelegate SeasonAdded;
        public event SeasonDelegate ActualSeasonChanged;
        protected virtual void OnGradeAdded(double grade)
        {
            if (GradeAdded != null)
            {
                GradeAdded(this, new MovieGradeAddedEventArgs(grade));
            }
        }
        protected virtual void OnSeasonAdded()
        {
            if (SeasonAdded != null)
            {
                SeasonAdded(this, EventArgs.Empty);
            }
        }
        protected virtual void OnActualSeasonChanged()
        {
            if (ActualSeasonChanged != null)
            {
                ActualSeasonChanged(this, EventArgs.Empty);
            }
        }

        public void AddSeason()
        {
            this.Seasons.Add(new TvSeriesSeason(Seasons.Count + 1));
            OnSeasonAdded();
        }

        public void AddGrade(string grade)
        {
            if (double.TryParse(grade, out double result))
            {
                if (result >= 1 && result <= 10)
                {
                    this.Seasons[ActualSeason - 1].Grades.Add(result);
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
        public void SetActualSeason(int actualSeason)
        {
            if (actualSeason <= this.Seasons.Count && actualSeason > 0)
            {
                this.ActualSeason = actualSeason;
            }
            else
            {
                throw new ArgumentException("Nie ma takiego sezonu");
            }
            OnActualSeasonChanged();
        }

        public Statistics GetStatistics()
        {
            var stat = new Statistics();
            if (Seasons[ActualSeason - 1].Grades.Count != 0)
            {
                foreach (double g in Seasons[ActualSeason - 1].Grades)
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

