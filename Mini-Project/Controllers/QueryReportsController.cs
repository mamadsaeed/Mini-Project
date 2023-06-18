using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mini_Project.Model;
using Newtonsoft.Json;

namespace Mini_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryReportsController : ControllerBase
    {
        private readonly ReportContext _context;
        private readonly IConfiguration _Configuration;

        public QueryReportsController(IConfiguration configuration, ReportContext context)
        {
            _Configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetReport(int id)
        {
            Report? find = _context.Report.Where(x => x.Id == id).FirstOrDefault();
            if (find == null)
            {
                return NotFound();
            }
            try
            {
                string? query_string = find.Query;
                SqlConnection sqlConnection = new SqlConnection(_Configuration.GetConnectionString("ReportContext"));
                SqlCommand sqlCommand = new SqlCommand(query_string, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                string json = JsonConvert.SerializeObject(dataTable);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
