function attachEvents() {
    const textarea = document.getElementById('messages');
    const nameInput = document.querySelector('input[name="author"]');
    const messageInput = document.querySelector('input[name="content"]');
    const sendButton = document.getElementById('submit');
    const refreshButton = document.getElementById('refresh');
    const URL = `http://localhost:3030/jsonstore/messenger`;

    sendButton.addEventListener('click', sendMessageHandler);
    refreshButton.addEventListener('click', getAllMessagesHandler);

    function getAllMessagesHandler() {
        textarea.value = '';
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                let allMessages = Object.values(data);
                let output = [];
                for (let index = 0; index < allMessages.length; index++) {
                    output.push(`${allMessages[index].author}: ${allMessages[index].content}`);
                }
                textarea.value = output.join('\n');
            })
            .catch(error => console.error(error));
    }

    function sendMessageHandler() {
        let author = nameInput.value;
        let content = messageInput.value;
        let messageObject = {
            author: author,
            content: content
        };

        let httpHeaders = {
            method: 'POST',
            body: JSON.stringify(messageObject)
        }

        fetch(URL, httpHeaders)
            .catch(error => console.error(error));
        
        nameInput.value = '';
        messageInput.value = '';
    }
}

attachEvents();