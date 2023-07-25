function solve(input) {
    let movies = [];

    for (let index = 0; index < input.length; index++) {
        if (input[index].includes('addMovie')) {
            let movieName = input[index].replace('addMovie', '').trimStart();
            let movie = {name: movieName};
            movies.push(movie);
        } else if (input[index].includes('directedBy')) {
            let [movieName, movieDirector] = input[index].split(' directedBy ');
            for (let index = 0; index < movies.length; index++) {
                if (movies[index].name == movieName) {
                    movies[index].director = movieDirector;
                }
            }
        } else {
            let [movieName, movieDate] = input[index].split(' onDate ');
            for (let index = 0; index < movies.length; index++) {
                if (movies[index].name == movieName) {
                    movies[index].date = movieDate;
                }
            }
        }
    }

    for (let index = 0; index < movies.length; index++) {
        let currentMovieKeys = Object.keys(movies[index]).length;
        if (currentMovieKeys == 3) {
            let movieAsJSON = JSON.stringify(movies[index]);
            console.log(movieAsJSON);
        }
    }
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]);

// solve([
//     'addMovie The Avengers',
//     'addMovie Superman',
//     'The Avengers directedBy Anthony Russo',
//     'The Avengers onDate 30.07.2010',
//     'Captain America onDate 30.07.2010',
//     'Captain America directedBy Joe Russo'
//     ]
//     );