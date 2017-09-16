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

        public Guid ObterIdPeloIdentity(string idIdentity)
        {
            var sql = "SELECT * FROM Usuarios u " +
                      "WHERE u.IdentityId = @uid";

            var user = Db.Database.Connection.Query<Usuario>(sql, new { uid = idIdentity }).FirstOrDefault();
            return user.Id;
        }

        public Usuario ObterTudoDoUsuario(Guid id)
        {
            var user = Db.Database.Connection.Query<Usuario>(
                @"select top 1 u.Nome,
			                   u.Sobrenome,
			                   u.Nascimento,
			                   u.Altura
                    from Usuarios u
                    where u.Id = @UserId",
                new { UserId = id }).FirstOrDefault();

            var pesos = Db.Database.Connection.Query<Peso>(
                @"select top 5 peso.DataHora,
			                   peso.PesoValue
                    from Pesos peso
                    where peso.UsuarioId = @UserId
                    order by peso.DataHora desc",
                new { UserId = id }).DefaultIfEmpty();
            user.Pesos = pesos.ToList();

            var alimentos = Db.Database.Connection.Query<Alimento>(
                @"select top 5 alimento.DataHora,
			                   alimento.Tipo,
			                   alimento.Calorias
                    from Alimentos alimento
                    where alimento.UsuarioId = @UserId
                    order by alimento.DataHora desc",
                new { UserId = id }).DefaultIfEmpty();
            user.Alimentos = alimentos.ToList();

            var exercicios = Db.Database.Connection.Query<ExercicioFisico>(
                @"select top 5 exercicio.DataHora,
			                   exercicio.Tipo,
			                   exercicio.Calorias
                from ExerciciosFisicos exercicio
                where exercicio.UsuarioId  = @UserId
                order by exercicio.DataHora desc",
                new { UserId = id }).DefaultIfEmpty();
            user.ExerciciosFisicos = exercicios.ToList();

            var pressao = Db.Database.Connection.Query<PressaoArterial>(
                @"select top 5 pressao.DataHora,
			                   pressao.[Status],
			                   pressao.Sistolica,
			                   pressao.Diastolica
                from PressoesArteriais pressao
                where pressao.UsuarioId = @UserId
                order by pressao.DataHora desc",
                new { UserId = id }).DefaultIfEmpty();
            user.PressoesArteriais = pressao.ToList();

            return user;
        }

        public override void Remover(Guid id)
        {
            Usuario obj = ObterPorId(id);
            obj.Excluir();

            Atualizar(obj);
        }
    }
}