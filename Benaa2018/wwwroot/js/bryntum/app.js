Ext.application({
    name: 'Gnt.examples.baseline',

    requires: [
        'Gnt.examples.baseline.view.Gantt',
        'Sch.util.Date'
    ],

    launch: function () {
        Ext.QuickTips.init();

        Ext.create('Ext.Viewport', {
            layout: 'border',

            items: [
                Ext.create('Gnt.examples.baseline.view.Gantt', {
                    region  : 'center'
                }),
                {
                    xtype: 'details'
                }
            ]
        });
    }
});
