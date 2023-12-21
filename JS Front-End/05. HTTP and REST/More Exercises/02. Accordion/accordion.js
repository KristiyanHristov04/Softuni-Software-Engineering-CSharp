function solution() {
    const mainSection = document.getElementById('main');
    const URL = 'http://localhost:3030/jsonstore/advanced/articles/list';

    loadArticles();
    
    function loadArticles() {
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                let articles = Object.values(data);
                for (const article of articles) {
                    let title = article.title;
                    let id = article._id;
                    createArticle(title, id);
                }
            })
            .catch(error => console.log(error));
    }

    function createArticle(title, id) {
        let divAccordion = document.createElement('div');
        divAccordion.classList.add('accordion');

        let divHead = document.createElement('div');
        divHead.classList.add('head');

        let span = document.createElement('span');
        span.textContent = title;

        let button = document.createElement('button');
        button.classList.add('button');
        button.id = id;
        button.textContent = 'More';
        button.addEventListener('click', (e) => {
            if (e.currentTarget.textContent === 'More') {
                let p = e.currentTarget.parentElement.parentElement.children[1].children[0];
                let id = e.currentTarget.id;
                fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`)
                    .then(response => response.json())
                    .then(data => {
                        p.textContent = data.content;
                    })
                    .catch(error => console.log(error));
                e.currentTarget.textContent = 'Less';
                e.currentTarget.parentElement.parentElement.children[1].style.display = 'block';
            } else {
                e.currentTarget.textContent = 'More';
                e.currentTarget.parentElement.parentElement.children[1].style.display = 'none';
            }
        });

        let divExtra = document.createElement('div');
        divExtra.classList.add('extra');
        divExtra.style.display = 'none';

        let p = document.createElement('p');

        divHead.appendChild(span);
        divHead.appendChild(button);
        divExtra.appendChild(p);
        divAccordion.appendChild(divHead);
        divAccordion.appendChild(divExtra);
        mainSection.appendChild(divAccordion);
    }

}

solution();