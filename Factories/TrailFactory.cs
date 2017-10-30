
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Linq;
using Dapper;
using LostWoods.Models;

namespace LostWoods.Factory
{
    public class TrailFactory
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;
 
        public TrailFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
        
        //This method runs a query and stores the response in a list of dictionary records
        public void Add(Trail trail)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO trails (name, description, length, elevationChange, latitude, longitude)" +
                               "VALUES (@name, @description, @length, @elevationChange, @latitude, @longitude)";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
        public Trail FindById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"SELECT * FROM trails WHERE id = {id}";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).FirstOrDefault();
            }
        }
        public IEnumerable<Trail> GetAllTrails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * from trails";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query);
            }
        }
    }
}