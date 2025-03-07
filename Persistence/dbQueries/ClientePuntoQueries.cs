using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class ClientePuntoQueries {
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM ClientePunto WHERE id = @id and codsala = @codsala)
            BEGIN
             INSERT INTO [dbo].[ClientePunto]
               ([codsala]
               ,[id]
               ,[clienteid]
               ,[totalpuntos]
               ,[puntos]
               ,[puntoCortesia]
               ,[puntoCortesiaNC]
               ,[fecharegistrodw])
         VALUES
               (@codsala
               ,@id
               ,@clienteid
               ,@totalpuntos
               ,@puntos
               ,@puntoCortesia
               ,@puntoCortesiaNC
               ,getdate())
            END
";
}
