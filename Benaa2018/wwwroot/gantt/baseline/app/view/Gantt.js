/**
 * This example shows both the current plan and the original baseline.
 */
Ext.define('Gnt.examples.baseline.view.Gantt', {
    extend : 'Gnt.panel.Gantt',

    requires : [
        'Gnt.column.Name',
        'Gnt.column.BaselineStartDate',
        'Gnt.column.BaselineEndDate',
        'Sch.plugin.Pan',
        'Gnt.plugin.taskeditor.TaskEditor',
        'Gnt.plugin.TaskContextMenu',
        'Gnt.plugin.DependencyEditor',
        'Sch.plugin.TreeCellEditing'
    ],

    dependencyViewConfig : {
        overCls : 'dependency-over'
    },

    title : 'Baseline demo',

    // enables showing baseline for tasks
    enableBaseline  : true,
    // show baselines from start
    baselineVisible : true,

    viewPreset        : 'monthAndYear',
    rowHeight         : 40,
    highlightWeekends : false,

    lockedGridConfig : { width : 401 },

    columns : [
        {
            xtype : 'namecolumn',
            width : 200
        },
        {
            // column with baseline start date of a task
            xtype : 'baselinestartdatecolumn'
        },
        {
            // column with baseline end date of a task
            xtype : 'baselineenddatecolumn'
        }
    ],

    plugins : [
        // enables task editing by double clicking, displays a window with fields to edit
        'gantt_taskeditor',
        // enables double click dependency editing
        'gantt_dependencyeditor',
        // shows a context menu when right clicking a task
        'gantt_taskcontextmenu',
        // column editing
        'scheduler_treecellediting',
        // plugin that allows gantt to be panned by dragging the view around
        'scheduler_pan'
    ],

    initComponent : function() {
        var me = this;

        var taskStore = new Gnt.data.TaskStore({
            proxy : {
                type   : 'ajax',
                url    : 'data/tasks.json'
            }
        });

        var dependencyStore = new Gnt.data.DependencyStore({
            //autoLoad : true,
            proxy    : {
                type   : 'ajax',
                url    : 'data/dependencies.json'
            }
        });

        Ext.apply(me, {
            taskStore       : taskStore,
            dependencyStore : dependencyStore,

            header : {
                items: [
                    {
                        xtype       : 'button',
                        text        : 'Show baseline task bars',
                        enableToggle: true,
                        pressed     : true,
                        style       : 'margin-right: 5px',
                        handler     : function () {
                            // Since we're using animation at baseline elements visibility toggling
                            // we will need to handel dependencies rendering properly
                            me.getDependencyView().setDrawDependencies(false);
                            // toggle baseline visibility
                            me.toggleBaseline();
                            // The animation is set to last 0.4s in the examples app.css
                            // thus we should re-enable dependency drawing in 0.5s
                            Ext.Function.defer(function() {
                                me.getDependencyView().setDrawDependencies(true);
                            }, 500);
                        }
                    },
                    {
                        xtype  : 'button',
                        text   : 'Set new baseline',
                        handler: function () {
                            // adjust baseline for all nodes to their current start and end dates
                            taskStore.getRoot().cascadeBy(function (node) {
                                node.beginEdit();
                                node.set('BaselineStartDate', node.getStartDate());
                                node.set('BaselineEndDate', node.getEndDate());
                                node.endEdit();
                            });
                        }
                    }
                ]
            }
        });

        me.callParent();

        dependencyStore.load();
    }
});
