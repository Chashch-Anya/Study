//1.Вывести кнопку с текстом "Привет", при нажатии на неё выводим alert c текстом "Привет Мир!"
var btn = document.createElement('button');
btn.appendChild(document.createTextNode('Привет'));
btn.style.width ="400px";
btn.style.height ="70px";
btn.style.marginLeft = "35%";
btn.style.marginTop = "5%";
document.body.appendChild(btn);
document.querySelector('button').onclick = function(){alert("Привет, мир!");};