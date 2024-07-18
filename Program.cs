using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*

// Configuración JWT
var key = Encoding.ASCII.GetBytes("TuClaveSecretaSuperSegura123!");


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "tu_issuer",
        ValidAudience = "tu_audience",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

 

builder.Services.AddAuthorization();



app.UseAuthentication();
  */

/*
 
 class program
    {
        static void Main(string[] args)
        {
            //GET-
            using (var client = new HttpClient())
            {
                string url = "https://jsonplaceholder.typicode.com/posts/1";

                client.DefaultRequestHeaders.Clear();
                // client.DefaultRequestHeaders.Add("Autorization", "LKASJFKDLFDSAKJ");

                var response = client.GetAsync(url).Result;

                var res = response.Content.ReadAsStringAsync().Result;
                dynamic json = JObject.Parse(res);

                Console.WriteLine(json);
                //-GET
                //POST-
                string url2 = "https://jsonplaceholder.typicode.com/posts";

                // Crea el objeto JSON a enviar
                var parametros = new
                {
                    title = "juanito",
                    body = "Prueba Post",
                    userId = 124
                };

                // Serializa el objeto a JSON
                string jsonString = JsonConvert.SerializeObject(parametros);

                var httpContent = new StringContent(jsonString, Encoding.UTF8, "aplication/json");
                var response2 = client.PostAsync(url2, httpContent).Result;
                var res2 = response2.Content.ReadAsStringAsync().Result;
                dynamic r2 = JObject.Parse(res2);

                Console.WriteLine(r2);
               
                //-POST
            }



        }
    }

 */

app.UseAuthorization();

app.MapControllers();

app.Run();
