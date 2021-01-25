using ISM_Vison.Services.Interfaces;

namespace ISM_Vison.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
