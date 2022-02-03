using System;

namespace FlyoutMovie.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public string MediaFormat { get; set; }
    }
}