function attachEvents() {
    const URL = 'http://localhost:3030/jsonstore/messenger';
    const sendButton = document.getElementById('submit');
    const refreshButton = document.getElementById('refresh');
    const [name, message] = document.querySelectorAll('input[type=text]');
    const messages = document.getElementById('messages');

    sendButton.addEventListener('click', (e) => {
        let author = name.value;
        let content = message.value;

        fetch(URL, {
            method: 'POST',
            body: JSON.stringify({
                author,
                content
            })
        })
        .then(name.value = '', message.value = '')
        .catch(error => console.log(error));
    });

    refreshButton.addEventListener('click', (e) => {
        messages.textContent = '';
        fetch(URL)
            .then(response => response.json())
            .then(data => {
                let messagesData = Object.values(data);
                for (const currentMessage of messagesData) {
                    messages.textContent += `${currentMessage.author}: ${currentMessage.content}\n`;
                }
                messages.textContent = messages.textContent.trim();
            })
            .catch(error => console.log(error));
    });
}

attachEvents();