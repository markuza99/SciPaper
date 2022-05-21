using System;

namespace SharedModels
{
    public class SciPaperPublished
    {
        public SciPaperPublished()
        {

        }
        public SciPaperPublished(Guid id, string sciPaperAuthor, string sciPaperTitle)
        {
            Id = id;
            SciPaperAuthor = sciPaperAuthor;
            SciPaperTitle = sciPaperTitle;
        }



        public Guid Id { get; set; }
        public string SciPaperAuthor { get; set; }
        public string SciPaperTitle { get; set; }
    }
}
