function solve(input) {
    let leaders = {};
    for (let i = 0; i < input.length; i++) {
        let line = input[i];
        if (line.includes('arrives')) {
            let leader = line.split(' ');
            leader.pop();
            let leaderName = leader.join(' ');
            leaders[leaderName] = { totalArmyCount: 0, armyInfo: [] };
        } else if (line.includes('defeated')) {
            let defeatedLiderArray = line.split(' ');
            defeatedLiderArray.pop();
            let defeatedLider = defeatedLiderArray.join(' ');
            delete leaders[defeatedLider];
        } else if (line.includes('+')) {
            let [name, count] = line.split(' + ');
            count = Number(count);

            // Not sure if this code actually works -> Needs to be tested !!
            let findArmy = false;
            for (const leader in leaders) {
                // console.log(leaders[leader]);
                if (findArmy) {
                    break;
                }
                for (let index = 0; index < leaders[leader].armyInfo.length; index++) {
                    // console.log(leaders[leader].armyInfo[index]);
                    if (leaders[leader].armyInfo[index].armyName === name) {
                        leaders[leader].armyInfo[index].armyCount += count;
                        leaders[leader].totalArmyCount += count;
                        findArmy = true;
                        break;
                    }
                }
            }
        } else {
            let temp = line.split(': ');
            let leader = temp[0];
            let [armyName, armyCount] = temp[1].split(', ');
            armyCount = Number(armyCount);
            if (leaders.hasOwnProperty(leader)) {
                leaders[leader].totalArmyCount += armyCount;
                let armyInfoObj = { armyName: armyName, armyCount: armyCount };
                leaders[leader].armyInfo.push(armyInfoObj);
            }
        }
    }

    let leadersEntries = Object.entries(leaders);
    let leadersSorted = leadersEntries.sort((a, b) => b[1].totalArmyCount - a[1].totalArmyCount);

    for (let i = 0; i < leadersSorted.length; i++) {
        console.log(`${leadersSorted[i][0]}: ${leadersSorted[i][1].totalArmyCount}`);
        let currentArmies = leadersSorted[i][1].armyInfo;
        let currentArmiesSorted = currentArmies.sort((a, b) => b.armyCount - a.armyCount);
        for (let j = 0; j < currentArmiesSorted.length; j++) {
            console.log(`>>> ${currentArmiesSorted[j].armyName} - ${currentArmiesSorted[j].armyCount}`);
        }
    }
}

// solve(['Rick Burr arrives',
//     'Fergus: Wexamp, 30245',
//     'Rick Burr: Juard, 50000',
//     'Findlay arrives',
//     'Findlay: Britox, 34540',
//     'Wexamp + 6000',
//     'Juard + 1350',
//     'Britox + 4500',
//     'Porter arrives',
//     'Porter: Legion, 55000',
//     'Legion + 302',
//     'Rick Burr defeated',
//     'Porter: Retix, 3205']);

solve(['Rick Burr arrives',
    'Findlay arrives',
    'Rick Burr: Juard, 1500',
    'Wexamp arrives',
    'Findlay: Wexamp, 34540',
    'Wexamp + 340',
    'Wexamp: Britox, 1155',
    'Wexamp: Juard, 43423']);