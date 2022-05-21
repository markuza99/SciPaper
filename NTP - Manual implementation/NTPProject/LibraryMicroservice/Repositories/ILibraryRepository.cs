using SharedModels;
using System.Collections.Generic;

namespace LibraryMicroservice.Repositories
{
    public interface ILibraryRepository
    {
        bool SaveChanges();

        IEnumerable<SciPaperPublished> GetAllSciPapersPublished();
        SciPaperPublished GetSciPaperPublishedById(string id);
        void CreateSciPaperPublished(SciPaperPublished sciPaperPublished);
    }
}
