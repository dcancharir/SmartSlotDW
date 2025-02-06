using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
[ExcludeFromCodeCoverage]
public class AfluenciaHoraQueries
{
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM AfluenciaHora WHERE hora = @hora and codsala = @codsala)
            BEGIN
                INSERT INTO [dbo].[AfluenciaHora]
           ([codsala]
           ,[hora]
           ,[cantJuego]
           ,[fechaJuego]
           ,[produccion]
           ,[totalPuntos]
           ,[cantclientes]
           ,[maquina]
           ,[fecharegistrodw])
     VALUES
           (@codsala
           ,@hora
           ,@cantJuego
           ,@fechaJuego
           ,@produccion
           ,@totalPuntos
           ,@cantclientes
           ,@maquina
           ,getdate())
            END
";
}
