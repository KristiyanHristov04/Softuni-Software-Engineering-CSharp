function solve(input) {
    let n = Number(input.shift());
    let sprintBoard = {};
    let toDoPoints = 0;
    let inProgressPoints = 0;
    let codeReviewPoints = 0;
    let donePoints = 0;

    for (let index = 0; index < n; index++) {
        let [asignee, taskId, title, status, estimatedPoints] = input.shift().split(':');
        if (!sprintBoard.hasOwnProperty(asignee)) {
            sprintBoard[asignee] = [{ taskId, title, status, estimatedPoints }];
        } else {
            sprintBoard[asignee].push({ taskId, title, status, estimatedPoints });
        }
    }

    for (let index = 0; index < input.length; index++) {
        let commandInfo = input[index].split(':');
        let mainCommand = commandInfo.shift();
        if (mainCommand === 'Add New') {
            let [cmdAssignee, cmdTaskId, cmdTitle, cmdStatus, cmdEstimatedPoints] = commandInfo;
            if (sprintBoard.hasOwnProperty(cmdAssignee)) {
                sprintBoard[cmdAssignee].push({ taskId: cmdTaskId, titel: cmdTitle, status: cmdStatus, estimatedPoints: cmdEstimatedPoints })
            } else {
                console.log(`Assignee ${cmdAssignee} does not exist on the board!`);
            }
        } else if (mainCommand === 'Change Status') {
            let [cmdAssignee, cmdTaskId, cmdNewStatus] = commandInfo;
            if (!sprintBoard.hasOwnProperty(cmdAssignee)) {
                console.log(`Assignee ${cmdAssignee} does not exist on the board!`)
            } else {
                let isTaskFound = false;
                for (let j = 0; j < sprintBoard[cmdAssignee].length; j++) {
                    if (sprintBoard[cmdAssignee][j].taskId === cmdTaskId) {
                        sprintBoard[cmdAssignee][j].status = cmdNewStatus;
                        isTaskFound = true;
                        break;
                    }
                }
                if (!isTaskFound) {
                    console.log(`Task with ID ${cmdTaskId} does not exist for ${cmdAssignee}!`);
                }
            }
        } else {
            let [cmdAssignee, cmdIndex] = commandInfo;
            if (!sprintBoard.hasOwnProperty(cmdAssignee)) {
                console.log(`Assignee ${cmdAssignee} does not exist on the board!`);
            } else {
                if (cmdIndex >= sprintBoard[cmdAssignee].length || cmdIndex < 0) {
                    console.log(`Index is out of range!`);
                } else {
                    sprintBoard[cmdAssignee].splice(cmdIndex, 1);
                }
            }
        }
    }

    for (const key in sprintBoard) {
        for (let i = 0; i < sprintBoard[key].length; i++) {
            let sprintStatus = sprintBoard[key][i].status;
            if (sprintStatus === 'ToDo') {
                toDoPoints += Number(sprintBoard[key][i].estimatedPoints);
            } else if (sprintStatus === 'In Progress') {
                inProgressPoints += Number(sprintBoard[key][i].estimatedPoints);
            } else if (sprintStatus === 'Code Review') {
                codeReviewPoints += Number(sprintBoard[key][i].estimatedPoints);
            } else {
                donePoints += Number(sprintBoard[key][i].estimatedPoints);
            }
        }
    }

    console.log(`ToDo: ${toDoPoints}pts`);
    console.log(`In Progress: ${inProgressPoints}pts`);
    console.log(`Code Review: ${codeReviewPoints}pts`);
    console.log(`Done Points: ${donePoints}pts`);

    if (donePoints >= toDoPoints + inProgressPoints + codeReviewPoints) {
        console.log('Sprint was successful!');
    } else {
        console.log('Sprint was unsuccessful...');
    }
}

// solve([
//     '5',
//     'Kiril:BOP-1209:Fix Minor Bug:ToDo:3',
//     'Mariya:BOP-1210:Fix Major Bug:In Progress:3',
//     'Peter:BOP-1211:POC:Code Review:5',
//     'Georgi:BOP-1212:Investigation Task:Done:2',
//     'Mariya:BOP-1213:New Account Page:In Progress:13',
//     'Add New:Kiril:BOP-1217:Add Info Page:In Progress:5',
//     'Change Status:Peter:BOP-1290:ToDo',
//     'Remove Task:Mariya:1',
//     'Remove Task:Joro:1',
// ]
// );

solve([
    '4',
    'Kiril:BOP-1213:Fix Typo:Done:1',
    'Peter:BOP-1214:New Products Page:In Progress:2',
    'Mariya:BOP-1215:Setup Routing:ToDo:8',
    'Georgi:BOP-1216:Add Business Card:Code Review:3',
    'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
    'Change Status:Georgi:BOP-1216:Done',
    'Change Status:Will:BOP-1212:In Progress',
    'Remove Task:Georgi:3',
    'Change Status:Mariya:BOP-1215:Done',
]
);