﻿using System;
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
        // GET api/values
        [HttpGet]
        public List<News> Get()
        {
            return repository.getNews();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public News Get(int id)
        {
            return repository.Get(id);
        }

        [HttpPost]
        public async Task Create([FromBody] News news)
        {
            await repository.Create(news);
        }

        [HttpPut]
        public async Task Update([FromBody] News news)
        {
            await repository.Update(news);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await repository.Delete(id);
        }
    }
}