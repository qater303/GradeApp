using System;
namespace GradeApp
{
    public class Statistics
    {
        public double Low;
        public double High;
        public int Count;
        public double Sum;
        public string Stars
        {
            get
            {
                switch (Average)
                {
                    case var i when i >= 8:
                        return "*****";
                    case var i when i >= 6 && i < 8:
                        return "****";
                    case var i when i >= 4 && i < 6:
                        return "***";
                    case var i when i >= 2 && i < 4:
                        return "**";
                    case var i when i > 0 && i < 2:
                        return "*";
                    default:
                        return "Brak ocen";
                }
            }
        }

        public Statistics()
        {
            Sum = 0.0;
            Count = 0;
            Low = double.MaxValue;
            High = double.MinValue;
        }


        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public void Add(double grade)
        {
            Sum += grade;
            Low = Math.Min(grade, Low);
            High = Math.Max(grade, High);
            Count++;
        }
    }
}