function solve(area, vol, input) {
    let result = [];
    let data = JSON.parse(input);
    for (let index = 0; index < data.length; index++) {
        let currentObject = data[index];
        let areaResult = area.call(currentObject);
        let volumeResult = vol.call(currentObject);
        let newObject = {
            area: areaResult,
            volume: volumeResult
        };
        result.push(newObject);
    }
    return result;
}

function area() {
    return Math.abs(this.x * this.y);
};


function vol() {
    return Math.abs(this.x * this.y * this.z);
};

solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
);
