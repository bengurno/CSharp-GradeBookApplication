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
                var dropLetterGrade = (int)Math.Ceiling(Students.Count * 0.2);
                var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
                if (grades[dropLetterGrade - 1] <= averageGrade)
                {
                    return 'A';
                }
                else if (grades[2 * dropLetterGrade - 1] <= averageGrade)
                {
                    return 'B';
                }
                else if (grades[3 * dropLetterGrade - 1] <= averageGrade)
                {
                    return 'C';

                }
                else if (grades[4 * dropLetterGrade - 1] <= averageGrade)
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