using model;
using model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SpeciesRepository : ARepository<Species, int>
    {
        public SpeciesRepository(CarbonCalculatorModel context)
            : base(context.Species) { }

        public SpeciesRepository()
            : base(new CarbonCalculatorModel().Species) { }

        public override bool Exist(int Id)
        {
            return
                this.Set
                    .Any(species => species.Id == Id);
        }

        public bool ExistName(string name)
        {
            return 
                this.Exist(
                    species =>
                    species.scientificName.Equals(name) ||
                    species.commonName.Equals(name) ||
                    species.code.Equals(name)
                );
        }

        public override Species GetById(int Id)
        {
            return
                this.Set
                    .FirstOrDefault(entity => entity.Id == Id);
        }

        public Species GetByName(string name)
        {
            return
                this.GetFirst(
                    species =>
                    species.scientificName.Equals(name) ||
                    species.commonName.Equals(name) ||
                    species.code.Equals(name)
                );
        }

        public List<Species> ApproximateName(string name)
        {
            return
                this.Where(
                        species =>
                        species.scientificName.Equals(name) ||
                        species.commonName.Equals(name) ||
                        species.code.Equals(name))
                    .ToList();
        }
    }
}
