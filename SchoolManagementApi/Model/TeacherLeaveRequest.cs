using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.Model
{
    public class TeacherLeaveRequest
    {
         [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveRequestId { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public string UserName { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? Reason { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }
    }
}
