using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ImageModel
    {
        
        public long Id { get; set; }
        public string Filename { get; set; }
        public List<byte[]> Data { get; set; }
    }
}
