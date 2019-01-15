using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Models
{
    [Table("GroundIndexes")]
    public class GroundIndex
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public double defaultValue { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(SpeciesGroundIndex.GroundIndex))]
        public ICollection<SpeciesGroundIndex> Species { get; set; }
    }
}
