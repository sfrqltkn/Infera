using Infera_WebApi.Requests.Base;
namespace Infera_WebApi.Requests.Ticket
{
    public class TicketGetAllRequest : BaseRequest
    {
        //kullanıcı ticket tablosuna veri girerken filtremek için kullanılır
        public String? NotiferPersonFullName { get; set; }
        public String? Description { get; set; }
    }
}
