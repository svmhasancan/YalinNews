using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetAll();
        IDataResult<Author> GetById(int authorId);
        IResult Add(Author author);
        IResult Update(Author author);
        IResult Delete(Author author);
    }
} 