using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROG_POE_ClassLib.Model
{
    [Table("StudentModules")]
    public class StudentModules
    {
        [Key]
        public int Student_Id { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Module_Name { get; set; }

        [Required]
        public string Module_Code { get; set; }

        [Required]
        public int Num_Credits { get; set; }

        [Required]
        public int Class_Hours { get; set; }

        [Required]
        public int Semester_Weeks { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start_Date { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date_Studied { get; set; }

        [Required]
        public int Hours_Studied { get; set; }


        public int SelfStudyHrsReq { get; set; }
        public int SelfStudyHrsRem { get; set; }
        public int Weeks { get; set; }
    }
}
