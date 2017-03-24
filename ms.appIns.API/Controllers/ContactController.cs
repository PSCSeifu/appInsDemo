using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ms.appIns.Types.Contact;
using Microsoft.Extensions.Logging;
using Raven.Client.Document;
using Serilog;

namespace ms.appIns.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Contact")]
    public class ContactController : Controller
    {
        //private readonly ILogger<ContactController> _logger;

        //public ContactController(ILogger<ContactController> logger)
        //{
        //    _logger = logger;          
        //}

        public ContactController()
        {
            //Serilog.ILogger logger = new LoggerConfiguration()
            //                            .WriteTo.Sink<>.RavenDB
            //                            .CreateLogger();
        }




        //Get api/Contact
        [HttpGet]
        public IActionResult Get()
        {
            var result = Data();
            //_logger.LogInformation("Fetched Contact list { @Contacts}", result);
            //logger.LogInformation("Fetched Contact list { @Contacts}", result);
            return Json(result);
           
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           // _logger.LogInformation($"Fetching a contact with id ={id}");
            var result = Data().Where(c => c.Id == id).Select(c => c).SingleOrDefault();
            //_logger.LogInformation($"After Fetching a contact with id ={id}", result);
            return Json(result);
        }



        private List<ContactDTO> Data()
        {
            return new List<ContactDTO> {   new ContactDTO { Id = 1, Address1 = "11 Cambridge Way", Address2 = "Cambridge", PostCode = "CB1 1WW", Age = 25 },
               new ContactDTO  { Id = 2, Address1 = "12 Havehill Way", Address2 = "Haverhill", PostCode = "CB21 1WW", Age = 35 },
                  new ContactDTO  { Id = 3, Address1 = "12 Barhill Way", Address2 = "Barhill", PostCode = "CB21 1WW", Age = 45 },
                   new ContactDTO  { Id = 4, Address1 = "122 Chesterton Road", Address2 = "Haverhill", PostCode = "CB1 9GH", Age = 38 },
                new ContactDTO  { Id = 5, Address1 = "88 Somthing Close", Address2 = "Barhill", PostCode = "CB2 3RR", Age = 22 }
            };
        }
    }
}