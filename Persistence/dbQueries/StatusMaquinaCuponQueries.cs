using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class StatusMaquinaCuponQueries
{
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM StatusMaquinaCupon WHERE idDetalle = @idDetalle and codsala = @codsala)
            BEGIN
    INSERT INTO [dbo].[StatusMaquinaCupon]
           ([codsala]
           ,[idDetalle]
           ,[idCabecera]
           ,[idSorteo]
           ,[sorteo]
           ,[cupon]
           ,[fecharegistrodw])
     VALUES
           (@codsala
           ,@idDetalle
           ,@idCabecera
           ,@idSorteo
           ,@sorteo
           ,@cupon
           ,getdate())
            END
";
}
