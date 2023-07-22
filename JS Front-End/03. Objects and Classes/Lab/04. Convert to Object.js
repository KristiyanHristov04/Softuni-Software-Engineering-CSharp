function convertJSONtoObject(text) {
    let personObj = JSON.parse(text);
    for (const key in personObj) {
        console.log(`${key}: ${personObj[key]}`);
    }
}

convertJSONtoObject('{"name": "George", "age": 40, "town": "Sofia"}');