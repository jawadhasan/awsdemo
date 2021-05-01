using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Npgsql;

namespace AWSServerlessDemo.DataLayer
{
    public class ProductsRepository
    {
        private readonly IDbConnection _db;

        //ctor
        public ProductsRepository(string connectionString)
        {
            _db = new NpgsqlConnection(connectionString);
        }

        public List<dynamic> GetAll()
        {
            return _db.Query("SELECT * FROM products").ToList();
        }
    }
}
