
//This function uses the Noty Jquery plugin
//Parameter 'message' - the message to display
//Used mainly for validation engine in connection with asp.net validation engine
function displayNoty(message) {
    noty({
        text: '<b>Validation Message!</b><br>' + message + '<br><b>Thank you! Click to dissapear.</b> ',
        type: 'warning',
        dismissQueue: false,
        layout: 'center',
        theme: 'defaultTheme',
        modal: true
    });
}



