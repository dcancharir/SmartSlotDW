namespace Persistence.dbQueries;
public class SorteoQueries {
    public static string Create => @"
            IF NOT EXISTS (SELECT 1 FROM Sorteo WHERE id = @id and codsala = @codsala)
            BEGIN
             INSERT INTO [dbo].[Sorteo]
                   ([codsala]
                   ,[id]
                   ,[descripcion]
                   ,[fechaInicioSorteo]
                   ,[fechaFinSorteo]
                   ,[sorteovirtual]
                   ,[estado]
                   ,[tipo]
                   ,[fecharegistrodw])
             VALUES
                   (@codsala
                   ,@id
                   ,@descripcion
                   ,@fechaInicioSorteo
                   ,@fechaFinSorteo
                   ,@sorteovirtual
                   ,@estado
                   ,@tipo
                   ,getdate())
            END
";
}
