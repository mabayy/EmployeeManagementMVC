namespace EmployeeManagement.Models
{
    public class LeaveApplication : ApprovalActivity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int NoOfDays { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationId { get; set; }
        public SystemCodeDetail Duration { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public string? Attachment { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public SystemCodeDetail Status { get; set; }
    }
}
