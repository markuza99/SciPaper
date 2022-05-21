using LibraryMicroservice.Repositories;
using SharedModels;
using System.Collections.Generic;

namespace LibraryMicroservice.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public void CreateSciPaperPublished(SciPaperPublished sciPaper)
        {
            _repository.CreateSciPaperPublished(sciPaper);
            _repository.SaveChanges();
        }

        public IEnumerable<SciPaperPublished> GetAllSciPapersPublished()
        {
            return _repository.GetAllSciPapersPublished(); 
        }

        public SciPaperPublished GetSciPaperPublishedById(string id)
        {
            return _repository.GetSciPaperPublishedById(id);
        }
    }
}
