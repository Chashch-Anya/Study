//1) Сделай функцию, которая принимает массив любых целых чисел, которая возращает истинну,
// если все элементы четные, если бы хотя бы один элемент не четный, то false.
function myFunction1(arr) {
    for (i = 0; i < arr.length; i++) {
      if (arr[i]%2!=0) return false;
    }
    return true;
  }
  
  console.log(myFunction1([12, 14, 1, 2]));

// 2)Сделай функцию, которая принимает массив любых целых чисел, которая возращает истинну, 
//если хотя бы один элемент нечетный, если все четные, то false.
function myFunction2(arr) {
    for (i = 0; i < arr.length; i++) {
      if (arr[i]%2!=0) return true;
    }
    return false;
  }
  
  console.log(myFunction2([12, 14, 4, 2]));

// 3)Сделай функцию, которая принимает массив любых целых чисел, которая возращает новый массив, 
// где все элементы кратны пяти. ([1,2,5,12,15,21] вернет [5,15])

function myFunction3(arr) {
    var newArr = Array();
    for (i = 0; i < arr.length; i++) {
      if (arr[i]%5==0) newArr.push(arr[i]);
    }
    return newArr;
  }
  
  console.log(myFunction3([1,2,5,12,15,21]));

// 4)Написать функцию, которая принимает массив чисел, например [1,2,3,4,5] 
//и функция возращает среднее арифметическое, (округлить результат до десятых)
function myFunction4(arr) {
    var summ=0;
    for (i = 0; i < arr.length; i++)
    {
      summ+=arr[i];
    }
    
    summ = summ/arr.length;
    return summ.toFixed(1);
  }
  
  console.log(myFunction4([1,2,3,5,5]));

  // 5)Написать функцию, которая принимает массив чисел, например [1,2,3,4,5], и переносит первый элемент массива в конец 
  //(например можно засунуть первый элемент в конец, затем удалить первый элемент)

  function myFunction5(arr) {
    arr.push(arr[0]);
    arr.shift();
    return arr;
  }
  
  console.log(myFunction5([1,2,3,4,5]));

  // 6)Написать функцию, которая принимает массив сотрудников, каждый сотрудник имеет имя и возраст 
  //([{name: 'Иван', age: 23},...]) и возвращает массив, где каждый элемент представляет из себя строку "Имя: Иван, возвраст: 23".

  function myFunction6(arr) {
    var strArr= Array();
    for (i = 0; i < arr.length; i++)
    {
        strArr.push("Имя: "+ arr[i].name + ", возраст: " + arr[i].age);
    }
    return strArr;
  }
  
  console.log(myFunction6([{name: 'Иван', age: 23},{name: 'Анна', age: 21},{name: 'Антон', age: 26},{name: 'Ольга', age: 21}]));