using SharedModels;
using System.Collections.Generic;

namespace LibraryMicroservice.Services
{
    public interface ILibraryService
    {
        IEnumerable<SciPaperPublished> GetAllSciPapersPublished();
        SciPaperPublished GetSciPaperPublishedById(string id);
        void CreateSciPaperPublished(SciPaperPublished sciPaper);
    }
}
