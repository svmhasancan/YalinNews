using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult("Kategori başarıyla eklendi");
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult("Kategori başarıyla silindi");
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), "Kategoriler listelendi");
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == categoryId));
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult("Kategori başarıyla güncellendi");
        }
    }
} 