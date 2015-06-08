function iBold()
{
    document.execCommand('bold', false, null);
}

function iUnderline()
{
    document.execCommand('underline', false, null);
}

function iItalic()
{
    document.execCommand('italic', false, null);
}

function iSymbol(symbol)
{
    document.execCommand('insertHTML', false, symbol);
}


function iAnswer()
{
    var answer = "<u><answer>" + getSelectedText() + "</answer></u>";

    document.execCommand('insertHTML', false, answer);
}

function removeAnswer()
{
    var answer = getSelectedText();

    document.execCommand('insertHTML', false, answer);
}

function addColor(color)
{
    var select = "\\\\color{" + color + "}{" + getSelectedText() + "}";

    document.execCommand('insertText', false, select);
}

function getSelectedText()
{
    if (window.getSelection)
    {
        return window.getSelection().toString();
    }

    return "";
}

function makeEditable(type)
{
    $(type).slideDown(500);

    if ($("#problemSelection" + " option:selected").attr('data-type') == 1 || type == "default")
        editDefault();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 3 || type == "multiplechoice")
        editMultipleChoice();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 2 || type == "graph")
        editGraph();
}

function editDefault()
{
    
    $(".controlBox").slideDown(500);

    $(".stepbox").attr('contenteditable', 'true');
    $(".examplebox").attr('contenteditable', 'true');

    $(".ruleSelector").removeAttr("disabled");
}

function editMultipleChoice()
{
    $(".mc").removeAttr("disabled");
    $("#question").focus();
    $("#question").select();
}

function editGraph()
{
    $(".g").removeAttr("disabled");
    $("#option1").focus();
    $("#option1").select();
}

function makeUnEditable(type)
{
    $(type).slideDown(500);

    if ($("#problemSelection" + " option:selected").attr('data-type') == 1 || type == "default")
        uneditDefault();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 3 || type == "multiplechoice")
        uneditMultipleChoice();

    else if ($("#problemSelection" + " option:selected").attr('data-type') == 2 || type == "graph")
        uneditGraph();
}

function uneditDefault()
{
    $(".controlBox").slideUp(500);
    $(".stepbox").attr('contenteditable', 'false');
    $(".examplebox").attr('contenteditable', 'false');

    $(".ruleSelector").attr("disabled", "true");
}

function uneditMultipleChoice()
{
    $(".mc").attr("disabled", "true");
}

function uneditGraph()
{
    $(".g").attr("disabled", "true");
}