using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp2.Models.News
{
    public class CreateNewsViewModel
    {
        [Display(Name = "Metnin bashligi")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Display(Name = "Metnin texti")]
        [Required]
        public string Body { get; set; }

        public DateTime dateTime { get; set; }
    }
}
