using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class ClienteCategoriaQueries {
    public static string Create => @"
        IF NOT EXISTS (SELECT 1 FROM ClienteCategoria WHERE id = @id and codsala = @codsala)
        BEGIN
INSERT INTO [dbo].[ClienteCategoria]
           ([codsala]
           ,[id]
           ,[nombre]
           ,[estado],[fecharegistrodw],[puntos])
     VALUES
           (@codsala
           ,@id
           ,@nombre
           ,@estado,getdate(),@puntos)
        END
";
}
