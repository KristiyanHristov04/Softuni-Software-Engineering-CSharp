function convertObjectToJSON(firstName, lastName, hairColor) {
    let personObj = { name: firstName, lastName, hairColor };
    let personObjAsJSON = JSON.stringify(personObj);
    console.log(personObjAsJSON);
}

convertObjectToJSON('George', 'Jones', 'Brown' );