function solve(input) {
    let maxBadGrades = Number(input[0]);
    let lastTaskName = '';
    let gradesSum = 0;
    let numberOfTasks = 0;
    let numberOfBadGrades = 0;
    let index = 1;
    while (true) {
        if (index % 2 != 0) {
            let currentInput = input[index];
            if (currentInput == 'Enough') {
                let averageScore = gradesSum / numberOfTasks;
                console.log(`Average score: ${averageScore.toFixed(2)}`);
                console.log(`Number of problems: ${numberOfTasks}`);
                console.log(`Last problem: ${lastTaskName}`);
                return;
            }
            lastTaskName = currentInput;
            numberOfTasks++;
            index++;
            continue;
        }
        else {
            let currentGrade = Number(input[index]);
            if (currentGrade <= 4) {
                numberOfBadGrades++;
                if (numberOfBadGrades >= maxBadGrades) {
                    console.log(`You need a break, ${numberOfBadGrades} poor grades.`);
                    return;
                }
            }
            gradesSum += currentGrade;
            index++;
        }
    }
}

// solve(['3', 'Money', '6', 'Story', '4', 'Spring Time', '5', 'Bus', '6', 'Enough']);
// solve(['2','Income','3','Game Info','6','Best Player','4']);