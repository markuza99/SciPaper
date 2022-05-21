using Microsoft.EntityFrameworkCore;
using SciPaperMicroservice.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace SciPaperMicroservice.Models
{
    public class Section
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SciPaperId { get; set; }
        public string Name  { get; set; }
        public string Content { get; set; }

        public Section(SectionCreateDto sectionDto)
        {
            Name = sectionDto.Name;
            Content = sectionDto.Content;
        }
        public Section()
        {

        }
    }
}
