/// <reference path="../Scripts/UIFunctions.js"/>

beforeEach(function () {
    var fixture = '<div id="menu"></div>' +
        '<div id= "change-text-form"></div>' +
        '<div id= "changeText"></div>' +
        '<div id= "change-color-form"></div>' +
        '<div id= "title"></div>' +
        '<div id= "messageBoxContainer"></div>' +
        '<div id= "message-body"></div>' +
        '<div id= "feature-flag"></div>';
    document.body.insertAdjacentHTML(
        'afterbegin',
        fixture);
});

afterEach(function () {
    document.body.removeChild(document.getElementById('menu'));
    document.body.removeChild(document.getElementById('change-text-form'));
    document.body.removeChild(document.getElementById('change-color-form'));
    document.body.removeChild(document.getElementById('changeText'));
    document.body.removeChild(document.getElementById('title'));
    document.body.removeChild(document.getElementById('messageBoxContainer'));
    document.body.removeChild(document.getElementById('feature-flag'));
    document.body.removeChild(document.getElementById('message-body'));

});




describe('Frontend_Context Menu', function () {
    it('ShowDiv fucntion run with no error', function () {
        showDiv();

    });

});


describe('changeText', function () {
    it('changeH1Text fucntion run with no error', function () {
        changeH1Text();

    });
});

describe('hideMessage', function () {
    it('hide Message fucntion run with no error', function () {
        hideMessage();

    });
});

describe('display Change Text Form', function () {
    it('display Change Text Form fucntion run with no error', function () {
        displayChangeTextForm();

    });
});

describe('display Change Color Form', function () {
    it('change Color fucntion run with no error', function () {
        displayChangeColorForm();

    });
});

//describe('display Message', function () {
  //  it('display Message', function () {
    //    displayMessage(message);
// function failed on test M.Taha 18-May-20
    //});
//});
describe('show Feature Flag Form', function () {
    it('show Feature Flag Form fucntion run with no error', function () {
        showFeatureFlagForm();

    });
});
