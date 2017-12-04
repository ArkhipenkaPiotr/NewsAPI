using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NewsApi.Models
{
    public interface INewsRepository
    {
        Task Create(News news);
        Task Delete(long id);
        Task<News> Get(int id);
        Task<IEnumerable<News>> getNews();
        Task Update(News news);
    }
}
