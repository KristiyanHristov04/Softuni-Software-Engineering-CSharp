function solve(input) {
    let courses = {};
    for (let index = 0; index < input.length; index++) {
        let line = input[index].split(': ');
        if (line.length == 2) {
            let courseName = line[0];
            let courseCapacity = Number(line[1]);
            if (courses.hasOwnProperty(courseName)) {
                courses[courseName].capacity += courseCapacity;
            } else {
                let courseInfoObj = { capacity: courseCapacity, students: [] };
                courses[courseName] = courseInfoObj;
            }
        } else {
            line = input[index].split(' ');
            let userNameAndCredits = line[0];
            let bracketIndex = userNameAndCredits.indexOf('[');

            let user = userNameAndCredits.substring(0, bracketIndex);
            let userCredits = Number(userNameAndCredits.substring(bracketIndex + 1, userNameAndCredits.length - 1));
            let userEmail = line[3];
            let course = line[5];
            let studentInfoObj = { username: user, email: userEmail, credits: userCredits };

            if (courses.hasOwnProperty(course) && courses[course].capacity > 0) {
                courses[course].capacity--;
                courses[course].students.push(studentInfoObj);
            }
        }
    }

    let coursesEntries = Object.entries(courses);
    let sortedCourses = coursesEntries.sort((a, b) => b[1].students.length - a[1].students.length);

    for (let i = 0; i < coursesEntries.length; i++) {
        console.log(`${coursesEntries[i][0]}: ${coursesEntries[i][1].capacity} places left`);
        let studentsForThisCourse = coursesEntries[i][1].students;
        let sortStudentsByCredits = studentsForThisCourse.sort((a , b) => b.credits - a.credits);
        for (const iterator of sortStudentsByCredits) {
            console.log(`--- ${iterator.credits}: ${iterator.username}, ${iterator.email}`);
        }
    }
}

solve(['JavaBasics: 2',
    'user1[25] with email user1@user.com joins C#Basics',
    'C#Advanced: 3',
    'JSCore: 4',
    'user2[30] with email user2@user.com joins C#Basics',
    'user13[50] with email user13@user.com joins JSCore',
    'user1[25] with email user1@user.com joins JSCore',
    'user8[18] with email user8@user.com joins C#Advanced',
    'user6[85] with email user6@user.com joins JSCore',
    'JSCore: 2',
    'user11[3] with email user11@user.com joins JavaBasics',
    'user45[105] with email user45@user.com joins JSCore',
    'user007[20] with email user007@user.com joins JSCore',
    'user700[29] with email user700@user.com joins JSCore',
    'user900[88] with email user900@user.com joins JSCore']
);