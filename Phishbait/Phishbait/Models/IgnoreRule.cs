using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phishbait
{
    public enum IgnoreType
    {
        FrequentItem
    }

    public partial class IgnoreRule
    {
        public IgnoreRule()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UID { get; set; }

        public string Term { get; set; }

        public IgnoreType Type { get; set; }
    }

}
