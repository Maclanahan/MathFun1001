$(document).ready(iFrameOn);

function iFrameOn()
{
    
}

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

function iSymbol() {
    document.execCommand('insertHTML', false, "&#920;");
}

function iSymbol() {
    document.execCommand('insertHTML', false, "&#920;");
}

function iAnswer() {

    var answer = "<u><answer>" + getSelectedText() + "</answer></u>";

    document.execCommand('insertHTML', false, answer);
}

function getSelectedText()
{
    
    if (window.getSelection) {
        return window.getSelection().toString();
    }

    return "";
}

function makeEditable()
{
    if ($("#problemSelection").val() != -1) {
        $("#editProblem").slideDown(500);

        $(".stepbox").attr('contenteditable', 'true');
        $(".examplebox").attr('contenteditable', 'true');
        //$(".rulebox").attr('contenteditable', 'true');

        $(".ruleSelector").children('option').each(function () {
            $(this).removeAttr('disabled');
        });
    }
}

function makeUnEditable()
{
    $(".stepbox").attr('contenteditable', 'false');
    $(".examplebox").attr('contenteditable', 'false');
    //$(".rulebox").attr('contenteditable', 'false');

    $(".ruleSelector").children('option').each(function () {
        $(this).attr('disabled');
    });
}