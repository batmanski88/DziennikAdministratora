using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DziennikAdministratora.Repository.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IAppDbContext _context;

        public CategoryRepo(IAppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAysnc(Guid categoryId)
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Where(x => x.CategoryId == categoryId).FirstOrDefault();
        }

        public async Task RemoveCategoryAsync(Guid categoryId)
        {
            var categories = await _context.Categories.ToListAsync();
            _context.Categories.Remove(categories.Where(x => x.CategoryId == categoryId).FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}