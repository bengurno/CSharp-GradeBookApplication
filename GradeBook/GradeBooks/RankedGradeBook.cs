using GradeBook.Enums;
using System;
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
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            else
            {

                var dropGrade = (int)Math.Round(Students.Count * 0.2);
                var aveGrade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

                if(aveGrade[dropGrade - 1] <= averageGrade)
                {
                    return 'A';
                }
                else if(aveGrade[dropGrade * 2 - 1] <= averageGrade)
                {
                    return 'B';
                
                }
                else if(aveGrade[dropGrade * 3 - 1] <= averageGrade)
                {
                    return 'C';
                }
                else if(aveGrade[dropGrade * 4 - 1] <= averageGrade)
                {
                    return 'D';
                }
                else
                {
                    return 'F';
                }
            }
        }
    }
}
