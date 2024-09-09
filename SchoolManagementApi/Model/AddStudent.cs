using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Model
{
    public class AddStudent
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentUser { get; set; }

        public string Studentpass { get; set; }

        public string fullname { get; set; }

        public string Email { get; set; }

        public long Contect { get; set; }

        public string Standard { get; set; }

        public string AddMisstiondate { get; set; }
    }
}
