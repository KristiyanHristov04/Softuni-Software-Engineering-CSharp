function solve(input) {
    let grades = {};
    for (let index = 0; index < input.length; index++) {
        let line = input[index].split(',');
        let studentName = line[0].split(': ')[1];
        let studentGrade = Number(line[1].split(': ')[1]);
        let studentAverageGrade = Number(line[2].split(': ')[1]);
        
        if (studentAverageGrade >= 3) {
            if (grades.hasOwnProperty(studentGrade + 1)) {
                grades[studentGrade + 1].listOfStudents.push(studentName);
                grades[studentGrade + 1].studentsGrades.push(studentAverageGrade);
            } else {
                grades[studentGrade + 1] = { listOfStudents: [studentName], studentsGrades: [studentAverageGrade]};
            }
            
        }
    }

    let keys = Object.keys(grades);
    for (let index = 0; index < keys.length; index++) {
        let currentGrade = Number(keys[index]);
        console.log(`${currentGrade} Grade`);
        console.log(`List of students: ${grades[currentGrade].listOfStudents.join(', ')}`);
        let averageScoreLastYear = 0;
        for (let j = 0; j < grades[currentGrade].studentsGrades.length; j++) {
            averageScoreLastYear += grades[currentGrade].studentsGrades[j];
        }
        averageScoreLastYear = averageScoreLastYear / grades[currentGrade].studentsGrades.length;
        console.log(`Average annual score from last year: ${averageScoreLastYear.toFixed(2)}` + '\n');
    }
}

solve([
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
    "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
    "Student name: George, Grade: 8, Graduated with an average score: 2.83",
    "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
    "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
    "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
    "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
    "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
    "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
    "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
    "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
    "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00" 
]);