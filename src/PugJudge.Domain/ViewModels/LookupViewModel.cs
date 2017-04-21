using System.ComponentModel.DataAnnotations;

namespace PugJudge.Domain.ViewModels
{
    public class LookupViewModel
    {
        [Required]
        [Display(Name = "Character Name")]
        public string Name { get; set; }

        [Required]
        public string Realm { get; set; }
    }
}