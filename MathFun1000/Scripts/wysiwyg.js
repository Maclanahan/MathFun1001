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

function iSymbol(symbol) {
    document.execCommand('insertHTML', false, symbol);
}


function iAnswer() {

    var answer = "<u><answer>" + getSelectedText() + "</answer></u>";

    document.execCommand('insertHTML', false, answer);
}

function removeAnswer() {

    var answer = getSelectedText();

    document.execCommand('insertHTML', false, answer);
}

function addColor(color)
{
    var select = "\\\\color{" + color + "}{" + getSelectedText() + "}";

    document.execCommand('insertText', false, select);
}

function removeColor()
{

}

function getSelectedText()
{
    
    if (window.getSelection) {
        return window.getSelection().toString();
    }

    return "";
}

function makeEditable(type)
{
    //if ($("#problemSelection").val() != -1) {
        $(type).slideDown(500);
        $(".controlBox").slideDown(500);

        $(".stepbox").attr('contenteditable', 'true');
        $(".examplebox").attr('contenteditable', 'true');
        //$(".rulebox").attr('contenteditable', 'true');

        $(".ruleSelector").removeAttr("disabled");

        //$(".ruleSelector").children('option').each(function () {
        //    $(this).removeAttr('disabled');
        //});
    //}
}

function makeUnEditable()
{
    $(".controlBox").slideUp(500);
    $(".stepbox").attr('contenteditable', 'false');
    $(".examplebox").attr('contenteditable', 'false');
    //$(".rulebox").attr('contenteditable', 'false');

    $(".ruleSelector").attr("disabled", "true");

    //$(".ruleSelector").children('option').each(function () {
    //    $(this).attr('disabled');
    //});
}