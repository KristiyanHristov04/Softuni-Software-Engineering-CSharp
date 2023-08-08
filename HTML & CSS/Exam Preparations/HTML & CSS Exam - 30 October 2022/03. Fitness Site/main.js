let h1 = document.querySelector('h1');
let paragraph = document.querySelector('#heroSection p');
let button = document.querySelector('button');

let options = {};

let observer = new IntersectionObserver((entries, observer) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('showElement')
        }
    })
}, options);

observer.observe(h1);
observer.observe(paragraph);
observer.observe(button);

//

let browserWidth = window.innerWidth;
console.log(browserWidth);

let options2Threshold = 0.2;
let options2RootMargin = "0px 0px 0px 0px";

if (browserWidth <= 1000) {
    options2Threshold = 0;
    options2RootMargin = "0px 0px 500px 0px";
}

let firstSection = document.querySelector('#firstSection');
let secondSection = document.querySelector('#secondSection');

let options2 = { 
    threshold: options2Threshold,
    rootMargin: options2RootMargin
};

let observer2 = new IntersectionObserver((entries, observer) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('showElement')
        }
    })
}, options2);

observer2.observe(firstSection);
observer2.observe(secondSection);

//

let list = document.querySelector('#heroSection ul');

let optionsList = {};

let observerList = new IntersectionObserver((entries, observer) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('showList')
        }
    })
}, optionsList);

observerList.observe(list);