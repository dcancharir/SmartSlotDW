using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public static class HistorialCuponQueries {
    public static string Remove => $@"
        delete 
        from 
        dbo.HistorialCupon 
        where codsala = @codsala 
        and fechadw = convert(date,@fechadw)
";
}
