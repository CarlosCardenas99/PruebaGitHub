using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketByCodigoQuery
    {
        public GetTicketByCodigoQuery(int IdVehiculo) => IdVehiculo = IdVehiculo;
        public int IdVehiculo { get; set; }
    }
}
