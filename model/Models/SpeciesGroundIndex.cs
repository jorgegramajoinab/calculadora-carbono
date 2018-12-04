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
    [Table("SpeciesGroundIndexes")]
    public class SpeciesGroundIndex
    {
        public SpeciesGroundIndex(int groundIndexId, double value )
        {
            this.groundIndexId = groundIndexId;
            this.value = value;
        }

        public SpeciesGroundIndex(GroundIndex groundIndex, double value)
        {
            this.GroundIndex = groundIndex;
            this.value = value;
        }

        public SpeciesGroundIndex()
        {

        }

        [Key]
        public int id { get; set; }

        [ForeignKey(nameof(Species))]
        public int specieId { get; set; }

        [ForeignKey(nameof(GroundIndex))]
        public int groundIndexId { get; set; }

        public double value { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Models.Species.GroundIndexes))]
        public Species Species { get; set; }

        [InverseProperty(nameof(Models.GroundIndex.Species))]
        public GroundIndex GroundIndex { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}m)", this.GroundIndex is null ? "" : this.GroundIndex.name, this.value);
        }
    }
}
