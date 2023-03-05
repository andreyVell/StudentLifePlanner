namespace Slp.WebApi.Contracts.Pagging
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
    }
}
