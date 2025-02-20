using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IResult Add(Author author)
        {
            _authorDal.Add(author);
            return new SuccessResult("Yazar başarıyla eklendi");
        }

        public IResult Delete(Author author)
        {
            _authorDal.Delete(author);
            return new SuccessResult("Yazar başarıyla silindi");
        }

        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll(), "Yazarlar listelendi");
        }

        public IDataResult<Author> GetById(int authorId)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(a => a.Id == authorId));
        }

        public IResult Update(Author author)
        {
            _authorDal.Update(author);
            return new SuccessResult("Yazar başarıyla güncellendi");
        }
    }
} 