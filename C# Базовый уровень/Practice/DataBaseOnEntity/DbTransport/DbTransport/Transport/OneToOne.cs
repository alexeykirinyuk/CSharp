using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseTransport
{
    public class OneToOne
    {
        [Key, ForeignKey("Transport")]
        public int OneId { get; set; }

        public virtual Transport Transport { get; set; }

        public override bool Equals(object obj)
        {
            var one = obj as OneToOne;
            if (one == null) return false;
            
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
