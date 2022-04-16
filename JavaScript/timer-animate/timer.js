let btn = document.querySelector('.btn'),
    elem1 = document.querySelector('.figure1'),
    elem2 = document.querySelector('.figure2'),
    elem3 = document.querySelector('.figure3'),
    elem4 = document.querySelector('.figure4');

function myAnimatoin() {
    let pos = 0;

    let id = setInterval(frame, 10);

    function frame() {
        if (pos == 300) {
            clearInterval(id);
        } else {
            pos++;
            elem1.style.top = pos + "px";
            elem1.style.left = pos + "px";
            elem2.style.top = 250-pos + "px";
            elem2.style.left = 300-pos + "px";
            elem3.style.top = -100+pos + "px";
            elem3.style.left = 300-pos + "px";
            elem4.style.top = 150-pos + "px";
            elem4.style.left = pos + "px";
        }
    }
}

btn.addEventListener('click',myAnimatoin);