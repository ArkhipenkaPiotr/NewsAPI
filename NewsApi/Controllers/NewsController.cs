using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Models;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private INewsRepository repository;

        public NewsController (INewsRepository newsRepository)
        {
            repository = newsRepository; 
        }

        [HttpGet]
        public async Task<IEnumerable<News>> GetByPage(int startnum, string category)
        {
            return await repository.GetNews(startnum, category);
        }

        [HttpGet("{id}")]
        public async Task<News> GetById(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] News news)
        {
            news.DateTime = DateTime.Now;
            return await repository.Create(news);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] News news)
        {
            return await repository.Update(news);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await repository.Delete(id);
        }
    }
}
