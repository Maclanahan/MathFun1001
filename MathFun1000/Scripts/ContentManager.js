
$(document).ready(getBooks);


function getBooks()
{
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetBooks",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);

            $.each(data.d, function (key, value) {
                $("#bookSelection").append('<option value="' + value[0] + '">' + value[1] + '</option>');
            });
        },
        error: function (data) {
            //console.log(data);
        }
    });
}

function getChapters()
{
    $("#chapter").slideUp(0);

    //console.log(JSON.stringify({ id: $("#bookSelection").val() }));
    $("#chapterSelection").empty();
    $("#chapterSelection").append('<option value="-1">Select Chapter</option>');
    $("#problemSelection").empty();
    $("#problemSelection").append('<option value="-1">Select Problem</option>');

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetChapters",
        data: JSON.stringify({ id: $("#bookSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);

            $.each(data.d, function (key, value) {
                $("#chapterSelection").append('<option value="' + value[0] + '">' + value[1] + '</option>');
            });

            $("#chapter").slideDown(500);
            $("#chapter").css('visibility', '');
        },
        error: function (data) {
            //console.log(data);
        }
    });
    
}

function getProblems()
{
    $("#problem").slideUp(0);
    //console.log(JSON.stringify({ id: $("#bookSelection").val() }));
    $("#problemSelection").empty();
    $("#problemSelection").append('<option value="-1">Select Problem</option>');

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetProblems",
        data: JSON.stringify({ id: $("#chapterSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var i = 1;
            $.each(data.d, function (key, value) {
                $("#problemSelection").append('<option value="' + value[0] + '">Problem ' + i + '</option>');
                i++;
            });

            $("#problem").slideDown(500);
            $("#problem").css('visibility', '');
        },
        error: function (data) {
            //console.log(data);
        }
    });

    
}

function getSteps()
{
    $("#step").slideUp(0);
    $("#step").empty();
    

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetSteps",
        data: JSON.stringify({ id: $("#problemSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var i = 1;
            $.each(data.d, function (key, value) {
                var innerRowDiv = document.createElement('div');
                innerRowDiv.setAttribute('class', 'insideRow');
                //innerRowDiv.setAttribute('id', 'innerRow' + currentStep);
                innerRowDiv.appendChild(makeControls());
                innerRowDiv.appendChild(makeStep(value[1]));
                innerRowDiv.appendChild(makeExample(value[2]));
                innerRowDiv.appendChild(makeRule(value[3]));
                //$("#step").append(makeStep(value[1]));
                //$("#step").append(makeExample(value[2]));
                //$("#step").append(makeRule(value[3]));
                $("#step").append(innerRowDiv);
                
                
                i++;
            });

            //loadJax();
            //MathJax.Hub.Queue(["Typeset", MathJax.Hub]);

            $("#step").slideDown(500);
            $("#step").css('visibility', '');
        },
        error: function (data) {
            //console.log(data);
        }
    });

    
}

function makeControls() {
    var newDiv = document.createElement('div');
    //newDiv.setAttribute('id', 'stepbox');
    newDiv.setAttribute('class', 'controlBox');
    
    $(newDiv).append('<input type="button" value="B" onclick="iBold()"/>');
    $(newDiv).append('<input type="button" value="&#920;" onclick="iSymbol()"/>');

    return (newDiv);
}

function makeStep(step) {
    var newDiv = document.createElement('div');
    //newDiv.setAttribute('id', 'stepbox');
    newDiv.setAttribute('contenteditable', 'true');
    newDiv.setAttribute('class', 'stepbox');
    var par = document.createElement('p');
    par.textContent = step;

    newDiv.appendChild(par);
    return (newDiv);
}

function makeExample(step) {
    var newDiv = document.createElement('div');
    //newDiv.setAttribute('id', 'examplebox' + currentStep);
    newDiv.setAttribute('contenteditable', 'true');
    newDiv.setAttribute('class', 'examplebox');
    newDiv.innerHTML = step;
    return (newDiv);
}

function makeRule(step) {
    var newDiv = document.createElement('div');
    //newDiv.setAttribute('id', 'rulebox' + currentStep);
    newDiv.setAttribute('class', 'rulebox');
    newDiv.setAttribute('contenteditable', 'true');
    var par = document.createElement('p');
    //var redirect = document.createElement('a');
    par.innerText = step;
    //redirect.setAttribute('href', '/Rules.aspx?#MainContent_' + link[currentStep]);
    //redirect.setAttribute('target', '_blank');

    //par.appendChild(redirect);
    newDiv.appendChild(par);




    return (newDiv);
}