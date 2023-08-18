function attachEvents() {
    let loadPostsButton = document.getElementById('btnLoadPosts');
    let viewPostButton = document.getElementById('btnViewPost');
    let allPostsMenu = document.getElementById('posts');
    let h1PostTitle = document.getElementById('post-title');
    let pPostBody = document.getElementById('post-body');
    let ulPostComments = document.getElementById('post-comments');
    const POSTS_URL = 'http://localhost:3030/jsonstore/blog/posts';
    const COMMENTS_URL = 'http://localhost:3030/jsonstore/blog/comments';

    loadPostsButton.addEventListener('click', loadPostsHandler);
    viewPostButton.addEventListener('click', loadCommentsHandler);

    let postBody = [];

    function loadCommentsHandler() {
        ulPostComments.textContent = '';
        let currentSelectedPostValue = allPostsMenu.value;

        let title = allPostsMenu.querySelector('option:checked');
        h1PostTitle.textContent = title.textContent;
        var selectedPostIndex = allPostsMenu.selectedIndex;
        pPostBody.textContent = postBody[selectedPostIndex];

        fetch(COMMENTS_URL)
            .then(response => response.json())
            .then(data => {
                let array = Object.entries(data);
                for (let index = 0; index < array.length; index++) {
                    if (array[index][1].postId === currentSelectedPostValue) {
                        let comment = array[index][1].text;
                        let li = document.createElement('li');
                        li.textContent = comment;
                        ulPostComments.appendChild(li);
                    }
                }
            })
            .catch(error => console.error(error));
    }

    function loadPostsHandler() {
        fetch(POSTS_URL)
            .then(response => response.json())
            .then(data => {
                let array = Object.entries(data);
                for (let index = 0; index < array.length; index++) {
                    let postValue = array[index][0];
                    let postTitle = array[index][1].title;
                    let option = document.createElement('option');
                    option.setAttribute('value', postValue);
                    option.textContent = postTitle;
                    allPostsMenu.appendChild(option);
                    postBody.push(array[index][1].body);
                }
            })
            .catch(error => console.error(error));
    }
}

attachEvents();