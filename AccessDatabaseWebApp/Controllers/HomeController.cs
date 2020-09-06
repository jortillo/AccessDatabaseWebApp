using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccessDatabaseWebApp.Models;
using System.Data;
//using System.Data.OleDb;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Dapper;
//using System.Data.Odbc;
using Microsoft.Data.Sqlite;

namespace AccessDatabaseWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            
            List<TypeModel> types = new List<TypeModel>();
            using (IDbConnection connection = new SqliteConnection(ConfigurationExtensions.GetConnectionString(_configuration,"DefaultConnection")))
            {
                types = connection.Query<TypeModel>("Select * From Type").ToList();
            }
            return View(types);
        }

        [HttpPost]
        public IActionResult Results()
        {
            String type = Request.Form["objtype"];
            //Console.WriteLine(type);
            String title = Request.Form["title"];
            //Console.WriteLine(title);
            List<Mymsy1Model> result = new List<Mymsy1Model>();
            using (IDbConnection connection = new SqliteConnection(ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection")))
            {
                if(!type.Equals(""))
                {
                    result = connection.Query<Mymsy1Model>("Select * From MIMSY1 Where objtype LIKE '" + type + "'" +
                        "AND objname LIKE '%" + title +"%' LIMIT 4000").ToList();
                }
                else
                {
                    result = connection.Query<Mymsy1Model>("Select * From MIMSY1 Where objname LIKE '%" + title + "%' LIMIT 4000").ToList();
                }
   
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Documents()
        {
            String type = Request.Form["objname"];
            Console.WriteLine(type);
            List<DocumentsModel> result = new List<DocumentsModel>();
            using (IDbConnection connection = new SqliteConnection(ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection")))
            {
                result = connection.Query<DocumentsModel>("SELECT DOCUMENTS.Document_Name, DOCUMENTS.DateCreated, MIMSY1.[counter], MIMSY1.objtype, MIMSY1.objname, " +
                    "MIMSY1.description, MIMSY1.location1, MIMSY1.Sort1, MIMSY1.Sort2, MIMSY1.Sorts, MIMSY1.ytdcounter, MIMSY1.itemcount, MIMSY1.maker, MIMSY1.objclass1, MIMSY1.checkedout, MIMSY1.lost, " +
                    "MIMSY1.objdate,MIMSY1.acqsource, MIMSY1.acqmethod, MIMSY1.acqdate, MIMSY1.objstatus, MIMSY1.location2, MIMSY1.Key1 FROM(MIMSY1 INNER JOIN DOCUMENTS ON MIMSY1.[counter] = DOCUMENTS.[counter])" +
                    "Where objname LIKE '" + type + "' LIMIT 4000").ToList();
            }
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
