namespace SciPaperMicroservice.Models
{
    public class Message
    {
        public string PaperId { get; set; }
        public string PaperTitle { get; set; }
        public string PaperAuthor { get; set; }

        public Message()
        {

        }

        public Message(string paperId, string paperTitle, string paperAuthor)
        {
            PaperAuthor = paperAuthor;
            PaperId = paperId;
            PaperTitle = paperTitle;
        }

    }
}
