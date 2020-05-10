

function showDiv(){
    var currentDisplayStyleForMenu = document.getElementById('menu').style.display;
    var currentDisplayStyleForChangeColor = document.getElementById('change-color-form').style.display;
        
    if (currentDisplayStyleForChangeColor == "block") {
        document.getElementById('change-color-form').style.display = "none";
        return;
    }

    if (currentDisplayStyleForMenu == "block") {    
        document.getElementById('menu').style.display = "none";
    }
    else {
        document.getElementById('menu').style.display = "block";
    }
}


function changeH1Color(color) {
    var clickedColor = window.getComputedStyle(document.getElementById(color), null).getPropertyValue("background-color");

    document.getElementById('title').style.background = clickedColor;
    document.getElementById('sumbtn').style.background = clickedColor;
    document.getElementById('dividebtn').style.background = clickedColor;
    document.getElementById('subtractbtn').style.background = clickedColor;

        }



function displayChangeColorForm() {
    document.getElementById('menu').style.display = "none";
    document.getElementById('change-color-form').style.display = "block";
}



