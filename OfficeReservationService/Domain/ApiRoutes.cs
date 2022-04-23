namespace OfficeReservationService.Domain
{
    public class ApiRoutes
    {
        public const string Root = "api/";
        public const string Version = "v1/";
        public const string Base = Root + Version;
        public static class AdminPanel
        {
            private const string _controllerName = Base + "adminpanel/";

            public const string CreateRoom = _controllerName + "createroom";
            public const string EditRoom = _controllerName + "editroom";
            public const string AcceptUser = _controllerName + "acceptuser";
            public const string RemoveUser = _controllerName + "removeuser";
            public const string InviteUser = _controllerName + "invite";
        }
    }
}
