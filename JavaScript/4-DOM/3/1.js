//3.Выводим кнопку и инпут, в инпуте можно ввести любой и текст и при нажатии на кнопку,
// выводится алерт с текстом "Вы ввели 'текст инпута'" или "Вы ничего не ввели в поле".

var btn = document.createElement('button');
btn.appendChild(document.createTextNode('Готово'));
document.body.appendChild(btn);

var inp = document.createElement('input');
document.body.appendChild(inp);

document.querySelector('button').onclick = function(){
    if(inp.value=="") alert("Вы ничего не ввели в поле");
    else alert("Вы ввели \"" + inp.value +"\"");
};