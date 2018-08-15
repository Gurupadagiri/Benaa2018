$(document).ready(function () {
    $(document).on('click', 'a.allProject', function () {
        $('#projectid').text($(this).attr('data-projectid'));
        $('#spnproject').text($(this).text());
        $("#projectname").text($(this).text());
        $("#ProjectId").val($(this).attr('data-projectid'));
        $('.mainContentDiv').css('display', 'block');
        $('#calendarpage').css('display', 'none');
        $("#SaveType").val('insert');
        populatecalendar($(this).attr('data-projectid'));
    });
    $('#btnAddScheule').on('click', function () {
        $('#calendarmodal').addClass('in').css('display', 'block');
    });
    $(document).on('click', '.infoclose', function () {
        $('#calendarmodal').removeClass('in').css('display', 'none');
        $('#calendarmodalgeneral').removeClass('in').css('display', 'none');
    });
    $('#morepredecessors').on('click', function () {
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
            if (data == true) {
                infoForm.find("input[type='text']").each(function (i, element) {
                    $(this).val('');
                });
                alert("Predecessor Details Successfully Added");
            }
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
                infoForm.find("input[type='text']").each(function (i, element) {
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
                infoForm.find("input[type='text']").each(function (i, element) {
                    $(this).val('');
                });
            }
            alert("Schedule Details Successfully Added");
        });
    });
    $('#btnAddTag').on('click', function () {
        var postData = { "projectId": parseInt($('#projectid').text()), "tagName": $('#txtTag').val() };
        $.post("Calendar/SubmitTagAsync", postData, function (data) {
            if (data == true) {
                infoForm.find("input[type='text']").each(function (i, element) {
                    $(this).val('');
                });
            }
            alert("Schedule Details Successfully Added");
        });
    });
    $(document).on('click', '.fc-agendaWeek-button', function () {
        $('.fc-left').css('display', 'block');
        $('.fc-center').css('display', 'block');
    });
    $(document).on('click', '.fc-month-button', function () {
        $('.fc-left').css('display', 'block');
        $('.fc-center').css('display', 'block');
    });
    $(document).on('click', '.fc-agendaDay-button', function () {
        $('.fc-left').css('display', 'block');
        $('.fc-center').css('display', 'block');
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
            //BindCalendar(data);
            $('#calendar').fullCalendar('removeEvents');
            $('#calendar').fullCalendar('addEventSource', JSON.parse(data));
            $('#calendar').fullCalendar('rerenderEvents');
        });
    });
});   

function populatecalendar(projectid) {
    var postData = { "projectId": parseInt(projectid) };
    $.post("Calendar/GetScheduledItemsByProjectId", postData, function (data) {
        BindCalendar(data);
        $('#calendar').fullCalendar('removeEvents');
        $('#calendar').fullCalendar('addEventSource', JSON.parse(data));
        $('#calendar').fullCalendar('rerenderEvents');
    });
}
function BindCalendar(data) {
    $('#calendar').fullCalendar('refetchEvents');
    //$('#calendar').fullCalendar('rerenderEvents');
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
        defaultDate: '2018-03-12',
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
                $("#SelectedDate").val(convert(date._d, '-'));
            }
        },
        eventClick: function (calEvent, jsEvent, view) {
            var postData = { "scheduledId": calEvent.id };
            $("#calendarmodal").load('Calendar/GetScheduledDetailsByIdAsync', postData);
            $('#calendarmodal').addClass('in').css('display', 'block');
        },
        eventRender: function (event, element) {
            $('.fc-right').insertBefore('.fc-left');
        }
    });
}

function convert(str, seperator) {
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join(seperator);
}

var FC = $.fullCalendar; // a reference to FullCalendar's root namespace
var View = FC.View;      // the class that all views must inherit from
var AgendaView;          // our subclass
var ListView;
var GnattView;
var BaselineView;
var PhasesListView;

AgendaView = View.extend({ // make a subclass of View
    initialize: function () {
    },
    render: function () {
        this.el.html('<div class="fc-view fc-agendaWeek-view fc-agenda-view" style=""><div class="toolbatHolder">' +
            '<button class="">Show Earlier</button >' +
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
            var postData = { "projectId": parseInt(projectId), "selectedDate": $("#datepicker").val() };
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
                '<td> Day 9 of 20</td> ' +
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
            $.each(dailyEvents, function (index, day) {
                t.el.find('.listviewtable').append(t.dayHtml(day.date, day.events));
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
    dayHtml: function (day, events) {
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
                '<td>' + event.startDate + '</td>' +
                '<td>' + event.endDate + '</td>' +
                '<td>' +
                '<div style="margin: 0 auto; display: table">' +
                '<div style="margin-right: 23px;">' + event.assignedTo + '</div>' +
                '<div style="position: relative; left: 76px; top: 50%; margin-top: -12px;">' +
                '<div style="float: none; position: relative; cursor: pointer" class="show-more-recipients-header" title="Expand/Collapse"></div>' +
                '</div>' +
                '</div>' +
                '</td>' +
                '<td>' +
                '<input type="checkbox" id="chkconfirm' + index + '" />' +
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
            '</div>' +
            '</div>');
        t.el.find('.phaseHolder').append('<div class="phaseBody">' +
            '<div class="phaseBodyHolder"></div></div>');
           
        t.el.find('.phaseBodyHolder').append('<div class="phaseBodyHolderTop">' +
            '<table>' +
            '<tbody>' +
            '<tr>' +
            '<td style="border-right: 1px solid #d1d1d1; position: relative">' +
            '<div class="Status fieldHeader">Status: <span>Completed</span></div>' +
            '<div class="ExpandPhase">' +
            '<a href="javascript:void(0);">' +
            '<img border="0" src="/images/Common/edit.gif">' +
            '</a>' +
            '</div>' +
            '<div class="CheckBoxPhase">' +
            '<input name="chkPhaseSelected" type="checkbox">' +
            '</div>' +
            '<div class="PhaseTitle">' +
            '<span>1542</span>' +
            '</div>' +
            '</td>' +
            '<td style="width: 20%; border-right: 1px solid #d1d1d1;">' +
            '<div class="tdContent">' +
            '<div style="float: left">' +
            '<div class="fieldHeader">Start Date</div>' +
            '<span>05/03/2018</span>' +
            '</div>' +
            '<div style="float: right">' +
            '<div class="fieldHeader" style="text-align: right">End Date</div>' +
            '<span>27/03/2018</span>' +
            '</div>' +
            '<div style="clear: both"></div>' +
            '</div>' +
            '</td>' +
            '<td style="width: 13%; min-width: 200px">' +
            '<div class="tdContent">' +
            '<div class="fieldHeader">Items Completed</div>' +
            '<span>1</span> / <span >1</span>' +
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
            '<tr data-bind="template: { name: headerTemplate }">' +
            '<th style="width: 15px;"></th>' +
            '<th style="width: 180px; text-align: left; display: none;" data-bind="visible: parent.multipleJobsSelected">Jobsite</th>' +
            '<th style="width: 230px; text-align:left;">Schedule Item Title</th>' +
            '<th style="width: 50px; text-align:left;">Dur.</th>' +
            '<th style="width: 130px; text-align:left;">Start</th>' +
            '<th style="width: 130px; text-align:left;">Finish</th>' +
            '<th style="width: 85px;" data-bind="visible: !AsyncJobPickerHelper.GetJobPickerVM().templatesOnly()">Completed</th>' +
            '<th style="text-align:left;">Assigned To</th>' +
            '</tr>' +
            '</thead>' +
            '<tbody class="tdschedule">' +
            
            '</tbody>' +
            '</table>' +
            '</div>' +
            '</div>');
        function getDailyEvents(data) {
            dailyEvents = [];
            $.each(data, function (index, day) {
                dailyEvents.push({
                    date: day.start,
                    events: [day]
                });
            });
            $.each(dailyEvents, function (index, day) {
                t.el.find('.tdschedule').append('<tr class="whiteBack">' +
                    '<td><input name="chkPhaseItem" type="checkbox" value="48843727"></td>' +
                    '<td class="tdL" style="display: none;"><span data-bind="    text: jobName"></span></td>' +
                    '<td class="tdL"><a href="javascript:void(0);" >' + day.events[0].title + '</a></td>' +
                    '<td style="text-align:left;"><span >' + day.events[0].duration + '</span></td>' +
                    '<td class="tdL"><span >' + convert(day.events[0].startDate,'/') + '</span></td>' +
                    '<td class="tdL"><span >' + convert(day.events[0].endDate, '/') + '</span></td>' +
                    '<td class="tdC" ><input name="chkPhaseItemCompleted" type="checkbox" ></td>' +
                    '<td style="text-align:left;"><span title="aryan singh">' + day.events[0].assignedTo + '</span></td>' +
                    ' </tr>');
            });
        }
    },
    destroyEvents: function () {
    },
    renderSelection: function (range) {
    },
    destroySelection: function () {
    }
});
FC.views.PhasesList = PhasesListView; 