function solve(input) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let songs = [];
    const songsCount = input.shift();
    const typeList = input.pop();

    for (let index = 0; index < input.length; index++) {
        let [songTypeList, songName, songDuration] = input[index].split('_');
        let newSong = new Song(songTypeList, songName, songDuration);
        songs.push(newSong);
    }

    for (const song of songs) {
        if (typeList !== 'all') {
            if (song.typeList == typeList) {
                console.log(song.name);
            }
        } else {
            console.log(song.name);
        }
    }
}

solve([2,
    'like_Replay_3:15',
    'ban_Photoshop_3:48',
    'all']);