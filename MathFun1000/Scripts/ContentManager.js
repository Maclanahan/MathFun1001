
$(document).ready(getBooks);
$(document).ready(hideAll(0));

function hideAll(num)
{
    $("#addBook").slideUp(num);
    $("#editBook").slideUp(num);

    $("#addChapter").slideUp(num);
    $("#editChapter").slideUp(num);

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
        success: function (data) {
            //console.log(data);

            $.each(data.d, function (key, value) {
                $("#bookSelection").append('<option value="' + value[0] + '">' + value[1] + '</option>');
            });

            $("#book").slideDown(500);
            $("#book").css('visibility', '');
        },
        error: function (data) {
            //console.log(data);
        }
    });
}

function getChapters()
{
    hideAll(500);

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
            //console.log(data);

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
        success: function (data) {
            //console.log(data);
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
    hideAll(500);

    $("#step").slideUp(0);
    $("#step").empty();
    

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetSteps",
        data: JSON.stringify({ id: $("#problemSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //console.log(data);
            var i = 1;
            $.each(data.d, function (key, value) {
                var innerRowDiv = document.createElement('div');
                innerRowDiv.setAttribute('class', 'insideRow');
                innerRowDiv.setAttribute('value', value[0]);
                innerRowDiv.appendChild(makeControls());
                innerRowDiv.appendChild(makeStep(value[1]));
                innerRowDiv.appendChild(makeExample(value[2]));
                innerRowDiv.appendChild(makeRule(value[3]));

                $("#step").append(innerRowDiv);
                
                
                i++;
            });
            $(".controlBox").slideUp(0);
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
    $(newDiv).append('<input type="button" value="Answer" onclick="iAnswer()"/>');
    $(newDiv).append('<input type="button" value="Remove Answer" onclick="removeAnswer()"/>');

    return (newDiv);
}

function makeStep(step) {
    var newDiv = document.createElement('div');

    //newDiv.setAttribute('contenteditable', 'true');
    newDiv.setAttribute('class', 'stepbox');
    var par = document.createElement('p');
    par.innerHTML = step;

    newDiv.appendChild(par);
    return (newDiv);
}

function makeExample(step) {
    var newDiv = document.createElement('div');

    //newDiv.setAttribute('contenteditable', 'true');
    newDiv.setAttribute('class', 'examplebox');
    //var par = document.createElement('p');
    newDiv.innerHTML = step;

    //newDiv.appendChild(par);

    return (newDiv);
}

function makeRule(step) {

    var newDiv = document.createElement('div');
    newDiv.setAttribute('class', 'rulebox');

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetRules",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //console.log(data);

            //var newDiv = document.createElement('div');
            //newDiv.setAttribute('class', 'rulebox');

            var ruleSelect = document.createElement('select');
            ruleSelect.setAttribute('class', 'ruleSelector');
            //$(ruleSelect).append()

            $.each(data.d, function (key, value) {
                $(ruleSelect).append('<option disabled="true" value="' + value[0] + '">' + value[1] + '</option>');
            });

            $(ruleSelect).val(step);

            $(newDiv).append(ruleSelect);

            return (newDiv);
        },
        error: function (data) {
            //var newDiv = document.createElement('div');
           // newDiv.setAttribute('class', 'rulebox');

            //return newDiv;
        }

    });

    var newDiv = document.createElement('div');
    newDiv.setAttribute('class', 'rulebox');

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
        success: function (data) {
            //console.log(data);

            $("#bookName").val("");
            $("#addBook").slideUp(500);
            $("#book").slideUp(500);
            $("#addBook").css('visibility', '');
            getBooks();
        },
        error: function (data) {
            alert(JSON.parse(data.responseText).Message);
        }
    });
}

function updateBook() {
    if ($("#bookSelection").val() != -1) {
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/UpdateBook",
            data: JSON.stringify({ title: $("#editBookName").val(), id: $("#bookSelection").val() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //console.log(data);
                $("#editBookName").val("");
                $("#editBook").slideUp(500);
                $("#book").slideUp(500);
                $("#editBook").css('visibility', '');
                getBooks();
            },
            error: function (data) {
                
                alert(JSON.parse(data.responseText).Message);
            }
        });
    }
}

function addNewChapter() {
    //console.log($("#chapterName").val() + $("#chapterDesc").val() + $("#bookSelection").val());
    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/AddChapter",
        data: JSON.stringify({ title: $("#chapterName").val(), desc: $("#chapterDesc").val(), book: $("#bookSelection").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //console.log(data);

            $("#chapterName").val("");
            $("#chapterBook").slideUp(500);
            $("#chapter").slideUp(500);
            $("#addChapter").css('visibility', '');
            getChapters();
        },
        error: function (data) {
            alert(JSON.parse(data.responseText).Message);
        }
    });
}

function updateChapter() {
    //console.log($("#editChapterName").val() + $("#editChapterDesc").val() + $("#chapterSelection").val());
    if ($("#chapterSelection").val() != -1) {
        $.ajax({
            type: "POST",
            url: "ContentManager.asmx/UpdateChapter",
            data: JSON.stringify({ title: $("#editChapterName").val(), desc: $("#editChapterDesc").val(), id: $("#chapterSelection").val() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //console.log(data);
                $("#editChapterName").val("");
                $("#editChapter").slideUp(500);
                $("#chapter").slideUp(500);
                $("#editChapter").css('visibility', '');
                getChapters();
            },
            error: function (data) {

                alert(JSON.parse(data.responseText).Message);
            }
        });
    }
}

function updateProblem() {
    
    $(".insideRow").each(function () {
        //console.log($(this).children(".stepbox").children('p').text());
        //console.log($(this).children(".examplebox").html());
        //console.log($(this).children(".rulebox").children('select').val());
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
                success: function (data) {
                    console.log(data);
                    
                },
                error: function (data) {

                    alert(JSON.parse(data.responseText).Message);
                    return;
                }
            });
        

    });

    //getProblems();
    getSteps();
    
}


function openEdit(select, div, text)
{
    //console.log($(select).val());
    $("#addBook").slideUp(500);

    if ($(select).val() != -1)
    {
        $(text).val($(select + " option:selected").text());
        $(div).slideDown(500);
    }
}

function openChapterEdit(select, div) {
    //console.log($(select).val());
    $("#addChapter").slideUp(500);

    $.ajax({
        type: "POST",
        url: "ContentManager.asmx/GetChapter",
        data: JSON.stringify({ id: $("#chapterSelection").val()}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //console.log(data);

            $("#editChapterName").val($(select + " option:selected").text());
            $("#editChapterDesc").val(data.d[0][2]);
            $(div).slideDown(500);
            
        },
        error: function (data) {
            //console.log(data);
        }
    });
}

function closeDiv(object)
{
    //console.log($(object + " :first-child").val());
    $(object).slideUp(500);
    $(object +" :first-child").val("");
}