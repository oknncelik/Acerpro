namespace Acerpro.Entities.Abstruct
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public bool ActiveFlag { get; set; }
    }
}
