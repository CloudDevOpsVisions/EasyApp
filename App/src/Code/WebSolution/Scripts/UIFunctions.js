//// Add handler to even in javascript
//document.addEventListener("DOMContentLoaded", function (event) {
//    // but function for sum button

//    document.getElementById("sumbtn").addEventListener("click", function () {
//        alert("Hello World!")
//    });
//});


function showDiv(){
    var currentDisplayStyleForMenu = document.getElementById('menu').style.display;
    var currentDisplayStyleForChangeText = document.getElementById('change-text-form').style.display;
    var currentDisplayStyleForChangeColor = document.getElementById('change-color-form').style.display;

    if (currentDisplayStyleForChangeText === "block") {
        document.getElementById('change-text-form').style.display = "none";
        return;
    }
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

function changeH1Text() {
    var textToChange = document.getElementById('changeText').value;
    if (textToChange == "") {
        displayMessage("Ooops, there is no value. Please enter the text you want to change ffff.");
    }

    else {
        document.getElementById('change-text-form').style.display = "none";
        document.getElementById('title').innerHTML = textToChange;
    } 
}


function hideMessage() {
    document.getElementById('messageBoxContainer').style.display = "none"; 
}

function displayChangeTextForm() {
    document.getElementById('menu').style.display = "none";
    document.getElementById('change-text-form').style.display = "block";
}

function displayChangeColorForm() {
    document.getElementById('menu').style.display = "none";
    document.getElementById('change-color-form').style.display = "block";
}

function displayMessage(message) {
    document.getElementById('message-body').innerText = message;
    document.getElementById('messageBoxContainer').style.display = "block";
}

function showFeatureFlagForm() {

    var currentDisplayFeatureFlag = document.getElementById('feature-flag').style.display;
    
    if (currentDisplayFeatureFlag == "block") {
        document.getElementById('feature-flag').style.display = "none";
        return;
    }
    else
    {
        document.getElementById('feature-flag').style.display = "block";
    }
}
