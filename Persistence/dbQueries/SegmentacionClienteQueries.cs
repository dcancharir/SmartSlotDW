using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class SegmentacionClienteQueries
{
    public static string Create => @"
        IF NOT EXISTS (SELECT 1 FROM ClienteCategoria WHERE id = @id and codsala = @codsala)
        BEGIN
INSERT INTO [dbo].[SegmentacionCliente]
           ([codsala]
           ,[id]
           ,[nombre]
           ,[desde]
           ,[hasta]
           ,[fecharegistrodw])
     VALUES
           (@codsala
           ,@id
           ,@nombre
           ,@desde
           ,@hasta
           ,getdate())
        END
";
}
