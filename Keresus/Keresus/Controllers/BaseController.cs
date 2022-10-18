using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Keresus.Controllers
{
    public class BaseController : Controller
    {
        IConfiguration _config;
        public BaseController(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connect()
        {
            return new SqlConnection(_config.GetConnectionString("Baglanti"));
        }
    }
}
