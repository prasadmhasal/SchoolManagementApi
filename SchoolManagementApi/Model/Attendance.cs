using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.Model
{
    public class Attendance
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Standard { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public bool IsPresent { get; set; }

    }
}
