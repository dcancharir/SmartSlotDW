using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class PromocionQueries
{
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM Promocion WHERE id = @id and codsala = @codsala)
            BEGIN
     INSERT INTO [dbo].[Promocion]
           ([codsala]
           ,[id]
           ,[nombre]
           ,[fechaVigenciainicial]
           ,[fechaVigenciaFinal]
           ,[estado]
           ,[fecharegistrodw])
     VALUES
           (@codsala
           ,@id
           ,@nombre
           ,@fechaVigenciainicial
           ,@fechaVigenciaFinal
           ,@estado
           ,getdate())
            END
";
}
