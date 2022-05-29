using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class TicketFilterDto
    {
        public int IdLote { get; set; }
        public bool Activo { get; set; }
    }
}
