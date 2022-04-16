//2.Выводим кнопку с текстом "Заполнить" и незаполненный инпут, при клике на кнопку, заполняем инпут текстом "test@email.ru"
var btn = document.createElement('button');
btn.appendChild(document.createTextNode('Заполнить'));
document.body.appendChild(btn);

var inp = document.createElement('input');
document.body.appendChild(inp);
document.querySelector('button').onclick = function(){
    inp.value='test@email.ru';
};