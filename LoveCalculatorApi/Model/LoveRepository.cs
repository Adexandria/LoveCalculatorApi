using Microsoft.AspNetCore.Routing.Constraints;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoveCalculatorApi.Model
{
    public class LoveRepository :ICalculator
    {
        private readonly LoveDbContext db;
        public LoveRepository(LoveDbContext db)
        {
            this.db = db;
        }

        public Calculator Add(Calculator calculator)
        {
            db.Calculators.Add(calculator);
            return calculator;
        }
        //without using the length as a multiplier
        public int Calculation(string name, string name1)
        {
        
            int total = 0;
            double score = 1;
            const double percent = 8.33;
              
            foreach(var items in name)
            {
               if(name1.Contains(items))
                {
                     score *= 2;
                     total = (int)(Math.Round(score * percent));
                    if (total > 100)
                    {
                        return 100;
                    }
                    if (name == name1)
                    {
                        return 100;
                    }
                }

            }
            return total;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Calculator GetCalculator(string name, string name1)
        {
            return db.Calculators.Where(r => r.Name == name && r.Name1 == name1).FirstOrDefault();
        }


        //using the length as a multiplier
        public int Percentage(string name, string name1)
        {
            var length1 = name.Length;
            var length2 = name1.Length;
            int total = 0;
            double official = 0;
            double official1 = 0;
            if (length1 > length2)
            {
                official = length1 / length2;
               

            }
            else
            {
             official1 = length2 / length1;
            }
            foreach(var c in name1)
               {
                 var j =name.IndexOf(c);
                    if (j !=0)
                    {
                        double s = official * 2;
                        total = (int)(Math.Round(s * 8.3));
                    if (name == name1)
                    {
                        return 100;
                    }
                    }
                    else
                    {
                        return 0;
                    }
                }
                return total;
           
        }
    }
}
