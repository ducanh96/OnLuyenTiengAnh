using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PracticeEnglish.Models;
using Dapper;
using PracticeEnglish.Data.Interface;

namespace PracticeEnglish.Data.Implement
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }
        public CategoryRepository()
        {
            // TODO: It will be refactored...
            _connectionString = "Server=DESKTOP-ET1GGIC\\SQLEXPRESS;Database=RESTfulSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[Name]                     
                                FROM [dbo].[Category]";
                var categories = await dbConnection.QueryAsync<Category>(query);
                return categories;
            }
        }

        public async Task<Category> GetAsync(long id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT [Id] ,[Name]                     
                                FROM [dbo].[Category] where Id = @Id";

                var category = await dbConnection.QueryFirstOrDefaultAsync<Category>(query, new Category { @Id = id });
                return category;
            }
        }

       
    }
}