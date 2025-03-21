﻿using Application.IRepositories;
using Dapper;
using Domain;
using Persistence.dbQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class SorteoRepository : ISorteoRepository{
    private readonly DapperContext _context;
    public SorteoRepository(DapperContext context) {
        _context = context;
    }
    public async Task<bool> CreateSorteo(Sorteo registro) {
        var db = _context.CreateSmartSlotConnection();
        bool result = false;
        try {
            var res = await db.ExecuteAsync(SorteoQueries.Create, registro);
            result = res > 0;
        } catch(Exception ex) {
            Console.WriteLine($"Error fetching records from db: ${ex.Message}");
            throw new Exception("Unable to fetch data. Please contact the administrator.");
        } finally {
            db.Close();
        }
        return result;
    }
    public async Task<IEnumerable<Sorteo>> GetAllSorteoByCodSala(int codsala) {
        var db = _context.CreateSmartSlotConnection();
        IEnumerable<Sorteo> result;
        try {
            result = await db.QueryAsync<Sorteo>(SorteoQueries.GetAllByCodSala, new { codsala = codsala });
        } catch(Exception ex) {
            Console.WriteLine($"Error fetching records from db: ${ex.Message}");
            throw new Exception("Unable to fetch data. Please contact the administrator.");
        } finally {
            db.Close();
        }
        return result;
    }
}
