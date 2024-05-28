using Dapper;
using Microsoft.Extensions.Configuration;
using MisaAsp.Models;
using Npgsql;
using System.Data;
using System.Threading.Tasks;

namespace MisaAsp.Services
{
    public interface IRegistrationService
    {
        Task<int> RegisterUserAsync(RegistrationRequest request);
        Task<bool> AuthenticateUserAsync(LoginRequest request);
    }

    public class RegistrationService : IRegistrationService
    {
        private readonly IConfiguration _configuration;

        public RegistrationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> RegisterUserAsync(RegistrationRequest request)
        {
            var sql = "INSERT INTO Registrations (FirstName, LastName, Email, PhoneNumber, Password) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Password)";

            await using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                var result = await connection.ExecuteAsync(sql, request);
                return result;
            }
        }

        public async Task<bool> AuthenticateUserAsync(LoginRequest request)
        {
            var sql = "SELECT COUNT(1) FROM Registrations WHERE (Email = @EmailOrPhoneNumber OR PhoneNumber = @EmailOrPhoneNumber) AND Password = @Password";

            await using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                var result = await connection.ExecuteScalarAsync<bool>(sql, request);
                return result;
            }
        }
    }
}
