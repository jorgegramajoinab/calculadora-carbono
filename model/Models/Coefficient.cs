using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.Models
{
    [Table("Coefficients")]
    public class Coefficient
    {
        public Coefficient(string height, double value)
        {
            this.type = height;
            this.value = value;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Species))]
        public int speciesId { get; set; }

        public string type { get; set; }

        public double value { get; set; }

        [InverseProperty(nameof(Models.Species.Coefficients))]
        public Species Species { get; set; }

        #region Types
        public const string Height = "height";
        public const string DAP = "dap";
        public const string Area = "area";
        public const string Volume = "volumen";
        #endregion
    }
}
