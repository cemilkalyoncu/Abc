using Abc.Northwind.Busines.Abstract;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.Busines.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
