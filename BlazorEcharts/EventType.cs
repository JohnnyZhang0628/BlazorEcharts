namespace BlazorEcharts
{
    
    public enum EventType
    {
        /// <summary>
        /// 点击
        /// </summary>
        click,

        /// <summary>
        /// 双击
        /// </summary>
        dblclick,

        /// <summary>
        /// 当鼠标指针移动到元素上方，并按下鼠标左键时，会发生 mousedown 事件。
        /// </summary>
        mousedown,

        /// <summary>
        /// 当鼠标指针在指定的元素中移动时，就会发生 mousemove 事件。
        /// </summary>
        mousemove,

        /// <summary>
        /// 当鼠标指针移动到元素上方，并松开鼠标左键时，会发生 mouseup 事件。
        /// </summary>
        mouseup,

        /// <summary>
        /// 当鼠标指针位于元素上方时，会发生 mouseover 事件。
        /// </summary>
        mouseover,

        /// <summary>
        /// 当鼠标指针离开被选元素时，会发生 mouseout 事件。
        /// </summary>
        mouseout,

        /// <summary>
        ///
        /// </summary>
        globalout,

        /// <summary>
        ///
        /// </summary>
        contextmenu,

        /// <summary>
        /// 图例选中后的事件。
        /// </summary>
        legendselectchanged,

        /// <summary>
        /// 图例取消选中后的事件。
        /// </summary>
        legendunselected,

        /// <summary>
        /// 图例全选后的事件。
        /// </summary>
        legendselectall,

        /// <summary>
        /// 图例反选后的事件。
        /// </summary>
        legendinverseselect,

        /// <summary>
        /// 图例滚动事件。
        /// </summary>
        legendscroll,

        /// <summary>
        /// 数据区域缩放后的事件。
        /// </summary>
        datazoom,

        /// <summary>
        /// 视觉映射组件中，range 值改变后触发的事件。
        /// </summary>
        datarangeselected,

        /// <summary>
        /// 时间轴中的时间点改变后的事件。
        /// </summary>
        timelinechanged,

        /// <summary>
        ///  时间轴中播放状态的切换事件。
        /// </summary>
        timelineplaychanged,

        /// <summary>
        /// 重置 option 事件。
        /// </summary>
        restore,

        /// <summary>
        /// 工具栏中数据视图的修改事件。
        /// </summary>
        dataviewchanged,

        /// <summary>
        /// 工具栏中动态类型切换的切换事件。
        /// </summary>
        magictypechanged,

        /// <summary>
        /// geo 中地图区域切换选中状态的事件。用户点击选中会触发该事件。
        /// </summary>
        geoselectchanged,

        /// <summary>
        /// geo 中地图区域选中后的事件。
        /// 使用dispatchAction可触发此事件，用户点击不会触发此事件（用户点击事件请使用 geoselectchanged）。
        /// </summary>
        geoselected,

        /// <summary>
        /// geo 中地图区域取消选中后的事件。
        /// 使用dispatchAction可触发此事件，用户点击不会触发此事件（用户点击事件请使用 geoselectchanged）。
        /// </summary>
        geounselected,

        /// <summary>
        /// series-pie 中饼图扇形切换选中状态的事件。 用户点击选中会触发该事件。
        /// </summary>
        pieselectchanged,

        /// <summary>
        /// series-pie 中饼图扇形选中后的事件。
        /// 使用dispatchAction可触发此事件，用户点击不会触发此事件（用户点击事件请使用 pieselectchanged）。
        /// </summary>
        pieselected,

        /// <summary>
        /// series-pie 中饼图扇形取消选中后的事件.
        /// 使用dispatchAction可触发此事件，用户点击不会触发此事件（用户点击事件请使用 pieselectchanged）。
        /// </summary>
        pieunselected,

        /// <summary>
        /// series-map 中地图区域切换选中状态的事件。 用户点击选中会触发该事件。
        /// </summary>
        mapselectchanged,

        /// <summary>
        /// series-map 中地图区域选中后的事件。使用dispatchAction可触发此事件，用户点击不会触发此事件（用户点击事件请使用 mapselectchanged）。
        /// </summary>
        mapselected,

        /// <summary>
        /// series-map 中地图区域取消选中后的事件。
        /// 使用dispatchAction可触发此事件，用户点击不会触发此事件（用户点击事件请使用 mapselectchanged）。
        /// </summary>
        mapunselected,

        /// <summary>
        /// 平行坐标轴 (Parallel)范围选取事件。
        /// 当进行坐标轴范围选取时，可以用如下方式获取当前高亮的线所对应的 data indices （即 series 的 data 中的序号列表）。
        /// </summary>
        axisareaselected,

        /// <summary>
        /// graph的邻接节点高亮事件。
        /// </summary>
        focusnodeadjacency,

        /// <summary>
        /// graph的邻接节点取消高亮事件。
        /// </summary>
        unfocusnodeadjacency,

        /// <summary>
        /// “选框正在添加”事件。即发出 brush action 得到的事件。
        /// </summary>
        brush,

        /// <summary>
        /// 选框添加完毕”事件。即发出 brushEnd action 得到的事件。
        /// </summary>
        brushEnd,

        /// <summary>
        /// 对外通知当前选中了什么。
        /// </summary>
        brushselected,

        /// <summary>
        ///
        /// </summary>
        globalcursortaken,

        /// <summary>
        /// 渲染结束事件。注意 rendered 事件并不代表渲染动画（参见 animation 相关配置）或者渐进渲染（参见 progressive 相关配置）停止，只代表本帧的渲染结束。
        /// </summary>
        rendered,

        /// <summary>
        /// 渲染完成事件。当渲染动画（参见 animation 相关配置）或者渐进渲染（参见 progressive 相关配置）停止时触发。
        /// </summary>
        finished
    }
}