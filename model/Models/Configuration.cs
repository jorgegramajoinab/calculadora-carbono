using model.Models.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Models
{
    [Table("Configurations")]
    public class Configuration
    {
        [Key]
        public string Id { get; set; }

        public string Value { get; set; }

        public Types Type { get; set; }

        public Categories Category { get; set; }
    }
}
