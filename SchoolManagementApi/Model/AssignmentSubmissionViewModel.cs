using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.Model
{
    public class AssignmentSubmissionViewModel
    {
        [Key]
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public string FileUpload { get; set; }
    }
}
