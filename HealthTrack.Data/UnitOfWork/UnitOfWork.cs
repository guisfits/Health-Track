using Core.Interfaces.Repository;
using HealthTrack.Data.Context;
using HealthTrack.Data.Repository;
using HealthTrack.Domain.Interfaces;
using HealthTrack.Domain.Interfaces.Repository;

namespace HealthTrack.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthTrackContext _context;
        public IUsuarioRepository UsuarioRepository { get; }
        public IAlimentoRepository AlimentoRepository { get; }
        public IExercicioFisicoRepository ExercicioFisicoRepository { get; }
        public IPesoRepository PesoRepository { get; }
        public IPressaoArterialRepository PressaoArterialRepository { get; }

        public UnitOfWork(HealthTrackContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
            AlimentoRepository = new AlimentoRepository(_context);
            ExercicioFisicoRepository = new ExercicioFisicoRepository(_context);
            PesoRepository = new PesoRepository(_context);
            PressaoArterialRepository = new PressaoArterialRepository(_context);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}