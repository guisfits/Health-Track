using Dapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class ExercicioFisicoRepository : Repository<ExercicioFisico>, IExercicioFisicoRepository
    {
        public ExercicioFisicoRepository(HealthTrackContext context) : base(context)
        {

        }

        public IEnumerable<ExercicioFisico> ObterTodosPorUsuario(Guid id)
        {
            var sql = "SELECT * FROM ExerciciosFisicos a WHERE a.UsuarioId = @uid ORDER BY a.DataHora DESC";
            return Db.Database.Connection.Query<ExercicioFisico>(sql, new { uid = id });
        }
    }
}
