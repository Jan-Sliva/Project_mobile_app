using Microsoft.EntityFrameworkCore;
using Project_mobile_app.Models;
using Project_mobile_app.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Data
{
    class Project_mobile_appContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<DefaultChoice> DefaultChoices { get; set; }

        public DbSet<DisplayObject> DisplayObjects { get; set; }

        public DbSet<DisplayObjectStopDisplayAfterDisplay> DisplayObjectStopDisplayAfterDisplay { get; set; }

        public DbSet<DisplayObjectStopDisplayAfterUnlock> DisplayObjectStopDisplayAfterUnlock { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<PasswordGameRequirement> GamePasswords { get; set; }

        public DbSet<Choice> Choices { get; set; }

        public DbSet<ChoiceForChoiceQuestion> ChoiceForChoiceQuestions { get; set; }

        public DbSet<ChoiceForTextQuestion> ChoiceForTextQuestions { get; set; }

        public DbSet<ChoiceQuestion> ChoiceQuestions { get; set; }

        public DbSet<Introduction> Introductions { get; set; }

        public DbSet<MapPosition> MapPositions { get; set; }

        public DbSet<PasswordGameRequirement> PasswordGameRequirements { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Statistics> Statistics { get; set; }

        public DbSet<Stop> Stops { get; set; }

        public DbSet<Text> Texts { get; set; }

        public DbSet<TextQuestion> TextQuestions { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Project_mobile_app;Data Source=DESKTOP-MEZIOKN\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Text>();
            modelBuilder.Entity<Picture>();
            modelBuilder.Entity<ChoiceForChoiceQuestion>();
            modelBuilder.Entity<ChoiceForTextQuestion>();
            modelBuilder.Entity<DefaultChoice>();
            modelBuilder.Entity<ChoiceQuestion>();
            modelBuilder.Entity<TextQuestion>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Admin>();

            modelBuilder.ApplyConfiguration(new DisplayObjectStopDADConfiguration());
            modelBuilder.ApplyConfiguration(new DisplayObjectStopDAUConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new ChoiceConfiguration());
            modelBuilder.ApplyConfiguration(new ChoiceQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new IntroductionConfiguration());
            modelBuilder.ApplyConfiguration(new PasswordGameRequirementConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new StopConfiguration());
            modelBuilder.ApplyConfiguration(new TextQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
