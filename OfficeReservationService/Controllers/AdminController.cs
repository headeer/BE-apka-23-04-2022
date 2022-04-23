using Microsoft.AspNetCore.Mvc;
using OfficeReservationService.Contracts.Requests;
using OfficeReservationService.Domain;
using OfficeReservationService.Services.Interfaces;

namespace OfficeReservationService.Controllers
{
    public class AdminController : ControllerBase
    {
        private readonly IAdminPanelService _adminService;
        public AdminController(IAdminPanelService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost(ApiRoutes.AdminPanel.CreateRoom)]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("RoomModel is invalid");
            }
            var created = await _adminService.CreateRoomAsync(room);
            if(!created)
            {
                return BadRequest("Something went wrong"); //CHANGE RESPONSE
            }
            return Ok();
        }
        [HttpPut(ApiRoutes.AdminPanel.EditRoom)]
        public IActionResult EditRoom()
        {
            return Ok(); //TODO with good db
        }
        [HttpPost(ApiRoutes.AdminPanel.AcceptUser)]
        public IActionResult AcceptNewMember([FromBody] UserTransaction user)
        {
            return Ok();
        }
        [HttpDelete(ApiRoutes.AdminPanel.RemoveUser)]
        public IActionResult RemoveMember([FromBody] UserTransaction user)
        {
            return Ok();
        }
        [HttpPost(ApiRoutes.AdminPanel.InviteUser)]
        public IActionResult InviteUserToCompany([FromBody] InvitationRequest invitation)
        {
            return Ok();
        }
    }
}
