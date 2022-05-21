

using LibraryMicroservice.Services;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using System.Collections.Generic;

namespace LibraryMicroservice.Controllers
{

    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _service;


        public LibraryController(ILibraryService service)
        {
            _service = service;
        }


        [Route("{id}")]
        [HttpGet]
        public ActionResult<SciPaperPublished> getSciPaper([FromRoute] string id)
        {
            return Ok(_service.GetSciPaperPublishedById(id));
        }

        [HttpGet]
        public ActionResult<SciPaperPublished> getSciPapers()
        {
            return Ok(_service.GetAllSciPapersPublished());
        }
    }
}
