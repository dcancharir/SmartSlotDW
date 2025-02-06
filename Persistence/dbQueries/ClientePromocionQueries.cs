using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class ClientePromocionQueries {
    public static string Create => @"
        IF NOT EXISTS (SELECT 1 FROM ClientePromocion WHERE id = @id and codsala = @codsala)
        BEGIN
INSERT INTO [dbo].[ClientePromocion]
           ([codsala]
           ,[id]
           ,[promocionsalaid]
           ,[clienteid]
           ,[tipoPremio]
           ,[categoriaPremio]
           ,[premio]
           ,[tipoPremioStr]
           ,[categoriaPremioStr]
           ,[fecharegistrodw])
     VALUES
           (@codsala
           ,@id
           ,@promocionsalaid
           ,@clienteid
           ,@tipoPremio
           ,@categoriaPremio
           ,@premio
           ,@tipoPremioStr
           ,@categoriaPremioStr
           ,getdate())
        END
";
}
