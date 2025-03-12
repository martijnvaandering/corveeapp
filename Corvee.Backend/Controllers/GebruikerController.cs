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

            var output = new List<string>();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var naam = reader.GetString(0);
                    output.Add(naam);
                }

                return output;
            }
        }

        [HttpPost]
        public ActionResult AddNewUser([FromBody] GebruikerDTO gebruiker)
        {
            MySqlConnection connection = new MySqlConnection("Server=mysql;Database=corvee_app;Uid=root;Pwd=DitIsEchtEenSuperVeiligWachtwoord;");
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT into Gebruiker (Naam) VALUES (\"" + gebruiker.Naam + "\")"; //TODO: SQL injection nog fixen
            cmd.ExecuteNonQuery();

            return new OkResult();

        }
    }
}
