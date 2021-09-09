
using Microsoft.AspNetCore.Http;
using SistemaBuscador.Repositories;
using System.Threading.Tasks;

namespace SistemaBuscador.Test
{
    public class LoginRepositoryEFFalse : ILoginRepository
    {
        public void SetSessionAndCookie(HttpContext context)
        {

        }

        public async Task<bool> UserExist(string usuario, string password)
        {
            return await Task.FromResult(false);
        }
    }
}