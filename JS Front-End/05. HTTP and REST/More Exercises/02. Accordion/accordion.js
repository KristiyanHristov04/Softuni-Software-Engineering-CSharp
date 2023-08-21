function solution() {
    const main = document.getElementById('main');
    const accordionTemplate = document.getElementsByClassName('accordion')[0];
    const URL = `http://localhost:3030/jsonstore/advanced/articles/list`;
    main.textContent = '';

    fetch(URL)
        .then(response => response.json())
        .then(data => {
            for (let index = 0; index < data.length; index++) {
                let newAccordion = accordionTemplate.cloneNode(true);
                let title = data[index].title;
                let id = data[index]._id;
                newAccordion.children[0].children[0].textContent = title;
                newAccordion.children[0].children[1].id = id;
                let CONTENT_URL = `http://localhost:3030/jsonstore/advanced/articles/details/${id} `;
                fetch(CONTENT_URL)
                    .then(response => response.json())
                    .then(data => {
                        newAccordion.children[1].children[0].textContent = data.content;
                    })
                    .catch(error => console.error(error));
                newAccordion.children[0].children[1].addEventListener('click', moreLessButtonHandler);
                main.appendChild(newAccordion);
            }
        })
        .catch(error => console.error(error));

    function moreLessButtonHandler(event) {
        if (event.currentTarget.textContent === 'More') {
            event.currentTarget.textContent = 'Less';
            event.currentTarget.parentElement.parentElement.children[1].style.display = 'block';
        } else {
            event.currentTarget.textContent = 'More';
            event.currentTarget.parentElement.parentElement.children[1].style.display = 'none';
        }
    }
}

solution();