function encodeAndDecodeMessages() {
    const [encodeButton, decodeButton] = document.getElementsByTagName('button');
    const [encodeTextarea, decodeTextarea] = document.getElementsByTagName('textarea');
    encodeButton.addEventListener('click', encodeText);
    decodeButton.addEventListener('click', decodeText);

    function encodeText() {
        let normalText = encodeTextarea.value;
        let encodedText = '';
        for (let index = 0; index < normalText.length; index++) {
            encodedText += String.fromCharCode(normalText[index].charCodeAt(0) + 1);
        }
        decodeTextarea.value = encodedText;
        encodeTextarea.value = '';
    }

    function decodeText() {
        let encodedText = decodeTextarea.value;
        let decodedText = '';
        for (let index = 0; index < encodedText.length; index++) {
            decodedText += String.fromCharCode(encodedText[index].charCodeAt(0) - 1);
        }
        decodeTextarea.value = decodedText;
    }
}