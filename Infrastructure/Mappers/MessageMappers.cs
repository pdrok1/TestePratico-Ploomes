

using BusinessLogic.Entities;
using Infrastructure.Dtos;

namespace Infrastructure.Mappers
{
    public static class MessageMappers
    {
        public static Message ToDomain(this MessageDto dto)
            => new Message()
            {
                Id = dto.Id,
                ReceiverId = dto.ReceiverId,
                Type = dto.Type,
                Title = dto.Title,
                Content = dto.Content,
            };

        public static MessageDto ToDto(this Message domain)
            => new MessageDto()
            {
                Id = domain.Id,
                ReceiverId = domain.ReceiverId,
                Type = domain.Type,
                Title = domain.Title,
                Content = domain.Content,
            };

    }
}
