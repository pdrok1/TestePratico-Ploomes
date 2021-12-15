using BusinessLogic.Entities;
using Infrastructure.Dtos;
using System.Linq;
using Infrastructure.Mappers.ClientMapper;
using System.Collections.Generic;

namespace Infrastructure.Mappers
{
    public static class ClientMappers
    {
        public static Client ToDomain(this ClientDto dto)
            => new Client()
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Nickname = dto.Nickname,
                Contacts = dto.Contacts?.Select(c => c.ToDomain()).ToList(),
                Enabled = dto.Enabled
            }; 
        
        public static ClientDto ToDto(this Client domain)
             => new ClientDto()
             {
                 Id = domain.Id,
                 FullName = domain.FullName,
                 Nickname = domain.Nickname,
                 Contacts = domain.Contacts?.Select(c => c.ToDto()).ToList(),
                 Enabled = domain.Enabled
             };

    }
}
