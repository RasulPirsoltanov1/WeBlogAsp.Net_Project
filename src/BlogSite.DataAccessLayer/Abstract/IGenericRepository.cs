using BlogSite.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> _context { get; }
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(T t);
    }
}
