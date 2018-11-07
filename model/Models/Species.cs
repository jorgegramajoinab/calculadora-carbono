using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Models
{
    [Table("Species")]
    public class Species
    {
        public Species()
        {
            this.Coefficients = new HashSet<Coefficient>();
            this.GroundIndexes = new HashSet<SpeciesGroundIndex>();
        }

        [Key]
        public int Id { get; set; }

        public string code { get; set; }

        public string commonName { get; set; }

        public string scientificName { get; set; }

        public double shapeCoefficient { get; set; }

        public int limitYear { get; set; }

        public double dryMaterial { get; set; }

        [InverseProperty(nameof(SpeciesGroundIndex.Species))]
        public virtual ICollection<SpeciesGroundIndex> GroundIndexes { get; set; }

        [InverseProperty(nameof(Coefficient.Species))]
        public virtual ICollection<Coefficient> Coefficients { get; set; }
    }
}
