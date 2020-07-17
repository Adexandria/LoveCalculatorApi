
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoveCalculatorApi.Model
{
    public class LoveDbContext: DbContext
    {
        public LoveDbContext(DbContextOptions<LoveDbContext> options) : base(options)
        {

        }
        public DbSet<Calculator> Calculators { get; set; }
    }
}
