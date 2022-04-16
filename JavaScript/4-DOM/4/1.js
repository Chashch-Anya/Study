//4.Выводим кнопку с текстом "Поменять" и два инпута, при клике на кнопку инпуты меняются своим введеным текстом
var inp = document.createElement('input');
document.body.appendChild(inp);

var btn = document.createElement('button');
btn.appendChild(document.createTextNode('Поменять'));
document.body.appendChild(btn);

var inp2 = document.createElement('input');
document.body.appendChild(inp2);

document.querySelector('button').onclick = function(){
    let str = inp.value;
    inp.value=inp2.value;
    inp2.value=str;
};