using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class ClientePuntoFechasQueries {
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM ClientePuntoFechas WHERE clienteid = @clienteid and codsala = @codsala and fechacorta = @fechacorta)
            BEGIN
                INSERT INTO [dbo].[ClientePuntoFechas]
                       ([codsala]
                       ,[clienteid]
                       ,[tipoPunto]
                       ,[puntos]
                       ,[saldoactual]
                       ,[fecha]
                       ,[fechacorta]
                       ,[fecharegistrodw])
                 VALUES
                       (@codsala
                       ,@clienteid
                       ,@tipoPunto
                       ,@puntos
                       ,@saldoactual
                       ,@fecha
                       ,@fechacorta
                       ,@fecharegistrodw)
            END
";
}
