function solve(input){
    let serialName = input[0];
    let episodeLength = Number(input[1]);
    let breakLength = Number(input[2]);

    let neededTimeForLaunch = breakLength / 8;
    let neededTimeForBreak = breakLength / 4;
    let leftTime = breakLength - neededTimeForLaunch - neededTimeForBreak;

    if(leftTime >= episodeLength){
        leftTime -= episodeLength;
        console.log(`You have enough time to watch ${serialName} and left with ${Math.ceil(leftTime)} minutes free time.`);
    }
    else{
        leftTime = episodeLength - leftTime;
        console.log(`You don't have enough time to watch ${serialName}, you need ${Math.ceil(leftTime)} more minutes.`);
    }
}

solve(['Game of Thrones', '60', '96']);
solve(['Teen Wolf', '48', '60'])

