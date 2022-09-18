using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public virtual Language? Language { get; set; }

        public Technology()
        {
        }

        public Technology(int id, string name, int languageId)
        {
            Id = id;
            Name = name;
            LanguageId = languageId;
        }
    }
}
