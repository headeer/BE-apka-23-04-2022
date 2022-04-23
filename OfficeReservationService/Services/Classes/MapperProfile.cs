using AutoMapper;
using OfficeReservationService.Contracts.Models;
using OfficeReservationService.Contracts.Requests;


namespace OfficeReservationService.Services.Classes
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RoomDto, Room>();
            CreateMap<SeatingDto, Seating>();
        }
    }
}
