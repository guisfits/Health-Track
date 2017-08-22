using guisfits.HealthTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public override Usuario ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Usuarios u " +
                      "LEFT JOIN Pesos p " +
                      "ON u.Id = p.UsuarioId " +
                      "WHERE u.Id = @uid";

            return Db.Database.Connection.Query<Usuario, Peso, Usuario>(sql,
                (u, p) =>
                {
                    u.PesosKg.Add(p);
                    return u;
                }, new { uid = id }).FirstOrDefault();
        }

        public override IEnumerable<Usuario> ObterTodos()
        {
            var sql = @"SELECT * FROM Usuarios u " +
                        "LEFT JOIN Pesos p " +
                        "ON p.UsuarioId = u.Id";

            return Db.Database.Connection.Query<Usuario, Peso, Usuario>(sql, 
                (u, p) => 
                {
                    u.PesosKg.Add(p);
                    return u;
                });
        }
    }
}
