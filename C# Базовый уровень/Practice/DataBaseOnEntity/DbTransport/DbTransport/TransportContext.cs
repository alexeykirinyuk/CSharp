using System.Data.Entity;

namespace DataBaseTransport
{
    public class TransportContext : DbContext
    {
        public TransportContext() : base("DbTransportV3") { }

        static TransportContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TransportContext>());
        }

        public DbSet<Transport> Transports { get; set; }
    }
}
