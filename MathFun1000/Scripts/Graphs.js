var mainArea = document.getElementById("MainContent_innerMain");

function CheckAns(ans)
{      
    var answer = document.getElementById("MainContent_RadioButtonList1_" + ans);
    
    if (answer.checked == true)
    {
        $("#CorrectLabel").css("visibility", "hidden");
        $("#CorrectLabel").text("$$\\color{green}{CORRECT!!}$$");
        MathJax.Hub.Typeset();
        $("#CorrectLabel").css("visibility", "");
    }

    for (var i = 0; i < 5; i++)
    {
        if(i == ans)
            i++;
        var check = document.getElementById("MainContent_RadioButtonList1_" + i);
        if(check.checked == true)
        {
            $("#CorrectLabel").css("visibility", "hidden");
            $("#CorrectLabel").text("$$\\color{red}{INCORRECT!!\\: Please\\: try\\: again!}$$");
            MathJax.Hub.Typeset();
            $("#CorrectLabel").css("visibility", "");
        }
    }
}

function scrollToBottomOfPage()
{
    console.log("here");
    $("html, body").animate({ scrollTop: $(document).height() - $(window).height() }, 500);
}

function stepForward()
{

}

function stepBack()
{

}