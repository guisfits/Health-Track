using Dapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class AlimentoRepository : Repository<Alimento>, IAlimentoRepository
    {
        public AlimentoRepository(HealthTrackContext context) : base(context)
        {
        }

        public IEnumerable<Alimento> ObterTodosPorUsuario(Guid id)
        {
            var sql = "SELECT * FROM Alimentos a WHERE a.UsuarioId = @uid ORDER BY a.DataHora DESC";
            return Db.Database.Connection.Query<Alimento>(sql, new { uid = id });
        }
    }
}
