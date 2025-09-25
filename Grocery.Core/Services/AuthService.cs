using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientService _clientService;
        public AuthService(IClientService clientService)
        {
            _clientService = clientService;
        }
        public Client? Login(string email, string password)
        {
            Client? client = _clientService.Get(email);
            if (client == null) return null;
            if (PasswordHelper.VerifyPassword(password, client.Password)) return client;
            return null;
        }

        public Client? Register(string name, string email, string password)
        {
            // Cheks if client already exists
            var existingClient = _clientService.Get(email);
            if (existingClient != null) return null;

            // Hashes the password
            var passwordHash = PasswordHelper.HashPassword(password);

            // Creates a new account
            var client = new Client(0, name, email, passwordHash);
            _clientService.Add(client);

            return client;
        }
    }
}
