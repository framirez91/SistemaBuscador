using System.Security.Cryptography;
using System.Text;

namespace SistemaBuscador.Utilidades
{
    public class Seguridad : ISeguridad
    {
        public string Encriptar(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();//variable algoritmo
            ASCIIEncoding encoding = new ASCIIEncoding();//variable codificador
            byte[] stream = null; //arreglo bytes
            StringBuilder sb = new StringBuilder();//reconstruccion de bites
            stream = sha256.ComputeHash(encoding.GetBytes(password));//llamado
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);

            }
            return sb.ToString();
        }
    }
}