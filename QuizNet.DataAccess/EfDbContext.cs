using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QuizNet.DataAccess.Models;

namespace QuizNet.DataAccess
{
    public class EfDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {

        }
    }
}
