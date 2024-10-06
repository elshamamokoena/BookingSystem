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
            "Pending" => "warning",
            "Reserved" => "primary",
            "Cancelled" => "danger",
            "Approved" => "success",
            _ => "secondary"
        };

        public string Icon => Status switch
        {
            "Pending" => "fas fa-stream",
            "Reserved" => "fas fa-redo",
            "Cancelled" => "fas fa-calendar-times",
            "Approved" => "fas fa-check",
            _ => "fas fa-ban"
        };
    }
}