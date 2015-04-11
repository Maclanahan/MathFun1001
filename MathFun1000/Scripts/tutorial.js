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

        $(rowDiv).slideDown(500);
        setBoxHeights(innerRowDiv);

        currentStep++;
        
    }
};

function setBoxHeights(innerRow)
{
    var height = 0;

    height = $('#stepbox' + currentStep).height();

    if($('#examplebox' + currentStep).height() > height)
        height = $('#examplebox' + currentStep).height();

    if($('#rulebox' + currentStep).height() > height)
        height = $('#rulebox' + currentStep).height();

    $(innerRow).slideUp(0);
    $(innerRow).slideDown(500);

    $('#stepbox' + currentStep).animate({ height: height }, 1000, function () { });
   // $('#stepbox' + currentStep).css('min-height', height + 'px');
    //$('#stepbox' + currentStep).css('max-height', height + 'px');
   //$('#stepbox' + currentStep + ' > p').css('line-height', box[0] - 40 + 'px');

    $('#examplebox' + currentStep).animate({ height: height }, 1000, function () { });
    //$('#examplebox' + currentStep).css('min-height', height + 'px');
    //$('#examplebox' + currentStep).css('max-height', height + 'px');
    $('#examplebox' + currentStep + '> p').css('line-height', height - 40 + 'px');

    $('#rulebox' + currentStep).animate({ height: height }, 1000, function () { });
    //$('#rulebox' + currentStep).css('min-height', height + 'px');
    //$('#rulebox' + currentStep).css('max-height', height + 'px');
    $('#rulebox' + currentStep + ' > p').css('line-height', height - 40 + 'px');
};

function makeStep()
{
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'stepbox'+ currentStep);
    newDiv.setAttribute('class', 'stepbox');
    var par = document.createElement('p');
    par.textContent = step[currentStep];

    newDiv.appendChild(par);
    return (newDiv);
}

function makeExample() {
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'examplebox' + currentStep);
    newDiv.setAttribute('class', 'examplebox');
    newDiv.innerHTML = example[currentStep];
    return (newDiv);
}

function makeRule() {
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'rulebox' + currentStep);
    newDiv.setAttribute('class', 'rulebox');
    var par = document.createElement('p');
    par.textContent = rule[currentStep];

    newDiv.appendChild(par);
    return (newDiv);
}


function stepForward()
{
    nextRow();
};

function stepBack()
{
    if (currentStep > 0)
    {
        currentStep--;

        var row = document.getElementById("row" + (currentStep));
        $(row).slideUp(500, function () { row.parentNode.removeChild(row); });
       



        var inner = document.getElementById("innerRow" + (currentStep));
        $(inner).slideUp(500, function () { inner.parentNode.removeChild(inner); });
        
    }
};

function hideColumn(col)
{
    //var text = 
    console.log(col);
    $("." + col + "box").animate({ opacity: 0.00, width: "toggle", padding: "toggle"}, 500, function () { });

    var button = document.getElementById('Hide' + col + 'Column');
    button.setAttribute("onclick", "showColumn(\'" + col + "\')");
    button.setAttribute("value", "Show " + col + "s");
}

function showColumn(col)
{
    $('.' + col + 'box').animate({ opacity: 1.00, width: "toggle", padding: "toggle" }, 500, function () { });
    console.log(col);
    var button = document.getElementById('Hide' + col + 'Column');
    button.setAttribute("onclick", "hideColumn(\'" + col + "\')");
    button.setAttribute("value", "Hide " + col + "s");
}

function accordion(i)
{
    $('#row' + i).next().slideToggle(300);
}