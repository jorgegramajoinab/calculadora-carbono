function SpeciesGroundIndexesFactory() {
    var speciesGroundIndexes = new SpeciesGroundIndexesService();

    this.getBySpecieId =
        specieId => {
            speciesGroundIndexes.getBySpecieId(specieId)
                .then(data => {
                    let result = [];

                    data.Content.forEach(
                        specieGroundIndex =>
                            result.push({
                                id: specieGroundIndex.GroundIndex.name,
                                text: specieGroundIndex.value
                            })
                    );
                    return result;
                });
        }
}