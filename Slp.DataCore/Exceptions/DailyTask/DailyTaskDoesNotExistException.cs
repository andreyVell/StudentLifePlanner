namespace Slp.DataCore.Exceptions.DailyTask
{
    public class DailyTaskDoesNotExistException:Exception
    {
        public DailyTaskDoesNotExistException() : base("The daily task does not exist") { }
    }
}
