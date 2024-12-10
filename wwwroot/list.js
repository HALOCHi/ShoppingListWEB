// Создаем кнопку закрытия и присоединяем ее к каждому элементу списка
var myShoplist = document.getElementsByTagName("LI");
var i;
for (i = 0; i < myShoplist.length; i++) {
  var span = document.createElement("SPAN");
  var txt = document.createTextNode("\u00D7");
  span.className = "close";
  span.appendChild(txt);
  myShoplist[i].appendChild(span);
}

// Делаем, чтобы при нажатии на кнопку закрытия этот элемент списка скрывался
var close = document.getElementsByClassName("close");
var i;
for (i = 0; i < close.length; i++) {
  close[i].onclick = function() {
    var div = this.parentElement;
    div.style.display = "none";
  }
}

// Делаем, чтобы при нажатии на элемент списка добавлялся символ "отмечено"
var list = document.querySelector('ul');
list.addEventListener('click', function(ev) {
  if (ev.target.tagName === 'LI') {
    ev.target.classList.toggle('checked');
  }
}, false);

// Создаем новый элемент списка при нажатии на кнопку "Добавить"
function newElement() {
  var li = document.createElement("li");
  var inputValue = document.getElementById("list_input").value;
  var t = document.createTextNode(inputValue);
  li.appendChild(t);
  if (inputValue === '') {
    alert("You must write something!");
  } else {
    document.getElementById("myUL").appendChild(li);
  }
  document.getElementById("list_input").value = "";

  var span = document.createElement("SPAN");
  var txt = document.createTextNode("\u00D7");
  span.className = "close";
  span.appendChild(txt);
  li.appendChild(span);

  for (i = 0; i < close.length; i++) {
    close[i].onclick = function() {
      var div = this.parentElement;
      div.style.display = "none";
    }
  }
}