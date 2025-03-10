using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public static class ClienteJugadaQueries {
    public static string Remove => $@"
        delete from dbo.ClienteJugada
        where codsala = @codsala
        and fechadw = convert(date,@fechadw)
    ";
}
