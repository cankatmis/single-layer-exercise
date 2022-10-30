using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace single_layerExercise
{
    public partial class UserTweetContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }
        public UserTweetContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                   .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UserTweets.mdf;Integrated Security=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>(entity =>
            {
                entity.HasOne(tweet => tweet.User)
                .WithMany(user => user.Tweets);
            });

        }
    }
}
