using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApi.Model
{
    public class AddTeacher
    {
        [Key]
        public int TeacherId { get; set; }

        public string TeacherUser { get; set; }

        public string Teacherpass { get; set; }

        public string TecherName { get; set; }

        public string Subject { get; set; }

        public string Standard { get;set; }

        public string TeacherEmail { get; set; }

        public long Contact { get; set; }

        public string qualification{ get; set; }

    }
}
