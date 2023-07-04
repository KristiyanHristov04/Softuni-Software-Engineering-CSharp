function solve(currentSpeed, area) {
    let overSpeed = 0;
    switch (area) {
        case 'motorway':
            if(currentSpeed <= 130){
                console.log(`Driving ${currentSpeed} km/h in a 130 zone`);
                return;
            }
            overSpeed = currentSpeed - 130;
            if(overSpeed <= 20){
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 130 - speeding`);
            } else if(overSpeed <= 40){
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 130 - excessive speeding`);
            } else {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 130 - reckless driving`);
            }
            break;
        case 'interstate':
            if(currentSpeed <= 90){
                console.log(`Driving ${currentSpeed} km/h in a 90 zone`);
                return;
            }
            overSpeed = currentSpeed - 90;
            if(overSpeed <= 20){
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 90 - speeding`);
            } else if(overSpeed <= 40){
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 90 - excessive speeding`);
            } else {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 90 - reckless driving`);
            }
            break;
        case 'city':
            if(currentSpeed <= 50){
                console.log(`Driving ${currentSpeed} km/h in a 50 zone`);
                return;
            }
            overSpeed = currentSpeed - 50;
            if(overSpeed <= 20){
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 50 - speeding`);
            } else if(overSpeed <= 40){
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 50 - excessive speeding`);
            } else {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 50 - reckless driving`);
            }
            break;
        case 'residential':
            if(currentSpeed <= 20){
                console.log(`Driving ${currentSpeed} km/h in a 20 zone`);
                return;
            }
            overSpeed = currentSpeed - 20;
            if(overSpeed <= 20){
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 20 - speeding`);
            } else if(overSpeed <= 40){
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 20 - excessive speeding`);
            } else {
                console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of 20 - reckless driving`);
            }
            break;
    }
}

solve(21, 'residential');