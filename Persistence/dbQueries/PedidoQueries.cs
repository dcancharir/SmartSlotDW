using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
public static class PedidoQueries {
    public static string Create => $@"
    INSERT INTO [dbo].[Pedido]
           ([canjeproductoid]
           ,[codsala]
           ,[producto]
           ,[categoriaProducto]
           ,[cantidad_pedida])
     VALUES
           (@canjeproductoid
           ,@codsala
           ,@producto
           ,@categoriaProducto
           ,@cantidad_pedida)
";
}
