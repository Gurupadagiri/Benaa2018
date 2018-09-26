﻿$(document).on("click", "#addRemoveButton", function (event) {
    if ($(this).val() == "Remove Checklist") {
        $('.permanentNot').remove();
        $('.cloneingboxholder').hide();
    }
    else {

        $('.multiInputHolder').show();
    }
});
$(window).load(function () {
    $(document).on('click', '.type1', function () {
        var ids = $(this).attr('dataids');
        $('#hiddenToDoDetailsId').val(ids);
        var postData = { "ToDoDetailsId": parseInt(ids) };
        $.post("ToDo/SearchToDoMessage", postData, function (result) {
            $.each(JSON.parse(result), function (key, value) {
                var items = "<div><span>" + value.ToDoMessageTitle + "</span> <span>" + value.CreatedBy + " </span></div>"
                $('#messageId').append(items);
            });
            $('#messagepopup').modal('show');
        });
    });
});
$(document).ready(function () {
    $(document).on("click", "td[aria-describedby='internaluser_ToDoDetails.Title']", function () {
        var ids = $(this).find('a').attr('dataids');
        var postData = { "ToDoDetailsId": parseInt(ids) };
        $("#ToDoUpdate").load('ToDo/PopulateTodoInfo', postData);
    });

    $(document).on('click', '#btnAddExtraUpdate', function (e) {
        for (var j = 3; j < 6; j++) {
            var index = 'cloneingboxholder' + j;
            $('#cloneingboxholder' + j).show();
        }
        itemCount = itemCount + 3;
        itemMaxCount = itemMaxCount + 3;
        $('#hdnCheckListIndex').val(itemCount);
    });
    $(document).on('click', '#btnUpdateToDo', function (e) {
        var postData = { "toDoAllView": $("#frmSubmitUpdateToDoMaster").serialize() };
        $.post("ToDo/UpdateToDo", postData, function (result) {
            if (result == "Success") {
                alert("Todo Saved Successfully");
            } else {
                alert("Some problem occurred!! Please try again");
            }
        });
    });
    var itemCount = 3;
    var itemMaxCount = itemCount + 3;
    $('#hdnCheckListIndex').val(3);
    $('#todoContain').hide();
    $('.todoAreaVisible').hide();
    $("#projectname").text('To-Do');
    $('#ddltravelmode111').multiselect();
    $('#ddlUserDiffer1').multiselect();
    $('#ddlUserDiffer2').multiselect();
    $('#UserMasters').multiselect();
    $('#ddlUserDiffer0').multiselect();
    $('#ddlPermissionUserAssign').multiselect();
    $('#ddltravelmodeSearchFilter').multiselect();
    $("#ddlUserDiffer1").removeAttr("style");
    $("#ddlUserDiffer2").removeAttr("style");
    $("#ddlUserDiffer0").removeAttr("style");
    $('#addRemoveButton').click(function () {
        if ($(this).val() == "Remove Checklist") {
            $('.permanentNot').remove();
            $('.cloneingboxholder').hide();
        } else {
            $('.cloneingboxholder').show();
        }
    });
    $('#btnAddExtra').click(function () {
        var startindex = $('#checkListAppend .cloneingboxholder').length;
        var maxindex = startindex + 3;
        for (var i = startindex; i < maxindex; i++) {
            var innerhtml = '';
            innerhtml = '<div class="cloneingboxholder permanentNot">';
            innerhtml += '<div class="grabHandle dragHandle grabbable ui-sortable-handle">';
            innerhtml += '<span id=""><img src="images/drag.png" id="" style="border-width: 0px; height: 30px;"></span></div><div class="liColumn">';
            innerhtml += '<input type="checkbox" asp-for="lstCheckListDetail[Model.lstCheckListDetail.IndexOf[' + i + '].ToDoIsCheckList" />';
            innerhtml += '<label  class="lineItemCheck"></label>';
            innerhtml += '</div><div class="liColumn1" style="">';
            innerhtml += '<input type="text" id="lstCheckListDetail_(0)__ToDoCheckListTitle"  name="lstCheckListDetail[' + i + '].ToDoCheckListTitle" rows="2" cols="20" class="flatTextBox" style="width: 100%; white-space: normal; overflow: hidden; word-wrap: break-word; resize: horizontal; height: 32px;" />';
            innerhtml += '<span id="linedescription" style="color:Red;display:none;">Please enter a maximum of 256 characters</span>';
            innerhtml += '</div>';
            innerhtml += '<div class="liColumn1" title="" style="display:none">';
            innerhtml += '<a class="chosen-single"></a>';
            innerhtml += '<select id="lstCheckListDetail[' + i + '].ToDoCheckListUserId" class="ddldropdown1" name="lstCheckListDetail[' + i + '].ToDoCheckListUserId">';
            var erty = $('#lstCheckListDetail_0__ToDoCheckListUserId').html();
            innerhtml += erty;
            innerhtml += '</select></div>';
            $('#checkListAppend').append(innerhtml);
        }
    });
    $('#btnAddTag').click(function () {
        var title = $('#txtTag').val();
        $.post("ToDo/SaveTag", { tagTitle: title }, function (result) {
            if (result == "success") {
                alert('Success');
            }
        });
    });
    $('#btnAssignNewUsers').click(function () {
        var userSelected = $('#ddlPermissionUser').val();
        var title = $('#txtTag').val();
        $.post("ToDo/AssignToDoUser", { userids: userSelected, ToDoDetailsId: $('#hdnAssignNewUsersRole').val() }, function (result) {
            alert('assign user successfull');
        });
    });
    $('.multipleSelectBoxes .mainButton').click(function () {
        $('.multiCheckBoxHolder, .multiInputHolder').slideToggle();
        if ($(this).val() == "Add Checklist")
            $(this).val("Remove Checklist")
        else
            $(this).val("Add Checklist");
    });
    $('.cloneBtnHolder').click(function () {
        $(".cloneMainContainer").clone().prependTo(".cloneBtnHolder");
    });
    $(".checkboxAssignChecklist input[type=checkbox]").change(function () {
        if (this.checked) {
            $('.chosen-container.chosen-container-single').show();
        } else {
            $('.chosen-container.chosen-container-single').hide();
        }
    });
    $('.checkListUser').click(function () {
        if ($(this).prop("checked") == true) {
            $('.liddl').show();
            $(".liColumn1").removeAttr("style");
            $(".ddldropdown1").show();
        }
        else if ($(this).prop("checked") == false) {
            $('.liddl').hide();
            $(".ddldropdown1").hide();
        }
    });
    $('.todoleftmenu').click(function () {
        $('a.todoleftmenu').removeClass('selected-project');
        $(this).addClass('selected-project');
        $('#todoContain').show();
        $('#calendarpage').hide();
        $('.todoAreaVisible').show();
        $("#projectname").text($(this).text());
        $('#lblJobsites').text($(this).text());
        var projectId = $(this).attr('data-projectid');
        $('#ProjectId').val(projectId);
        $('#hdnProjectIdToDo').val(projectId);
        $('#spnproject').text($(this).text());
        var postData = { "projectId": parseInt(projectId) };
        $.post("ToDo/SearchToDobyProject", postData, function (result) {
            BindToDoGrid(result);
        });
        $('#internaluser_toppager_left').empty().append('<button id="btnExcelLink"><span class="ui-icon ui-icon-excel"></span></button>');
    });
    $('#FromCompletion').hide();
    $('#ToCompletion').hide();
    $('#FromDue').hide();
    $('#TomDue').hide();
    $('#ddlDueDate').click(function () {
        var dueDate = $(this).val();
        if (dueDate == 2) {
            $('#FromDue').show();
            $('#TomDue').show();
        }
        else {
            $('#FromDue').hide();
            $('#TomDue').hide();
        }
    });
    $('#ddlCompletionDate').click(function () {
        var completionDate = $(this).val();
        if (completionDate == 2) {
            $('#FromCompletion').show();
            $('#ToCompletion').show();
        }
        else {
            $('#FromCompletion').hide();
            $('#ToCompletion').hide();
        }
    });
    $('#btnCancelPostComment').click(function () {
        //location.reload(true);
    });
    $('#ddlAssign').change(function () {
        var text = $(this).val();
        if (text == "3") {
            var grid = $("#internaluser");
            var rowKey = grid.getGridParam("selrow");
            if (!rowKey)
                alert("No rows are selected");
            else {
                var selectedIDs = grid.getGridParam("selarrrow");
                var result = "";
                for (var i = 0; i < selectedIDs.length; i++) {
                    result += selectedIDs[i] + ",";
                }
                $.post("ToDo/SaveToDoIsComplete", { ToDoDetailsId: result }, function (result) {
                    if (result != '') {
                        BindToDoGrid(result);
                        alert('success');
                    }
                });
            }
        }
        else if (text == "2") {
            var grid = $("#internaluser");
            var rowKey = grid.getGridParam("selrow");
            if (!rowKey)
                alert("No rows are selected");
            else {
                var selectedIDs = grid.getGridParam("selarrrow");
                var result = "";
                for (var i = 0; i < selectedIDs.length; i++) {
                    result += selectedIDs[i] + ",";
                }
                $('#hdnAssignNewUsersRole').val(result);
                $('#todoAssignNewUsers').modal('show');
            }
        }
        else if (text == "5") {
            var grid = $("#internaluser");
            var rowKey = grid.getGridParam("selrow");
            if (!rowKey)
                alert("No rows are selected");
            else {
                var selectedIDs = grid.getGridParam("selarrrow");
                var result = "";
                for (var i = 0; i < selectedIDs.length; i++) {
                    result += selectedIDs[i] + ",";
                }
                $.post("ToDo/DeleteToDo", { ToDoDetailsId: result }, function (result) {
                    alert('success');
                });
            }
        }
        else if (text == "4") {
            var grid = $("#internaluser");
            var rowKey = grid.getGridParam("selrow");
            if (!rowKey)
                alert("No rows are selected");
            else {
                var selectedIDs = grid.getGridParam("selarrrow");
                var result = "";
                for (var i = 0; i < selectedIDs.length; i++) {
                    result += selectedIDs[i] + ",";
                }
                $.post("ToDo/CopyToDo", { ToDoDetailsId: result }, function (result) {
                    alert('success');
                    $('#hdnProjectIdToDo').val(projectId);
                    $.post("ToDo/SearchToDobyProject", { projectId: parseInt($('#hdnProjectIdToDo')) }, function (result) {
                        BindToDoGrid(result);
                    });
                });
            }
        }
    });
});

$(document).ready(function () {
    $('.bootstrap-switch-wrapper').click(function () {
        if ($(this).hasClass('bootstrap-switch-off')) {
            $(this).removeClass('bootstrap-switch-off');
            $(this).addClass('bootstrap-switch-on');
            $('.bootstrap-switch-container').css('margin-left', '0');
            $('.bt-link-schedule-item--datetime-picker').hide();
            $('.sheduleItemHolder').show();
        } else {
            $(this).addClass('bootstrap-switch-off');
            $(this).removeClass('bootstrap-switch-on');
            $('.bootstrap-switch-container').css('margin-left', '-71px');
            $('.bt-link-schedule-item--datetime-picker').show();
            $('.sheduleItemHolder').hide();
        }
    });
    BindToDoGridInitial(response){
        $("#internaluser").jqGrid({
            colModel: [
                { name: "ToDoDetails.TodoDetailsID", label: "TodoDetailsID", width: 53, key: true, hidden: true },
                { name: "ToDoDetails.IsCheckedList", label: "", width: 18, key: true, formatter: IsCheckedList },
                {
                    name: "ToDoDetails.Title", label: "Title", width: 53, formatter: formatTitle
                },
                {
                    name: "TotalNumberOfMessages", label: "<img src='/images/miComments.png' />", width: 20, formatter: formatNumberOfMessages
                },
                {
                    name: "ToDoDetails.IsMarkedComplete", label: "Complete", editable: true, sortable: true, edittype: 'checkbox',
                    formatter: 'checkbox', formatoptions: { disabled: false }, width: 53, formatter: formatCheckBox
                },
                { name: "ToDoDetails.Priority", label: "Priority", width: 65, formatter: IsPriority },
                { name: "UserNames", label: "AssignedTo", width: 70, formatter: formatAssignedTo },
                { name: "ToDoDetails.AssignedTo", label: "Related Daily Log", width: 65 },
                { name: "ToDoDetails.AssignedTo", label: "Files", width: 65 },
                { name: "ToDoDetails.Duedate", label: "Due", width: 41 },
                { name: "ToDoDetails.CreatedBy", label: "CreatedBy", width: 41 },
                { name: "TagNames", label: "Tags", width: 65 }
            ],
            data: response,
            iconSet: "fontAwesome",
            idPrefix: "g5_",
            rownumbers: false,
            sortname: "Title",
            sortorder: "desc",
            threeStateSort: true,
            sortIconsBeforeText: true,
            headertitles: true,
            rowList: [5, 10, 20, "10000:All"],
            toppager: true,
            multiselect: true,
            toolbarfilter: true,
            pager: true,
            rowNum: 10,
            height: 'auto',
            viewrecords: true,
            searching: {
                defaultSearch: "cn"
            },
            cellEdit: true,
            caption: "",
            reload: false,
            refresh: true,
            onCellSelect: function (rowid, index, contents, event) {
                var cm = $("#internaluser").jqGrid('getGridParam', 'colModel');
                if (cm[index].name == "ToDoDetails.IsMarkedComplete") {
                    var rowData = $('#internaluser').jqGrid('getRowData', rowid);
                    var postData = { "todoId": parseInt(rowData["ToDoDetails.TodoDetailsID"]), "projectId": parseInt($('#ProjectId').val()) };
                    $.post("ToDo/IsToDoComplete", postData, function (result) {
                        if (result !== '') {
                            $('#' + rowid).delay(2500).addClass('strikeout').show().slideUp(1000);
                            BindToDoGrid(result);
                        }
                    });
                }
                if (cm[index].name == "TotalNumberOfMessages") {
                    var rowData = $('#internaluser').jqGrid('getRowData', rowid);
                    $('#hiddenToDoDetailsId').val(rowData["ToDoDetails.TodoDetailsID"]);
                    var postData = { "ToDoDetailsId": parseInt(rowData["ToDoDetails.TodoDetailsID"]) };
                    $.post("ToDo/SearchToDoMessage", postData, function (result) {
                        $.each(JSON.parse(result), function (key, value) {
                            var items = "<div><span>" + value.ToDoMessageTitle + "</span> <span>" + value.CreatedBy + " </span></div>"
                            $('#messageId').append(items);
                        });
                        $('#messagepopup').modal('show');
                    });
                }
            }
        });
    }
    $("#internaluser").jqGrid('navGrid', '#gridpager',
        { add: false, edit: false, del: false, search: false, refresh: true },
        { width: 5 });

    $("#internaluser").jqGrid('setLabel',
        'Complete',
        '<img src="~/images/message.png width=16 height=16>');
    $('#btnExcelLink').click(function () {
        JSONToCSVConvertor(JSON.stringify($('#internaluser').jqGrid('getRowData')), 'Title', true);
    });
    $(document).on('click', '.mainTdToggleBtn', function () {
        $(this).parents('.asignToToggleHolder').find('.toggleBody').toggle().slow();
    });
    function JSONToCSVConvertor(JSONData, ReportTitle, ShowLabel) {
        var arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;
        var CSV = '';
        //Set Report title in first row or line

        CSV += ReportTitle + '\r\n\n';
        //This condition will generate the Label/Header
        if (ShowLabel) {
            var row = "";
            //This loop will extract the label from 1st index of on array
            for (var index in arrData[0]) {

                //Now convert each value to string and comma-seprated
                row += index + ',';
            }
            row = row.slice(0, -1);
            //append Label row with line break
            CSV += row + '\r\n';
        }
        //1st loop is to extract each row
        for (var i = 0; i < arrData.length; i++) {
            var row = "";

            //2nd loop will extract each column and convert it in string comma-seprated
            for (var index in arrData[i]) {
                row += '"' + arrData[i][index] + '",';
            }
            row.slice(0, row.length - 1);
            //add a line break after each row
            CSV += row + '\r\n';
        }
        if (CSV == '') {
            alert("Invalid data");
            return;
        }
        //Generate a file name
        var fileName = "MyReport_";
        //this will remove the blank-spaces from the title and replace it with an underscore
        fileName += ReportTitle.replace(/ /g, "_");
        //Initialize file format you want csv or xls
        var uri = 'data:text/csv;charset=utf-8,' + escape(CSV);
        var link = document.createElement("a");
        link.href = uri;
        //set the visibility hidden so it will not effect on your web-layout
        link.style = "visibility:hidden";
        link.download = fileName + ".csv";
        //this part will append the anchor tag and remove it after automatic click
        console.log(document.body);
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    };
});
function BindToDoGrid(result) {
    $('#internaluser').jqGrid('clearGridData');
    $("#internaluser").jqGrid('setGridParam', { data: jQuery.parseJSON(result) }).trigger('reloadGrid');
}
function IsCheckedList(cellValue, options, rowObject) {
    var linkMessage = '';
    if (cellValue) {
        linkMessage = '<img src="/images/ToDoListIndicator.png" style="padding-right:5px; vertical-align:middle" title="This to-do contains a checklist">';
    }
    return linkMessage;
}
function IsPriority(cellValue, options, rowObject) {
    var linkMessage = '';
    if (cellValue.toUpperCase() === "HIGHEST") {
        linkMessage = '<img src="/images/warning.png" style="padding-right:5px; vertical-align:middle">';
    }
    return linkMessage + ' ' + cellValue.toUpperCase();
}
function formatAssignedTo(cellValue, options, rowObject) {
    var dataid = rowObject.ToDoDetails.TodoDetailsID;
    var linkMessage = '<div class="asignToToggleHolder">' +
        '<div class="toggleHolder" >' +
        '<div class="mainName">Admin</div>' +
        '<div class="asignToRightHolder">' +
        '<div class="numberLabel assignedTo" id="assignedTo">(+2) </div>' +
        '<div class="mainTdToggleBtn">...</div>' +
        '</div>' +
        '</div>' +
        '<div class="toggleBody">' +
        '<ul>' +
        '<li>raja bajaShahnawaz Khan  </li>' +
        '<li>Ahmed Garrash </li>' +
        '<li>Al Asaseya</li>' +
        '</ul>' +
        '</div>' +
        '</div>';
    return linkMessage;
}
function formatCheckBox(cellValue, options, rowObject) {
    var dataid = rowObject.ToDoDetails.TodoDetailsID;
    var linkMessage = '<input class="single-to-do-check" data-val="true" data-val-required="The IsMarkedComplete field is required." id="ismarkedcomplete' + dataid + '" name="ismarkedcomplete' + dataid + '" type="checkbox"><label for="ismarkedcomplete' + dataid + '" class="single-to-do-check"></label>';
    return linkMessage;
}
function formatNumberOfMessages(cellValue, options, rowObject) {
    var dataid = rowObject.ToDoDetails.TodoDetailsID;
    var linkMessage = "<a href='javascript:void(0);' data-toggle='modal'  class='type1' dataids=" + dataid + ">" + cellValue + "</a>";
    return linkMessage;
};
function formatTitle(cellValue, options, rowObject) {
    var dataid = rowObject.ToDoDetails.TodoDetailsID;
    var linkMessage = "<a href='#ToDoUpdate' data-toggle='modal' class='typeTitle' dataids=" + dataid + ">" + cellValue + "</a>";
    return linkMessage;
}
$(document).ready(function () {
    $('#btnPostComment').click(function () {
        var textComment = $('#titleMessage').val();
        var owner = $('input[name="chkOwner"]').prop('checked');
        var notify = $('input[name="chkNotify"]').prop('checked');
        var sub = $('input[name="chkSub"]').prop('checked');
        var postData = { todoDetailsId: $('#hiddenToDoDetailsId').val(), titleMessage: textComment, owner: owner, notify: true, sub: sub };
        $.post("ToDo/SaveToDoMessage", postData, function (result) {
            if (result == "success") {
                alert('sucees');
                $('#titleMessage').val('');
                $('#messageId').prepend("<div><span>" + textComment + "</span></div>");
            }
        });
    });

    $('#ddlTag').multiselect({
        includeSelectAllOption: true
    });
    $('#ddlTagUpdate').multiselect({
        includeSelectAllOption: true
    });
    $('#btnSaveAndNewToDo').click(function (e) {
        $.post("ToDo/SaveToDo", $("#frmSubmitToDoMaster").serialize(), function (result) {
            if (data == "Success") {
                alert("Todo Saved Successfully");
                $('#todoinfoModal').show();
            } else {
                alert("Some problem occurred!! Please try again");
            }
        });
    });
    $("#btnSaveToDo").click(function (e) {
        $.post("ToDo/SaveToDo", $("#frmSubmitToDoMaster").serialize(), function (data) {
            if (data.success) {
                $("#frmSubmitToDoMaster").find("input[type='text']").each(function (i, element) {
                    $(this).val('');
                });
                if (data.toDoAllModels !== '') {
                    $('#internaluser').jqGrid('clearGridData');
                    $("#internaluser").jqGrid('setGridParam', { data: JSON.parse(data.toDoListContent) });
                    $("#internaluser").trigger('reloadGrid');
                }
                $('#todoinfoModal').removeClass('in').hide();
                alert("Todo Saved Successfully");
            }
            else {
                alert("Some problem occurred!! Please try again");
            }
        });
    });
    $('#btnUpdatetodoResults').click(function (e) {
        var Keywords = $('#txtToDoKeyWords').val();
        var AssignedTo = $('#ddlAssignedToToDoSearch :selected').val();
        var usersAssignedTo = $('#ddlToDoAssignToDoSearch :selected').val();
        var status = $('#ddlToDoStatusToDoSearch :selected').val();
        var priority = $('#ddlToDoPriorityToDoSearch').next().children('button').children().text();
        var projectId = $('#ProjectId').val();
        var selectedTags = $('#ddlTagToDoSearch').next().children('button').children().text();
        var postdata = { keywords: Keywords, assignedto: AssignedTo, usersAssignedTo: parseInt(usersAssignedTo), status: parseInt(status), priority: priority, tags: selectedTags, selectedProjectId: projectId };
        $.post("ToDo/SearchToDo", postdata, function (result) {
            $('#internaluser').jqGrid('clearGridData');
            $("#internaluser").jqGrid('setGridParam', { data: jQuery.parseJSON(result), datatype: 'local' }).trigger('reloadGrid');
        });
    });
    $('#ddlToDoPriorityToDoSearch').multiselect();
    $('#ddlTagToDoSearch').multiselect();
    $('#FromCompletion').hide();
    $('#ToCompletion').hide();
    $('#FromDue').hide();
    $('#TomDue').hide();
    $('#ddlDueDate').click(function () {
        var dueDate = $(this).val();
        if (dueDate == 2) {
            $('#FromDue').show();
            $('#TomDue').show();
        }
        else {
            $('#FromDue').hide();
            $('#TomDue').hide();
        }
    });
    $('#ddlCompletionDate').click(function () {
        var completionDate = $(this).val();
        if (completionDate == 2) {
            $('#FromCompletion').show();
            $('#ToCompletion').show();
        }
        else {
            $('#FromCompletion').hide();
            $('#ToCompletion').hide();
        }
    });
    var item = 3;
    var itemLength = item + 3;
    $('.checkListUser').click(function () {
        if ($(".checkListUser").prop('checked') == true) {
            $('.ddlCheckListUser').show();
        }
        else {
            $('.ddlCheckListUser').hide();
        }
    });
});