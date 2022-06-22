
(function ($) {
    "use strict";
    let i = 0;
    let CalcI = () => {
        i = $(".social-item").length - 1;
    }
    CalcI();

    $('#addSocial').click(function (e) {
        $.ajax({
            url: "GetSocials",
            type: "GET",
            dataType: "JSON",
            success: function (response) {
                console.log(response);

                i++;
                let social = $(".social");
                let divItem = $('<div class="social-item"></div>');

                let label = $('<label for="SocialToTeams[' + i + '].SocialId">Social</label>');
                let divSocial = $('<div class="mt-2"></div>');
                let select = $('<select name="SocialToTeams[' + i + '].SocialId" data-placeholder="Select your favorite actors" class="select2 w-full"></select>');
                let defaultOption = $('<option selected="" disabled>Select social</option>');
                select.append(defaultOption);

                let labellink = $('<label for="SocialToTeams[' + i + '].SocialId">Link</label>');
                let divLink = $('<input name="SocialToTeams[' + i + '].Link" class="input w-full border mt-2" placeholder="Input text">');

                let deleteButton = $('<span class="deleteSocial">x</span>');

                for (var j = 0; j < response.length; j++) {
                    let option = $('<option value="' + response[j].id + '" >' + response[j].name + '</option>');
                    select.append(option);
                }

                let hr = $('<hr style="margin:10px 0px"/>');


                divItem.append(label);
                divSocial.append(select);
                divItem.append(divSocial);

                divItem.append(labellink);
                divItem.append(divLink);

                divItem.append(deleteButton);

                social.append(divItem);
                social.append(hr);
            },
            error: function () { },
            complete: function () {
                $('.select2').select2()
            }
        });
    });

    //$(".deleteSocial").on("click", function (e) {
    //    console.log("slvnkljb ");
    //    $(this).parent().remove();
    //})

    $(document).on('click', '.deleteSocial', function () {
        $(this).parent().remove();
        CalcI();
    });
})($);