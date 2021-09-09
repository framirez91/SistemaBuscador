using Microsoft.AspNetCore.Http;
using SistemaBuscador.Repositories;
using System.Threading.Tasks;

namespace SistemaBuscador.Test
{
    public class LoginRepositoryEFTrue : ILoginRepository
    {
        public void SetSessionAndCookie(HttpContext context)
        {

        }

        public async Task<bool> UserExist(string usuario, string password)
        {
            return await Task.FromResult(true);
        }
    }
}