using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTechnique.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string ShortLink { get; set; }
        public string OriginalLink { get; set; }        
        public User Creator { get; set; }
    }
}
