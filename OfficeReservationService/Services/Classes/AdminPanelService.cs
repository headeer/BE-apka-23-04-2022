using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OfficeReservationService.Contracts.Models;
using OfficeReservationService.Contracts.Requests;
using OfficeReservationService.Data;
using OfficeReservationService.Services.Interfaces;

namespace OfficeReservationService.Services.Classes
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public AdminPanelService(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> AcceptUser(UserTransaction dto)
        {
            //TODO
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            return false;
        }

        public async Task<bool> CreateRoomAsync(RoomDto dto)
        {
            var room = _mapper.Map<Room>(dto);
            room.Seatings = _mapper.Map<List<Seating>>(dto.Seatings);
            await _context.Room.AddAsync(room);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
