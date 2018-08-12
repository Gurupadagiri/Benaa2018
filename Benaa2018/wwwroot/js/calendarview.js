var FC = $.fullCalendar; // a reference to FullCalendar's root namespace
var View = FC.View;      // the class that all views must inherit from
var AgendaView;          // our subclass
//var ListView; 
var GnattView;
var BaselineView;
var PhasesListView;

AgendaView = View.extend({ // make a subclass of View

    initialize: function () {
        //alert('hi');
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
            '<input type= "submit" name= "" value= "Go" > ' +
            '</div> ' +
            '</div></div><div class="dataHolder">' +
            '<table class="innercontent"></table>' +
            '</div>');
        // responsible for displaying the skeleton of the view within the already-defined
        // this.el, a jQuery element.
    },
    setHeight: function (height, isAuto) {
        // responsible for adjusting the pixel-height of the view. if isAuto is true, the
        // view may be its natural height, and `height` becomes merely a suggestion.
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
                '<td>' + event.title + '</td>' +
                '<td>Shahnawaz Khan (+1)</td>' +
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
                '<div style="float: none; position: relative; cursor: pointer" class="show-more-recipients-header" title="Expand/Collapse" onclick="DynamicGrid.expandCollapseAll("",event)">...</div>' +
                '</div>' +
                '</div>' +
                '</td>' +
                '<td>' +
                'User Confirm&nbsp;<img src="images/UserControls/iconToolTip.png" class="ToolTip" style="cursor:pointer;" border="0" data-bind="tooltip: true" data-tooltip="This column displays the status of the user confirmation(s) for this schedule item. ' +
                'If there is only one user assigned to the item, a checkbox will appear to indicate' +
                'the status of the confirmation, with the check being placed once the user has confirmed the schedule item.' +
                'If multiple users have been assigned to the schedule item, 3 numbers will be displayed: number of accepted' +
                'confirmations, number of declined confirmations, and number of pending confirmations respectively.' +
                'If any number of users have declined this schedule item, a red X will appear in the same field." data-hasqtip="6">' +
                '</td>' +
                '<td class="checkBox">' +
                '<img src="images/ownerIcon.png" title="Show Owner?" width="15">' +
                '</td>' +
                '<td>Pred</td>' +
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
                '<div style="margin-right: 23px;">Shahnawaz Khan</div>' +
                '<div style="position: relative; left: 76px; top: 50%; margin-top: -12px;">' +
                '<div style="float: none; position: relative; cursor: pointer" class="show-more-recipients-header" title="Expand/Collapse" onclick="DynamicGrid.expandCollapseAll("",event)">...</div>' +
                '</div>' +
                '</div>' +
                '</td>' +
                '<td>' +
                'User Confirm&nbsp;<img src="images/UserControls/iconToolTip.png" class="ToolTip" style="cursor:pointer;" border="0" data-bind="tooltip: true" data-tooltip="This column displays the status of the user confirmation(s) for this schedule item. ' +
                'If there is only one user assigned to the item, a checkbox will appear to indicate' +
                'the status of the confirmation, with the check being placed once the user has confirmed the schedule item.' +
                'If multiple users have been assigned to the schedule item, 3 numbers will be displayed: number of accepted' +
                'confirmations, number of declined confirmations, and number of pending confirmations respectively.' +
                'If any number of users have declined this schedule item, a red X will appear in the same field." data-hasqtip="6">' +
                '</td>' +
                '<td class="checkBox">' +
                '<img src="images/ownerIcon.png" title="Show Owner?" width="15">' +
                '</td>' +
                '<td>Pred</td>' +
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
        var postData = { "projectId": parseInt(projectId) };
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
BaselineView = View.extend({ // make a subclass of View

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
        // responsible for undoing everything in renderEvents
    },
    renderSelection: function (range) {
        // accepts a {start,end} object made of Moments, and must render the selection
    },
    destroySelection: function () {
        // responsible for undoing everything in renderSelection
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

        // called once when the view is instantiated, when the user switches to the view.
        // initialize member variables or do other setup tasks.
    },
    render: function () {
        this.el.html('<div class="phaseslistview">Phases List View</div>');
        // responsible for displaying the skeleton of the view within the already-defined
        // this.el, a jQuery element.
    },
    setHeight: function (height, isAuto) {
        // responsible for adjusting the pixel-height of the view. if isAuto is true, the
        // view may be its natural height, and `height` becomes merely a suggestion.
    },
    renderEvents: function (events) {
        // reponsible for rendering the given Event Objects
        console.dir(events);
    },
    destroyEvents: function () {
        // responsible for undoing everything in renderEvents
    },
    renderSelection: function (range) {
        // accepts a {start,end} object made of Moments, and must render the selection
    },
    destroySelection: function () {
        // responsible for undoing everything in renderSelection
    }

});
FC.views.PhasesList = PhasesListView; 