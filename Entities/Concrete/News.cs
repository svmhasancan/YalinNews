using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class News : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public bool IsActive { get; set; }
    }
}