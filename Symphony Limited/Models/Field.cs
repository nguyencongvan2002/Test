using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Symphony_Limited.Models
{
    public class Field
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Field")]
        public string FieldName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string FieldDescription { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
