using System.ComponentModel.DataAnnotations;

namespace OfficeReservationService.Contracts.Models
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }
        public int CompanyRoomId { get; set; }
        public string Name { get; set; }
        public bool IsWorkSpaceRoom { get; set; }
        public virtual List<Seating> Seatings { get; set; } = new List<Seating>();
        public virtual Company Company { get; set; }
    }
}
