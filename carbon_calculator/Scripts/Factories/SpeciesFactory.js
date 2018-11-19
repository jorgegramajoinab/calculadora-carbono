function SpeciesFactory() {
    var species = new SpeciesService();

    this.getSimpleNamesToDropdown =
        () => 
            species.getSimpleNames()
                .then(data => {
                    var result = [];
                    data.Content
                        .forEach(specie => result.push({ id: specie.Id, text: specie.simpleName }));
                    return result;
                });
}