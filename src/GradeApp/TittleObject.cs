namespace GradeApp
{
    public abstract class TittleObject
    {
        public string Tittle { get; set; }

        public TittleObject(string tittle)
        {
            this.Tittle = tittle;
        }
    }
}

