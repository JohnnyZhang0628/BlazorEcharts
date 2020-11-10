// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.echartsFunction = {
    echartsInstance: {},
    getInstance: function (domId) {
        var tagert = this.echartsInstance[domId];
        if (tagert) {
            return tagert;
        }
        else {
            this.init(domId);
            return this.echartsInstance[domId];
        }
    },
    init: function (domId, theme = "", opts = {}) {
        if (!this.echartsInstance[domId]) {
            this.echartsInstance[domId] = echarts.init(document.getElementById(domId), theme, opts);
        }
        //return this.echartsInstance[domId];
    },
    connect: function (group) {
        echarts.connect(group);
    },
    disconnect: function (group) {
        echarts.disconnect(group);
    },
    dispose: function (domId) {
        var target = this.getInstance(domId);
        echarts.dispose(target);
        delete this.echartsInstance[domId];
    },
    registerMap: function (mapName, geoJson, specialAreas) {
        return echarts.registerMap(mapName, geoJson, specialAreas);
    },
    getMap: function (mapName) {
        return echarts.getMap(mapName);
    },
    registerTheme: function (themeName, theme) {
        return echarts.registerTheme(themeName, theme);
    },
    setOption: function (domId, option, notMerge = false, lazyUpdate = false) {
        //console.log(option);
        option = eval('(' + option + ')');
        this.getInstance(domId).setOption(option, notMerge, lazyUpdate);
    },
    on: function (domId, eventType, dotnetHelper) {
        var target = this.getInstance(domId);
        target.on(eventType, function (params) {
            console.log(domId)
            var echartsEventArgs = {};
            echartsEventArgs.eventType = eventType;
            if (params) {
                echartsEventArgs.componentType = params.componentType;
                echartsEventArgs.seriesType = params.seriesType;
                echartsEventArgs.seriesIndex = params.seriesIndex;
                echartsEventArgs.seriesName = params.seriesName;
                echartsEventArgs.name = params.name;
                echartsEventArgs.dataIndex = params.dataIndex;
                echartsEventArgs.data = params.data;
                echartsEventArgs.dataType = params.dataType;
                echartsEventArgs.value = params.value;
                echartsEventArgs.color = params.color;
                echartsEventArgs.info = params.info;
            }
            dotnetHelper.invokeMethodAsync('EchartsEventCaller', echartsEventArgs);
        });
    }
};