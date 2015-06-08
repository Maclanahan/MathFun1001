

var currentStep = 0;
var totalNumOfSteps = example.length;

var rulesHidden = false;
var stepesHidden = false;

var answer = "";

function problemType()
{
    
}

problemType.prototype.parser = function ()
{
    return example[currentStep];

}

var problem = new problemType();

$("#answerArea").slideUp(0);
$("#unguidedAnswerArea").slideUp(0);
$("#StepBackward").slideUp(0);

var mainArea = document.getElementById("MainContent_innerMain");

tutorialParser(); //removes answer tags as default, so MathJax parses correctly
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

        if (rulesHidden)
            $("#rulebox" + currentStep).animate({ opacity: 0.00, width: "toggle", padding: "toggle" }, 0, function () { });

        if (stepesHidden)
            $("#stepbox" + currentStep).animate({ opacity: 0.00, width: "toggle", padding: "toggle" }, 0, function () { });


        $(rowDiv).slideUp(0);
        $(rowDiv).slideDown(500, scrollToBottomOfPage());
        setBoxHeights(innerRowDiv);

        currentStep++;
        MathJax.Hub.Typeset();

        
    }
};

function scrollToBottomOfPage()
{
    console.log("here");
    $("html, body").animate({ scrollTop: $(document).height() - $(window).height() }, 500);
}

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

    $('#stepbox' + currentStep).animate({ height: height }, 500, function () { });


    $('#examplebox' + currentStep).animate({ height: height }, 500, function () { });
    $('#examplebox' + currentStep + '> p').css('line-height', height - 40 + 'px');

    $('#rulebox' + currentStep).animate({ height: height }, 500, function () { });
    $('#rulebox' + currentStep + ' > p').css('line-height', height - 40 + 'px');
};

function makeStep()
{
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'stepbox'+ currentStep);
    newDiv.setAttribute('class', 'stepbox');
    var par = document.createElement('p');
    par.innerHTML = step[currentStep];

    newDiv.appendChild(par);
    return (newDiv);
}

function makeExample() {
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'examplebox' + currentStep);
    newDiv.setAttribute('class', 'examplebox');
    newDiv.innerHTML = problem.parser();
    return (newDiv);
}

function makeRule() {
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'rulebox' + currentStep);
    newDiv.setAttribute('class', 'rulebox');
    var par = document.createElement('p');
    var redirect = document.createElement('a');
    redirect.textContent = rule[currentStep];
    redirect.setAttribute('href', '/Rules.aspx?#MainContent_' + link[currentStep]);
    redirect.setAttribute('target', '_blank');

    par.appendChild(redirect);
    newDiv.appendChild(par);
    

    

    return (newDiv);
}


function stepForward()
{
    nextRow();

    if (currentStep > 1)
        $("#StepBackward").slideDown(300);

    if (currentStep === totalNumOfSteps)
        $("#StepForward").slideUp(300);
};

function stepBack()
{
    if (currentStep > 1)
    {
        currentStep--;

        var row = document.getElementById("row" + (currentStep));
        $(row).slideUp(500, function () { row.parentNode.removeChild(row); });
       
        var inner = document.getElementById("innerRow" + (currentStep));
        $(inner).slideUp(500, function () { inner.parentNode.removeChild(inner); });


        if(currentStep < 2)
            $("#StepBackward").slideUp(300);

        if (currentStep < totalNumOfSteps)
            $("#StepForward").slideDown(300);
    }

};

function hideColumn(col)
{
    $("." + col + "box").animate({ opacity: 0.00, width: "toggle", padding: "toggle"}, 500, function () { });

    var button = document.getElementById('Hide' + col + 'Column');
    button.setAttribute("onclick", "showColumn(\'" + col + "\')");
    button.setAttribute("value", "Show " + col + "s");

    if (col === "step")
        stepesHidden = true;

    if (col === "rule")
        rulesHidden = true;
}

function showColumn(col)
{
    $('.' + col + 'box').animate({ opacity: 1.00, width: "toggle", padding: "toggle" }, 500, function () { });
    var button = document.getElementById('Hide' + col + 'Column');
    button.setAttribute("onclick", "hideColumn(\'" + col + "\')");
    button.setAttribute("value", "Hide " + col + "s");

    if (col === "step")
        stepesHidden = false;

    if (col === "rule")
        rulesHidden = false;
}

function accordion(i)
{
    $('#row' + i).next().slideToggle(300);
}

function tutorialParser()
{
    //Button Highlight
    $("#unguided").css("background-color", "#DE8642"); //unguided.style.backgroundColor = "#DE8642";
    $("#tutorial").css("background-color", "#99FF99");
    $("#fillIn").css("background-color", "#DE8642");//fillIn.style.backgroundColor = "#DE8642";
    //

    resetProblem();

    problemType.prototype.parser = function () {
        var string = "";
        string = example[currentStep];

        if (string.indexOf("<answer>") !== -1)
        {
            string = string.replace(/<answer>/g, '');
            string = string.replace(/<\/answer>/g, '');
            string = string.replace(/<u>/g, '');
            string = string.replace(/<\/u>/g, '');
            string = string.replace(/<i>/g, '');
            string = string.replace(/<\/i>/g, '');
            string = string.replace(/<b>/g, '');
            string = string.replace(/<\/b>/g, '');
            string = string.replace(/&nbsp;/g, '');

            return string;
        }

        return example[currentStep];
    }
}

function fillInParser()
{
    //Button Highlight
    $("#unguided").css("background-color", "#DE8642"); //unguided.style.backgroundColor = "#DE8642";
    $("#tutorial").css("background-color", "#DE8642");
    $("#fillIn").css("background-color", "#99FF99");//fillIn.style.backgroundColor = "#DE8642";
    //

    resetProblem();

    problemType.prototype.parser = function()
    {
        var string = "";
        string = example[currentStep];

        if (string.indexOf("<answer>") !== -1)
        {
            //string = string.replace("<u>", "");
            //string = string.replace("</u>", "");
            answer = string.substring(string.indexOf("<answer>") + 8, string.indexOf("</answer>"));
            string = string.replace("<answer>" + answer + "</answer>", "???");
            
            string = string.replace(/<answer>/g, '');
            string = string.replace(/<\/answer>/g, '');
            string = string.replace(/<u>/g, '');
            string = string.replace(/<\/u>/g, '');
            string = string.replace(/<i>/g, '');
            string = string.replace(/<\/i>/g, '');
            string = string.replace(/<b>/g, '');
            string = string.replace(/<\/b>/g, '');
            string = string.replace(/&nbsp;/g, '');

            $("#StepForward").slideUp(500);

            $("#AnswerBox").width(25);
            showAnswerBox();
        }

        else
        {
            hideAnswerBox();
        }

        return string;
    }
    //Button Highlight





    
}

function unguidedParser()
{
    //Button Highlight
    $("#unguided").css("background-color", "#99FF99"); //unguided.style.backgroundColor = "#DE8642";
    $("#tutorial").css("background-color", "#DE8642");
    $("#fillIn").css("background-color", "#DE8642");
    //

    resetProblem();

    var string = "";
    string = example[example.length - 1];
    string = string.replace(/<(?:.|\n)*?>/gm, '');
    string = string.replace(/\$/g, '');
    string = string.replace(/\\/g, '');
    string = string.replace(/\{/g, '');
    string = string.replace(/\}/g, '');
    string = string.replace(/color/g, '');
    string = string.replace(/blue/g, '');
    string = string.replace(/red/g, '');
    string = string.replace(/green/g, '');
    string = string.replace(/ /g, '');
    string = string.replace(/<answer>/g, '');
    string = string.replace(/<\/answer>/g, '');
    string = string.replace(/<u>/g, '');
    string = string.replace(/<\/u>/g, '');
    string = string.replace(/<i>/g, '');
    string = string.replace(/<\/i>/g, '');
    string = string.replace(/<b>/g, '');
    string = string.replace(/<\/b>/g, '');
    string = string.replace(/&nbsp;/g, '');

    string = string.replace("<answer>", "");
    string = string.replace("</answer>", "");
    string = string.replace("<u>", "");
    string = string.replace("</u>", "");

    answer = string;
    $("#unguidedAnswerLabel").text(string);
    $("#unguidedAnswerBox").width(230);

    $("#StepForward").slideUp(500);

    showUnguidedAnswerBox();

    problemType.prototype.parser = function ()
    {
        return example[currentStep];
    }
}

function showAnswerBox()
{
    $("#answerArea").slideDown(500);
}

function hideAnswerBox()
{
    $("#answerArea").slideUp(500);
}

function showUnguidedAnswerBox()
{
    $("#unguidedAnswerArea").slideDown(500);
}

function hideUnguidedAnswerBox()
{
    $("#unguidedAnswerArea").slideUp(500);
}


function checkAnswer()
{
    var input = $("#AnswerBox").val();

    input.replace(/ /g, '');

    if (input === answer)
    {
        hideAnswerBox();
        $("#AnswerBox").val("");

        $("#answerLabel").text("");//step is correct in case user answered wrong the first time.

        stepForward();
    }
    else
        $("#answerLabel").text("INCORRECT");

}

function checkUnguidedAnswer() {
    var input = $("#unguidedAnswerBox").val();

    input.replace(/ /g, '');

    if (input === answer)
    {
        hideAnswerBox();
        $("#unguidedAnswerBox").val("");

        currentStep = example.length - 1;

        hideUnguidedAnswerBox();

        stepForward();
    }
    else
        $("#unguidedAnswerLabel").text("INCORRECT");

}

function resetProblem()
{

    for(var i = 0; i < step.length; i++)
    {
        stepBack();
    }

    hideAnswerBox();
    hideUnguidedAnswerBox();
    $("#StepForward").slideDown(500);

}