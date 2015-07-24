//Function that will be used to show and hide the specified elements when their links are pressed
//They are in this file to take advantage of the cache feature from the broswers. This file will be loaded only once from the server.
function bindLinks () {
    $('#ctl00_ContentPlaceHolder1_EducationTrainingShowHyperLink').click(function () {
        if ($('#ctl00_ContentPlaceHolder1_EducationTrainingShowHyperLink').text() == 'Hide') {
            $('#EducationTrainingDiv').fadeOut('slow');
            $('#ctl00_ContentPlaceHolder1_EducationTrainingShowHyperLink').text('Show');
        }
        else {
            $('#EducationTrainingDiv').fadeIn('slow');
            $('#ctl00_ContentPlaceHolder1_EducationTrainingShowHyperLink').text('Hide');
            $('html,body').animate({
                scrollTop: $('#EducationTrainingDiv').offset().top
            },
                    'slow');
        }
    });

    $('#ctl00_ContentPlaceHolder1_ExperienceShowHyperLink').click(function () {
        if ($('#ctl00_ContentPlaceHolder1_ExperienceShowHyperLink').text() == 'Hide') {
            $('#ExperienceDiv').fadeOut('slow');
            $('#ctl00_ContentPlaceHolder1_ExperienceShowHyperLink').text('Show');
        }
        else {
            $('#ExperienceDiv').fadeIn('slow');
            $('#ctl00_ContentPlaceHolder1_ExperienceShowHyperLink').text('Hide');
            $('html,body').animate({
                scrollTop: $('#ExperienceDiv').offset().top
            },
                    'slow');
        }
    });

    $('#ctl00_ContentPlaceHolder1_EmployeeActiveContractsShowHyperLink').click(function () {
        if ($('#ctl00_ContentPlaceHolder1_EmployeeActiveContractsShowHyperLink').text() == 'Hide') {
            $('#ActiveContractsDiv').fadeOut('slow');
            $('#ctl00_ContentPlaceHolder1_EmployeeActiveContractsShowHyperLink').text('Show');
        }
        else {
            $('#ActiveContractsDiv').fadeIn('slow');
            $('#ctl00_ContentPlaceHolder1_EmployeeActiveContractsShowHyperLink').text('Hide');
            $('html,body').animate({
                scrollTop: $('#ActiveContractsDiv').offset().top
            },
                    'slow');
        }
    });

    $('#ctl00_ContentPlaceHolder1_EmployeePasiveContractsShowHyperLink').click(function () {
        if ($('#ctl00_ContentPlaceHolder1_EmployeePasiveContractsShowHyperLink').text() == 'Hide') {
            $('#PasiveContractsDiv').fadeOut('slow');
            $('#ctl00_ContentPlaceHolder1_EmployeePasiveContractsShowHyperLink').text('Show');
        }
        else {
            $('#PasiveContractsDiv').fadeIn('slow');
            $('#ctl00_ContentPlaceHolder1_EmployeePasiveContractsShowHyperLink').text('Hide');
            $('html,body').animate({
                scrollTop: $('#PasiveContractsDiv').offset().top
            },
                    'slow');
        }
    });
}

//function bindLinks(action, reaction) {
//    $(action).click(function () {
//        if ($(action).text() == 'Hide') {
//            $(reaction).fadeOut('slow');
//            $(action).text('Show');
//        }
//        else {
//            $(reaction).fadeIn('slow');
//            $(action).text('Hide');
//            $('html,body').animate({
//                scrollTop: $(reaction).offset().top
//            },
//                    'slow');
//        }
//    });
//}
//End
