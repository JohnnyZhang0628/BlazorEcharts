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

        // 生命周期只触发一次的事件
        var tiggerOnceEventList = ['finished'];

        target.on(eventType, function (params) {
            var echartsEventArgs = {};
            echartsEventArgs.eventType = eventType;

            // 渲染完成，获取图片
            if (eventType === 'finished') {
                echartsEventArgs.dataUrl = target.getDataURL();
            }

            // 生命周期只触发一次的事件，触发后，解绑事件
            if (tiggerOnceEventList.indexOf(eventType) > -1)
                target.off(eventType);

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

            // console.log(echartsEventArgs)
            dotnetHelper.invokeMethodAsync('EchartsEventCaller', JSON.stringify(echartsEventArgs));
        });
    }
};