//menu mobilne
const menu = document.querySelector('#mobile_menu');
const menuLinks = document.querySelector('.nar__menu_proper');

const moblieMenu = () => {
  menu .classList.toggle('is-active');
  menuLinks.classList.toggle('active');
}

menu.addEventListener('click', moblieMenu );

//ładowanie obrazkow
var bCheckEnabled = true;
var bFinishCheck = false;

var img;
var imgArray = [];
var i = 1;

var myInterval = setInterval(loadMemes, 1);

function loadMemes()
{
  if (bFinishCheck) {
    clearInterval(myInterval);
    alert('Loaded ' + i + ' image(s)!)');
    const list = document.querySelector(".image_boxes")
    imgArray.forEach(function(img){
      let newMeme = list.querySelector(".meme_item").cloneNode(true)
      newMeme.querySelector(".meme").src = img.src
      newMeme.querySelector(".title").label = String(img.src)
      list.appendChild(newMeme)
    })
    return;
  }

  if (bCheckEnabled) {

    bCheckEnabled = false;

    img = new Image();
    img.onload = memeExists;
    img.onerror = memeDoesntExist;
    img.src = 'img/pic' + i + '.png';

  }
}

function memeExists() {
  imgArray.push(img);
  i++;
  bCheckEnabled = true;
}

function memeDoesntExist() {
  bFinishCheck = true;
}
