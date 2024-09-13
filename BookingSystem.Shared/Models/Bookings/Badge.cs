namespace BookingSystem.Shared.Models.Bookings
{
    public class Badge
    {
        public Badge(string status)
        {
            Status = status;
        }
        public string Status { get; set; }
        public string Type => Status switch
        {
            "Pending" => "bg-soft-warning",
            "Reserved" => "bg-soft-primary",
            "Cancelled" => "bg-soft-danger",
            "Completed" => "bg-soft-success",
            _ => "bg-soft-secondary"
        };
        public string Icon => Status switch
        {
            "Pending" => "fas fa-stream",
            "Reserved" => "fas fa-redo",
            "Cancelled" => "fas fa-calendar-times",
            "Completed" => "fas fa-check",
            _ => "fas fa-ban"
        };
    }
}