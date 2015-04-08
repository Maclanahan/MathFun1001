var currentStep = 0;
var totalNumOfSteps = example.length;

var mainArea = document.getElementById("MainContent_innerMain");
nextRow();

function nextRow()
{
    if (currentStep < totalNumOfSteps)
    {
        var rowDiv = document.createElement('div');
        rowDiv.setAttribute('class', 'row');
        rowDiv.setAttribute('id', 'row' + currentStep);
        rowDiv.setAttribute('onclick', "accordion(" + currentStep +")");
        rowDiv.innerHTML = "+-";

        var innerRowDiv = document.createElement('div');
        innerRowDiv.setAttribute('class', 'insideRow');
        innerRowDiv.setAttribute('id', 'innerRow' + currentStep);

        innerRowDiv.appendChild(makeStep());
        innerRowDiv.appendChild(makeExample());
        innerRowDiv.appendChild(makeRule());

        mainArea.appendChild(rowDiv);
        mainArea.appendChild(innerRowDiv);

        currentStep++;
    }
};

function makeStep()
{
    var newDiv = document.createElement('div');
    newDiv.setAttribute('class', 'box');
    var par = document.createElement('p');
    par.textContent = step[currentStep];

    newDiv.appendChild(par);
    //mainArea.appendChild(newDiv);
    return (newDiv);
}

function makeExample() {
    var newDiv = document.createElement('div');
    newDiv.setAttribute('class', 'box');
   // var par = document.createElement('p');
    newDiv.innerHTML = example[currentStep];

    //newDiv.appendChild(par);
    //mainArea.appendChild(newDiv);
    return (newDiv);
}

function makeRule() {
    var newDiv = document.createElement('div');
    newDiv.setAttribute('class', 'box');
    var par = document.createElement('p');
    par.textContent = rule[currentStep];

    newDiv.appendChild(par);
    //mainArea.appendChild(newDiv);
    return (newDiv);
}


function stepForward()
{
    nextRow();
};

function stepBack()
{
    currentStep--;

    var elem = document.getElementById("row" + (currentStep));
    elem.parentNode.removeChild(elem);

    elem = document.getElementById("innerRow" + (currentStep));
    elem.parentNode.removeChild(elem);
    
};

function removeElement(elem)
{
    elem
};

function accordion(i)
{
    //alert("here");
    $('#row' + i).next().slideToggle(300);
}