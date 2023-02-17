using Microsoft.EntityFrameworkCore;
using Slp.DataCore.Entities;
using Slp.DataCore.Enums;
using System.Reflection.Emit;

namespace Slp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<FinalResult> FinalResults { get; set; }
        public DbSet<HomeworkTask> HomeworkTasks { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobIncome> JobIncomes { get; set; }
        public DbSet<JobTask> JobTasks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<PeriodicOutcome> PeriodicOutcomes { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            UpdateStructure(builder);
            SeedDate(builder);
            base.OnModelCreating(builder);
        }

        private void UpdateStructure(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .Property(b => b.ReadingStatus)
                    .HasDefaultValue(ReadingBookStatus.Planned);
            builder.Entity<Book>()
                .Property(b => b.CurrentPage)
                    .HasDefaultValue(0);
            builder.Entity<Book>()
                .Property(b => b.TotalNumberOfPages)
                    .HasDefaultValue(0);

            builder.Entity<DailyTask>()
                .Property(b => b.IsCompleted)
                    .HasDefaultValue(false);

            builder.Entity<FinalResult>()
                .Property(b => b.Score)
                    .HasDefaultValue(0);

            builder.Entity<HomeworkTask>()
                .Property(b => b.IsCompleted)
                    .HasDefaultValue(false);

            builder.Entity<JobTask>()
                .Property(b => b.IsCompleted)
                    .HasDefaultValue(false);

            builder.Entity<Sport>()
                .Property(b => b.IsMondayTraining)
                    .HasDefaultValue(false);
            builder.Entity<Sport>()
                .Property(b => b.IsTuesdayTraining)
                    .HasDefaultValue(false);
            builder.Entity<Sport>()
                .Property(b => b.IsWednesdayTraining)
                    .HasDefaultValue(false);
            builder.Entity<Sport>()
                .Property(b => b.IsThursdayTraining)
                    .HasDefaultValue(false);
            builder.Entity<Sport>()
                .Property(b => b.IsFridayTraining)
                    .HasDefaultValue(false);
            builder.Entity<Sport>()
                .Property(b => b.IsSaturdayTraining)
                    .HasDefaultValue(false);
            builder.Entity<Sport>()
                .Property(b => b.IsSundayTraining)
                    .HasDefaultValue(false);
            builder.Entity<Vacancy>()
                .Property(b => b.CurrentStatus)
                    .HasDefaultValue(VacancyStatus.SuccessfulResponce);




            builder.Entity<JobIncome>()
                .HasOne(a => a.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<JobTask>()
                .HasOne(a => a.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<Subject>()
                .HasOne(a => a.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<Exam>()
                .HasOne(a => a.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<HomeworkTask>()
                .HasOne(a => a.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<Lesson>()
                .HasOne(a => a.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<FinalResult>()
                .HasOne(a => a.CreatedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientNoAction);
        }

        private void SeedDate(ModelBuilder builder)
        {
            //TODO Admin user
            //var users = new List<User>
            //{
            //    new()
            //    {
                    
            //    }
            //};

            

            //builder.Entity<User>().HasData(users.ToArray());
        }
    }
}
