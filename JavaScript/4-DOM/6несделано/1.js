//6.Вывести любой квадрат и кнопку "скрыть квадрат". Когда мы нажимаем на скрыть, квадрат исчезает
// и текст кнопки меняется на "показать квадрат" и так можно кликать сколько угодно раз.

var red = document.createElement('div');
red.style.backgroundColor ="red";
red.style.width="100px";
red.style.height="100px";
document.body.appendChild(red);

var btn = document.createElement('button');
red.style.width="100px";
red.style.height="100px";
btn.appendChild(document.createTextNode("Скрыть квадрат"));
document.body.appendChild(btn);

document.querySelector('btn').onclick = function(){
    red.style.display="none";
    btn.appendChild(document.createTextNode("Показать квадрат"));
};

document.querySelector('btn').onclick = function(){
    red.style.display="visible";
    btn.appendChild(document.createTextNode("Скрыть квадрат"));
};
