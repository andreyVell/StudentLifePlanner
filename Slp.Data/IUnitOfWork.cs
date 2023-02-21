using Microsoft.EntityFrameworkCore.ChangeTracking;
using Slp.DataProvider.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slp.Data
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IDailyTaskRepository DailyTasks { get; }
        IExamRepository Exams { get; }
        IFinalResultRepository FinalResults { get; }
        IHomeworkTaskRepository HomeworkTasks { get; }
        IIncomeRepository Incomes { get; }
        IJobRepository Jobs { get; }
        IJobIncomeRepository JobIncomes { get; }
        IJobTaskRepository JobTasks { get; }
        ILessonRepository Lessons { get; }
        IOutcomeRepository Outcomes { get; }
        IPeriodicOutcomeRepository PeriodicOutcomes { get; }
        ISportRepository Sports { get; }
        ISubjectRepository Subjects { get; }
        ITrainingPlanRepository TrainingPlans { get; }
        IUserRepository Users { get; }
        IUserSettingRepository UsersSettngs { get; }
        IVacancyRepository Vacancies { get; }
        EntityEntry GetContextEntry(object obj);
    }
}
