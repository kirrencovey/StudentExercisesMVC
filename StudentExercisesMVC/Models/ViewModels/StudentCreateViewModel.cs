using Microsoft.AspNetCore.Mvc.Rendering;
using StudentExercisesMVC.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC.Models.ViewModels
{
    public class StudentCreateViewModel
    {
        // A single student
        public Student Student { get; set; } = new Student();

        // All cohorts
        public List<SelectListItem> Cohorts;

        // All exercises for select element on edit form
        [Display(Name = "Assigned Exercises")]
        public List<SelectListItem> Exercises { get; private set; }

        // List of ExerciseIds chosen by user on the form
        public List<int> SelectedExercises { get; set; }

        public SqlConnection Connection;

        public StudentCreateViewModel() { }

        public StudentCreateViewModel(SqlConnection connection)
        {
            Connection = connection;
            BuildCohortOptions();
        }

        public void BuildCohortOptions()
        {
            Cohorts = CohortRepository.GetAllCohorts()
                .Select(li => new SelectListItem
                {
                    Text = li.Designation,
                    Value = li.Id.ToString()
                }).ToList();

            Cohorts.Insert(0, new SelectListItem
            {
                Text = "Choose cohort...",
                Value = "0"
            });
        }
    }
}