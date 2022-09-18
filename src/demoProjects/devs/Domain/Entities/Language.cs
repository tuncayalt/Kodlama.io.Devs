using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Language : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }

        public Language()
        {

        }

        public Language(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
