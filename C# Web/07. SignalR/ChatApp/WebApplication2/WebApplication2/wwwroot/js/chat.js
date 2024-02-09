var connection = new signalR.HubConnectionBuilder().withUrl("/MyHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    var span = document.createElement('span');
    span.textContent = 'new ';
    span.style.fontStyle = 'oblique';
    span.style.color = 'cornflowerblue';
    span.style.fontSize = '12px';
    span.style.verticalAlign = 'super';
    span.style.fontWeight = 'bold';
    document.getElementById("messages").prepend(li);
    li.textContent = `${user}: ${message}`;
    li.prepend(span);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    event.preventDefault();
    var user = document.getElementById("username").value;
    var message = document.getElementById("message").value;
    document.getElementById("message").value = '';
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
});