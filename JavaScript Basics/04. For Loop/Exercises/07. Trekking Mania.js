function solve(input){
    let groupsCount = Number(input[0]);

    let totalPeopleCount = 0;
    let peopleForMusala = 0;
    let peopleForMonblan = 0;
    let peopleForKilimandjaro = 0;
    let peopleForK2 = 0;
    let peopleForEverest = 0;

    for(let i = 1; i < input.length; i++){
        let currentGroupPeopleCount = Number(input[i]);
        if(currentGroupPeopleCount <= 5){
            totalPeopleCount += currentGroupPeopleCount;
            peopleForMusala += currentGroupPeopleCount;
        }
        else if(currentGroupPeopleCount >= 6 && currentGroupPeopleCount < 13){
            totalPeopleCount += currentGroupPeopleCount;
            peopleForMonblan += currentGroupPeopleCount;
        }
        else if(currentGroupPeopleCount >= 13 && currentGroupPeopleCount < 26){
            totalPeopleCount += currentGroupPeopleCount;
            peopleForKilimandjaro += currentGroupPeopleCount;
        }
        else if(currentGroupPeopleCount >= 26 && currentGroupPeopleCount < 41){
            totalPeopleCount += currentGroupPeopleCount;
            peopleForK2 += currentGroupPeopleCount;
        }
        else{
            totalPeopleCount += currentGroupPeopleCount;
            peopleForEverest += currentGroupPeopleCount;
        }
    }

    let totalCountClimbersForMusala = peopleForMusala / totalPeopleCount * 100;
    let totalCountClimbersForMonblan = peopleForMonblan / totalPeopleCount * 100;
    let totalCountClimbersForKilimandjaro = peopleForKilimandjaro / totalPeopleCount * 100;
    let totalCountClimbersForK2 = peopleForK2 / totalPeopleCount * 100;
    let totalCountClimbersForEverest = peopleForEverest / totalPeopleCount * 100;

    console.log(`${totalCountClimbersForMusala.toFixed(2)}%`);
    console.log(`${totalCountClimbersForMonblan.toFixed(2)}%`);
    console.log(`${totalCountClimbersForKilimandjaro.toFixed(2)}%`);
    console.log(`${totalCountClimbersForK2.toFixed(2)}%`);
    console.log(`${totalCountClimbersForEverest.toFixed(2)}%`);
}

// solve(['10','10','5','1','100','12','26','17','37','40','78']);