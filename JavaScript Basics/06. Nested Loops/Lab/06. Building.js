function solve(input){
    let floors = Number(input[0]);
    let rooms = Number(input[1]);
    let allRoomsOnSingleLine = '';

    for(let floor = floors; floor >= 1; floor--){
        for(let room = 0; room < rooms; room++){
            if(floor == floors){
                allRoomsOnSingleLine += `L${floor}${room} `;
                if(room + 1 == rooms){
                    console.log(allRoomsOnSingleLine);
                    allRoomsOnSingleLine = '';
                }
            }
            else if(floor % 2 == 0){
                allRoomsOnSingleLine += `O${floor}${room} `;
                if(room + 1 == rooms){
                    console.log(allRoomsOnSingleLine);
                    allRoomsOnSingleLine = '';
                }
            }
            else{
                allRoomsOnSingleLine += `A${floor}${room} `;
                if(room + 1 == rooms){
                    console.log(allRoomsOnSingleLine);
                    allRoomsOnSingleLine = '';
                }
            }
        }
    }
}

// solve(['9', '5']);