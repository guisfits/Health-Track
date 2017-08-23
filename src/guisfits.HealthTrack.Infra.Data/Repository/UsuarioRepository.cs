using guisfits.HealthTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                      "WHERE u.Id = @uid AND u.Excluido = 0";

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
                        "ON p.UsuarioId = u.Id " +
                        "WHERE u.Excluido = 0";

            return Db.Database.Connection.Query<Usuario, Peso, Usuario>(sql, 
                (u, p) => 
                {
                    u.PesosKg.Add(p);
                    return u;
                });
        }

        public override void Remover(Guid id)
        {
            Usuario obj = ObterPorId(id);
            Db.Usuarios.Attach(obj);
            Db.Entry(obj).State = EntityState.Deleted;
            DbSet.Remove(obj);
            SaveChanges();
        }
    }
}
