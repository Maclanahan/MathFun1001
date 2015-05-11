var mainArea = document.getElementById("MainContent_innerMain");
var correct = false;
var selected = -1;


function CheckAns(id) 
{

    var radio = document.getElementsByName(id);
    for (var j = 0; j < radio.length; j++) {
        if (radio[j].checked)
           document.getElementById('txt1').value = radio[j].value;
    }

    alert(radio.length);

    /*var elementRef = document.getElementById('<%= RadioButton1.ClientID %>');
    var radioButtonListArray = elementRef.getElementsByTagName('input');
    var rbElement = elementRef.nextSibling;
    for (var i = 0; i < radioButtonListArray.length; i++) {
        var radioButtonRef = radioButtonListArray[i];

        //if (i == radioButtonNumber) {
            var labelArray = radioButtonRef.parentNode.getElementsByTagName('label');
            alert(labelArray);
            rbElement.value("DOES THIS SHOW?");

            if (labelArray.length > 0) {
                labelArray[0].innerHTML("Changed label");
                break;
            }
        //}
    }*/
}

function scrollToBottomOfPage()
{
    console.log("here");
    $("html, body").animate({ scrollTop: $(document).height() - $(window).height() }, 500);
}