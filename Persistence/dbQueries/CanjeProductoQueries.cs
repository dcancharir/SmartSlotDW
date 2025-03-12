using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public static class CanjeProductoQueries {
    public static string Create => $@"
    INSERT INTO [dbo].[CanjeProducto]
           ([id]
           ,[codsala]
           ,[comprobante]
           ,[tipodocumento]
           ,[documento]
           ,[apellidoPaterno]
           ,[apellidoMaterno]
           ,[nombres]
           ,[categoriaCliente]
           ,[puntos_canjeados]
           ,[estado]
           ,[fechaPedido])
     VALUES
           (@id
           ,@codsala
           ,@comprobante
           ,@tipodocumento
           ,@documento
           ,@apellidoPaterno
           ,@apellidoMaterno
           ,@nombres
           ,@categoriaCliente
           ,@puntos_canjeados
           ,@estado
           ,@fechaPedido)
SELECT SCOPE_IDENTITY()
";
}
