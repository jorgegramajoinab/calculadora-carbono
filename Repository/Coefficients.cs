using model;
using model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class Coefficients : ARepository<Coefficient, int>
    {
        public Coefficients()
            : base(new CarbonCalculatorModel().Coefficients) { }

        public Coefficients(CarbonCalculatorModel context)
            : base(context.Coefficients) { }

        public override bool Exist(int Id)
        {
            return
                this.Set
                    .Any(species => species.Id == Id);
        }

        public override Coefficient GetById(int Id)
        {
            return
                this.Set
                    .FirstOrDefault(entity => entity.Id == Id);
        }

        public List<Coefficient> GetBySpecie(int specieId)
        {
            return
                this.Where(entity => entity.speciesId == specieId)
                    .ToList();
        }

        public List<Coefficient> GetByType(int specieId, string type)
        {
            return
                this.Where(
                        entity => 
                        entity.speciesId == specieId &&
                        entity.type.Equals(type))
                    .ToList();
        }
    }
}
