using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using model;
using model.Models;

namespace carbon_calculator.Controllers
{
    [RoutePrefix("api/Species")]
    public class SpeciesApiController : ApiController
    {
        CarbonCalculatorModel context = new CarbonCalculatorModel();

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            context.Configuration.LazyLoadingEnabled = false;

            var species =
                await context.Species
                    .ToListAsync();

            if (!species.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Actualmente no hay ninguna especie");
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { Content = context.Species.ToListAsync() });
        }

        [HttpGet]
        [Route("all")]
        public async Task<HttpResponseMessage> GetAll()
        {
            this.context.Configuration.LazyLoadingEnabled = false;

            var species =
                await context.Species
                    .Include(dbSpecies => dbSpecies.GroundIndexes)
                    .Include(dbSpecies => dbSpecies.GroundIndexes.Select(specieGI => specieGI.GroundIndex))
                    .Include(dbSpecies => dbSpecies.MathExpressions)
                    .ToListAsync();

            if (!species.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Actualmente no hay ninguna especie");
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { Content = species });
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> byId(int id)
        {
            return await by(species => species.Id == id);
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> byName(string name)
        {
            name = name.ToLower().Trim();

            return await by(
                species =>
                species.simpleName
                    .ToLower()
                    .Trim()
                    .Equals(name)
            );
        }

        protected async Task<HttpResponseMessage> by(Expression<Func<Species, bool>> expression)
        {
            this.context.Configuration.LazyLoadingEnabled = false;
            this.context.Configuration.ProxyCreationEnabled = false;

            var specie =
               await context.Species
                   .Include(dbSpecie => dbSpecie.GroundIndexes)
                   .Include(dbSpecie => dbSpecie.GroundIndexes.Select(especieGroundIndex => especieGroundIndex.GroundIndex))
                   .Include(dbSpecie => dbSpecie.MathExpressions)
                   .FirstOrDefaultAsync(expression);

            if (specie == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Especie no encontrada.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { Content = specie });
        }
    }
}