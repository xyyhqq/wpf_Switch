using FullApp.ThermometerDemo.Services.Interfaces;

namespace FullApp.ThermometerDemo.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
