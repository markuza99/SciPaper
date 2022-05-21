using SciPaperMicroservice.Dtos;
using SciPaperMicroservice.Models;
using System.Collections.Generic;

namespace SciPaperMicroservice.Services
{
    public interface ISciPaperService
    {
        IEnumerable<SciPaper> GetAllSciPapers();
        SciPaper GetSciPaperById(string id);
        string CreateSciPaper(SciPaperCreateDto sciPaperDto, string jwt);
    }
}
