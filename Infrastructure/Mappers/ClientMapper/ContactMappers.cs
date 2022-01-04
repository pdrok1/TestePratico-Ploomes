using BusinessLogic.Entities;
using BusinessLogic.Entities.Contacts;
using Infrastructure.Dtos;

namespace Infrastructure.Mappers.ClientMapper
{
    public static class ContactMappers
    {
        public static Contact ToDomain(this ContactDto dto)
            => new Contact()
            {
                Id = dto.Id,
                TypeId = (TypeEnum)dto.TypeId,
                Value = dto.Value
            };

        public static ContactDto ToDto(this Contact domain)
            => new ContactDto()
            {
                Id = domain.Id,
                TypeId = (int)domain.TypeId,
                Value = domain.Value
            };

    }
}
