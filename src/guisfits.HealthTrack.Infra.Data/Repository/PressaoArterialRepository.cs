using System;
using System.Collections.Generic;
using Dapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class PressaoArterialRepository : Repository<PressaoArterial>, IPressaoArterialRepository
    {
        public PressaoArterialRepository(HealthTrackContext context) : base(context)
        {
        }

        public IEnumerable<PressaoArterial> ObterTodosPorUsuario(Guid id)
        {
            var sql = "SELECT * FROM PressoesArteriais a WHERE a.UsuarioId = @uid";
            return Db.Database.Connection.Query<PressaoArterial>(sql, new { uid = id });
        }
    }
}
