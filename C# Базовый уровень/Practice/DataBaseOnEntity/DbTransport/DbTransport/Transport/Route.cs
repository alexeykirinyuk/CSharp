using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataBaseTransport
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        public string Begin { get; set; }
        
        public string End { get; set; }

        [ForeignKey("Transport")]
        public int TransportId { get; set; }

        public Transport Transport { get; set; }

        public Route() { }

        public Route(string begin, string end)
        {
            Begin = begin;
            End = end;
        }
    }
}
