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