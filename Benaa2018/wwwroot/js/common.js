$(document).ready(function () {
    $('[data-toggle="popover"]').popover({ html: true });
    $(".closeModal").click(function () {
        $("#groupAddModal").hide();
    });
    $(".closeModal").click(function () {
        $("#groupMinusModal").hide();
    });
    $(".closeModal").click(function () {
        $("#locationModal").hide();
    });
    $('.newBtn, .newActionBtn').click(function (e) {
        $(this).parent().children('.ulHolder').slideToggle();
    });
    $('.newActionBtn').click(function (e) {
        $(this).toggleClass('close1');
        $(this).parent().children('.innercaotHolder').slideToggle();
    });
    $(document).on('click', '#usermasters_UserIsForumHandle', function (e) {
        if ($(this).prop('checked')) {
            $("#usermasters_UserForumHandle").prop("readonly", false);
        }
        else {
            $("#usermasters_UserForumHandle").prop("readonly", true);
        }
    });
    $(document).on('click', '#saveUserPreference', function (e) {
        $('#usermasters_UserFirstName').removeAttr('style');
        $('#usermasters_UserLastName').removeAttr('style');
        $('#usermasters_UserName').removeAttr('style');
        $('#usermasters_UserPassword').removeAttr('style');
        $('#usermasters_UserForumHandle').removeAttr('style');
        var firstName = $('#usermasters_UserFirstName').val().trim();
        var lastName = $('#usermasters_UserLastName').val().trim();
        var userName = $('#usermasters_UserName').val().trim();
        var password = $('#usermasters_UserPassword').val().trim();
        var forumValidate = '0';
        if (!$('#usermasters_UserForumHandle').is('[readonly]')) {
            forumValidate = '1';
        }
        var validate = '0';
        if (firstName == '') {
            $('#usermasters_UserFirstName').css('border-color', 'red');
            validate = '1';
        }
        if (lastName == '') {
            $('#usermasters_UserLastName').css('border-color', 'red');
            validate = '1';
        }
        if (userName == '') {
            $('#usermasters_UserName').css('border-color', 'red');
            validate = '1';
        }
        if (password == '') {
            $('#usermasters_UserPassword').css('border-color', 'red');
            validate = '1';
        }
        if (forumValidate == '1') {
            if ($('#usermasters_UserForumHandle').val().trim() == '') {
                $('#usermasters_UserForumHandle').css('border-color', 'red');
            }
        }
        if (validate == '0') {
            $.ajax({
                url: "Home/UserPreferences",
                type: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                },
                data: $("#frmSubmitUserPreferenceMaster").serialize(),
                success: function (result) {
                    if (result == '1') {
                        alert("User Details Successfully Added");
                        location.reload(true);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        }
    });
    $(document).on('click', '#chkAllPermissionEmail', function (e) {
        if ($('#chkAllPermissionEmail').prop('checked')) {
            $('.chkEmailAllNotification').attr('checked', true);
        }
        else {
            $('.chkEmailAllNotification').attr('checked', false);
        }
    });

    $("#chkAllPermissionText").click(function (e) {
        if ($('#chkAllPermissionText').prop('checked')) {
            $('.chkTextAllNotification').attr('checked', true);
        }
        else {
            $('.chkTextAllNotification').attr('checked', false);
        }
    });
    $("#chkAllPermissionPushOn").click(function (e) {
        if ($('#chkAllPermissionPushOn').prop('checked')) {
            $('.chkAllPushPermission').attr('checked', true);
        }
        else {
            $('.chkAllPushPermission').attr('checked', false);
        }
    });

    $("#chkAllPermissionAllUsers").click(function (e) {
        if ($('#chkAllPermissionAllUsers').prop('checked')) {
            $('.chkAUsersAllNotification').attr('checked', true);
        }
        else {
            $('.chkAUsersAllNotification').attr('checked', false);
        }
    });
    $("#chkAllView").click(function (e) {
        if ($('#chkAllView').prop('checked')) {
            $('.IsChkViewPermission').attr('checked', true);
        } else {
            $('.IsChkViewPermission').attr('checked', false);
        }
    });

    $("#chkAllAdd").click(function (e) {
        if ($('#chkAllAdd').prop('checked')) {
            $('.IsChkAddPermission').attr('checked', true);
        }
        else {
            $('.IsChkAddPermission').attr('checked', false);
        }
    });

    $("#chkAllEdit").click(function (e) {
        if ($('#chkAllEdit').prop('checked')) {
            $('.IsChkEditPermission').attr('checked', true);
        } else {
            $('.IsChkEditPermission').attr('checked', false);
        }
    });

    $("#chkAllDelete").click(function (e) {
        if ($('#chkAllDelete').prop('checked')) {
            $('.IsChkDeletePermission').attr('checked', true);
        }
        else {
            $('.IsChkDeletePermission').attr('checked', false);
        }
    });
    $("#btnPermissionUser").click(function () {
        var postData = $("#frmSubmitUserPreferenceMaster").serializeArray();
        $.ajax({
            url: "Home/SetUserPreference",
            type: 'Get',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            },
            data: {
                userPreferenceViewModel: postData,
                caseSet: 1,
                setUserId: 23
            },
            success: function (data) {
                if (data == true) {
                    infoForm.find("input[type='text']").each(function (i, element) {
                        infoForm.serialize();
                    });
                    alert("Project Details Successfully Added");
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    });
    $('[data-toggle="popover"]').popover({ html: true });
    $(".closeModal").click(function () {
        $("#groupAddModal").hide();
    });
    $(".closeModal").click(function () {
        $("#groupMinusModal").hide();
    });
    $(".closeModal").click(function () {
        $("#locationModal").hide();
    });
    var mmWidth = $(".mainContentDiv").outerWidth() + 10;
    var lftNavWidth = $("#leftNavCon").outerWidth() + 10;
    var curentmmWidth = mmWidth - lftNavWidth;
    $(".mainContentDiv").css({ marginLeft: lftNavWidth });
    $('.openIcon').click(function () {
        if ($(this).hasClass('openSlide')) {
            $(".mainContentDiv").css({ marginLeft: "20px" });
            $("#leftNavCon").css({ marginLeft: -lftNavWidth });
            $(".openIcon").css({ right: '-23px' });
            $(this).removeClass('openSlide').addClass('closeSlide');
            $('.leftOuterBtn').show();
        }
        else {
            $(".mainContentDiv").css({ marginLeft: lftNavWidth });
            $("#leftNavCon").css({ marginLeft: "0px" });
            $(".openIcon").css({ right: '-8px' });
            $(this).removeClass('closeSlide').addClass('openSlide');
            $('.leftOuterBtn').hide();
        }
    });
    $('.leftOuterBtn').click(function () {
        $(".mainContentDiv").css({ marginLeft: lftNavWidth });
        $("#leftNavCon").css({ marginLeft: "0px" });
        $(".openIcon").css({ right: '-23px' });
        $(".openIcon").removeClass('closeSlide').addClass('openSlide');
        $(this).hide();

    });
    var date_input = $('.cal'); //our date input has the name "date"
    var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
    date_input.datepicker({
        format: 'mm/dd/yyyy',
        container: container,
        todayHighlight: true,
        autoclose: true,
    });
    // tooltip demo
    $('.tooltip-div').tooltip({
        selector: "[data-toggle=tooltip]",
        container: "body"
    });
    $('.withCheckbox').multiselect({
        columns: 1,
        placeholder: '--Select--',
        search: true,
        selectAll: true
    });

    $('.sort-me').sortable({ connectWith: '.sort-me' });
    $('.sort-me').sortable({ handle: '.handle' }); // This one isn't connected back.
    $('.sort-me1').sortable({ connectWith: '.sort-me1' });
    $('.sort-me1').sortable({ handle: '.handle' }); // This one isn't connected back.

    $('.myColse').click(function () {
        $(this).parent().parent().parent().hide();
    });
    $('.grayClose').click(function (e) {
        $(this).parent().parent().hide();
    });
    $(".myPlus").click(function (e) {
        $(".myPlusContainer").show();
        $(".myFilterContainer").hide();
        $(".mySortContainer").hide();
        e.stopPropagation();
    });
    $(".myPlusContainer").click(function (e) {
        e.stopPropagation();
    });
    $(document).click(function () {
        $(".myPlusContainer").hide();
    });
    $(".myFilter").click(function (e) {

        $(".myFilterContainer").show();
        $(".myPlusContainer").hide();
        $(".mySortContainer").hide();
        e.stopPropagation();
    });
    $(".myFilterContainer").click(function (e) {
        e.stopPropagation();
    });
    $(document).click(function () {
        $(".myFilterContainer").hide();
    });
    $(".mySort").click(function (e) {
        $(".mySortContainer").show();
        $(".myPlusContainer").hide();
        $(".myFilterContainer").hide();
        e.stopPropagation();
    });
    $(".mySortContainer").click(function (e) {
        e.stopPropagation();
    });
    $(document).click(function () {
        $(".mySortContainer").hide();
    });
    $('.allJobs').click(function (e) {
        $('.view').show();
        $('.projectNameContainer').hide();
        $('.allJobs').addClass('active');
        $('.allProject').removeClass('active');
    });
    $('.allProject').click(function (e) {
        $('.projectNameContainer').show();
        $('.view').hide();
        $('.allProject').addClass('active');
        $('.allJobs').removeClass('active');
    });
    $("ul.nav-tabs a").click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    });
    $(document).off('click.bs.modal.data-api').on('click.bs.modal.data-api', '[data-toggle="modal"]', function (e) {
        var $this = $(this),
            href = $this.attr('href'),
            $target = $($this.attr('data-target') || (href && href.replace(/.*(?=#[^\s]+$)/, ''))), //strip for ie7
            option = $target.data('modal') ? 'toggle' : $.extend({ remote: !/#/.test(href) && href }, $target.data(), $this.data());

        $target
            .modal(option)
            .one('hide', function () {
                $this.focus();
            });
    });
    $("#saveJobInfonew").click(function () {
        SaveProjectInfo(false);
    });
    $("#saveJobInfo").click(function () {
        SaveProjectInfo(true);
    });
    $('.color-select').on('change', function () {
        $(this).css('background-color', $(this).val());
    });
    //Filter Result
    $('a.filterproject').on('click', function () {
        var projectGroupId = $('#ddlProjectGroup').val();
        var ManagerId = $('#ddlProjectManager').val();
        var postData = { projectGroupId: projectGroupId, managerID: ManagerId };
        $("#leftNavCon").load('Home/FilterProjectDetailsAsync', postData);
    });

    //Filter Result
    $(document).on('change', '#ddlToDoLost', function () {
        var days = parseInt($(this).val());
        var postData = { days: days };
        $("#tbltodolist").load('Home/FilterToDoListAsync', postData);
    });

    $(document).on('click', '#btnUpdateResults', function () {
        var projectGroup = $('#ProjectMasterModel_ProjectGroupID').val();
        var projectManager = $('#ProjectMasterModel_ProjectManagerID').val();
        var projectStatus = $('#ProjectMasterModel_ProjectStatusID').val();
        var projectType = $('#ProjectMasterModel_ProjectTypeID').val();
        var searchKeyWord = $('#txtKeyWord').val();
        var startDate = $('#ActualStartDate').val();
        var endDate = $('#ActualEndDate').val();
        var datainfo = {
            projectGroups: projectGroup,
            projectManagers: projectManager,
            status: projectStatus,
            projectTypes: projectType,
            searchKeyWord: searchKeyWord,
            startDate: startDate,
            endDate: endDate
        };
        $.post("home/FilterProjectsAsync", datainfo, function (data) {
            $('#example').jqGrid('clearGridData');
            $("#example").jqGrid('setGridParam', { data: JSON.parse(data.projectModelJsonString) });
            $("#example").trigger('reloadGrid');
        });        
    });
    $('span.glyphicon-map-marker').on('click', function () {
        var coordinate = $(this).attr('data-coordinate');
        var lat = coordinate.split(',')[0];
        var lan = coordinate.split(',')[1];
        $('#dvMapEdit').empty().removeAttr('style');
        BindAddress(lat, lan, document.getElementById("dvMapEdit"));
    });
    $(document).on('click', '#btnResetInfo', function () {
        setmultiselectvalue('infoModal', 'ProjectMasterModel_ProjectGroupID', ['']);
        setmultiselectvalue('infoModal', 'ProjectMasterModel_ProjectManagerID', ['']);
        setmultiselectvalue('infoModal', 'ProjectMasterModel_ProjectStatusID', ['']);
        setmultiselectvalue('infoModal', 'ProjectMasterModel_ProjectTypeID', ['']);
        $('#txtKeyWord').val('');
        $('#ActualStartDate').val('');
        $('#ActualEndDate').val('');
    });
    $('#btnProjectGroup').off('click').on('click', function () {
        var jobGroupName = $('#Projectgroupname').val();
        if (jobGroupName != '') {
            var datainfo = { "jobGroupName": jobGroupName };
            $.get("home/SaveProjectGroup", datainfo, function (data) {
                $('#newProject').find('#ProjectMasterModel_ProjectGroupID')
                    .append($("<option></option>")
                        .attr("value", data)
                        .text(jobGroupName));
                var resjobstr = '<li data-search-term="' + jobGroupName + '"><label for="ms-opt-18"><input type="checkbox" title="' + jobGroupName + '" id="ms-opt-18" value="' + data + '">' + jobGroupName + '</label></li>'
                $('#newProject').find('#ProjectMasterModel_ProjectGroupID').next().find('ul').append(resjobstr);
                $('#groupAddModal').hide();
            });
        }
    });
    $('.btn-print').on('click', function () {
        window.print();
    });

    $('span.MapCon > a').on('click', function () {
        $('#locationModal').css('display', 'block');
    });
    $('input[id^=worksdays_]').change(function () {
        var workdays = $('#ProjectScheduleMasterModel_WorkDays').val();
        var arrworkDays = new Array();
        if (workdays !== "") {
            arrworkDays = workdays.split(',');
        }
        if (arrworkDays.indexOf($(this).val()) > -1) {
            arrworkDays.splice(arrworkDays.indexOf($(this).val()));
        }
        else {
            arrworkDays.push($(this).val());
        }
        var strDays = '';
        for (var i = 0; i < arrworkDays.length; i++) {
            strDays = strDays + arrworkDays[i] + ',';
        }
        $('#ProjectScheduleMasterModel_WorkDays').val(strDays.replace(/,\s*$/, ""));
    });
    $('.close').click(function () {
        $('#existingower').hide();
    });

    $("#txtHomeSearch").keypress(function (e) {
        if (e.which == 13) {
            searchProject();
        }
    });

    $('#selectinfo').on('change', function () {
        if ($(this).val() == "1") {
            $("div.owner-existing-info").css('display', 'block');
            $('#existingower').css('display', 'none');
            $('.owner-existing-info input').each(function () {
                $(this).val('');
            });
        }
        else if ($(this).val() == "2") {
            $('#existingower').css('display', 'block');
            $("div.owner-existing-info").css('display', 'none');
        }
        else {
            $("div.owner-existing-info").css('display', 'none');
            $('#existingower').css('display', 'none');
            $('.owner-existing-info input').each(function () {
                $(this).val('');
            });
        }
    });
    $(document).on("click", "#export", function () {
        createExcelFromGrid('example', 'test');
    });
    
    $('.project-info').on('click', function () {
        var projectId = $(this).attr('data-projectid');
        var param = { "projectId": parseInt(projectId) }
        $.ajax({
            url: "Home/GetProjectDetailsbyProjectIdAsync",
            type: 'post',
            data: param,
            success: function (data) {
                $('#existingower').hide();
                $('div.owner-existing-info').show();
                $('#OwnerMasterModel_OwnerName').val(data.ownerMasterModel.ownerName);
                $('#OwnerMasterModel_Email').val(data.ownerMasterModel.email);
                $('#OwnerMasterModel_Telephone').val(data.ownerMasterModel.telephone);
                $('#OwnerMasterModel_MobileNo').val(data.ownerMasterModel.mobileNo);
                $('#OwnerMasterModel_Address').val(data.ownerMasterModel.address);
                $('#OwnerMasterModel_City').val(data.ownerMasterModel.city);
                $('#OwnerMasterModel_State').val(data.ownerMasterModel.state);
                $('#OwnerMasterModel_Zip').val(data.ownerMasterModel.zip);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    });

    $("#newProject").on('shown.bs.modal', function () {
        $(this).find('input[type="text"]').focus();
    });
});
$(window).load(function () {
    $(document).on("click", "div.listmapCon > a", function () {
        var projectId = parseInt($(this).attr('data-project'));
        SetProjectDetails(projectId);
    });
    $(document).on("click", "td[aria-describedby='example_ProjectName']", function () {
        var projectId = parseInt($(this).prev().prev().text());
        SetProjectDetails(projectId);
    });
    $(document).on('click', '#projectclose', function () {
        $('#newProject').removeClass('in').removeAttr('style').attr('style', 'display:none');
    });
    var innerexport = $('div.dataTableConatainer').children('span').html();
    $('#example_toppager_left').html(innerexport);
    $('#export').remove();
    $('.datepicker-dropdown').hide();
});

var createExcelFromGrid = function (gridID, filename) {
    var grid = $('#' + gridID);
    var rowIDList = grid.getDataIDs();
    var row = grid.getRowData(rowIDList[0]);
    var colNames = [];
    var i = 0;
    for (var cName in row) {
        colNames[i++] = cName; // Capture Column Names
    }
    var html = "";
    for (var j = 0; j < rowIDList.length; j++) {
        row = grid.getRowData(rowIDList[j]); // Get Each Row
        for (var i = 0; i < colNames.length; i++) {
            html += row[colNames[i]] + ';'; // Create a CSV delimited with ;
        }
        html += '\n';
    }
    html += '\n';
    var a = document.createElement('a');
    a.id = 'ExcelDL';
    a.href = 'data:application/vnd.ms-excel,' + html;
    a.download = filename ? filename + ".xls" : 'DataList.xls';
    document.body.appendChild(a);
    a.click(); // Downloads the excel document
    document.getElementById('ExcelDL').remove();
}

function searchProject() {
    // Declare variables
    var input, filter, listGroup, records, filteredRecord, i;
    input = $("#txtHomeSearch");
    filter = input.val().toUpperCase();
    listGroup = $(".list-group");
    records = listGroup.find("a.allProject");
    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < records.length; i++) {
        filteredRecord = records[i];
        if (filteredRecord) {
            if (filteredRecord.innerHTML.toUpperCase().indexOf(filter) > -1) {
                records[i].style.display = "";
            } else {
                records[i].style.display = "none";
            }
        }
    }
}
function SaveProjectInfo(isclosed) {
    var infoForm = $("#frmSubmitProjectMaster");
    if ($('#ProjectMasterModel_ProjectName').val() == '') {
        $('#ProjectMasterModel_ProjectName').parent().find('.errormessege').css('display', 'block');
        $('.tab-content > .tab-pane').removeClass('in').removeClass('active');
        $('#set1').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set1") {
                $(this).addClass('active');
            }
        });
        return;
    } else {
        $('#ProjectMasterModel_ProjectName').parent().find('.errormessege').css('display', 'none');
    }
    if ($('#ProjectMasterModel_JobsitePrefix').val() == '') {
        $('#ProjectMasterModel_JobsitePrefix').parent().find('.errormessege').css('display', 'block');
        $('.tab-content > .tab-pane').removeClass('in').removeClass('active');
        $('#set1').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set1") {
                $(this).addClass('active');
            }
        });
        return;
    }
    else {
        $('#ProjectMasterModel_JobsitePrefix').parent().find('.errormessege').css('display', 'none');
    }
    if ($('#ProjectMasterModel_StreetAddress').val() == '') {
        $('#ProjectMasterModel_StreetAddress').parent().find('.errormessege').css('display', 'block');
        $('.tab-content > .tab-pane').removeClass('in').removeClass('active');
        $('#set1').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set1") {
                $(this).addClass('active');
            }
        });
        return;
    } else {
        $('#ProjectMasterModel_StreetAddress').parent().find('.errormessege').css('display', 'none');
    }
    if ($('#ProjectMasterModel_LotInfo').val() == '') {
        $('#ProjectMasterModel_LotInfo').parent().find('.errormessege').css('display', 'block');
        $('.tab-content > .tab-pane').removeClass('in').removeClass('active');
        $('#set1').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set1") {
                $(this).addClass('active');
            }
        });
        return;
    } else {
        $('#ProjectMasterModel_LotInfo').parent().find('.errormessege').css('display', 'none');
    }
    if ($('#OwnerMasterModel_OwnerName').val() == '') {
        $('#OwnerMasterModel_OwnerName').parent().find('.errormessege').css('display', 'block');
        $('.tab-content > .tab-pane').removeClass('in').removeClass('active');
        $('#set2').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set2") {
                $(this).addClass('active');
            }
        });
        return;
    } else {
        $('#OwnerMasterModel_OwnerName').parent().find('.errormessege').css('display', 'none');
    }
    if ($('#OwnerMasterModel_Email').val() == '') {
        $('#OwnerMasterModel_Email').parent().find('.errormessege').css('display', 'block');
        $('#set2').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set2") {
                $(this).addClass('active');
            }
        });
        return;
    } else {
        $('#OwnerMasterModel_Email').parent().find('.errormessege').css('display', 'none');
    }
    if ($('#OwnerMasterModel_Telephone').val() == '') {
        $('#OwnerMasterModel_Telephone').parent().find('.errormessege').css('display', 'block');
        $('#set2').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set2") {
                $(this).addClass('active');
            }
        });
        return;
    } else {
        $('#OwnerMasterModel_Telephone').parent().find('.errormessege').css('display', 'none');
    }
    if ($('#OwnerMasterModel_MobileNo').val() == '') {
        $('#OwnerMasterModel_MobileNo').parent().find('.errormessege').css('display', 'block');
        $('#set2').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set2") {
                $(this).addClass('active');
            }
        });
        return;
    } else {
        $('#OwnerMasterModel_MobileNo').parent().find('.errormessege').css('display', 'none');
    }
    if ($('#OwnerMasterModel_Address').val() == '') {
        $('#OwnerMasterModel_Address').parent().find('.errormessege').css('display', 'block');
        $('#set2').addClass('in').addClass('active');
        $('.parentTabs > ul > li').each(function () {
            $(this).removeClass('active');
            if ($(this).find('a').attr('href') == "#set2") {
                $(this).addClass('active');
            }
        });
        return;
    } else {
        $('#OwnerMasterModel_Address').parent().find('.errormessege').css('display', 'none');
    }
    $('.required').each(function () {
        var txtval = $(this).val();
        if (txtval == '') {
            if ($(this).parent().find('.errormessege').length > 0) {
                $(this).parent().find('.errormessege').css('display', 'block');
                event.preventDefault();
                return false;
            }
        }
        else {
            $(this).parent().find('.errormessege').css('display', 'none');
        }
    });
    var postData = infoForm.serialize();
    $.post("home/SubmitProjectInfo", postData, function (data) {
        if (data.success == true) {
            infoForm.find("input[type='text']").each(function (i, element) {
                $(this).val('');
            });
            if (data.projectModelJsonString !== '') {
                $('#example').jqGrid('clearGridData');
                $("#example").jqGrid('setGridParam', { data: JSON.parse(data.projectModelJsonString) });
                $("#example").trigger('reloadGrid');
            }
            if (isclosed) {
                $('#newProject').removeClass('in').hide();
            }
            alert("Project Details Successfully Added");
        } else {
            alert("Project Details not Saved");
        }
    });
}
function SetProjectDetails(projectId) {
    var datainfo = { "projectID": projectId };
    $.post("home/GetProjectInfoByProjectID", datainfo, function (data) {
        $('#infoModal').show();
        $('#leftNavCon').css("z-index", "000000");
        $('#infoModal').css("z-index", "000000");

        $("#ProjectMasterModel_ProjectName").val(data.item1.projectName);
        $("#ProjectMasterModel_StreetAddress").val(data.item1.streetAddress);
        $("#ProjectMasterModel_JobsitePrefix").val(data.item1.jobsitePrefix);
        $("#ProjectMasterModel_LotInfo").val(data.item1.lotInfo);
        $("#ProjectMasterModel_Permit").val(data.item1.permit);
        $("#ProjectMasterModel_City").val(data.item1.city);
        $("#ProjectMasterModel_State").val(data.item1.state);
        $("#ProjectMasterModel_Zip").val(data.item1.zip);
        $("#ProjectMasterModel_ContractPrice").val(data.item1.contractPrice);
        $('#ProjectMasterModel_ProjectID').val(data.item1.projectID);
        $("#ProjectMasterModel_Latitude").val(data.item1.latitude);
        $("#ProjectMasterModel_Longitude").val(data.item1.longitude);
        setmultiselectvalue('newProject', 'ProjectMasterModel_ProjectTypeID', data.item1.projectTypeID);
        setmultiselectvalue('newProject', 'ProjectMasterModel_ProjectGroupID', data.item1.projectGroupID);
        setmultiselectvalue('newProject', 'ProjectMasterModel_ProjectManagerID', data.item1.projectManagerID);
        $("#ProjectMasterModel_ProjectStatusID").val(data.item1.projectStatusID);
        if (data.item1.latitude != null) {
            BindAddress(data.item1.latitude, data.item1.longitude, document.getElementById("dvMap"));
            BindAddress(data.item1.latitude, data.item1.longitude, document.getElementById("dvMapEdit"));
            BindAddress(data.item1.latitude, data.item1.longitude, document.getElementById("dvMapCluster"));
        }

        //Ownwr Schedule
        $('.owner-existing-info').show();
        $('#OwnerMasterModel_OwnerName').val(data.item2.ownerName);
        $('#OwnerMasterModel_Address').val(data.item2.address);
        $('#OwnerMasterModel_City').val(data.item2.city);
        $('#OwnerMasterModel_State').val(data.item2.state);
        $('#OwnerMasterModel_Zip').val(data.item2.zip);
        $('#OwnerMasterModel_Telephone').val(data.item2.telephone);
        $('#OwnerMasterModel_MobileNo').val(data.item2.mobileNo);
        $('#OwnerMasterModel_Email').val(data.item2.email);
        $('#OwnerMasterModel_AccessMethod').val(data.item2.accessMethod);
        $('#OwnerMasterModel_OwnerCalendar').val(data.item2.ownerCalendar);
        $('#OwnerMasterModel_ShowProjectPrice').prop('checked', data.item2.showProjectPrice)
        $('#OwnerMasterModel_ShowBudgetPurchaseOrders').prop('checked', data.item2.showBudgetPurchaseOrders);
        $('#OwnerMasterModel_AllowOrderRequests').prop('checked', data.item2.allowOrderRequests);
        $('#OwnerMasterModel_AllowLockedSelections').prop('checked', data.item2.allowLockedSelections)
        $('#OwnerMasterModel_AllowLockedSelections').prop('checked', data.item2.allowLockedSelections);
        $('#OwnerMasterModel_AllowPaymentsTab').prop('checked', data.item2.allowPaymentsTab);

        //Schedule Info
        $('#ProjectMasterModel_InternalNotes').val(data.item1.internalNotes);
        $('#ProjectMasterModel_SubNotes').val(data.item1.subNotes);
        $("#ProjectScheduleMasterModel_ProjectStart").datepicker("setDate", data.item1.projectScheduleMasterModel.projectStart);
        $("#ProjectScheduleMasterModel_ProjectStart").datepicker("hide");
        $("#ProjectScheduleMasterModel_ActualStart").datepicker("setDate", data.item1.projectScheduleMasterModel.actualStart);
        $("#ProjectScheduleMasterModel_ActualStart").datepicker("hide");
        $("#ProjectScheduleMasterModel_ProjectCompletion").datepicker("setDate", data.item1.projectScheduleMasterModel.projectCompletion);
        $("#ProjectScheduleMasterModel_ProjectCompletion").datepicker("hide");
        $("#ProjectScheduleMasterModel_ActualCompletion").datepicker("setDate", data.item1.projectScheduleMasterModel.actualCompletion);
        $("#ProjectScheduleMasterModel_ActualCompletion").datepicker("hide");
        $('#ProjectScheduleMasterModel_JobColorID').val(data.item1.projectScheduleMasterModel.jobColorID);
        $('#ProjectScheduleMasterModel_JobColorID').css('background-color', data.item1.projectScheduleMasterModel.jobColorID)
        $('.datepicker.datepicker-dropdown').hide();
        if (data.item1.projectScheduleMasterModel.workDays !== '' && data.item1.projectScheduleMasterModel.workDays !== null) {
            var workdays = data.item1.projectScheduleMasterModel.workDays.split(',');
            $('#newProject').find('.work-days input[type=checkbox]').prop('prop', false);
            for (var i = 0; i < workdays.length; i++) {
                $('#newProject').find('.work-days input[type=checkbox]').each(function () {
                    if ($(this).val() == workdays[i]) {
                        $(this).prop('checked', true);
                    }
                });
            }
        }
    });
}

function setmultiselectvalue(parentid, id, values) {
    var selectedtext = '';
    $('#' + parentid).find('#' + id).next().find('input[type=checkbox]').prop('checked', false);
    $('#' + parentid).find('#' + id).next().find('button > span').text('--Select--');
    for (var i = 0; i < values.length; i++) {
        $('#' + parentid).find('#' + id).next().find('input[type=checkbox]').each(function () {
            if ($(this).val() == values[i]) {
                $(this).click();
                selectedtext = selectedtext + $(this).attr('title') + ', ';
            }
        });
    }
}

function formatColor(cellValue, options, rowObject) {
    var linkMessage = '<div class="colorcode" style= "background-color: ' + cellValue + '; padding: 10px 47px; margin: -2px;"></div>';
    return linkMessage;
};

function formatName(cellValue, options, rowObject) {
    var linkMessage = '<a href="#newProject" data-toggle="modal">' + cellValue + '</a>';
    return linkMessage;
};

function BindGrid(divId, jsondata) {
    $("#" + divId).jqGrid({
        colModel: [
            { name: "ProjectId", label: "Project Id", width: 53, hidden: true },
            { name: "ProjectColor", label: "", width: 15, formatter: formatColor },
            { name: "ProjectName", label: "Project Name", width: 53, formatter: formatName },
            {
                name: "StreetAddress", label: "Street Address", width: 75
            },
            { name: "City", label: "City", width: 65 },
            { name: "State", label: "State", width: 41 },
            { name: "Zip", label: "Zip", width: 41 },
            { name: "ManagerName", label: "Proj. Manager", width: 51 },
            { name: "OwnerName", label: "Owner", width: 59 },
            { name: "Telephone", label: "Phone", width: 65 },
            { name: "MobileNo", label: "Cell", width: 41 },
            { name: "Active", label: "Active", width: 51 }
        ],
        data: jsondata,
        iconSet: "fontAwesome",
        idPrefix: "g5_",
        rownumbers: false,
        sortname: "ProjectName",
        sortorder: "desc",
        threeStateSort: true,
        sortIconsBeforeText: true,
        headertitles: true,
        toppager: true,
        pager: true,
        rowNum: 10,
        viewrecords: true,
        searching: {
            defaultSearch: "cn"
        },
        caption: ""
    });
}
function BindAddress(latitude, longitude, mapCanvas) {
    var myCenter = new google.maps.LatLng(latitude, longitude);
    var mapOptions = {
        center: myCenter,
        zoom: 13
    };
    var map = new google.maps.Map(mapCanvas, mapOptions);
    var marker = new google.maps.Marker({
        position: myCenter,
        draggable: true,
        map: map,
        title: "<div style='font-size:large; font-family: Arial Black; background-color:yellow; color:blue; text-align: center'>Your Current Location Coordinates:<br />Latitude: 12.9716° N<br />Longitude: 77.5946° E"
    });
    google.maps.event.addListener(marker, 'dragend', function (event) {
        var lat = this.position.lat();
        var lng = this.position.lng();
        $('#ProjectMasterModel_Latitude').val(lat);
        $('#ProjectMasterModel_Longitude').val(lng);
        var latlng = new google.maps.LatLng(lat, lng);
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[1]) {
                    $('#ProjectMasterModel_StreetAddress').val(results[1].formatted_address);
                }
            }
        });
    });
    marker.setMap(map);
}