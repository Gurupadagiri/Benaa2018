$(document).ready(function () {
    $(document).on('click', 'a.allProject', function () {
        $(this).addClass('selected-project');
        $('#projectid').text($(this).attr('data-projectid'));
        $('#frmSchedule').find("#ProjectId").val($(this).attr('data-projectid'));
        $('#spnproject').text($(this).text());
        $("#projectname").text($(this).text());
        $("#ProjectId").val($(this).attr('data-projectid'));
        $('.mainContentDiv').css('display', 'block');
        $('#calendarpage').css('display', 'none');
        $("#SaveType").val('insert');
        populatecalendar($(this).attr('data-projectid'));
    });
    $(document).on("change", ".select_month", function (event) {
        $('#calendar').fullCalendar('changeView', 'month', this.value);
        $('#calendar').fullCalendar('gotoDate', "2018-" + this.value + "-1");
    });
    $('#btnAddScheule').on('click', function () {
        $('#calendarmodal').addClass('in').css('display', 'block');
    });
    $(document).on('click', '.infoclose', function () {
        $('#calendarmodal').removeClass('in').css('display', 'none');
        $('#calendarmodalgeneral').removeClass('in').css('display', 'none');
    });
    $(document).on('click', '#morepredecessors', function () {
        var cntpredeitem = $('div.predecessoritem div.form-group').length;
        var innerhtml = $('div.predecessoritem > div.form-group:eq(0)').html();
        innerhtml = innerhtml.replace('PredecessorInformationModels[0].ScheduledItemId', "PredecessorInformationModels[" + cntpredeitem + "].ScheduledItemId")
            .replace('PredecessorInformationModels_0__ScheduledItemId', "PredecessorInformationModels_" + cntpredeitem + "__ScheduledItemId")
            .replace('PredecessorInformationModels_0__TimeFrame', "PredecessorInformationModels_" + cntpredeitem + "__TimeFrame")
            .replace('PredecessorInformationModels[0].TimeFrame', "PredecessorInformationModels[" + cntpredeitem + "].TimeFrame")
            .replace('PredecessorInformationModels_0__Lag', "PredecessorInformationModels_" + cntpredeitem + "__Lag")
            .replace('PredecessorInformationModels[0].Lag', "PredecessorInformationModels[" + cntpredeitem + "].Lag");
        $('.predecessoritem').append('<div class="form-group">' + innerhtml + '</div>');
    });
    $('.btncalendar').on('click', function () {
        var postData = $('#frmPredecessor').serialize();
        $.post("Calendar/SubmitPredecessorInfoAsync", postData, function (data) {
            $('#frmPredecessor').find("input[type='text']").each(function (i, element) {
                $(this).val('');
            });
            $('#calendarmodal').remove('in').hide();
            $('#calendar').fullCalendar('removeEvents');
            $('#calendar').fullCalendar('addEventSource', JSON.parse(data));
            $('#calendar').fullCalendar('rerenderEvents');
            alert("Predecessor Details Successfully Added");
        });
    });
    $('.fc-content-skeleton td').on('click', function () {
        if ($(this).attr('class') === undefined) {
            $('#calendarmodalgeneral').addClass('in').css('display', 'block');
        }
        else {
            $('#calendarmodal').addClass('in').css('display', 'block');
        }
    });

    $('#btnQuickAddSave').on('click', function () {
        var postData = $('#frmSchedule').serialize();
        $.post("Calendar/SubmitQuickSchedulerInfoAsync", postData, function (data) {
            if (data == true) {
                $('#frmSchedule').find("input[type='text']").each(function (i, element) {
                    $(this).val('');
                });
            }
            alert("Schedule Details Successfully Added");
        });
    });
    $('#btnAddPhase').on('click', function () {
        var postData = { "projectId": parseInt($('#projectid').text()), "phaseName": $('#PhaseName').val(), "displayOrder": parseInt($('#DisplayOrder').val()), "phasecolor": $('#phasecolor').val() };
        $.post("Calendar/SubmitPhaseAsync", postData, function (data) {
            if (data == true) {
                $('#PhaseName').val('');
                $('#DisplayOrder').val('');
                $('#phasecolor').val('');
            }
            alert("Schedule Details Successfully Added");
        });
    });
    $('#btnAddTag').on('click', function () {
        var postData = { "projectId": parseInt($('#projectid').text()), "tagName": $('#txtTag').val() };
        $.post("Calendar/SubmitTagAsync", postData, function (data) {
            if (data == true) {
                $('#txtTag').val('');
            }
            alert("Schedule Details Successfully Added");
        });
    });
    $(document).on('click', '.fc-agendaWeek-button', function () {
        $('.fc-left').css('display', 'block');
        $('.fc-center').css('display', 'block');
        $('.fc-header-toolbar > .gnattToolbarHolder').remove();
    });
    $(document).on('click', '.fc-month-button', function () {
        $('.fc-left').css('display', 'block');
        $('.fc-center').css('display', 'block');
        $('.fc-header-toolbar > .gnattToolbarHolder').remove();
    });
    $(document).on('click', '.fc-agendaDay-button', function () {
        $('.fc-left').css('display', 'block');
        $('.fc-center').css('display', 'block');
        $('.fc-header-toolbar > .gnattToolbarHolder').remove();
    });

    $('#btnCalendar').on('click', function () {
        var postData = {
            "projectId": parseInt($('#projectid').text()),
            "searchText": $('#Title').val(),
            "performedBy": $('#PerformedBy').val(),
            "status": $('#Status').val(),
            "tags": $('#ProjectTag').val(),
            "projectPhases": $('#ProjectPhases').val(),
            "otherItems": $('#ProjectOtherItem').val()
        };
        $.post("Calendar/GetFilteredScheduleAsync", postData, function (data) {
            $('#calendar').fullCalendar('removeEvents');
            $('#calendar').fullCalendar('addEventSource', JSON.parse(data));
            $('#calendar').fullCalendar('rerenderEvents');
        });
    });

    $('#btnQucikAddEditItem').on('click', function () {
        var date = new Date($('#frmSchedule').find('#SelectedDate').val());
        var newdate = new Date(date);
        newdate.setDate(newdate.getDate() + 1);
        $('#frmPredecessor').find('#StartDate').val(date.getDate() + '/' + date.getMonth() + '/' + date.getFullYear());
        $('#frmPredecessor').find('#EndDate').val(newdate.getDate() + '/' + newdate.getMonth() + '/' + newdate.getFullYear());
        $('#frmPredecessor').find('#Duration').val(1);
        $('#frmPredecessor').find('#Title').val($('#frmSchedule').find('#Title').val());
        $('#calendarmodal').addClass('in').css('display', 'block');
        $('#calendarmodalgeneral').removeClass('in').css('display', 'none');
    });

    $('#Hourly').on('change', function () {
        if ($(this).prop('checked')) {
            $('.timeHolder').css('display', 'block');
        } else {
            $('.timeHolder').css('display', 'none');
        }
    });
});

function populatecalendar(projectid) {
    var postData = { "projectId": parseInt(projectid) };
    $.post("Calendar/GetScheduledItemsByProjectId", postData, function (data) {
        if ($('.fc-left').length == 0) {
            BindCalendar(data);
        } else {
            $('#calendar').fullCalendar('removeEvents');
            $('#calendar').fullCalendar('addEventSource', JSON.parse(data));
            $('#calendar').fullCalendar('rerenderEvents');
        }
    });
}
function BindCalendar(data) {
    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next',
            center: 'title',
            right: 'month,agendaWeek,agendaDay,Agenda,ListView,Gnatt,Baseline,PhasesList'
        },
        views: {
            ListView: {
                buttonText: 'List View'
            },
            Baseline: {
                buttonText: 'Base line'
            },
            PhasesList: {
                buttonText: 'Phases List'
            }
        },
        defaultDate: new Date(),
        navLinks: true,
        editable: true,
        eventLimit: true,
        events: JSON.parse(data),
        Click: function (date, jsEvent, view) {
        },
        dayClick: function (date, allDay, jsEvent, view) {
            if (date._d.getDay() === 5 || date._d.getDay() === 6) {
                alert(convert(date._d, '/') + ' is not a working day');
            }
            else {
                $('#calendarmodalgeneral').addClass('in').css('display', 'block');
                $('#frmSchedule').find("#StartDate").val(convert(date._d, '-'));
            }
        },
        eventClick: function (calEvent, jsEvent, view) {
            var postData = { "scheduledId": calEvent.id };
            $("#calendarmodal").load('Calendar/GetScheduledDetailsByIdAsync', postData);
            $('#calendarmodal').addClass('in').css('display', 'block');
        },
        eventRender: function (event, element) {
            $('.fc-right').insertBefore('.fc-left');
            //$('.fc-sat').text('Non-Work Day');
            //$('.fc-fri').text('Non-Work Day');
            //if ($('.select_month').length == 0) {
            //    $(".fc-center").append('<select class="select_month"><option value="">Select Month</option><option value="1">Jan</option><option value="2">Feb</option><option value="3">Mrch</option><option value="4">Aprl</option><option value="5">May</option><option value="6">June</option><option value="7">July</option><option value="8">Aug</option><option value="9">Sep</option><option value="10">Oct</option><option value="11">Nov</option><option value="12">Dec</option></select>');
            //}            
        },
        eventMouseover: function (data, event, view) {
            tooltip = '<div class="tooltiptopicevent">' +
                '<div class="heading-color" style="background: ' + data.color + ';"> Title => ' + data.title + '</div><div class="tooltip-body">' + data.start._i + ' => ' + data.end._i + '</br > Progress => ' + data.status + '</br > Duration => ' + data.duration + '</br > AssignTo => ' + data.assignto + '</div></div > ';
            $("body").append(tooltip);
            $(this).mouseover(function (e) {
                $(this).css('z-index', 10000);
                $('.tooltiptopicevent').fadeIn('500');
                $('.tooltiptopicevent').fadeTo('10', 1.9);
            }).mousemove(function (e) {
                $('.tooltiptopicevent').css('top', e.pageY + 10);
                $('.tooltiptopicevent').css('left', e.pageX + 20);
            });
        },
        eventMouseout: function (data, event, view) {
            $(this).css('z-index', 8);
            $('.tooltiptopicevent').remove();
        },
    });
}

function convert(str, seperator) {
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join(seperator);
}

var FC = $.fullCalendar;
var View = FC.View;
var AgendaView;
var ListView;
var GnattView;
var BaselineView;
var PhasesListView;

AgendaView = View.extend({ // make a subclass of View
    initialize: function () {
    },
    render: function () {
        this.el.html('<div class="fc-view fc-agendaWeek-view fc-agenda-view" style=""><div class="toolbatHolder">' +
            '<button class="showearlier">Show Earlier</button >' +
            '<div class="calenderJq">' +
            '<script>' +
            ' $( function() {' +
            '$("#datepicker").datepicker();' +
            '});' +
            '</script>' +
            '<label> Jump To:</label> ' +
            '<p> <input type="text" id="datepicker"><span class="glyphicon glyphicon-calendar"></span></p>' +
            '<input type= "submit" name="datefilter" id="datefilter" value= "Go" > ' +
            '</div> ' +
            '</div></div><div class="dataHolder">' +
            '<table class="innercontent"></table>' +
            '</div>');
    },
    setHeight: function (height, isAuto) {
    },
    renderEvents: function (events) {
        $('.fc-left').css('display', 'none');
        $('.fc-center').css('display', 'none');
        $('.fc-header-toolbar > .gnattToolbarHolder').remove();
        var t = this;
        var dailyEvents = [];
        var projectId = $("#projectid").text();
        var postData = { "projectId": parseInt(projectId) };
        $.post("/Calendar/GetScheduledItems", postData, function (data) {
            getDailyEvents(data);
        });
        function getDailyEvents(data) {
            dailyEvents = [];
            $.each(data, function (index, day) {
                dailyEvents.push({
                    date: day.start,
                    events: [day]
                });
            });
            $.each(dailyEvents, function (index, day) {
                t.el.find('.innercontent').append(t.dayHtml(day.date, day.events));
            });
        }

        $("#datefilter").on('click', function () {
            var postData = { "projectId": parseInt(projectId), "selectedDate": $("#datepicker").val(), "sortOrder": sortOrder };
            $.post("/Calendar/GetScheduledItems", postData, function (data) {
                $('.innercontent').empty();
                getDailyEvents(data);
            });
        });
        $(document).on('click', '.dataschedule', function () {
            var postData = { "scheduledId": parseInt($(this).attr("data-schedule")) };
            $("#calendarmodal").load('Calendar/GetScheduledDetailsByIdAsync', postData);
            $('#calendarmodal').addClass('in').css('display', 'block');
        });
        var sortOrder = -1;
        $(document).on('click', '.showearlier', function () {
            if (sortOrder == 1)
                sortOrder = 0;
            else if (sortOrder == 0)
                sortOrder = 1;
            else sortOrder = 1;
            var postData = { "projectId": parseInt(projectId), "sortOrder": sortOrder };
            $.post("/Calendar/GetScheduledItems", postData, function (data) {
                $('.innercontent').empty();
                getDailyEvents(data);
            });
        });
    },
    destroyEvents: function () {
    },
    renderSelection: function (range) {
    },
    destroySelection: function () {
    },
    dayHtml: function (day, events) {
        var dayEvents = '';
        $.each(events, function (index, event) {
            dayEvents += '<tr>' +
                '<td>' + event.startDate + '</td>' +
                '<td> Day ' + event.scheuleDay + ' of ' + event.totalScheuleDay + '</td> ' +
                '<td><div style="position: absolute; top: 0px; left: 0px; height: 100%"><div style="width: 10px; height: 100%; background-color: ' + event.colorCode + '"></div></div><div class="dataschedule" data-schedule="' + event.scheduledItemId + '">' + event.title + '</div></td>' +
                '<td>' + event.assignedTo + '</td>' +
                '</tr>';
        });
        return dayEvents;
    }
});
FC.views.Agenda = AgendaView;
ListView = View.extend({ // make a subclass of View
    initialize: function () {

    },
    render: function () {
        this.el.html('<div class="fc-view fc-agendaWeek-view fc-agenda-view" style=""> <div class="toolbatHolder">' +
            '<ul>' +
            '<li><a href="#">Basic</a></li>' +
            '<li><a href="#">Detailed</a></li>' +
            '<li><a href="#">Print</a></li>' +
            '<li></li>' +
            '</ul>' +
            '</div><div class="con">' +
            '<h2> Schedule Items</h2><table class="listviewtable"></table></div></div>');
    },
    setHeight: function (height, isAuto) {
    },
    renderEvents: function (events) {
        $('.fc-left').css('display', 'none');
        $('.fc-center').css('display', 'none');
        $('.fc-header-toolbar > .gnattToolbarHolder').remove();
        var t = this;
        var dailyEvents = [];
        var projectId = $("#projectid").text();
        var postData = { "projectId": parseInt(projectId) };
        $.ajax({
            url: "/Calendar/GetScheduledItems",
            type: "GET",
            data: postData,
            success: function (data) {
                getDailyEvents(data);
            }
        });
        function getDailyEvents(data) {
            $.each(data, function (index, day) {
                dailyEvents.push({
                    date: day.start,
                    events: [day]
                });
            });
            t.el.find('.listviewtable').append('<tr class="header">' +
                '<td class="checkBox" >' +
                '<input type="checkbox" id="checkAll" data-bind="click: CalendarList.CheckAll">' +
                '</td>' +
                '<td class="tdID" >ID</td>' +
                '<td class="title">Title</td>' +
                '<td>Status</td>' +
                '<td>Phase</td>' +
                '<td>Files</td>' +
                '<td>Dur.</td>' +
                '<td>Start</td>' +
                '<td>Finish</td>' +
                '<td>' +
                '<div style="margin: 0 auto; display: table">' +
                '<div style="margin-right: 23px;">Assigned To</div>' +
                '<div style="position: relative; left: 76px; top: 50%; margin-top: -12px;">' +
                '<div style="float: none; position: relative; cursor: pointer" class="show-more-recipients-header" title="Expand/Collapse"></div>' +
                '<div style="float: none; position: relative; cursor: pointer" class="show-more-recipients-header" title="Expand/Collapse"></div>' +
                '</div>' +
                '</div>' +
                '</td>' +
                '<td>' +
                'User Confirm' +
                '</td>' +
                '<td class="checkBox">pred' +
                '</td>' +
                '</tr>');
            var i = 0;
            $.each(dailyEvents, function (index, day) {
                i++;
                t.el.find('.listviewtable').append(t.dayHtml(day.date, day.events, i));
            });
        }
        $(document).on('click', '.title', function () {
            var postData = { "scheduledId": parseInt($(this).attr("data-schedule")) };
            $("#calendarmodal").load('Calendar/GetScheduledDetailsByIdAsync', postData);
            $('#calendarmodal').addClass('in').css('display', 'block');
        });
    },
    destroyEvents: function () {
    },
    renderSelection: function (range) {
    },
    destroySelection: function () {
    },
    dayHtml: function (day, events, i) {
        var dayEvents = '';
        $.each(events, function (index, event) {
            dayEvents += '<tr class="cont">' +
                '<td class="checkBox" >' +
                '<input type="checkbox" id="checkAll" data-bind="click: CalendarList.CheckAll">' +
                '</td>' +
                '<td class="tdID">' + event.scheduledItemId + '</td>' +
                '<td class="title" data-schedule="' + event.scheduledItemId + '">' + event.title + '</td>' +
                '<td>Status</td>' +
                '<td>Phase</td>' +
                '<td>Files</td>' +
                '<td>' + event.duration + '</td>' +
                '<td>' + convert(event.startDate, '/') + '</td>' +
                '<td>' + convert(event.endDate, '/') + '</td>' +
                '<td>' +
                '<div style="margin: 0 auto; display: table">' +
                '<div style="margin-right: 23px;">' + event.assignedTo + '</div>' +
                '<div style="position: relative; left: 76px; top: 50%; margin-top: -12px;">' +
                '<div style="float: none; position: relative; cursor: pointer" class="show-more-recipients-header" title="Expand/Collapse"></div>' +
                '</div>' +
                '</div>' +
                '</td>' +
                '<td>' +
                '<input type="checkbox" id="chkconfirm' + i + '" />' +
                '</td>' +
                '<td class="checkBox">' +
                '</td>' +
                '</tr>';
        });
        return dayEvents;
    }
});
FC.views.ListView = ListView;
GnattView = View.extend({
    initialize: function () {
    },
    render: function () {
        this.el.html('<div id="gantt_here" style="width:100%; height:600px;"></div>');
    },
    setHeight: function (height, isAuto) {
    },
    renderEvents: function (events) {
        $('.fc-left').css('display', 'none');
        $('.fc-center').css('display', 'none');
        $('.fc-header-toolbar > .gnattToolbarHolder').remove();
        $('.fc-header-toolbar').append('<div class="gnattToolbarHolder">' +
            '<div class="gnattLeft" >' +
            '<button type="button" class="columnDisplaySettingsBtn" data-toggle="modal" data-target="#columnDisplaySettings"><i class="fa fa-cog" aria-hidden="true" title="Column Display Settings"></i></button>' +
            '</div >' +
            '<div class="gnattRight">' +
            '<div class="selectHolder">' +
            '<div class="daily">' +
            '<select>' +
            ' <option>Daily</option>' +
            '<option>Weekly</option>' +
            ' </select>' +
            '</div>' +
            '<div class="item">' +
            ' <select>' +
            '<option>Item</option>' +
            '<option>Phase</option>' +
            '<option>Jobs</option>' +
            '</select>' +
            '</div>' +
            '</div>' +
            '<div class="checkboxHolder left">' +
            ' <input type="checkbox" name="showBaseline" id="showBaseline">' +
            '  <label for="showBaseline">Show Baseline</label>' +
            '   </div>' +
            '<div class="checkboxHolder">' +
            '   <input type="checkbox" name="highlightCriticalPath" id="highlightCriticalPath">' +
            '        <label for="highlightCriticalPath">Highlight critical path</label>' +
            '       </div>' +
            '</div>' +
            '</div>');

        var projectId = $("#projectid").text();
        var postData = { "projectId": parseInt(projectId), "selectedDate": "" };
        $.post("/Calendar/GetGnattItems", postData, function (data) {
            var item = JSON.parse(data);
            getDailyEvents(item)
        });
        function getDailyEvents(data) {
            var demo_tasks = {
                data: data.Item1,
                links: data.Item2,
            };
            gantt.config.work_time = true;
            gantt.config.details_on_create = false;
            gantt.config.scale_unit = "day";
            gantt.config.duration_unit = "day";
            gantt.config.row_height = 30;
            gantt.config.min_column_width = 40;
            gantt.init("gantt_here");
            gantt.templates.task_cell_class = function (task, date) {
                if (!gantt.isWorkTime(date))
                    return "week_end";
                return "";
            };
            gantt.parse(demo_tasks);
        }
    },
    eventClick: function (event, jsEvent) {
    },
    destroyEvents: function () {
    },
    renderSelection: function (range) {
    },
    destroySelection: function () {
    }
});
FC.views.Gnatt = GnattView;
BaselineView = View.extend({
    initialize: function () {
    },
    render: function () {
        this.el.html('<div class="fc-baseline-view"></div>');
    },
    setHeight: function (height, isAuto) {
    },
    renderEvents: function (events) {
        $('.fc-left').css('display', 'none');
        $('.fc-center').css('display', 'none');
        $('.fc-header-toolbar > .gnattToolbarHolder').remove();
        var t = this;
        var dailyEvents = [];
        var projectId = $("#projectid").text();
        var postData = { "projectId": parseInt(projectId) };
        $.ajax({
            url: "/Calendar/GetScheduledItems",
            type: "GET",
            data: postData,
            success: function (data) {
                getDailyEvents(data);
            }
        });
        function getDailyEvents(events) {
            t.el.find('.fc-baseline-view').append('<p>Baseline set for the 5th time by aryan singh on 07/08/18</p>');
            t.el.find('.fc-baseline-view').append('<div class="con"><table class="listviewtable"></table><div>');
            t.el.find('.fc-baseline-view').append('<div class="SummaryHolder">' +
                '<h2> Baseline Summary</h2>' +
                '<table class="conheader">' +
                '<tr>' +
                '<th>Duration</th>' +
                '<th>Start Date</th>' +
                '<th>End Date</th>' +
                '<th>Overall Slip</th>' +
                '</tr></table></div>');
            $.each(events, function (index, day) {
                t.el.find('.conheader').append('<tr>' +
                    '<td></td>' +
                    '<td>( 05-02-18) 05-02-18</td>' +
                    '<td>(22-08-18) 22-08-18	</td>' +
                    '<td></td>' +
                    '</tr>');
            });
            t.el.find('.listviewtable').append('<tr class="header">' +
                '<td class="checkBox" >' +
                'Status' +
                '</td>' +
                '<td class="tdID" >Title</td>' +
                ' <td>(Base) Dur</td>' +
                '<td class="title">(Base) Start Date</td>' +
                '<td>(Base) End Date</td>' +
                '<td>Direct Shifts</td>' +
                '<td>Duration Chng</td>' +
                '<td>Overall Slip</td>' +
                '<td>Reasons</td>' +
                '<td>Shift Notes</td>' +
                '<td>Assigned To</td>' +
                '</tr ><tr class="contheader">');
            $.each(events, function (index, day) {
                t.el.find('.listviewtable').append('<tr class="cont"><td class="checkBox">' +
                    '<input type="checkbox" id="chkstatus' + index + '">' +
                    '</td>' +
                    '<td>' + day.title + '</td>' +
                    '<td>(' + day.duration + ' d)' + day.duration + ' d</td>' +
                    '<td >(' + convert(day.startDate, '-') + ') ' + convert(day.startDate, '/') + '</td>' +
                    '<td>(' + convert(day.endDate, '-') + ') ' + convert(day.endDate, '/') + '</td>' +
                    '<td>0</td>' +
                    '<td>-</td>' +
                    '<td>0 d</td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td>' + day.assignedTo + '</td></tr>');
            });
            $('.SummaryHolder').insertBefore('.con');
        }
    },
    destroyEvents: function () {
    },
    renderSelection: function (range) {
    },
    destroySelection: function () {
    }
});
FC.views.Baseline = BaselineView;
PhasesListView = View.extend({ // make a subclass of View
    initialize: function () {
    },
    render: function () {

    },
    setHeight: function (height, isAuto) {
    },
    renderEvents: function (events) {
        $('.fc-left').css('display', 'none');
        $('.fc-center').css('display', 'none');
        var t = this;
        this.el.html('<div class="phaseHolder"></div>');

        var projectId = $("#projectid").text();
        var postData = { "projectId": parseInt(projectId) };
        $.post("/Calendar/GetPhasesListAsync", postData, function (data) {
            getDailyEvents(data);
        });
        t.el.find('.phaseHolder').append('<div class="phaseHeader">' +
            '<div class="leftHolder">' +
            '<a href="javascript:void(0);" class="toggleAll">' +
            '<img src="images/add.gif">' +
            '</a>' +
            '<input id="chkAll" type="checkbox" data-bind="checked: allChecked" />' +
            '</div><div class="rightHolder"><label>Sort Phases By: </label>' +
            '<select>' +
            '<option>Display Order</option>' +
            '</select> ' +
            '</div>' +
            '</div>');
        t.el.find('.phaseHolder').append('<div class="phaseBody">' +
            '<div class="phaseBodyHolder"></div></div>');
        function getDailyEvents(data) {
            $.each(data, function (index, item) {
                t.el.find('.phaseBodyHolder').append('<div class="phaseBodyHolderTop">' +
                    '<table>' +
                    '<tbody>' +
                    '<tr>' +
                    '<td style="border-right: 1px solid #d1d1d1; position: relative;border-left: 0!important;">' +

                    '<div class="phaseHeader">' +
                    '<div class="leftHolder">' +
                    '<a href="javascript:void(0);" class="toggleAll"><img src="images/add.gif"></a>' +
                    '<div class="CheckBoxPhase"><input name="chkPhaseSelected" value="' + item.item1 + '" type="checkbox"></div>' +
                    '</div>' +
                    '<div class="rightHolder">' +
                    '<div class="Status fieldHeader">Status: <span></span></div>' +
                    '<div class="ExpandPhase">' +
                    '<a href="javascript:void(0);"><img border="0" src="images/edit(1).gif"></a>' +
                    '</div>' +
                    '<div class="PhaseTitle"><span>' + item.item2 + '</span></div>' +
                    '</div>' +
                    '</div>' +
                    '</td>' +
                    '<td style="width: 20%; border-right: 1px solid #d1d1d1;">' +
                    '<div class="tdContent">' +
                    '<div style="float: left">' +
                    '<div class="fieldHeader">Start Date<br></div>' +
                    '<span>' + convert(item.item3, '/') + '</span>' +
                    '</div>' +
                    '<div style="float: right">' +
                    '<div class="fieldHeader" style="text-align: right">End Date<br></div>' +
                    '<span>' + convert(item.item4, '/') + '</span>' +
                    '</div>' +
                    '<div style="clear: both"></div>' +
                    '</div>' +
                    '</td>' +
                    '<td style="width: 13%; min-width: 200px">' +
                    '<div class="tdContent">' +
                    '<div class="fieldHeader">Items Completed</div>' +
                    '<span>' + item.item6 + '</span> / <span >' + item.item5 + '</span>' +
                    '</div>' +
                    '</td>' +
                    '</tr>' +
                    '</tbody>' +
                    '</table>' +
                    '</div>');
                t.el.find('.phaseBodyHolder').append('<div class="bottom">' +
                    '<div class="phaseList" data- bind="visible: showPhaseItems" style= "">' +
                    '<table class="expandSelectItemTable">' +
                    '<thead>' +
                    '<tr">' +
                    '<th style="width: 15px;"></th>' +
                    '<th style="width: 180px; text-align: left; display: none;">Jobsite</th>' +
                    '<th style="width: 230px; text-align:left;">Schedule Item Title</th>' +
                    '<th style="width: 50px; text-align:left;">Dur.</th>' +
                    '<th style="width: 130px; text-align:left;">Start</th>' +
                    '<th style="width: 130px; text-align:left;">Finish</th>' +
                    '<th style="width: 85px;">Completed</th>' +
                    '<th style="text-align:left;">Assigned To</th>' +
                    '</tr>' +
                    '</thead>' +
                    '<tbody class="tdschedule">' +
                    '</tbody>' +
                    '</table>' +
                    '</div>' +
                    '</div>');
                $.each(data[index].item7, function (index, item) {
                    t.el.find('.tdschedule').append('<tr class="whiteBack">' +
                        '<td><input name="chkPhaseItem" type="checkbox" value="' + item.scheduledItemId + '"></td>' +
                        '<td class="tdL" style="display: none;"><span></span></td>' +
                        '<td class="tdL"><a class="phasetitle" data-schedule="' + item.scheduledItemId + '" href="javascript:void(0);" >' + item.title + '</a></td>' +
                        '<td style="text-align:left;"><span >' + item.duration + '</span></td>' +
                        '<td class="tdL"><span >' + convert(item.startDate, '/') + '</span></td>' +
                        '<td class="tdL"><span >' + convert(item.endDate, '/') + '</span></td>' +
                        '<td class="tdC" ><input name="chkPhaseItemCompleted" type="checkbox" ></td>' +
                        '<td style="text-align:left;"><span title="aryan singh">' + item.assignedTo + '</span></td>' +
                        ' </tr>');
                });
            });
        }
        $(document).on('click', '.phasetitle', function () {
            var postData = { "scheduledId": parseInt($(this).attr("data-schedule")) };
            $("#calendarmodal").load('Calendar/GetScheduledDetailsByIdAsync', postData);
            $('#calendarmodal').addClass('in').css('display', 'block');
        });
    },
    destroyEvents: function () {
    },
    renderSelection: function (range) {
    },
    destroySelection: function () {
    }
});
FC.views.PhasesList = PhasesListView; 