using Microsoft.EntityFrameworkCore;
using SciPaperMicroservice.Data;
using SciPaperMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SciPaperMicroservice.Repositories
{
    public class SciPaperRepository : ISciPaperRepository
    {
        private readonly AppDbContext _context;
        public SciPaperRepository(AppDbContext contex)
        {
            _context = contex;
        }


        public void CreateSciPaper(SciPaper sciPaper)
        {
            if (sciPaper == null)
            {
                throw new ArgumentNullException(nameof(sciPaper));
            }
            _context.SciPapers.Add(sciPaper);
        }

        public IEnumerable<SciPaper> GetAllSciPapers()
        {
            return _context.SciPapers.Include(sciPaper => sciPaper.Sections).ToList();
        }

        public SciPaper GetSciPaperById(string id)
        {
            return _context.SciPapers.Include(sciPaper => sciPaper.Sections).FirstOrDefault(u => u.Id.ToString() == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
