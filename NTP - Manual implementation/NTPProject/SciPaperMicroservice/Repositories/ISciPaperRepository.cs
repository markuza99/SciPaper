using SciPaperMicroservice.Models;
using System.Collections.Generic;

namespace SciPaperMicroservice.Repositories
{
    public interface ISciPaperRepository
    {
        bool SaveChanges();

        IEnumerable<SciPaper> GetAllSciPapers();
        SciPaper GetSciPaperById(string id);
        void CreateSciPaper(SciPaper sciPaper);
    }
}
