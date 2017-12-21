using System;

namespace HealthTrack.Domain.Models
{
    public class Log
    {
        public string Id { get; set; }
        public string IdentityId { get; set; }
        public DateTime Data { get; set; }
        public string Mensagem { get; set; }
        public string Ip { get; set; }
    }
}