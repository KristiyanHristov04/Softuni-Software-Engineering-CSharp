function solve(input){
    let studentName = input[0];
    let gradesSum = 0;
    let currentGrade = 0;
    let numberOfFails = 0;
    let index = 1;

    while(true){
        let gradeForThisYear = Number(input[index]);

        if(gradeForThisYear >= 4){
            currentGrade++;
            gradesSum += gradeForThisYear;
        }
        else{
            numberOfFails++;
            if(numberOfFails == 2){
                console.log(`${studentName} has been excluded at ${currentGrade} grade`);
                break;
            }
            currentGrade++;  
        }

        if(currentGrade == 12){
            let averageGrade = gradesSum / 12;
            console.log(`${studentName} graduated. Average grade: ${averageGrade.toFixed(2)}`);
            break;
        }

        index++;
    }
}

// solve(['Gosho','5','5.5','6','5.43','5.5','6','5.55','5','6','6','5.43','5']);
// solve(['Mimi','5','6','5','6','5','6','6','2','3']);