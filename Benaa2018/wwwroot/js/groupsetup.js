$(document).ready(function () {
    $('#btnSaveGroupSetup').click(function () {
       // alert('Hi ');
        var car = { href: "GroupMaster/InsertGroupMaster", data: $("#frmGroupSetup").serialize() };
        var result = contentDisp(car);
        console.log('result from child' + result);
        if (result) {
            alert('Data Saved successfully');
            $('#groupSetup').modal('hide');
            $('.ulHolder').css("display", "none");

            var ert = '<div class=\"col-md-4\">';
            ert += '<h2 class=\"header1\" > Variances</h2 >';
            ert += '<div class=\"costCodeList costCodeListOdd\">';
            ert += '<a href="javascript:void(0);" class="newActionBtn">0 - 9 Plans</a>';
            ert += '</div></div>';
            $("#contentDetails").append(ert);
            if ($("#contentDetails div:last-child").hasClass("costCodeListOdd")) {
                var ert = '<div class=\"costCodeList costCodeListOdd\">';
                ert += '<a href="javascript:void(0);" class="newActionBtn">0 - 9 Plans</a>';
                ert += '</div>';
                $("#contentDetails").append(ert);
            }
            else {

            }
        }
        else {
            alert('Data did not saved successfully');
        }

    });

    $('#btnSaveGroupSetupandOpen').click(function () {
        alert('Hi ');
    });

    $('#btnDeleteGroupSetup').click(function () {
        alert('Hi ');
    })


    //Main activity setup page
    $('#btnSaveMainActivitySetup').click(function () {
        debugger;
        alert('hi');
        var car = { href: "MainActivityMaster/InsertMainActivityMaster", data: $("#frmMainActivitySetup").serialize() };
        var result = contentDisp(car);
        console.log('result from child' + result);
        if (result) {
            alert('Data Saved successfully');
            
            $('#mainActivity').modal('hide');
            $('.ulHolder').css("display", "none");
        }
    });
        

    
    $('#btnActivitySave').click(function () {
        debugger;
        
        var car = { href: "Activity/InsertActivityMaster", data: $("#frmActivitySetup").serialize() };
        var result = contentDisp(car);
        console.log('result from child' + result);
        if (result) {
            alert('Data Saved successfully');

            $('#activity').modal('hide');
            $('.ulHolder').css("display", "none");
        }
    });

        function contentDisp(obj) {
            var successresult = 0;
            var someurl = $(obj).attr("href");
            var postData = $(obj).attr("data");
            console.log('---------------------');
            console.log(obj);


            $.ajax({
                url: someurl,
                type: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                },
                data: postData,
                success: function (data) {
                    debugger;
                    return true;
                },
                error: function (data) {
                    return false;
                }
            });
            debugger;
            return true;
        }


    });