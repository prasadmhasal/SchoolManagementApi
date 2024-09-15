using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.Model
{
    public class Assignments
    {
        [Key]
        public int AssignmentId { get; set; }
        public int TeacherId { get; set; }
        public string Standard { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string FileUpload { get; set; }
    }
}
