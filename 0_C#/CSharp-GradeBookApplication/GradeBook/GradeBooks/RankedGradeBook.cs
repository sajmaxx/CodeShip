using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

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
            try
            {

                if (Students.Count < 5)
                {
                    throw new InvalidOperationException("Number of students less than 5");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                return 'F';
            }
           return 'F'; 
        }
    }
}
