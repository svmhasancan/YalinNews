using Core.Entities;

namespace Entities.Concrete
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
} 