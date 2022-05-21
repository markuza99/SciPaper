using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SciPaperMicroservice.Dtos;
using SciPaperMicroservice.Models;
using SciPaperMicroservice.Services;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SciPaperMicroservice.Controllers
{

    [Route("api/scipapers")]
    [ApiController]
    public class SciPaperController : ControllerBase
    {
        private readonly ISciPaperService _service;
        private readonly IBus _busService;


        public SciPaperController(ISciPaperService service, IBus busService)
        {
            _service = service;
            _busService = busService;
        }


        [Route("publish/{id}")]
        [HttpPost]
        public async Task<IActionResult> PublishSciPaper([FromRoute] string id)
        {
            SciPaper sciPaper = _service.GetSciPaperById(id);
            if(sciPaper != null)
            {
                SciPaperPublished sciPaperPublished = new SciPaperPublished(sciPaper.Id, sciPaper.Author, sciPaper.Title);
                Uri uri = new Uri("rabbitmq://localhost/sciPaperQueue");
                var endpoint = await _busService.GetSendEndpoint(uri);
                await endpoint.Send(sciPaperPublished);
                return Ok();
            }
            return NotFound();            
            
        }

        [HttpPost]
        public ActionResult<string> createSciPaper(SciPaperCreateDto sciPaperDto)
        {

            var auth = Request.Headers["Authorization"].ToString();
            if (auth.Trim().Length > 0)
            {
                string jwt = "";
                if(auth.ToString().StartsWith("Bearer") && auth.ToString().Split(" ").Length == 2)
                {
                    jwt = auth.ToString().Split(" ")[1];
                } else
                {
                    jwt = auth.ToString();
                }
                string resText = _service.CreateSciPaper(sciPaperDto, jwt);
                if(resText == "UserMicroservice is down!")
                {
                    return StatusCode(503, resText);
                }
                if (resText == "Invalid token!")
                {
                    return BadRequest(resText);
                }
                return Ok(resText);
            }
            return BadRequest("User is not logged in!");
        }

        [HttpGet]
        public ActionResult<IEnumerable<SciPaper>> getSciPapers()
        {
            return Ok(_service.GetAllSciPapers());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<SciPaper> getSciPaper([FromRoute] string id)
        {
            return Ok(_service.GetSciPaperById(id));
        }
    }
}
