using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count > 5) throw new InvalidOperationException();
            int howBetter = 0;
            foreach (var Student in Students)
            {
                if (averageGrade < Student.AverageGrade) howBetter++;
            }

            int percents = 100 * howBetter / Students.Count;

            if (percents < 20) return 'A';
            if (percents < 40) return 'B';
            if (percents < 60) return 'C';
            if (percents < 80) return 'D';
            else return 'F';

        }
    }
}
