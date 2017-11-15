using System;
using HealthTrack.Data.Context;
using HealthTrack.Domain.Models;

namespace HealthTrack.Data.Repository
{
    public class LogRepository
    {
        private readonly HealthTrackContext _context;

        public LogRepository(HealthTrackContext context)
        {
            _context = context;
        }

        public void RegistrarLog(Log log)
        {
            log.Id = Guid.NewGuid().ToString();
            _context.Log.Add(log);
            _context.SaveChanges();
        }
    }
}
