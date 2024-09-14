namespace SchoolManagementApi.Model
{
    public class Timetable
    {
        public int Id { get; set; }
        public string Standard { get; set; }
        public string Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Subject { get; set; }
        
    }
}
