using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Model
{
    public class AddLibrarian
    {
        [Key]
        public int LibararianId { get; set; }   

        public string LibrarianUser { get; set; }

        public string Librarianpass { get; set; }

        public string LibrarianName { get; set; }

        public string Email { get; set; }   

        public long Contact {  get; set; }

        public  string Joindate { get; set; }
        public double Salary { get; set; }
    }
}
