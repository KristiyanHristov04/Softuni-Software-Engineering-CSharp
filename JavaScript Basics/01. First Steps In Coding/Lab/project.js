function project(input){
    let architectName = input[0];
    let numberOfProjects = Number(input[1]);
    let totalHours = numberOfProjects * 3;
    console.log(`The architect ${architectName} will need ${totalHours} hours to complete ${numberOfProjects} project/s.`);
}

project(['George', 4])