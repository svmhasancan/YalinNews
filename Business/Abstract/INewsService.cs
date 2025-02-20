using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INewsService
    {
        IDataResult<List<News>> GetAll();
        IDataResult<News> GetById(int newsId);
        IDataResult<List<News>> GetAllByCategoryId(int categoryId);
        IDataResult<List<News>> GetAllByAuthorId(int authorId);
        IResult Add(News news);
        IResult Update(News news);
        IResult Delete(News news);
    }
} 