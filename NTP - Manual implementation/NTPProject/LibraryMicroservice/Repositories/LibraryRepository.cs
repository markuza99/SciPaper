using LibraryMicroservice.Data;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryMicroservice.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDbContext _context;
        public LibraryRepository(AppDbContext contex)
        {
            _context = contex;
        }

        public IEnumerable<SciPaperPublished> GetAllSciPapersPublished()
        {
            return _context.SciPapersPublished.ToList();
        }


        public SciPaperPublished GetSciPaperPublishedById(string id)
        {
            return _context.SciPapersPublished.FirstOrDefault(u => u.Id.ToString() == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateSciPaperPublished(SciPaperPublished sciPaperPublished)
        {
            if (sciPaperPublished == null)
            {
                throw new ArgumentNullException(nameof(sciPaperPublished));
            }
            _context.SciPapersPublished.Add(sciPaperPublished);
        }
    }
}
