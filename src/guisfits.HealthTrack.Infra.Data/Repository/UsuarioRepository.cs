using guisfits.HealthTrack.Domain.Models;
using System;

namespace guisfits.HealthTrack.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>
    {
        public override void Remover(Guid id)
        {
            Usuario usuario = ObterPorId(id);
            usuario.Excluir();
            Atualizar(usuario);
        }
    }
}
