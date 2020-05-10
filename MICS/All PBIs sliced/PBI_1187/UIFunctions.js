


function showDiv(){
    var currentDisplayStyleForMenu = document.getElementById('menu').style.display;
    var currentDisplayStyleForChangeText = document.getElementById('change-text-form').style.display;

    if (currentDisplayStyleForChangeText == "block") {
        document.getElementById('change-text-form').style.display = "none";
        return;
    }    
    if (currentDisplayStyleForMenu == "block") {    
        document.getElementById('menu').style.display = "none";
    }
    else {
        document.getElementById('menu').style.display = "block";
    }
}



function changeH1Text() {
    var textToChange = document.getElementById('changeText').value;
    if (textToChange == "") {
        displayMessage("Ooops, there is no value. Please enter the text you want to change.");
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

function displayMessage(message) {
    document.getElementById('message-body').innerText = message;
    document.getElementById('messageBoxContainer').style.display = "block";
}


