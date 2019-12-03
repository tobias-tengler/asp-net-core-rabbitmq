namespace Producer.Services
{
    public interface IRabbitMqClient
    {
        void Setup();

        void Push(string message);
    }
}