using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;
using System.Collections.Generic;
using WebApplication1.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/juanito")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly string _connectionString;
        // GET: api/<ValuesController>

        public ValuesController (IConfiguration configuration)
        {
            _connectionString =""+configuration.GetConnectionString("conexion");
        }


        [HttpGet]

        public ActionResult<IEnumerable<JuanitoModel>> ObtenerUsuarios()
        {
            List<JuanitoModel> usuarios = new List<JuanitoModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM juanito"; // Ajusta según tu esquema de base de datos
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JuanitoModel usuario = new JuanitoModel
                    {
                        id = (int)reader["id"],
                        nombre = reader["nombre"].ToString(),
                        fechanacimiento = reader["fechanacimiento"].ToString(),
                        especie = reader["especie"].ToString(),
                        edad = reader["edad"].ToString()
                        // Ajusta para más propiedades si es necesario
                    };
                    usuarios.Add(usuario);
                }
            }

            return Ok(usuarios);
        }



        // GET api/<ValuesController>/5

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<JuanitoModel>> Get(int id)
        {
            List<JuanitoModel> usuarios = new List<JuanitoModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM juanito WHERE id = {id}"; // Ajusta según tu esquema de base de datos
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    JuanitoModel usuario = new JuanitoModel
                    {
                        id = (int)reader["id"],
                        nombre = reader["nombre"].ToString(),
                        fechanacimiento = reader["fechanacimiento"].ToString(),
                        especie = reader["especie"].ToString(),
                        edad = reader["edad"].ToString()
                        // Ajusta para más propiedades si es necesario
                    };
                    usuarios.Add(usuario);
                }
            }

            return Ok(usuarios);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] JuanitoModel value)
        {
            JuanitoModel juanito = value;
            using (SqlConnection con = new SqlConnection(_connectionString)) {
                try
                {

                    string query = $"INSERT INTO juanito (nombre, fechanacimiento, especie, edad) " +
                        $"VALUES ('{value.nombre}','{value.fechanacimiento}', '{value.especie}', '{value.edad}');";
                    SqlCommand command = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    return "Se insertó con exito";

                }
                catch (Exception ex) {

                    return $"error al insertar mensaje : {ex.Message}";
                }




            }  
           
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JuanitoModel juanito)

        
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
