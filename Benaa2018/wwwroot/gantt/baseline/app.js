Ext.application({
    name: 'Gnt.baseline',

    requires: [
        'Gnt.baseline.view.Gantt',
        'Sch.util.Date'
    ],

    launch: function () {
        Ext.QuickTips.init();

        Ext.create('Gnt.baseline.view.Gantt', {
            layout: 'border',

            items: [
                Ext.create('Gnt.baseline.view.Gantt', {
                    region  : 'center',
                }),
                {
                    xtype: 'details'
                }
            ]
        });
    }
});
