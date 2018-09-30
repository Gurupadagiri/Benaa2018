$(document).ready(function () {

    $(document).on('click', '#varianceSetupDetails', function () {
        $.get("/Variance/SaveVarianceMaster", null, function (partialView) {
            $("#varianceSetUp").html(partialView);
        });
    });
    
    $(document).on('click', '.VarianceUpdate', function () {
        var varianceId= $(this).attr("data-id");
        $.get("/Variance/SaveVarianceMaster", {
            varianceId: varianceId
        }, function (partialView) {
            $("#varianceSetUp").html(partialView);
        });
    });
    $(document).on('click', '#btnVarianceSave', function () {

        ///alert('hi;');
        var car = { href: "Variance/SaveVarianceMaster", data: $("#frmVarianceSetup").serialize(), operation: "1" };
        var result;
        result = contentDisp(car);
    });


    $(document).on('click', '#btnVarianceDelete', function () {

        //alert('hi;');
        var car = { href: "Variance/DeleteVarianceMaster", data: $("#frmVarianceSetup").serialize(), operation: "1" };
        var result;
        result = contentDisp(car);
    });


    $(document).on('click', '#btnVarianceSaveNew', function () {
        var car = { href: "Variance/SaveVarianceMaster", data: $("#frmVarianceSetup").serialize(), operation: "1" };
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
                    $('#varianceSetUp').modal('toggle');
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

                    //$("#frmGroupSetup").trigger("reset");
                    alert(data.message);
                    $("#frmVarianceSetup").trigger("reset");
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