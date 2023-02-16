namespace Slp.Data.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifyAt { get; set; }
        public Guid? ModifyBy { get; set; }
    }
}