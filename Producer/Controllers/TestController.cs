using Microsoft.AspNetCore.Mvc;
using Producer.Services;

namespace Producer.Controllers
{
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly IRabbitMqClient _rabbitMqClient;

        public TestController(IRabbitMqClient rabbitMqClient)
        {
            _rabbitMqClient = rabbitMqClient;
        }

        [HttpPost("push")]
        public void PushMessage([FromBody] string message)
        {
            _rabbitMqClient.Push(message);
        }
    }
}