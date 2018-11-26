function SpeciesFactory() {
    let species = new SpeciesService();
    let utilities = new Utilities();


    this.currentSpecies = null;
    this.savedSpecies = null;


    const setDefaultSiteIndex =
        specie => {
            if (utilities.elementsInArray(specie.GroundIndexes)) {
                specie.currentSpeciesGroundIndex = specie.GroundIndexes[0];
            } else {
                return;
            }

            specie.GroundIndexes.forEach(specieGroundIndex =>
                specieGroundIndex.text =
                specieGroundIndex.GroundIndex.name + '(' +
                specieGroundIndex.value + 'm)'
            );
        }

    this.getSimpleNamesToDropdown =
        () => 
            species.getAll().then(data => {
                var result = [];

                if (this.savedSpecies === null) {
                    this.savedSpecies = data.Content;
                }

                this.currentSpecies = this.savedSpecies[0];


                this.savedSpecies.forEach(specie => {
                    setDefaultSiteIndex(specie);
                    result.push({ id: specie.Id, text: specie.simpleName });
                });

                return result;
            });

    this.getById =
        async id => {
            if (this.savedSpecies != null) {
                let specie = this.savedSpecies.find(dbSpecie => dbSpecie.Id == id);

                if (specie != null) {
                    return specie;
                }
            }

            await species.getById(id).then(result => {
                let specie = result.Content;
                setDefaultSiteIndex(specie);
                return specie;
            })
        };
}