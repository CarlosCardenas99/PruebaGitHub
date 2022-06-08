﻿using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Ticket
{
    public class DeleteTicketCommand : CommandBase
    {
        public DeleteTicketCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}