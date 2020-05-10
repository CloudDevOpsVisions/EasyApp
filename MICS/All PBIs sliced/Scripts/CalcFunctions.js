function sum() {
    var num1 = document.getElementById('firstNumber').value;
    var num2 = document.getElementById('secondNumber').value;
    if (isNaN(num1) || isNaN(num2) || (num1 == "") || (num2 == "")) {
        displayMessage("Ooops, one or more values is not a number. Please enter a valid number.");
    }
    else {
        document.getElementById('result').value = +num1 + (+num2);
    }
}


function divide() {
    var num1 = document.getElementById('firstNumber').value;
    var num2 = document.getElementById('secondNumber').value;
    if (isNaN(num1) || isNaN(num2) || (num1 == "") || (num2 == "")) {
        displayMessage("Ooops, one or more values is not a number. Please enter a valid number.");
    }
    else {
        document.getElementById('result').value = +num1 / +num2;
    }
}

function subtract() {
    var num1 = document.getElementById('firstNumber').value;
    var num2 = document.getElementById('secondNumber').value;
    if (isNaN(num1) || isNaN(num2) || (num1 == "") || (num2 == "")) {
        displayMessage("Ooops, one or more values is not a number. Please enter a valid number.");
    }
    else {
        document.getElementById('result').value = +num1 - +num2;
    }
}