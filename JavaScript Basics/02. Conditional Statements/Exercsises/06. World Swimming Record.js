function solve(input) {
    let swimmingRecord = Number(input[0]);
    let distanceInMeters = Number(input[1]);
    let swimDistanceInSeconds = Number(input[2]);

    let totalSecondsToSwim = distanceInMeters * swimDistanceInSeconds;
    waterDelay = Math.floor((distanceInMeters / 15)) * 12.5;
    let totalNeededSeconds = totalSecondsToSwim + waterDelay;

    if (totalNeededSeconds < swimmingRecord) {
        console.log(`Yes, he succeeded! The new world record is ${totalNeededSeconds.toFixed(2)} seconds.`);
    }
    else {
        console.log(`No, he failed! He was ${(totalNeededSeconds - swimmingRecord).toFixed(2)} seconds slower.`);
    }
}

//solve(['10464', '1500', '20'])
solve(['55555.67', '3017', '5.03'])