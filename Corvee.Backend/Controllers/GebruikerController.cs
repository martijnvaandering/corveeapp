using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Corvee.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        public IEnumerable<string> GetUserNames()
        {
            MySqlConnection connection = new MySqlConnection("Server=mysql;Database=corvee_app;Uid=root;Pwd=DitIsEchtEenSuperVeiligWachtwoord;");
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "select Naam from Gebruiker";
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return reader.GetString(0);
                }
            }
        }

        [HttpPost]
        public ActionResult AddNewUser([FromBody] GebruikerDTO gebruiker)
        {
            MySqlConnection connection = new MySqlConnection("Server=mysql;Database=corvee_app;Uid=root;Pwd=DitIsEchtEenSuperVeiligWachtwoord;");
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT into Gebruiker (Naam) VALUES (\"" + gebruiker.Naam + "\")";
            cmd.ExecuteNonQuery();

            return new OkResult();

        }
    }
}
