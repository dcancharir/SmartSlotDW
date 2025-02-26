using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class ClienteCuponQueries {
    public static string Create => @"
        IF NOT EXISTS (SELECT 1 FROM ClienteCupon WHERE clienteid = @clienteid and codsala = @codsala and idSorteo = @idSorteo)
        BEGIN
INSERT INTO [dbo].[ClienteCupon]
           ([codsala]
           ,[id]
           ,[clienteid]
           ,[idSorteo]
           ,[nombreSorteo]
           ,[cuponesGenerados]
           ,[cuponesAsignados]
           ,[estado]
           ,[fecharegistrodw])
     VALUES
           (@codsala
           ,@id
           ,@clienteid
           ,@idSorteo
           ,@nombreSorteo
           ,@cuponesGenerados
           ,@cuponesAsignados
           ,@estado
           ,getdate())
        END
";
}
