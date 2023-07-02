using Dapper.Contrib.Extensions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly string _connectionString;
        //private readonly IDbConnection _connection;

        public UserRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["UserDb"].ToString();
        }

        public User Get(long id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var user = connection.Get<User>(id);

                    return user;
                }
            }
            catch (Exception ex)
            {
                string MessageExcepction = ex.Message.ToString();
                string plainText = string.Join("----------", new string[2] { _connectionString, MessageExcepction });
                // Ruta completa del archivo que deseas guardar
                string rutaArchivo = @"C:\Temp\ErrorWCF.txt";

                File.WriteAllText(rutaArchivo, MessageExcepction);
                return null;
            }
            
        }

        public List<User> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var users = connection.GetAll<User>();

                return users.ToList();
            }
        }

        public long Insert(User user)
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();

                var identity = connection.Insert(user);
                return identity;
            }
        }

        public bool Update(User user)
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();

                bool isSuccess = connection.Update(user);
                return isSuccess;
            }
        }

        public bool Delete(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                bool isSuccess = connection.Delete(user);
                return isSuccess;
            }
        }

        public async Task<User> GetAsync(long id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var user = await connection.GetAsync<User>(id);

                return user;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var users = await connection.GetAllAsync<User>();

                return users.ToList();
            }
        }


        public async Task<long> InsertAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var identity = await connection.InsertAsync(user);
                return identity;
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                bool isSuccess = connection.Delete(user);
                return isSuccess;
            }
        }

        public async Task<bool> DeleteAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                bool isSuccess = await connection.DeleteAsync(user);
                return isSuccess;
            }
        }
    }
}
