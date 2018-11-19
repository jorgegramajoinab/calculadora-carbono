function SpeciesFactory() {
    let species = new SpeciesService();
    let utilities = new Utilities();


    this.currentSpecies = null;

    this.getSimpleNamesToDropdown =
        () => 
            species.getSimpleNames().then(data => {
                var result = [];
                data.Content.forEach(specie =>
                    result.push({ id: specie.Id, text: specie.simpleName })
                );

                if (utilities.elementsInArray(result)) {
                    return this.getById(result[0].id)
                        .then(data => this.currentSpecies = data)
                        .then(() => result);
                } else {
                    return result;
                }
            });

    this.getById =
        id => species.getById(id).then(result => {
            var specie = result.Content;
            specie.GroundIndexes.forEach(specieGroundIndex => 
                specieGroundIndex.text =
                    specieGroundIndex.GroundIndex.name + '(' +
                    specieGroundIndex.value + 'm)'
            );

            if (utilities.elementsInArray(specie.GroundIndexes)) {
                specie.currentSpeciesGroundIndex = specie.GroundIndexes[0];
            }

            return specie;
        });
}