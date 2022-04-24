using OfficeReservationService.Contracts.Requests;

namespace OfficeReservationService.Services.Interfaces
{
    public interface IAdminPanelService
    {
        public Task<bool> CreateRoomAsync(RoomDto dto);
        public Task<bool> AcceptUser(UserTransaction dto);
        public Task<bool> TempCreateAdmin(RegistrationRequest request);
    }
}
