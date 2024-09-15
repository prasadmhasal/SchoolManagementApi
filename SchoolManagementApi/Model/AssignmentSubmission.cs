using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.Model
{
    public class AssignmentSubmission
    {
        [Key]
        public int SubmissionId { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string FileUpload { get; set; }
    }
}
