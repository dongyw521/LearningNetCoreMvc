namespace Learning.NetCore.Domain
{
    public abstract class Entity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    public abstract class Entity : Entity<int>
    {
        
    }
}