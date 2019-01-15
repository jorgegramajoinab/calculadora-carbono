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
            this.GroundIndexes = new HashSet<SpeciesGroundIndex>();
            this.MathExpressions = new HashSet<MathExpression>();
        }

        [Key]
        public int Id { get; set; }

        public string code { get; set; }

        public string simpleName { get; set; }

        public string commonName { get; set; }

        public string scientificName { get; set; }

        public double shapeCoefficient { get; set; }

        public int limitYear { get; set; }

        public double dryMaterial { get; set; }

        [InverseProperty(nameof(SpeciesGroundIndex.Species))]
        public virtual ICollection<SpeciesGroundIndex> GroundIndexes { get; set; }

        [InverseProperty(nameof(MathExpression.Species))]
        public virtual ICollection<MathExpression> MathExpressions { get; set; }

        [NotMapped]
        public string[] StringGroundIndexes
        {
            get
            {
                if (this.GroundIndexes is null)
                {
                    return new string[] { "" };
                }
                if (!this.GroundIndexes.Any())
                {
                    return new string[] { "" };
                }

                var stringsGroundIndes =
                    this.GroundIndexes
                        .Select(groundIndexes => groundIndexes.ToString())
                        .ToArray();

                return stringsGroundIndes;
            }
        }
    }
}
