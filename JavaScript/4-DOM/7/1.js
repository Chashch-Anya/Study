//7.Выводим красный квадрат, при наведении на него он становиться зеленым, а когда уводим курсор от него, обратно красным.
var red = document.createElement('div');
red.style.backgroundColor ="red";
red.style.width="100px";
red.style.height="100px";
document.body.appendChild(red);

document.querySelector('div').onmouseover = function(){
    red.style.backgroundColor="green";
};

document.querySelector('div').onmouseout = function(){
    red.style.backgroundColor="red";
};