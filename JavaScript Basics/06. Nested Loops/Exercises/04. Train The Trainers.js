function solve(input){
    let judgeCount = Number(input[0]);
    let index = 1;
    let totalPresentationSumGrade = 0;
    let totalGrades = 0;
    while(true){       
        let currentPresentationGrade = 0;
        let presentation = input[index];
        if(presentation == 'Finish'){
            console.log(`Student's final assessment is ${(totalPresentationSumGrade / totalGrades).toFixed(2)}.`);
            return;
        }
        let judgeGradesCount = 0;
        index++;
        for(let i = index; i < input.length; i++){
            let currentGrade = Number(input[i]);
            totalPresentationSumGrade += currentGrade;
            currentPresentationGrade += currentGrade;
            totalGrades++;
            judgeGradesCount++;
            if(judgeGradesCount == judgeCount){
                console.log(`${presentation} - ${(currentPresentationGrade / judgeCount).toFixed(2)}.`);
                currentPresentationGrade = 0;
                judgeGradesCount = 0;
                index += judgeCount;
                break;
            }
        }
    }
}

// solve(['2',
// 'While-Loop',
// '6.00',
// '5.50',
// 'For-Loop',
// '5.84',
// '5.66',
// 'Finish']);
