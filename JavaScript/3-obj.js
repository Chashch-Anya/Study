//1) У нас есть объект, в котором хранятся зарплаты нашей команды:
// let salaries = {
//   John: 100,
//   Ann: 160,
//   Pete: 130
// }
// Напишите код для суммирования всех зарплат и сохраните результат в переменной sum. Должно получиться 390.

var salaries = {John: 100, Ann: 160, Pete: 130};
var sum=0;
for (var o in salaries)
{
    sum+=salaries[o];
}

console.log(sum);

// 2)Создайте функцию multiplyNumeric(obj), которая умножает все числовые свойства объекта obj на 2.
// Обратите внимание, что multiplyNumeric не нужно ничего возвращать. Следует напрямую изменять объект.
// P.S. Используйте typeof для проверки, что значение свойства числовое.

var menu = {
      width: 200,
      height: 300,
      title: "My menu"
    };

function multiplyNumeric(obj)
{
    for (var key in obj)
    {
        if (typeof(obj[key]) == "number") obj[key]=obj[key]*2;
    }
    return obj;
}

multiplyNumeric(menu);
console.log(menu);

// 3) Написать объект ladder - объект, который позволяет подниматься вверх и спускаться. Пример работы должен быть таким:

var ladder =
{
    step: 0,
    showStep: function() {console.log(this.step);},
    up: function() {this.step++;},
    down: function() {this.step--;}
};

ladder.showStep(); // 0 (выводит ступеньку на который мы находимся)
ladder.up(); 
ladder.up();
ladder.showStep(); // 2
ladder.down();
ladder.showStep(); // 1

