using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public class StatusPlayerQueries
{
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM StatusPlayer WHERE idStatus = @idStatus and codsala = @codsala)
            BEGIN
              INSERT INTO [dbo].[StatusPlayer]
                   ([codsala]
                   ,[idStatus]
                   ,[nombreCompleto]
                   ,[dni]
                   ,[maquina]
                   ,[fechaini]
                   ,[fechafin]
                   ,[token]
                   ,[puntos]
                   ,[coinin]
                   ,[coinout]
                   ,[jackpot],[fecharegistrodw])
            output inserted.idStatus
             VALUES
                   (@codsala
                   ,@idStatus
                   ,@nombreCompleto
                   ,@dni
                   ,@maquina
                   ,@fechaini
                   ,@fechafin
                   ,@token
                   ,@puntos
                   ,@coinin
                   ,@coinout
                   ,@jackpot,getdate())
            END
else
begin
select -1
end
";
}
