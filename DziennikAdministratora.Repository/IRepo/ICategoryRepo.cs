using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Repository.IRepo
{
    public interface ICategoryRepo
    {
         Task<Category> GetCategoryAysnc(Guid categoryId);
         Task<IEnumerable<Category>> GetCategoriesAsync();
         Task AddCategoryAsync(Category category);
         Task UpdateCategoryAsync(Category category);
         Task RemoveCategoryAsync(Guid categoryId);
    }
}