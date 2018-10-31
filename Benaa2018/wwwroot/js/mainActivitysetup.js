$(document).ready(function () {

    ///$("#GroupId").select2();
    $(document).on('click', '#chkSetUp', function () {
        var caseStat = '';
        if ($(this).prop("checked") == true) {
            $.get("/MainActivityMaster/CostCode", null, function (partialView) {
                $("#costCode2").html(partialView);
            });
        }
        else if ($(this).prop("checked") == false) {
            $.get("/MainActivityMaster/CostCode", {
                caseStat: "10"
            }, function (partialView) {
                $("#costCode2").html(partialView);
            });
        }
    });

    $("#GroupId").select2();



    $(document).on('click', '.mainActivityUpdate', function () {
        var mainActivityId = $(this).attr("data-id");
        $.get("/MainActivityMaster/SaveMainActivity", {
            mainActivityId: mainActivityId
        }, function (partialView) {
            $("#mainActivity").html(partialView);
        });
    });

    $(document).on('click', '#costCodes34', function () {
        var caseStat = '';
        $.get("/MainActivityMaster/CostCode", { caseStat: "10" }, function (partialView) {
            $("#costCode2").html(partialView);
        });
    });
    $(document).on('click', '#mainActivitySetUp', function () {


        $.get("/MainActivityMaster/SaveMainActivity", null, function (partialView) {
            $("#mainActivity").html(partialView);
        });

    });
    $(document).on('click', '#btnMainActivitySave', function () {

        debugger;
        //$('.error').hide();
        $('.error').remove();
        //$("#frmMainActivitySetup input[data-error]").each(function () {
        //    //$('.error').hide();
        //    if ($(this).is('input:text')) {
        //        if ($(this).val() == '') {
        //            console.log($(this).val());
        //            $(this).after("<span style='color: red' class='error'>" + $(this).data('error')+"</span>");
        //        }
        //    }
           
        //});

        //$('#frmMainActivitySetup select').each(function () {
        //    if ($(this).attr('data-error')) {
        //        ///alert('Hi ddl');
        //        if ($(this).val() === "0") {
        //            alert('Hi ddl');
        //        }
        //    }
        //    //alert('Hi ddl');
        //    //if ($(this).is('input:select')) {
        //    //    alert('hi ddl');
        //    //}
        //    //else {
        //    //    alert('others');
        //    //}

        //});
    //    //alert('hi;');
        var car = { href: "MainActivityMaster/InsertMainActivityMaster", data: $("#frmMainActivitySetup").serialize(), operation: "1" };
        var result;
        result = contentDisp(car);
    });

    
    $(document).on('click', '#btnMainActivityDelete', function () {

        //alert('hi;');
        var car = { href: "MainActivityMaster/DeleteMainActivityMaster", data: $("#frmMainActivitySetup").serialize(), operation: "1"};
        var result;
        result = contentDisp(car);
    });
    $(document).on('click', '#btnMainActivitySaveNew', function () {
        var car = { href: "MainActivityMaster/InsertMainActivityMaster", data: $("#frmMainActivitySetup").serialize(), operation: "2" };
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

                    $('#mainActivity').modal('toggle');
                    //PopUpShow();
                    PopUPCostCode();
                }
                else {
                    alert(data.message + '!!!!!');
                }
            }
            else if (operation == '2') {
                if (data.success) {
                    debugger;
                    console.log(data.message);

                    
                    alert(data.message);
                    $("#frmMainActivitySetup").trigger("reset");
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