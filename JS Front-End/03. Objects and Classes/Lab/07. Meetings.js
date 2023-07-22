function meetings(input) {
    let meetingsArrange = {};

    for (const iterator of input) {
        let [day, name] = iterator.split(' ');
        if (meetingsArrange.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
            continue;
        }
        meetingsArrange[day] = name;
        console.log(`Scheduled for ${day}`);
    }

    for (const key in meetingsArrange) {
        console.log(`${key} -> ${meetingsArrange[key]}`);
    }
}

meetings(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']);