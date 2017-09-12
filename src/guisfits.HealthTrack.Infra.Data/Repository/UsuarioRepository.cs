using Dapper;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(HealthTrackContext context) : base(context) { }

        public override Usuario ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Usuarios u " +
                    "LEFT JOIN Pesos p ON u.Id = p.UsuarioId " +
                    "LEFT JOIN PressoesArteriais pr ON u.Id = pr.UsuarioId " +
                    "WHERE u.Id = @uid " +
                    "ORDER BY p.DataHora DESC";

            return Db.Database.Connection.Query<Usuario, Peso, PressaoArterial, Usuario>(sql,
                (u, p, pr) =>
                {
                    u.Pesos.Add(p);
                    u.PressoesArteriais.Add(pr);
                    return u;
                }, new { uid = id }).FirstOrDefault();
        }

        public Usuario ObterTudoDoUsuario(Guid id)
        {
            var sql = @"SELECT TOP 5 * " +
                      "FROM Usuarios u " +
                      "LEFT JOIN Pesos p ON p.UsuarioId = u.Id " +
                      "LEFT JOIN Alimentos a ON a.UsuarioId = u.id " +
                      "LEFT JOIN ExerciciosFisicos e ON e.UsuarioId = u.id " +
                      "LEFT JOIN PressoesArteriais pa ON pa.UsuarioId = u.id " +
                      "WHERE u.Id = @uid";

            return Db.Database.Connection.Query<Usuario, Peso, Alimento, ExercicioFisico, PressaoArterial, Usuario>(sql,
                (u, p, a, e, pr) =>
                {
                    u.Pesos.Add(p);
                    u.Alimentos.Add(a);
                    u.ExerciciosFisicos.Add(e);
                    u.PressoesArteriais.Add(pr);
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
                    u.Pesos.Add(p);
                    return u;
                });
        }

        public override void Remover(Guid id)
        {
            Usuario obj = ObterPorId(id);
            obj.Excluir();

            Atualizar(obj);
        }

        public Guid ObterIdPeloIdentity(string idIdentity)
        {
            var sql = "SELECT * FROM Usuarios u " +
                      "WHERE u.IdentityId = @uid";

            var user = Db.Database.Connection.Query<Usuario>(sql, new { uid = idIdentity }).FirstOrDefault();
            return user.Id;
        }
    }
}
