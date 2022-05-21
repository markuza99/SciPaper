using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SciPaperMicroservice.Dtos
{
    public class SciPaperCreateDto
    {
        public string Title { get; set; }
        public List<SectionCreateDto> Sections { get; set; }
    }
}
