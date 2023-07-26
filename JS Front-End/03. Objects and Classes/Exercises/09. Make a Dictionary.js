function solve(input) {
    let dictionary = {};

    for (let index = 0; index < input.length; index++) {
        let currentObjectAsJSON = JSON.parse(input[index]);
        let array = Object.entries(currentObjectAsJSON);
        dictionary[array[0][0]] = array[0][1];
    }

    let sortedDictionary = Object.entries(dictionary)
                            .sort((a, b) => a[0].localeCompare(b[0]));

    for (let index = 0; index < sortedDictionary.length; index++) {
        let term = sortedDictionary[index][0];
        let definition = sortedDictionary[index][1];
        console.log(`Term: ${term} => Definition: ${definition}`);
    }
}

solve(['{"Cup":"A small bowl-shaped container for drinking from, typically having a handle"}', '{"Cake":"An item of soft sweet food made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated."} ', '{"Watermelon":"The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice."} ', '{"Music":"Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion."} ', '{"Art":"The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power."}']);