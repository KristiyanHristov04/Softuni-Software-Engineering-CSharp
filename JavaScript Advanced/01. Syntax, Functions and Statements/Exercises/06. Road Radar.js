function solve(speed, area){
    let driverSpeed = Number(speed);
    let overTheLimitStatus = function(limit){
        if(limit <= 20){
            return 'speeding';
        }
        else if(limit > 20 && limit <= 40){
            return 'excessive speeding';
        }
        else{
            return 'reckless driving';
        }
    }

    if(area === 'motorway' && driverSpeed <= 130){
        console.log(`Driving ${driverSpeed} km/h in a 130 zone`);
    }
    else if(area === 'motorway' && driverSpeed > 130){
        let overTheLimit = driverSpeed - 130;
        console.log(`The speed is ${overTheLimit} km/h faster than the allowed speed of 130 - ${overTheLimitStatus(overTheLimit)}`);
    }
    else if(area === 'interstate' && driverSpeed <= 90){
        console.log(`Driving ${driverSpeed} km/h in a 90 zone`);
    }
    else if(area === 'interstate' && driverSpeed > 90){
        let overTheLimit = driverSpeed - 90;
        console.log(`The speed is ${overTheLimit} km/h faster than the allowed speed of 90 - ${overTheLimitStatus(overTheLimit)}`);
    }
    else if(area === 'city' && driverSpeed <= 50){
        console.log(`Driving ${driverSpeed} km/h in a 50 zone`);
    }
    else if(area === 'city' && driverSpeed > 50){
        let overTheLimit = driverSpeed - 50;
        console.log(`The speed is ${overTheLimit} km/h faster than the allowed speed of 50 - ${overTheLimitStatus(overTheLimit)}`);
    }
    else if(area === 'residential' && driverSpeed <= 20){
        console.log(`Driving ${driverSpeed} km/h in a 20 zone`);
    }
    else if(area === 'residential' && driverSpeed > 20){
        let overTheLimit = driverSpeed - 20;
        console.log(`The speed is ${overTheLimit} km/h faster than the allowed speed of 20 - ${overTheLimitStatus(overTheLimit)}`);
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');