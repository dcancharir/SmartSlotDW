namespace Persistence.dbQueries;
public class SorteoQueries {
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM Sorteo WHERE id = @id and codsala = @codsala)
            BEGIN
             INSERT INTO [dbo].[Sorteo]
                   ([codsala]
                   ,[id],[nombre]
                   ,[descripcion]
                   ,[fechaInicioSorteo]
                   ,[fechaFinSorteo]
                   ,[estado]
                   ,[tipo]
                   ,[fecharegistrodw])
             VALUES
                   (@codsala
                   ,@id,@nombre
                   ,@descripcion
                   ,@fechaInicioSorteo
                   ,@fechaFinSorteo
                   ,@estado
                   ,@tipo
                   ,getdate())
            END
";  
    public static string GetAllByCodSala => @"
           SELECT [codsala]
                  ,[id],[nombre]
                  ,[descripcion]
                  ,[fechaInicioSorteo]
                  ,[fechaFinSorteo]
                  ,[estado]
                  ,[tipo]
                  ,[fecharegistrodw]
              FROM [dbo].[Sorteo] where codsala = @codsala
";
}
