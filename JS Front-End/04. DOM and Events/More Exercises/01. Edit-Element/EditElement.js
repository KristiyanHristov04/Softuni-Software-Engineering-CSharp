function editElement(element, match, replacer) {
    const text = element.textContent;
    const newText = text.replace(new RegExp(match, 'g'), replacer);
    // const newText = text.replaceAll(match, replacer);
    element.textContent = newText;
}
