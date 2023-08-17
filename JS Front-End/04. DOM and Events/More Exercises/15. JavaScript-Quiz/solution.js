function solve() {
  let rightAnswers = 0;

  //Result ul
  let resultUl = document.getElementById('results');

  //Sections
  let firstSection = document.querySelector('#quizzie > section:nth-child(2)');
  let secondSection = document.querySelector('#quizzie > section:nth-child(3)');
  let thirdSection = document.querySelector('#quizzie > section:nth-child(4)');

  //Divs
  let firstSectionFirstDivAnswer = document.querySelector('#quizzie > section:nth-child(2) > ul > li.quiz-answer.low-value > div');
  let firstSectionSecondDivAnswer = document.querySelector('#quizzie > section:nth-child(2) > ul > li.quiz-answer.high-value > div');

  let secondSectionFirstDivAnswer = document.querySelector('#quizzie > section:nth-child(3) > ul > li.quiz-answer.low-value > div');
  let secondSectionSecondDivAnswer = document.querySelector('#quizzie > section:nth-child(3) > ul > li.quiz-answer.high-value > div');

  let thirdSectionFirstDivAnswer = document.querySelector('#quizzie > section:nth-child(4) > ul > li.quiz-answer.low-value > div');
  let thirdSectionSecondDivAnswer = document.querySelector('#quizzie > section:nth-child(4) > ul > li.quiz-answer.high-value > div');

  //Events
  firstSectionFirstDivAnswer.addEventListener('click', answerFirstQuestion);
  firstSectionSecondDivAnswer.addEventListener('click', answerFirstQuestion);

  secondSectionFirstDivAnswer.addEventListener('click', answerSecondQuestion);
  secondSectionSecondDivAnswer.addEventListener('click', answerSecondQuestion);

  thirdSectionFirstDivAnswer.addEventListener('click', answerThirdQuestion);
  thirdSectionSecondDivAnswer.addEventListener('click', answerThirdQuestion);

  function answerFirstQuestion(event) {
    if (event.currentTarget === firstSectionFirstDivAnswer) {
      rightAnswers++;
    }
    firstSection.style.display = 'none';
    secondSection.style.display = 'block';
  }

  function answerSecondQuestion(event) {
    if (event.currentTarget === secondSectionSecondDivAnswer) {
      rightAnswers++;
    }
    secondSection.style.display = 'none';
    console.log('second section is hidden');
    thirdSection.style.display = 'block';
  }

  function answerThirdQuestion(event) {
    if (event.currentTarget === thirdSectionFirstDivAnswer) {
      rightAnswers++;
    }
    thirdSection.style.display = 'none';
    let resultText = '';
    if (rightAnswers === 3) {
      resultText = `You are recognized as top JavaScript fan!`;
    } else {
      resultText = `You have ${rightAnswers} right answers`;
    }

    resultUl.children[0].children[0].textContent = resultText;
    console.log(resultText);
    resultUl.style.display = 'block';
  }
}
