

var currentStep = 0;
var totalNumOfSteps = 5;

var rulesHidden = false;
var stepesHidden = false;

var CurrentAnswer = "";
var CurrentRow = "";

//window.alert(CorrectAnswer);

function problemType() {
    //this.parser = tutorialParser();
}

problemType.prototype.parser = function () {
    return example[currentStep];

}

var problem = new problemType();

$("#answerArea").slideUp(0);
$("#unguidedAnswerArea").slideUp(0);

var mainArea = document.getElementById("MainContent_innerMain");
var mainAreaTwo = document.getElementById("MainContent_innerMain0");

document.getElementById("StepForward").style.margin = "0 auto";

//tutorialParser(); //removes answer tags as default, so MathJax parses correctly
nextRow();



function nextRow()
{

    if (currentStep < totalNumOfSteps)
    {
        if(currentStep == 1)
        {
            //If currentStep is 1 then the Question is showing. Then we need to show all the multi questions.
            for(var i=0;i<4;i++)
            {
                var rowDiv = document.createElement('div');
                rowDiv.setAttribute('class', 'row');
                rowDiv.setAttribute('id', 'row' + currentStep);
                rowDiv.setAttribute('onclick', "highLightBar(row"+ currentStep + ","+currentStep+")");
                rowDiv.innerHTML = "Answer "+currentStep;
                rowDiv.style.textAlign = "center";
                rowDiv.style.fontSize = "medium";

                var innerRowDiv = document.createElement('div');
                innerRowDiv.setAttribute('class', 'insideRow');
                innerRowDiv.setAttribute('id', 'innerRow' + currentStep);

                innerRowDiv.appendChild(makeExample());

                mainArea.appendChild(rowDiv);
                mainArea.appendChild(innerRowDiv);

                $(rowDiv).slideUp(0);
                $(rowDiv).slideDown(500, scrollToBottomOfPage());
                setBoxHeights(innerRowDiv);

                currentStep++;
                MathJax.Hub.Typeset();
            }

        }
        else
        {
            var rowDiv = document.createElement('div');
            rowDiv.setAttribute('class', 'row');
            rowDiv.setAttribute('id', 'row' + currentStep);
            //rowDiv.setAttribute('onclick', "highLightBar(" + currentStep + ")");
            rowDiv.innerHTML = "Question";
            rowDiv.style.textAlign = "center";
            rowDiv.style.fontSize = "medium";
            rowDiv.style.pointerEvents = "none";

            var innerRowDiv = document.createElement('div');
            innerRowDiv.setAttribute('class', 'insideRow');
            innerRowDiv.setAttribute('id', 'innerRow' + currentStep);

            //innerRowDiv.appendChild(makeStep());
            innerRowDiv.appendChild(makeExample());
            //innerRowDiv.appendChild(makeRule());
            //alert(document.getElementById("MainContent_innerMain"));
            mainArea.appendChild(rowDiv);
            mainArea.appendChild(innerRowDiv);

            //if (rulesHidden)
            //    $("#rulebox" + currentStep).animate({ opacity: 0.00, width: "toggle", padding: "toggle" }, 0, function () { });

            //if (stepesHidden)
            //    $("#stepbox" + currentStep).animate({ opacity: 0.00, width: "toggle", padding: "toggle" }, 0, function () { });


            $(rowDiv).slideUp(0);
            $(rowDiv).slideDown(500, scrollToBottomOfPage());
            setBoxHeights(innerRowDiv);

            currentStep++;
            MathJax.Hub.Typeset();
        }
    }
};

function Confirm()
{
    //Check to see if answer is correct
    //If not then show them correct answer and mark theres wrong
    var rowOne = document.getElementById("row1");
    var rowTwo = document.getElementById("row2");
    var rowThree = document.getElementById("row3");
    var rowFour = document.getElementById("row4");

    

    if(CorrectAnswer == CurrentAnswer) //Correct
    {
        //window.alert("Correct Answer");

        //Hide confirm button
        var confirmButton = document.getElementById("Confirmbtn");
        confirmButton.hidden = true;

        document.getElementById("row1").onclick = "";
        document.getElementById("row2").onclick = "";
        document.getElementById("row3").onclick = "";
        document.getElementById("row4").onclick = "";
        //rowOne.Enabled = false;


        CurrentRow.style.background = '#74DF00';


    }
    else //Wrong
    {
        CurrentRow.style.background = '#DF0101';
    }
}

function highLightBar(bar,curStep)
{
    var rowOne = document.getElementById("row1");
    var rowTwo = document.getElementById("row2");
    var rowThree = document.getElementById("row3");
    var rowFour = document.getElementById("row4");

    var CurrentAnswerTemp = document.getElementById("examplebox"+curStep).innerHTML;

    if(curStep == 1)
    {
        rowOne.style.background = '#D0cabf';
        rowTwo.style.background = '#333';
        rowThree.style.background = '#333';
        rowFour.style.background = '#333';
        CurrentAnswer = CurrentAnswerTemp;
        CurrentRow = rowOne;
    }
    else if(curStep == 2)
    {
        rowOne.style.background = '#333';
        rowTwo.style.background = '#D0cabf';
        rowThree.style.background = '#333';
        rowFour.style.background = '#333';
        CurrentAnswer = CurrentAnswerTemp;
        CurrentRow = rowTwo;
    }
    else if(curStep == 3)
    {
        rowOne.style.background = '#333';
        rowTwo.style.background = '#333';
        rowThree.style.background = '#D0cabf';
        rowFour.style.background = '#333';
        CurrentAnswer = CurrentAnswerTemp;
        CurrentRow = rowThree;
    }
    else if(curStep == 4)
    {
        rowOne.style.background = '#333';
        rowTwo.style.background = '#333';
        rowThree.style.background = '#333';
        rowFour.style.background = '#D0cabf';
        CurrentAnswer = CurrentAnswerTemp;
        CurrentRow = rowFour;
    }

}

function scrollToBottomOfPage() {
    console.log("here");
    $("html, body").animate({ scrollTop: $(document).height() - $(window).height() }, 500);
    //$("#StepBackward").animate({ scrollTop: $("#StepBackward")[0].scrollHeight }, 1000);
}

function setBoxHeights(innerRow) {
    var height = 0;

    height = $('#stepbox' + currentStep).height();

    if ($('#examplebox' + currentStep).height() > height)
        height = $('#examplebox' + currentStep).height();

    if ($('#rulebox' + currentStep).height() > height)
        height = $('#rulebox' + currentStep).height();

    $(innerRow).slideUp(0);
    $(innerRow).slideDown(500);

    $('#stepbox' + currentStep).animate({ height: height }, 500, function () { });


    $('#examplebox' + currentStep).animate({ height: height }, 500, function () { });
    $('#examplebox' + currentStep + '> p').css('line-height', height - 40 + 'px');

    $('#rulebox' + currentStep).animate({ height: height }, 500, function () { });
    $('#rulebox' + currentStep + ' > p').css('line-height', height - 40 + 'px');
};

function makeExample() {
    var newDiv = document.createElement('div');
    newDiv.setAttribute('id', 'examplebox' + currentStep);
    newDiv.setAttribute('class', 'examplebox');
    newDiv.innerHTML = problem.parser();
    return (newDiv);
}


function stepForward() {
    nextRow();

    if (currentStep > 1)
        $("#StepBackward").slideDown(300);

    if (currentStep === totalNumOfSteps)
        $("#StepForward").slideUp(300);
};

function stepBack() {
    if (currentStep > 1)
    {
        currentStep--;

        var row = document.getElementById("row" + (currentStep));
        $(row).slideUp(500, function () { row.parentNode.removeChild(row); });

        var inner = document.getElementById("innerRow" + (currentStep));
        $(inner).slideUp(500, function () { inner.parentNode.removeChild(inner); });


        if (currentStep < 2)
            $("#StepBackward").slideUp(300);

        if (currentStep < totalNumOfSteps)
            $("#StepForward").slideDown(300);
    }

};

function accordion(i) {
    $('#row' + i).next().slideToggle(300);
}

function resetProblem() {
    //alert(step.length);

    for (var i = 0; i < step.length; i++) {
        stepBack();
    }

    //hideAnswerBox();
    //hideUnguidedAnswerBox();
    $("#StepForward").slideDown(500);
    //alert(i);
    //currentStep = 1;
}