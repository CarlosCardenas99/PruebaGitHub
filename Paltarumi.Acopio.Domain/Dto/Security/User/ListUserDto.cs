﻿namespace Paltarumi.Acopio.Domain.Dto.Security.User
{
    public class ListUserDto : UserDto
    {
        public Guid Id { get; set; }
        public bool Activo { get; set; }
    }
}
