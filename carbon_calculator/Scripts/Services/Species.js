function SpeciesService() {
    var utilities = new Utilities();
    const urls = {
        simpleNames: '/api/Species/all',
        byId: '/api/Species?id={speciesId}'
    }

    this.getAll =
        () => utilities.apiGet(urls.simpleNames).then();

    this.getById =
        id => utilities.apiGet(urls.byId.replace('{speciesId}', id + ""));
}
