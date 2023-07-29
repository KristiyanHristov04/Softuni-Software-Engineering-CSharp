function solve(input) {
    let users = [];
    let articles = [];
    let movies = {};
    for (let index = 0; index < input.length; index++) {
        let line = input[index].split(' ');
        if (line.length == 2) {
            let userOrArticle = line[0];
            if (userOrArticle === 'user') {
                let user = line[1];
                users.push(user);
            } else {
                let article = line[1];
                articles.push(article);
            }
        } else {
            line = input[index].split(': ');
            let userAndArticleInfo = line[0].split(' ');
            let currentUser = userAndArticleInfo[0];
            let currentArticle = userAndArticleInfo[userAndArticleInfo.length - 1];
            let [commentTitle, commentContent] = line[1].split(', ');
            let isUserInList = false;
            let isArticleInList = false;

            for (let i = 0; i < users.length; i++) {
                if (users[i] === currentUser) {
                    isUserInList = true;
                    break;
                }
            }

            
            for (let j = 0; j < articles.length; j++) {
                if (articles[j] === currentArticle) {
                    isArticleInList = true;
                    break;
                }
            }

            let movieInfo = {};
            if (isUserInList && isArticleInList) {
                if (movies.hasOwnProperty(currentArticle)) {
                    movieInfo = {user: currentUser, commentTitle: commentTitle, commentContent: commentContent};
                    movies[currentArticle].push(movieInfo);
                } else {
                    let currentArticleMovies = [];
                    movieInfo = {user: currentUser, commentTitle: commentTitle, commentContent: commentContent};
                    currentArticleMovies.push(movieInfo);
                    movies[currentArticle] = currentArticleMovies;
                }
            }
        }
    }

    let entries = Object.entries(movies);
    let entriesSorted = entries.sort((a, b) => b[1].length - a[1].length);
    
    for (let index = 0; index < entriesSorted.length; index++) {
        console.log(`Comments on ${entriesSorted[index][0]}`);
        let comments = entriesSorted[index][1];
        let commentsSorted = comments.sort((a, b) => a.user.localeCompare(b.user));
        for (const iterator of commentsSorted) {
            console.log(`--- From user ${iterator.user}: ${iterator.commentTitle} - ${iterator.commentContent}`);
        }
    }
}

solve(['user aUser123',
    'someUser posts on someArticle: NoTitle, stupidComment',
    'article Books',
    'article Movies',
    'article Shopping',
    'user someUser',
    'user uSeR4',
    'user lastUser',
    'uSeR4 posts on Books: I like books, I do really like them',
    'uSeR4 posts on Movies: I also like movies, I really do',
    'someUser posts on Shopping: title, I go shopping every day',
    'someUser posts on Movies: Like, I also like movies very much']);