using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostLectureReview.Models.Structure;

namespace PostLectureReview.Models
{
    public class DevelopmentContext : DbContext
    {
        public DevelopmentContext (DbContextOptions<DevelopmentContext> options)
            : base(options)
        {
        }

        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecture>().ToTable("Lecture");
            modelBuilder.Entity<Topic>().ToTable("Topic");
            modelBuilder.Entity<Question>().ToTable("Question");
        }
    }
}
