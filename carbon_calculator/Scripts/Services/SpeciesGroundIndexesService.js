function SpeciesGroundIndexesService() {
    var utilities = new Utilities();
    const urls = {
        getBySpecie: '/SpeciesGroundIndexes/bySpecie?specieId={speciesId}',
    }

    this.getBySpecieId =
        specieId => utilities.apiGet(urls.getBySpecie.replace('{speciesId}', specieId));
}