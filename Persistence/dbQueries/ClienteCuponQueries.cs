using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class ClienteCuponQueries {
    public static string Create => @"
        IF NOT EXISTS (SELECT 1 FROM ClienteCupon WHERE id = @id and codsala = @codsala)
        BEGIN
INSERT INTO [dbo].[ClienteCupon]
           ([codsala]
           ,[id]
           ,[clienteid]
           ,[sorteoid]
           ,[cupones]
           ,[fecharegistrodw])
     VALUES
           (@codsala
           ,@id
           ,@clienteid
           ,@sorteoid
           ,@cupones
           ,getdate())
        END
";
}
