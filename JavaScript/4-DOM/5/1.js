//5.Выводим две кнопки "заблокировать" и "разблокировать" и инпут. Одна из них блокирует инпут с помощью атрибута disabled, а другая разблокирует

var inp = document.createElement('input');
document.body.appendChild(inp);

var btn1 = document.createElement('button');
btn1.appendChild(document.createTextNode('Заблокировать'));
btn1.classList.add("block");
document.body.appendChild(btn1);

var btn2 = document.createElement('button');
btn2.appendChild(document.createTextNode('Разблокировать'));
btn2.classList.add("unblock");
document.body.appendChild(btn2);

document.querySelector(".block").onclick = function(){
    inp.disabled=true;
};

document.querySelector(".unblock").onclick = function(){
    inp.disabled=false;
};