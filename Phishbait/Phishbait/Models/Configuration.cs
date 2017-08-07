using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phishbait
{
    public partial class Configuration
    {
        public Configuration()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UID { get; set; }

        public string Parameter { get; set; }

        public string Value { get; set; }
    }

}
