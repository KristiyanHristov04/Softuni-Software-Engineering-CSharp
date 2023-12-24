const bell = document.getElementById('bell');
const thumbsUp = document.getElementById('thumbs-up');
const heart = document.getElementById('heart');
const react = document.getElementById('react');
const playAllButton = document.getElementsByTagName('button')[0];

var bellAudio = new Audio('soundEffects/bellRinging.mp3');
var thumbsUpAudio = new Audio('soundEffects/like.mp4');

react.addEventListener('click', (e) => {
    e.currentTarget.classList.add('play-react-animation');
});

playAllButton.addEventListener('click', () => {
    bell.classList.add('play-bell-animation');
    thumbsUp.classList.add('play-thumbs-up-animation');
    heart.classList.add('play-heart-animation');
    bellAudio.play();
    thumbsUpAudio.play();
    setTimeout(() => {
        bell.classList.remove('play-bell-animation');
        thumbsUp.classList.remove('play-thumbs-up-animation');
        heart.classList.remove('play-heart-animation');
    }, 1000);
});

heart.addEventListener('click', (e) => {
    e.currentTarget.classList.add('play-heart-animation');
    setTimeout(() => {
        heart.classList.remove('play-heart-animation');
    }, 1000);
});

bell.addEventListener('click', (e) => {
    e.currentTarget.classList.add('play-bell-animation');
    bellAudio.play();
    setTimeout(() => {
        bell.classList.remove('play-bell-animation');
    }, 1000);
});

thumbsUp.addEventListener('click', (e) => {
    e.currentTarget.classList.add('play-thumbs-up-animation');
    thumbsUpAudio.play();
    setTimeout(() => {
        thumbsUp.classList.remove('play-thumbs-up-animation');
    }, 1000);
});