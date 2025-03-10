using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public static class SorteoConfiguracionQueries {
    public static string Create => $@"
    INSERT INTO [dbo].[SorteoConfiguracion]
           ([codsala]
           ,[sorteoconfiguracionid]
           ,[sorteoid]
           ,[nombre]
           ,[coinin]
           ,[coinout]
           ,[cantidadpuntos]
           ,[minimaapuesta]
           ,[maximaapuesta]
           ,[jackpot]
           ,[cantidadcupones])
     VALUES
           (@codsala
           ,@sorteoconfiguracionid
           ,@sorteoid
           ,@nombre
           ,@coinin
           ,@coinout
           ,@cantidadpuntos
           ,@minimaapuesta
           ,@maximaapuesta
           ,@jackpot
           ,@cantidadcupones)
";
}
