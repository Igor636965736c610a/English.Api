using English.Core.Entities;

namespace English.Core.Domain
{
    public class Collection
    {
        public string Name { get; protected set; }
        public List<Word> Word { get; protected set; } = new List<Word>();
        public Guid Id { get; protected set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        protected Collection()
        {
        }
        public Collection(string name, Guid id, User user)
        {
            Name = name;
            Id = id;
            User = user;
        }
    }
}
