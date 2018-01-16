using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NewsApi.Models
{
    public interface INewsRepository
    {
        Task<int> Create(News news);
        Task Delete(long id);
        Task<News> Get(int id);
        Task<IEnumerable<News>> GetNews(int startnum, String category);
        Task<int> Update(News news);
    }
}
