using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Models
{
    [Table("MathEspressions")]
    public class MathExpression
    {
        public MathExpression()
        {

        }

        public MathExpression(string name, string expression)
        {
            this.Name = name;
            this.Expression = expression;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Species))]
        public int SpeciesId { get; set; }

        public string Name { get; set; }

        public string Expression { get; set; }

        [InverseProperty(nameof(Models.Species.MathExpressions))]
        public Species Species { get; set; }
    }
}