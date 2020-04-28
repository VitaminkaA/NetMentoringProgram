using System;

namespace BasicSerialization.DL.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string IsBn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
