using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using MySql.Data.MySqlClient;
using Dapper;

namespace NewsApi.Models
{
    public interface INewsRepository
    {
        Task Create(News news);
        Task Delete(long id);
        News Get(int id);
        List<News> getNews();
        Task Update(News news);
    }

    public class NewsRepository : INewsRepository
    {
        //string connectionString = null;
        private readonly IConfiguration _configuration;
        
        public NewsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Create(News news)
        {
            using (IDbConnection db = new MySqlConnection(_configuration["MySetting"]))
            {
                var sqlQuery = "INSERT INTO news (header, date_time, content, author, category) VALUES (@header,@date_time, @content,@author,@category)";
                await db.ExecuteAsync(sqlQuery, news);
            }
        }

        public async Task Delete(long id)
        {
            using (IDbConnection db = new MySqlConnection(_configuration["MySetting"]))
            {
                var sqlQuery = "DELETE FROM news WHERE id = @id";
                await db.ExecuteAsync(sqlQuery, new { id });
            }
        }

        public News Get(int id)
        {
            using (IDbConnection db = new MySqlConnection(_configuration["MySetting"]))
            {
                return db.Query<News>("Select * FROM news Where Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<News> getNews()
        {
            using (IDbConnection db = new MySqlConnection(_configuration["MySetting"]))
            {
                return db.Query<News>("SELECT * FROM news").ToList<News>();
            }
        }

        public async Task Update(News news)
        {
            using (IDbConnection db = new MySqlConnection(_configuration["MySetting"]))
            {
                var sqlQuery = "UPDATE news SET header = @header, content = @content WHERE id = @id";
                await db.ExecuteAsync(sqlQuery, news);
            }
        }
    }
}
