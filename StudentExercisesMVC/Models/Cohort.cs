using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StudentExercisesMVC.Models
{
    public class Cohort
    {
        public int Id { get; set; }
        [Required]
        public string Designation { get; set; }

        List<Student> Students = new List<Student>();

        List<Instructor> Instructors = new List<Instructor>();
    }
}
