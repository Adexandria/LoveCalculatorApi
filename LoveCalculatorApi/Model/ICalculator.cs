using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoveCalculatorApi.Model
{
   public interface ICalculator
    {
        Calculator GetCalculator(string name, string name1);
        Calculator Add(Calculator calculator);
        int Commit();
        int Calculation(string name, string name1);
        int Percentage(string name, string name1);
    }
}
