$(document).ready(function () {


    
    $(document).on('click', '.activityUpdate', function () {

       // alert('Hi');
        var activityId = $(this).attr("data-id");
        $.get("/Activity/SaveActivityMaster", { activityId: activityId}, function (partialView) {
            $("#activity").html(partialView);
        });
    });

    $(document).on('click', '#activitySetup', function () {
        $.get("/Activity/SaveActivityMaster", null, function (partialView) {
            $("#activity").html(partialView);
        });
    });
    $(document).on('click', '#btnActivitySave', function () {

        ///alert('hi;');
        var car = { href: "Activity/InsertActivityMaster", data: $("#frmActivitySetup").serialize(), operation: "1" };
        var result;
        result = contentDisp(car);
    });

    
    $(document).on('click', '#btnActivityDelete', function () {

        //alert('hi;');
        var car = { href: "Activity/DeleteActivityMaster", data: $("#frmActivitySetup").serialize(), operation: "1" };
        var result;
        result = contentDisp(car);
    });


    $(document).on('click', '#btnActivitySaveNew', function () {
        var car = { href: "Activity/InsertActivityMaster", data: $("#frmActivitySetup").serialize(), operation: "2" };
        var result;
        result = contentDisp(car);
    });


    function contentDisp(obj) {
        var successresult = 0;
        var someurl = $(obj).attr("href");
        var postData = $(obj).attr("data");
        var operation = $(obj).attr("operation");

        console.log('---------------------');
        console.log(obj);

        $.post(someurl, postData, function (data) {
            console.log('----------result-----------');
            console.log(data.success + ';' + data.message + ';' + data.operation);

            if (operation == '1') {
                if (data.success) {
                    debugger;
                    console.log(data.message);


                    alert(data.message);
                    //$("#frmActivitySetup").trigger("reset");
                    $('#activity').modal('toggle');
                    PopUPCostCode();
                    //PopUpShow();
                }
                else {
                    alert(data.message + '!!!!!');
                }
            }
            else if (operation == '2') {
                if (data.success) {
                    debugger;
                    console.log(data.message);
                    
                    $("#frmActivitySetup").trigger("reset");
                    alert(data.message);

                }
                else {
                    alert(data.message + '!!!!!');
                }
            }
            else {
                alert('deletr')
            }


            return data;
        });
    }

    function PopUPCostCode() {
        var caseStat = '';
        $.get("/MainActivityMaster/CostCode", { caseStat: "10" }, function (partialView) {
            $("#costCode2").html(partialView);
        });
    }
});