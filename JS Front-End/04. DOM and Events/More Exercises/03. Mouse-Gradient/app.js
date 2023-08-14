function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');
 
    gradientElement.addEventListener('mousemove', mouseIndicator);
    gradientElement.addEventListener('mouseout', mouseOut);
 
    function mouseIndicator(e) {
        let position = e.offsetX / (e.target.clientWidth - 1); // let position = e.clientX;
        let percentage = Math.trunc(position * 100);           // let percentage = Math.trunc((position - 9) / 3);
        resultElement.textContent = `${percentage}%`;
    }
 
    function mouseOut() {
        resultElement.textContent = "";
    }
}