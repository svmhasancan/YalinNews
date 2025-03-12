using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNewsDal : EfEntityRepositoryBase<News, NewsContext>, INewsDal
    {
        public List<NewsDetailDto> GetNewsDetail()
        {
            using(NewsContext context = new NewsContext())
            {
                var result = from n in context.News
                             join c in context.Categories
                                on n.CategoryId equals c.Id
                             join a in context.Authors
                                on n.AuthorId equals a.Id

                             select new NewsDetailDto
                             {
                                 Title = n.Title,
                                 Content = n.Content,
                                 ImageUrl = n.ImageUrl,
                                 PublishDate = n.PublishDate,
                                 CategoryName = c.Name,
                                 AuthorName = a.FirstName + "" + a.LastName,
                                 IsActive = n.IsActive
                             };
                return result.ToList();
            }
        }
    }
} 