﻿
$(document).ready(getBooks);
$(document).ready(hideAll(0));

function hideAll(num)
{
    $("#addBook").slideUp(num);
    $("#editBook").slideUp(num);

    $("#addChapter").slideUp(num);
    $("#editChapter").slideUp(num);

    $("#addProblem").slideUp(num);
    $("#editProblem").slideUp(num);
}

function getBooks()
{
    hideAll(500);

    $("#book").slideUp(0);
    $("#bookSelection").empty();
    $("#bookSelection").append('<option value="-1">Select Book</option>');

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetBooks",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            $.each(data.d, function (key, value)
            {
                $("#bookSelection").append('<option value="' + value[0] + '">' + value[1] + '</option>');
            });

            $("#book").slideDown(500);
            $("#book").css('visibility', '');
        },
        error: function (data)
        {
            alert("There has been a issue retrieving Books.");
        }
    });
}

function getChapters()
{
    hideAll(500);

    $("#chapter").slideUp(0);

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
        success: function (data)
        {
            $.each(data.d, function (key, value)
            {
                $("#chapterSelection").append('<option value="' + value[0] + '">' + value[1] + '</option>');
            });

            $("#chapter").slideDown(500);
            $("#chapter").css('visibility', '');
        },
        error: function (data)
        {
            alert("There has been an issue retrieving chapters");
        }
    });
    
}

function getProblems()
{
    hideAll(500);

    $("#problem").slideUp(0);
    
    $("#problemSelection").empty();
    $("#problemSelection").append('<option value="-1">Select Problem</option>');

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetProblems",
        data: JSON.stringify({ id: $("#chapterSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            var i = 1;
            $.each(data.d, function (key, value)
            {
                $("#problemSelection").append('<option value="' + value[0] + '" data-type="' + value[1] + '">Problem ' + i + '</option>');
                i++;
            });

            $("#problem").slideDown(500);
            $("#problem").css('visibility', '');
        },
        error: function (data) {
            alert("There has been an issue retrieving Problems");
        }
    });

    
}

function getSteps()
{
    hideAll(500);

    $("#step").slideUp(0);
    $("#step").empty();
    
    if ($("#problemSelection").val() == -1)
        return;

    if ($("#problemSelection" + " option:selected").attr('data-type') == 1)
        getDefaultProblem();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 3)
        getMultipleChoice();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 2)
        getGraph();

    else
        alert("There has been an error.");
}

function getDefaultProblem()
{
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetSteps",
        data: JSON.stringify({ id: $("#problemSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            var i = 1;
            $.each(data.d, function (key, value)
            {
                var innerRowDiv = document.createElement('div');
                innerRowDiv.setAttribute('class', 'insideRow');
                innerRowDiv.setAttribute('value', value[0]);
                innerRowDiv.appendChild(makeControls());
                innerRowDiv.appendChild(makeStep(value[1]));
                innerRowDiv.appendChild(makeExample(value[2]));
                innerRowDiv.appendChild(makeRule(value[3]));

                $("#step").append(innerRowDiv);


                i++;
                $("#cancelProblemButton").attr("onclick", "$('#editProblem').slideUp(500); uneditDefault()");
            });
            makeUnEditable("default");
            $(".controlBox").slideUp(0);
            $("#step").slideDown(500);
            $("#step").css('visibility', '');
        },
        error: function (data)
        {
            alert("There has been an issue retrieving Problem Info.");
        }
    });
}

function getMultipleChoice()
{
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetMultipleChoice",
        data: JSON.stringify({ id: $("#problemSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            console.log(data);
            $("#step").append("Question: <br/><textarea id='question' class='mc' disabled width='200px'>" + data.d[0][6] + "</textarea><br/>");
            $("#step").append("Option 1: <br/><textarea id='option1' class='mc' disabled width='200px'>" + data.d[0][1] + "</textarea><br/>");
            $("#step").append("Option 2: <br/><textarea id='option2' class='mc' disabled width='200px'>" + data.d[0][2] + "</textarea><br/>");
            $("#step").append("Option 3: <br/><textarea id='option3' class='mc' disabled width='200px'>" + data.d[0][3] + "</textarea><br/>");
            $("#step").append("Option 4: <br/><textarea id='option4' class='mc' disabled width='200px'>" + data.d[0][4] + "</textarea><br/>");
            $("#step").append("Answer: <br/><textarea id='answer' class='mc' disabled width='200px'>" + data.d[0][5] + "</textarea><br/>");

            $("#step").slideDown(500);
            $("#step").css('visibility', '');
            $("#cancelProblemButton").attr("onclick", "$('#editProblem').slideUp(500); uneditMultipleChoice()");
        },
        error: function (data)
        {
            alert("There has been an issue retrieving MultipleChoice Problem.");
        }
    });
}

function getGraph()
{
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetGraph",
        data: JSON.stringify({ id: $("#problemSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            //console.log(data);
            $("#step").append("Option 1: <br/><textarea id='option1' class='g' disabled width='200px'>" + data.d[0][1] + "</textarea><br/>");
            $("#step").append("Option 2: <br/><textarea id='option2' class='g' disabled width='200px'>" + data.d[0][2] + "</textarea><br/>");
            $("#step").append("Option 3: <br/><textarea id='option3' class='g' disabled width='200px'>" + data.d[0][3] + "</textarea><br/>");
            $("#step").append("Option 4: <br/><textarea id='option4' class='g' disabled width='200px'>" + data.d[0][4] + "</textarea><br/>");
            $("#step").append("Option 5: <br/><textarea id='option5' class='g' disabled width='200px'>" + data.d[0][5] + "</textarea><br/>");
            $("#step").append("Answer: (Please keep in y=mx+b form. ie: y=2x^3+4) <br/><textarea id='answer' class='g' disabled width='200px'>" + data.d[0][6] + "</textarea><br/>");


            $("#step").slideDown(500);
            $("#step").css('visibility', '');
            $("#cancelProblemButton").attr("onclick", "$('#editProblem').slideUp(500); uneditGraph()");
        },
        error: function (data)
        {
            alert("There has been a server error. We aplogize for the inconvenience");
        }
    });
}

function makeControls() {
    var newDiv = document.createElement('div');

    newDiv.setAttribute('class', 'controlBox');
    
    $(newDiv).append('<input type="button" value="B" onclick="iBold()"/>');
    $(newDiv).append('<input type="button" value="I" onclick="iItalic()"/>');
    $(newDiv).append('<input type="button" value="&#920;" onclick="iSymbol(' + "'&#920;'" + ')"/>');
    $(newDiv).append('<input type="button" value="&pi;" onclick="iSymbol(' + "'&pi;'" + ')"/>');
    $(newDiv).append('<input type="button" value="&radic;" onclick="iSymbol(' + "'&radic;'" + ')"/>');
    $(newDiv).append('<input type="button" value="&le;" onclick="iSymbol(' + "'&le;'" + ')"/>');
    $(newDiv).append('<input type="button" value="&ge;" onclick="iSymbol(' + "'&ge;'" + ')"/>');
    $(newDiv).append('<input type="button" value="Red" onclick="addColor(' + "'red'" + ')"/>');
    $(newDiv).append('<input type="button" value="Blue" onclick="addColor(' + "'blue'" + ')"/>');
    $(newDiv).append('<input type="button" value="Green" onclick="addColor(' + "'green'" + ')"/>');
    $(newDiv).append('<br/>');
    $(newDiv).append('<input type="button" value="Insert Answer" onclick="iAnswer()"/>');
    $(newDiv).append('<input type="button" value="Remove Answer" onclick="removeAnswer()"/>');

    return (newDiv);
}

function makeStep(step) {
    var newDiv = document.createElement('div');

    newDiv.setAttribute('class', 'stepbox');
    var par = document.createElement('p');
    par.innerHTML = step;

    newDiv.appendChild(par);
    return (newDiv);
}

function makeExample(step) {
    var newDiv = document.createElement('div');

    newDiv.setAttribute('class', 'examplebox');

    newDiv.innerHTML = step;

    return (newDiv);
}

function makeRule(step) {

    var newDiv = document.createElement('div');
    newDiv.setAttribute('class', 'rulebox');

    var ruleSelect = document.createElement('select');
    ruleSelect.setAttribute('class', 'ruleSelector');
    ruleSelect.setAttribute('disabled', 'true');

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetRules",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            $.each(data.d, function (key, value)
            {
                $(ruleSelect).append('<option value="' + value[0] + '">' + value[1] + '</option>');
            });

            $(ruleSelect).val(step);

            $(newDiv).append(ruleSelect);

            return (newDiv);
        },
        error: function (data)
        {
            alert("There has been an issue retrieving Rules.");
        }

    });


    $(newDiv).append(ruleSelect);

    return newDiv;
}

function addNewBook()
{
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/AddBook",
        data: JSON.stringify({ title: $("#bookName").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            $("#bookName").val("");
            $("#addBook").slideUp(500);
            $("#book").slideUp(500);
            $("#addBook").css('visibility', '');
            getBooks();
        },
        error: function (data)
        {
            alert(JSON.parse(data.responseText).Message);
        }
    });
}

function updateBook()
{
    if ($("#bookSelection").val() != -1)
    {
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/UpdateBook",
            data: JSON.stringify({ title: $("#editBookName").val(), id: $("#bookSelection").val() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data)
            {
                $("#editBookName").val("");
                $("#editBook").slideUp(500);
                $("#book").slideUp(500);
                $("#editBook").css('visibility', '');
                getBooks();
            },
            error: function (data)
            {
                alert(JSON.parse(data.responseText).Message);
            }
        });
    }
}

function addNewChapter()
{
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/AddChapter",
        data: JSON.stringify({ title: $("#chapterName").val(), desc: $("#chapterDesc").val(), book: $("#bookSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            $("#chapterName").val("");
            $("#chapterBook").slideUp(500);
            $("#chapter").slideUp(500);
            $("#addChapter").css('visibility', '');
            getChapters();
        },
        error: function (data)
        {
            alert(JSON.parse(data.responseText).Message);
        }
    });
}

function updateChapter() {
    if ($("#chapterSelection").val() != -1)
    {
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/UpdateChapter",
            data: JSON.stringify({ title: $("#editChapterName").val(), desc: $("#editChapterDesc").val(), id: $("#chapterSelection").val() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data)
            {
                $("#editChapterName").val("");
                $("#editChapter").slideUp(500);
                $("#chapter").slideUp(500);
                $("#editChapter").css('visibility', '');
                getChapters();
            },
            error: function (data)
            {
                alert(JSON.parse(data.responseText).Message);
            }
        });
    }
}

function updateProblem()
{
    if ($("#problemSelection" + " option:selected").attr('data-type') == 1)
        updateDefault();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 3)
        updateMultipleChoice();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 2)
        updateGraph();

    else
        alert("There has been an error.");
    
    
}

function updateDefault()
{
    $(".insideRow").each(function ()
    {
        console.log($(this).attr('value'));
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/UpdateProblem",
            data: JSON.stringify({
                step: $(this).children(".stepbox").children('p').html(),
                example: $(this).children(".examplebox").html(),
                rule: $(this).children(".rulebox").children('select').val(),
                id: $(this).attr('value')
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data)
            {
                console.log(data);
            },
            error: function (data)
            {
                alert(JSON.parse(data.responseText).Message);
                return;
            }
        });
    });

    getSteps();
}

function updateMultipleChoice()
{
    if (!checkMultipleChoice())
    {
        return;
    }

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/UpdateMultipleChoice",
        data: JSON.stringify({
            question: $("#question").val(),
            option1: $("#option1").val(),
            option2: $("#option2").val(),
            option3: $("#option3").val(),
            option4: $("#option4").val(),
            answer: $("#answer").val(),
            id: $("#problemSelection").val()
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            console.log(data);
            $("#step").slideUp(500, getSteps);
        },
        error: function (data)
        {
            alert(JSON.parse(data.responseText).Message);
            return;
        }
    });
}

function checkMultipleChoice()
{
    if ($("#answer").val() != $("#option1").val() &&
        $("#answer").val() != $("#option1").val() &&
        $("#answer").val() != $("#option2").val() &&
        $("#answer").val() != $("#option3").val() &&
        $("#answer").val() != $("#option4").val()) {
        alert("No Option Matched the Answer");
        return false;
    }
    return true;
}

function updateGraph()
{
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/UpdateGraph",
        data: JSON.stringify({
            option1: $("#option1").val(),
            option2: $("#option2").val(),
            option3: $("#option3").val(),
            option4: $("#option4").val(),
            option5: $("#option5").val(),
            answer: $("#answer").val(),
            id: $("#problemSelection").val()
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            console.log(data);
            $("#step").slideUp(500, getSteps);
        },
        error: function (data)
        {
            alert(JSON.parse(data.responseText).Message);
            return;
        }
    });
}

function openEdit(select, div, text)
{
    $("#addBook").slideUp(500);

    if ($(select).val() != -1)
    {
        $(text).val($(select + " option:selected").text());
        $(div).slideDown(500);
    }
}

function openChapterEdit(select, div)
{
    $("#addChapter").slideUp(500);

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetChapter",
        data: JSON.stringify({ id: $("#chapterSelection").val()}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            $("#editChapterName").val($(select + " option:selected").text());
            $("#editChapterDesc").val(data.d[0][2]);
            $(div).slideDown(500);
            
        },
        error: function (data)
        {
            alert("There has been an issue Editing Chapter.");
        }
    });
}

function addProblem()
{
    hideAll(500);
    $("#step").slideUp(500);
    $("#problemSelection").val(-1);
    $("#addProblem").slideDown(500);
}

function addDefault()
{
    $("#problemSelection").val(-1);
    $("#addProblem").slideDown(500);
    
    $("#step").slideUp(0);
    $("#step").empty();
    $("#step").append("<div id='rowArea'> </div>");
    $("#step").append("<input type='button' value='+' onclick='addRow()'/>");

    addRow();
    makeEditable("default");
    $("#step").css('visibility', '');
    $("#step").slideDown(500);

    $("#addProblemButton").attr("onclick", "addDefaultToDatabase()");
    
}

function addMultipleChoice()
{
    $("#problemSelection").val(-1);
    $("#addProblem").slideDown(500);

    $("#step").slideUp(0);
    $("#step").empty();

    $("#step").append("Question: <br/><textarea id='question' class='mc' disabled width='200px'>" +"</textarea><br/>");
    $("#step").append("Option 1: <br/><textarea id='option1' class='mc' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Option 2: <br/><textarea id='option2' class='mc' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Option 3: <br/><textarea id='option3' class='mc' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Option 4: <br/><textarea id='option4' class='mc' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Answer: <br/><textarea id='answer' class='mc' disabled width='200px'>" + "</textarea><br/>");

    makeEditable("multiplechoice");
    $("#step").css('visibility', '');
    $("#step").slideDown(500);

    $("#addProblemButton").attr("onclick", "addMultipleChoiceToDatabase()");
    $("#cancelProblemButton").attr("onclick", "uneditMultipleChoice()");
}

function addGraph()
{

    $("#problemSelection").val(-1);
    $("#addProblem").slideDown(500);

    $("#step").slideUp(0);
    $("#step").empty();

    $("#step").append("Option 1: <br/><textarea id='option1' class='g' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Option 2: <br/><textarea id='option2' class='g' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Option 3: <br/><textarea id='option3' class='g' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Option 4: <br/><textarea id='option4' class='g' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Option 5: <br/><textarea id='option5' class='g' disabled width='200px'>" + "</textarea><br/>");
    $("#step").append("Answer: <br/><textarea id='answer' class='g' disabled width='200px'>" + "</textarea><br/>");

    makeEditable("graph");
    $("#step").css('visibility', '');
    $("#step").slideDown(500);

    $("#addProblemButton").attr("onclick", "addGraphToDatabase()");
    $("#cancelProblemButton").attr("onclick", "uneditGraph()");
}

function addRow()
{
    var innerRowDiv = document.createElement('div');
    innerRowDiv.setAttribute('class', 'insideRow');
    innerRowDiv.appendChild(makeControls());
    innerRowDiv.appendChild(makeStep("Step Goes Here"));
    innerRowDiv.appendChild(makeExample("$$ Example Goes Here $$"));
    innerRowDiv.appendChild(makeRule("1"));

    $("#rowArea").append(innerRowDiv);
    $(innerRowDiv).slideUp(0);
    $(innerRowDiv).slideDown(500);

    makeEditable("default");
    
}

function addProblemToDatabase()
{
   
}

function addDefaultToDatabase()
{
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/AddProblem",
        data: JSON.stringify({
            chapter: $("#chapterSelection").val(),
            type: 1
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) 
        {
            addStepsToDatabase(data.d);
        },
        error: function (data)
        {
            alert(JSON.parse(data.responseText).Message);
            return;
        }
    });
}

function addMultipleChoiceToDatabase()
{
    if (!checkMultipleChoice()) {
        return;
    }

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/AddMultipleChoice",
        data: JSON.stringify({
            question: $("#question").val(),
            option1: $("#option1").val(),
            option2: $("#option2").val(),
            option3: $("#option3").val(),
            option4: $("#option4").val(),
            answer: $("#answer").val(),
            id: $("#chapterSelection").val(),
            book: $("#bookSelection").val(),
            type: "3"
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            console.log(data);
            getProblems();
            $("#step").slideUp(500);
        },
        error: function (data)
        {
            alert(JSON.parse(data.responseText).Message);
            return;
        }
    });
}

function addGraphToDatabase()
{
    
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/AddGraph",
        data: JSON.stringify({
            option1: $("#option1").val(),
            option2: $("#option2").val(),
            option3: $("#option3").val(),
            option4: $("#option4").val(),
            option5: $("#option5").val(),
            answer: $("#answer").val(),
            id: $("#chapterSelection").val(),
            book: $("#bookSelection").val(),
            type: "2"
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data)
        {
            console.log(data);
            getProblems();
            $("#step").slideUp(500);
        },
        error: function (data)
        {
            alert(JSON.parse(data.responseText).Message);
            return;
        }
    });
}

function addStepsToDatabase(id)
{
    $(".insideRow").each(function ()
    {
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/AddStep",
            data: JSON.stringify({
                step: $(this).children(".stepbox").children('p').html(),
                example: $(this).children(".examplebox").html(),
                rule: $(this).children(".rulebox").children('select').val(),
                problem: id
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data)
            {

            },
            error: function (data)
            {
                alert(JSON.parse(data.responseText).Message);
                return;
            }
        });
    });

    getProblems();
    $("#step").slideUp(500);
}

function deleteProblem()
{
    if ($("#problemSelection" + " option:selected").attr('data-type') == 1)
        deleteDefault();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 3)
        deleteMultipleChoice();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 2)
        deleteGraph();

    else
        alert("There has been an error."); 
}

function deleteDefault()
{
    if ($("#problemSelection").val() != -1 && confirm("Do you really want to delete this problem?"))
    {
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/DeleteProblem",
            data: JSON.stringify({
                problem: $("#problemSelection").val()
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data)
            {

            },
            error: function (data)
            {
                alert(JSON.parse(data.responseText).Message);
                return;
            }
        });
        
    }
    getProblems();
    $("#step").slideUp(500);
}

function deleteMultipleChoice()
{
    if ($("#problemSelection").val() != -1 && confirm("Do you really want to delete this problem?"))
    {
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/DeleteMultipleChoice",
            data: JSON.stringify({
                problem: $("#problemSelection").val()
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data)
            {
                getProblems();
                $("#step").slideUp(500);
            },
            error: function (data)
            {
                alert(JSON.parse(data.responseText).Message);
                return;
            }
        });

    }

    
}

function deleteGraph()
{
    if ($("#problemSelection").val() != -1 && confirm("Do you really want to delete this problem?"))
    {
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/DeleteGraph",
            data: JSON.stringify({
                problem: $("#problemSelection").val()
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data)
            {
                getProblems();
                $("#step").slideUp(500);
            },
            error: function (data)
            {
                alert(JSON.parse(data.responseText).Message);
                return;
            }
        });

    }
}

function closeDiv(object)
{
    $(object).slideUp(500);
    $(object +" :first-child").val("");
}