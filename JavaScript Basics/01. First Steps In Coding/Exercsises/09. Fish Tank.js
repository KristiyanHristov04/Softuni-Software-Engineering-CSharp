function solve(input){
    let length = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);
    let percent = Number(input[3]);

    let totalVolume = length * width * height;
    let totalVolumeInLiters = totalVolume / 1000;

    let neededVolume = totalVolumeInLiters * (1 - percent / 100);
    console.log(neededVolume);
}

solve(["85", "75", "47", "17"]);