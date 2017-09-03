using System;
using System.Collections.Generic;
using Dapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class PesoRepository : Repository<Peso>, IPesoRepository
    {
        public PesoRepository(HealthTrackContext context) : base(context)
        {
        }

        public IEnumerable<Peso> ObterTodosPorUsuario(Guid id)
        {
            var sql = "SELECT * FROM Pesos a WHERE a.UsuarioId = @uid ORDER BY DataHora DESC";
            return Db.Database.Connection.Query<Peso>(sql, new { uid = id });
        }
    }
}
