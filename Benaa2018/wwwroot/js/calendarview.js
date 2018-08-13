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
                '<td><div style="position: absolute; top: 0px; left: 0px; height: 100%"><div style="width: 10px; height: 100%; background-color: ' + event.colorCode + '"></div></div>' + event.title + '</td>' +
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
                '<td>Jobname</td>' +
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
                '<td>gdg</td>' +
                '<td class="title">' + event.title + '</td>' +
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
        var projectId = $("#projectid").text();
        var postData = { "projectId": parseInt(projectId), "selectedDate": ""};
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
            t.el.find('.fc-baseline-view').append('<p>Baseline set for the 5th time by aryan singh on 07/08/18</p>');
            $.each(dailyEvents, function (index, day) {
                t.el.find('.fc-baseline-view').append(dayBaselineSummary(dailyEvents));
            });
            t.el.find('.fc-baseline-view').append('<div class="con"><table class="listviewtable"></table><div>');
            $.each(dailyEvents, function (index, day) {
                t.el.find('.listviewtable').append(dayHtml(dailyEvents));
            });
        }
    },
    destroyEvents: function () {
    },
    renderSelection: function (range) {
    },
    destroySelection: function () {
    },
    dayHtml: function (events) {
        var dayHeader = '<tr class="header">' +
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
            '</tr ><tr class="contheader">';
        var dayFooter = '</tr>';
        var dayEvents = '';
        $.each(events, function (index, event) {
            dayEvents += '<td class="checkBox">' +
                '<img src= "">' +
                '</td>' +
                '<td>testing</td>' +
                '<td>(3 d)   3 d</td>' +
                '<td >(05-02-18) 05/02/18</td>' +
                '<td>(07-02-18) 07/02/18</td>' +
                '<td>0</td>' +
                '<td>-</td>' +
                '<td>0 d</td>' +
                '<td></td>' +
                '<td></td>' +
                '<td>Shahnawaz Khan</td>';
        });
        return dayHeader + dayEvents + dayFooter;
    },
    dayBaselineSummary: function (events) {
        var dayHeader = '<div class="SummaryHolder">' +
            '<h2> Baseline Summary</h2>' +
            '<table>' +
            '<tr>' +
            '<th></th>' +
            '<th>Duration</th>' +
            '<th>Start Date</th>' +
            '<th>End Date</th>' +
            '<th>Overall Slip</th>' +
            '</tr>';
        var dayFooter = '</table></div>';
        var dayEvents = '';
        $.each(events, function (index, event) {
            dayEvents += '<tr>' +
                '<td></td>' +
                '<td></td>' +
                '<td>(05-02-18) 05-02-18</td>' +
                '<td>(22-08-18) 22-08-18	</td>' +
                '<td></td>' +
                '</tr>';
        });
        return dayHeader + dayEvents + dayFooter;
    }

});
FC.views.Baseline = BaselineView;
PhasesListView = View.extend({ // make a subclass of View
    initialize: function () {
    },
    render: function () {
        this.el.html('<div class="phaseslistview">Phases List View</div>');
    },
    setHeight: function (height, isAuto) {
    },
    renderEvents: function (events) {
        console.dir(events);
    },
    destroyEvents: function () {
    },
    renderSelection: function (range) {
    },
    destroySelection: function () {
    }
});
FC.views.PhasesList = PhasesListView; 