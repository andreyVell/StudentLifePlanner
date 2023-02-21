using Microsoft.EntityFrameworkCore.ChangeTracking;
using Slp.DataProvider.Repositories.Interfaces;

namespace Slp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IBookRepository> _books;
        private readonly Lazy<IDailyTaskRepository> _dailyTasks;
        private readonly Lazy<IExamRepository> _exams;
        private readonly Lazy<IFinalResultRepository> _finalResults;
        private readonly Lazy<IHomeworkTaskRepository> _homeworkTasks;
        private readonly Lazy<IIncomeRepository> _incomes;
        private readonly Lazy<IJobRepository> _jobs;
        private readonly Lazy<IJobIncomeRepository> _jobIncomes;
        private readonly Lazy<IJobTaskRepository> _jobTasks;
        private readonly Lazy<ILessonRepository> _lessons;
        private readonly Lazy<IOutcomeRepository> _outcomes;
        private readonly Lazy<IPeriodicOutcomeRepository> _periodicOutcomes;
        private readonly Lazy<ISportRepository> _sports;
        private readonly Lazy<ISubjectRepository> _subjects;
        private readonly Lazy<ITrainingPlanRepository> _trainingPlans;
        private readonly Lazy<IUserRepository> _users;
        private readonly Lazy<IUserSettingRepository> _usersSettngs;
        private readonly Lazy<IVacancyRepository> _vacancies;

        public UnitOfWork(ApplicationDbContext context,
            Lazy<IBookRepository> books,
            Lazy<IDailyTaskRepository> dailyTasks,
            Lazy<IExamRepository> exams,
            Lazy<IFinalResultRepository> finalResults,
            Lazy<IHomeworkTaskRepository> homeworkTasks,
            Lazy<IIncomeRepository> incomes,
            Lazy<IJobRepository> jobs,
            Lazy<IJobIncomeRepository> jobIncomes,
            Lazy<IJobTaskRepository> jobTasks,
            Lazy<ILessonRepository> lessons,
            Lazy<IOutcomeRepository> outcomes,
            Lazy<IPeriodicOutcomeRepository> periodicOutcomes,
            Lazy<ISportRepository> sports,
            Lazy<ISubjectRepository> subjects,
            Lazy<ITrainingPlanRepository> trainingPlans,
            Lazy<IUserRepository> users,
            Lazy<IUserSettingRepository> usersSettngs,
            Lazy<IVacancyRepository> vacancies
            )
        {
            _context = context;
            _books = books;
            _dailyTasks = dailyTasks;
            _exams = exams;
            _finalResults = finalResults;
            _homeworkTasks = homeworkTasks;
            _jobs = jobs;
            _jobTasks = jobTasks;
            _lessons = lessons;
            _outcomes = outcomes;
            _incomes = incomes;
            _jobIncomes = jobIncomes;
            _periodicOutcomes = periodicOutcomes;
            _sports = sports;
            _subjects = subjects;
            _trainingPlans = trainingPlans;
            _users = users;
            _usersSettngs = usersSettngs;
            _subjects = subjects;
        }

        public IBookRepository Books => _books.Value;

        public IDailyTaskRepository DailyTasks => _dailyTasks.Value;

        public IExamRepository Exams => _exams.Value;

        public IFinalResultRepository FinalResults => _finalResults.Value;

        public IHomeworkTaskRepository HomeworkTasks => _homeworkTasks.Value;

        public IIncomeRepository Incomes => _incomes.Value;

        public IJobRepository Jobs => _jobs.Value;

        public IJobIncomeRepository JobIncomes => _jobIncomes.Value;

        public IJobTaskRepository JobTasks => _jobTasks.Value;

        public ILessonRepository Lessons => _lessons.Value;

        public IOutcomeRepository Outcomes => _outcomes.Value;

        public IPeriodicOutcomeRepository PeriodicOutcomes => _periodicOutcomes.Value;

        public ISportRepository Sports => _sports.Value;

        public ISubjectRepository Subjects => _subjects.Value;

        public ITrainingPlanRepository TrainingPlans => _trainingPlans.Value;

        public IUserRepository Users => _users.Value;

        public IUserSettingRepository UsersSettngs => _usersSettngs.Value;

        public IVacancyRepository Vacancies => _vacancies.Value;


        public EntityEntry GetContextEntry(object obj)
        {
            return _context.Entry(obj);
        }
    }
}
