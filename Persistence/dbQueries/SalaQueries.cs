using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.dbQueries;
[ExcludeFromCodeCoverage]
internal class SalaQueries {
    public static string SelectActives => @"SELECT [codSala]
      ,[nombre]
      ,[uri]
      ,[estado]
  FROM [dbo].[Sala] where estado = 1";
}
