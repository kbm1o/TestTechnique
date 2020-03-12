using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using TestTechnique.Models;

namespace TestTechnique.Data
{
    public class DataContext : DbContext
    {
        public string ConnectionString { get; set; }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public DbSet<Link> Links { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(string constr)
        {
            ConnectionString = constr;
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString);
            }
        }

        public User LogUser(string email, string pwd)
        {
            User user = new User();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Users where Email=@email and Pwd=@Pwd", conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Id = Convert.ToInt32(reader["Id"]);
                        user.Email = reader["Email"].ToString();
                        //user.Pwd = reader["Pwd"].ToString();
                    }
                }
            }
            return user;
        }
    }
}
