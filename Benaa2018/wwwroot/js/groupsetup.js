$(document).ready(function () {
    $(document).on('click', '.groupCode1', function () {
        var groupId = $(this).attr("data-id");
        $.get("/GroupMaster/SaveGroupMaster", { groupId: groupId}, function (partialView) {
            $("#groupSetup").html(partialView);
        });
    });
    $(document).on('click','#groupSetuppop', function () {
        $.get("/GroupMaster/SaveGroupMaster", null, function (partialView) {
            $("#groupSetup").html(partialView);
        });

    });
    $(document).on('click', '#btnSaveGroupSetup', function () {
       // alert('Hi ');
        var car = { href: "/GroupMaster/InsertGroupMaster", data: $("#frmGroupSetup").serialize(), operation:"1" };
        var result;
        result = contentDisp(car);
        

    });

   
        $(document).on('click', '#btnSaveGroupSetupandOpen', function () {
        
        var car = { href: "GroupMaster/InsertGroupMaster", data: $("#frmGroupSetup").serialize(), operation: "2" };
        var result;
        result = contentDisp(car);
    });
    $(document).on('click', '#btnDeleteGroupSetup', function () {
        var car = { href: "GroupMaster/DeleteGroupMaster", data: $("#frmGroupSetup").serialize(), operation: "1" };
        var result;
        result = contentDisp(car);
    })


    //Main activity setup page
    $('#btnSaveMainActivitySetup').click(function () {
        debugger;
        //alert('hi');
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
        var operation = $(obj).attr("operation");
        
        console.log('---------------------');
        console.log(obj);

        $.post(someurl, postData, function (data) {
            console.log('----------result-----------');
            console.log(data.success + ';' + data.message + ';' + data.operation);

            if (operation == '1') {
                //if (data.success == 'true') {
                if (data.success) {
                    debugger;
                    console.log(data.message);
                    //alert('1 st time');
                    alert(data.message);
                    $('#groupSetup').modal('toggle');
                    PopUPCostCode();
                    //$('.activityHolder').fadeOut(500);
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
                    //alert('2nd time;');
                    alert(data.message);
                    $("#frmGroupSetup").trigger("reset");
                   
                   
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
    function PopUpShow(){
        $('#groupSetup').modal('hide');
        $('.ulHolder').css("display", "none");
    }

    function PopUPCostCode() {
        var caseStat = '';
        $.get("/MainActivityMaster/CostCode", { caseStat: "10" }, function (partialView) {
            $("#costCode2").html(partialView);
        });
    }

    });