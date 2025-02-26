namespace Persistence.dbQueries;
public class ClientePromocionQueries {
    public static string Create => @"
        IF NOT EXISTS (SELECT 1 FROM ClientePromocion WHERE promocionid = @promocionid and codsala = @codsala and clienteid = @clienteid)
        BEGIN
INSERT INTO [dbo].[ClientePromocion]
           ([codsala]
           ,[clienteid]
           ,[promocionid]
           ,[cliente]
           ,[tipodocumento]
           ,[dni]
           ,[categoria]
           ,[promocion]
           ,[tipopromocion]
           ,[fechagenerado]
           ,[fechacanje]
           ,[premioGanado]
           ,[premio]
           ,[estado]
           ,[fecharegistrodw])
     VALUES
           (@codsala
           ,@clienteid
           ,@promocionid
           ,@cliente
           ,@tipodocumento
           ,@dni
           ,@categoria
           ,@promocion
           ,@tipopromocion
           ,@fechagenerado
           ,@fechacanje
           ,@premioGanado
           ,@premio
           ,@estado
           ,getdate())
        END
";
}
