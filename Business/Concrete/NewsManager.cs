using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class NewsManager : INewsService
    {
        private INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        [ValidationAspect(typeof(NewsValidator))]
        public IResult Add(News news)
        {
            _newsDal.Add(news);
            return new SuccessResult(Messages.NewsAdded);
        }

        public IResult Delete(News news)
        {
            _newsDal.Delete(news);
            return new SuccessResult(Messages.NewsDeleted);
        }

        public IDataResult<List<News>> GetAll()
        {
            return new SuccessDataResult<List<News>>(_newsDal.GetAll(), Messages.NewsListed);
        }

        public IDataResult<List<News>> GetAllByAuthorId(int authorId)
        {
            var result = _newsDal.GetAll(n => n.AuthorId == authorId);
            return new SuccessDataResult<List<News>>(result, Messages.NewsListed);
        }

        public IDataResult<List<News>> GetAllByCategoryId(int categoryId)
        {
            var result = _newsDal.GetAll(n => n.CategoryId == categoryId);
            return new SuccessDataResult<List<News>>(result, Messages.NewsListed);
        }

        public IDataResult<News> GetById(int newsId)
        {
            var news = _newsDal.Get(n => n.Id == newsId);
            if (news == null)
                return new ErrorDataResult<News>(Messages.NewsNotFound);
                
            return new SuccessDataResult<News>(news);
        }

        public IResult Update(News news)
        {
            _newsDal.Update(news);
            return new SuccessResult(Messages.NewsUpdated);
        }
    }
} 