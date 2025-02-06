using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
[ExcludeFromCodeCoverage]
public static class ClienteQueries {
    //public static string Create => @"INSERT INTO [Cliente] ([codsala],[id],[tipoDocumento],[documento],[categoriaCliente],[nombre],[apellidoPaterno],[apellidoMaterno],[fechaNacimiento],[correo],[celular]) 
				//        VALUES (@codsala,@id,@tipoDocumento,@documento, @categoriaCliente,@nombre,@apellidoPaterno, @apellidoMaterno, @fechaNacimiento,@correo,@celular) SELECT SCOPE_IDENTITY()";
    //public static string Create => @"INSERT INTO [dbo].[Cliente]
    //       ([id]
    //       ,[codsala]
    //       ,[tipoDocumento]
    //       ,[documento]
    //       ,[categoriaCliente]
    //       ,[nombre]
    //       ,[apellidoPaterno]
    //       ,[apellidoMaterno]
    //       ,[fechaNacimiento]
    //       ,[correo]
    //       ,[celular]
    //       ,[fecharegistrodw])
    // VALUES
    //       (@id
    //       ,@codsala
    //       ,@tipoDocumento
    //       ,@documento
    //       ,@categoriaCliente
    //       ,@nombre
    //       ,@apellidoPaterno
    //       ,@apellidoMaterno
    //       ,@fechaNacimiento
    //       ,@correo
    //       ,@celular
    //       ,getdate())";   
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM Cliente WHERE id = @id and codsala = @codsala)
            BEGIN
                INSERT INTO [dbo].[Cliente]
                           ([id]
                           ,[codsala]
                           ,[tipoDocumento]
                           ,[documento]
                           ,[categoriaCliente]
                           ,[nombre]
                           ,[apellidoPaterno]
                           ,[apellidoMaterno]
                           ,[fechaNacimiento]
                           ,[correo]
                           ,[celular]
                           ,[fecharegistrodw])
                     VALUES
                           (@id
                           ,@codsala
                           ,@tipoDocumento
                           ,@documento
                           ,@categoriaCliente
                           ,@nombre
                           ,@apellidoPaterno
                           ,@apellidoMaterno
                           ,@fechaNacimiento
                           ,@correo
                           ,@celular
                           ,getdate())
            END
";
}
