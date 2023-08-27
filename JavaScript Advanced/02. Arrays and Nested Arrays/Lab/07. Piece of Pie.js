function solve(pieFlavoursArray, targetFlavour01, targetFlavour02) {
    let endPies = [];
    let shoudAddPie = false;
    for (let index = 0; index < pieFlavoursArray.length; index++) {
        if (pieFlavoursArray[index] === targetFlavour01) {
            endPies.push(pieFlavoursArray[index]);
            shoudAddPie = true;
        } else if (pieFlavoursArray[index] === targetFlavour02) {
            endPies.push(pieFlavoursArray[index]);
            break;
        } else if (shoudAddPie) {
            endPies.push(pieFlavoursArray[index]);
        }
    }
    return endPies;
}

    solve(['Apple Crisp',
    'Mississippi Mud Pie',
    'Pot Pie',
    'Steak and Cheese Pie',
    'Butter Chicken Pie',
    'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
    );
