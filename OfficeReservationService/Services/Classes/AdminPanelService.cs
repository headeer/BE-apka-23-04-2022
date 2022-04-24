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

            var company = _context.Company.Where(x=>x.CompanyId == dto.CompanyId).FirstOrDefault();
            if(company == null)
            {
                return false; 
            }
            room.Company = company;
            await _context.Room.AddAsync(room);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        //Remove after registration
        public async Task<bool> TempCreateAdmin(RegistrationRequest request)
        {
            var user = new AppUser
            {

                Company = new Company
                {
                    CompanyId = Guid.NewGuid(),
                    Rooms = new List<Room>(),
                    Users = new List<AppUser>()
                },
                Email = request.Email,
                UserName = request.Email
            };
            var a = await _userManager.CreateAsync(user, request.Password);

            if (!a.Succeeded)
                return false;
            else
                return true;
        }
    }
}
