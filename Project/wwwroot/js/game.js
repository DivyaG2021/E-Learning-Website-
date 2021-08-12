const question = document.getElementById("question");
const choices = Array.from(document.getElementsByClassName('choice-text'));
const progresstext = document.getElementById('progresstext');
const scoretext = document.getElementById('score');
const progressbarfull = document.getElementById("progressbarfull");

let currentquestion = {};
let acceptingAnswers = false;
let score = 0;
let counter = 0;
let availablequestions = [];


let questions = [
	{
		question: "HTML full form is __:",
		choice1: "Hyper Technical Market Language",
		choice2: "Hyper Text Markup Language",
		choice3: "Hyper Text Markup Limited",
		choice4: "Hyper Text Market Language",

		answer: 2
	},

	{
		question: "Which of the following defines 1% of viewport width?",
		choice1: "px",
		choice2: "vm",
		choice3: "vmin",
		choice4: "vw",

		answer: 4
	},

	{
		question: "Which of the following defines a relative measurement for the height of a font in em spaces?",
		choice1: "%",
		choice2: "em",
		choice3: "cs",
		choice4: "wr",


		answer: 2
	},

	{
		question: "Which of the following property is used as shorthand to specify a number of other font properties?",
		choice1: "window",
		choice2: "status",
		choice3: "bold",
		choice4: "font",


		answer: 4
	},

	{
		question: "Which of the following tag represents a section of the document intended for navigation in HTML5?",
		choice1: "navigation",
		choice2: "navig",
		choice3: "nm",
		choice4: "nav",

		answer: 4
	},

	{
		question: "Choose the correct HTML element for the largest heading",
		choice1: "h2",
		choice2: "h5",
		choice3: "h1",
		choice4: "h3",


		answer: 3
	},

	{
		question: "What is the correct HTML element for inserting a line break?",
		choice1: "br",
		choice2: "break",
		choice3: "bk",
		choice4: "brk",

		answer: 1
	},

	{
		question: "Choose the correct HTML element to define important text",
		choice1: "b",
		choice2: "i",
		choice3: "strong",
		choice4: "imp",

		answer: 3
	},

	{
		question: "The external JavaScript file must contain the <script> tag.",
		choice1: "not sure",
		choice2: "false",
		choice3: "invalid question",
		choice4: "true",

		answer: 2
	},

	{
		question: "Which event occurs when the user clicks on an HTML element?",
		choice1: "onmouseclick",
		choice2: "onclick",
		choice3: "onhover",
		choice4: "other",

		answer: 2
	},

	{
		question: "Which operator is used to assign a value to a variable?",
		choice1: "->",
		choice2: ":",
		choice3: "=",
		choice4: "-",


		answer: 3
	}
];

const correct_bonus = 10;
const max_questions = 5

startgame = () => {

	counter = 0;
	score = 0;
	availablequestions = [...questions];
	getnew();
};

getnew = () => {
	if (availablequestions.length === 0 || counter >= max_questions) {
		localStorage.setItem('mostrecentscore', score);
		var url = 'Score';
		return window.location.assign(url);
	}

	counter++;

	progresstext.innerText = 'Question no. : ' + counter + '/' + max_questions;
	const x = (counter / max_questions) * 100;
	progressbarfull.style.width = x + "%";

	const questionindex = Math.floor(Math.random() * availablequestions.length);
	currentquestion = availablequestions[questionindex];
	question.innerText = currentquestion.question;


	choices.forEach(choice => {
		const number = choice.dataset["number"];
		choice.innerText = currentquestion["choice" + number];
	});

	availablequestions.splice(questionindex, 1);
	acceptingAnswers = true;
};

choices.forEach(choice => {
	choice.addEventListener("click", e => {
		if (!acceptingAnswers) return;

		acceptingAnswers = false;
		const selectedchoice = e.target;
		const selectedanswer = selectedchoice.dataset['number'];

		const classtoapply = selectedanswer == currentquestion.answer ? 'correct' : 'incorrect';

		if (classtoapply === 'correct') {
			incrementscore(correct_bonus);
		}

		selectedchoice.parentElement.classList.add(classtoapply);

		setTimeout(() => {
			selectedchoice.parentElement.classList.remove(classtoapply);
			getnew();
		}, 1000);
	});
});

incrementscore = num => {
	score += num;
	scoretext.innerText = score;
};

startgame();
