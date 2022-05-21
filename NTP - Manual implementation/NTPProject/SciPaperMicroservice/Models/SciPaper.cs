using SciPaperMicroservice.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SciPaperMicroservice.Models
{
    public class SciPaper
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Author { get; set; }

        public string Title { get; set; }
      
        public List<Section> Sections { get; set; }

        public SciPaper(SciPaperCreateDto sciPaperDto)
        {
            Title = sciPaperDto.Title;
            Sections = sciPaperDto.Sections.Select(s => new Section(s)).ToList();
        }
        public SciPaper()
        {

        }
    }
}
