using OfficeReservationService.Contracts.Models;

namespace OfficeReservationService.Contracts.Requests
{
    public class RoomDto
    {
        public int CompanyRoomId { get; set; }
        public string Name { get; set; }
        public bool IsWorkSpaceRoom { get; set; }
        public List<SeatingDto> Seatings { get; set; } = new List<SeatingDto>();
    }
}
