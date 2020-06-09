using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArmyTechTask.Models.Entities;

namespace ArmyTechTask.ViewModels.Student
    {
        public class StudentViewModel
        {
            public StudentViewModel()
            {
            }

            public int Id { get; set; }

            [Required] [StringLength(50)] public string Name { get; set; }

            [Column(TypeName = "date")]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            [Display(Name = "Governorate")]
            public int GovernorateId { get; set; }

            [Display(Name = "Neighborhood")]
            public int NeighborhoodId { get; set; }

            [Display(Name = "Field")]
            public int FieldId { get; set; }

            public string Field { get; set; }

            public string Governorate { get; set; }

            public string Neighborhood { get; set; }

        }
    }
