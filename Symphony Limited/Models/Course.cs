using System.ComponentModel.DataAnnotations;
using System;

namespace Symphony_Limited.Models
{
    public class Course
    {
        public int id { get; set; }

        [Display(Name="Course title")]
        public string CourseTitle { get; set; }

        [Display(Name ="Course content")]
        public string CourseContent { get; set; }

        [Display(Name="Course date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode=true,DataFormatString="{0:đd/MM/yyyy}")]
        public DateTime CourseDate { get; set; }

        [Display(Name ="Course duration")]
        public string CourseDuration { get; set; }

        [Display(Name="Course image")]
        public string CourseImage { get; set; }

        [Display(Name ="Course price")]
        public double CoursePrice { get; set; }
        public int FieldId { get; set; }
        public virtual Field Field { get; set; }
    }
}
