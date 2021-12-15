using BusinessLogic.Abstract;
using BusinessLogic.Entities.Messages;

namespace BusinessLogic.Entities
{
    public class Message : IEntity
    {
        public int Id { get; set; }

        public int ReceiverId { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
