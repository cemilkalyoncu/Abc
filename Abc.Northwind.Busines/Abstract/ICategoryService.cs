using Abc.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Northwind.Busines.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
