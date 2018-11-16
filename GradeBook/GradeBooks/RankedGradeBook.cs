using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
            }
            else
            {
                var dropGrade = (int)Math.Round(Students.Count * 0.2);
                var aveGrade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

                if (aveGrade[dropGrade - 1] <= averageGrade)
                {
                    return 'A';
                }
                else if (aveGrade[2 * dropGrade - 1] <= averageGrade)
                {
                    return 'B';
                }
                else if (aveGrade[3 * dropGrade - 1] <= averageGrade)
                {
                    return 'C';

                }
                else if (aveGrade[4 * dropGrade - 1] <= averageGrade)
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }
            }
            //return base.GetLetterGrade(averageGrade);
        }

    }
}