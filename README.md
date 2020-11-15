# BlazorEcharts [![GitHub license](https://img.shields.io/github/license/JohnnyZhang0628/BlazorEcharts)](https://github.com/JohnnyZhang0628/BlazorEcharts/blob/main/LICENSE) [![NuGet](https://img.shields.io/nuget/v/BlazorEcharts)](https://www.nuget.org/packages/BlazorEcharts/) ![downloads](https://img.shields.io/nuget/dt/BlazorEcharts)
基于blazor封装Echarts组件,[在线演示网址](http://blazor-echarts.5izhy.cn/)

## 起步
1、安装 `BlazorEcharts`

`Install-Package BlazorEcharts`

2、在 `wwwroot/index.html` 文件 (Blazor WebAssembly) 或 `Pages/_Host.cshtml` 文件 (Blazor Server) 中添加引用

```
<script src="_content/BlazorEcharts/echarts.min.js"></script>
<script src="_content/BlazorEcharts/main.js"></script>
```
在`Startup`的`ConfigureServices`方法中，添加配置
```
 // 如果不监听finished事件，不需要添加该配置
        services.AddSignalR(e =>
        {
            e.MaximumReceiveMessageSize = long.MaxValue;
        });
```
3、新建`razor`组件,复制以下代码
```
Echarts Option="@option" Debug="true" EventTypes="EventTypes" OnEventCallback="OnEchartsEvent"></Echarts>
<div>
    @if (callbackArgs != null)
    {
        <p>事件回调类型:@callbackArgs.EventType</p>
        <p>事件回调参数:@callbackArgs.ToString()</p>
    }
</div>

@code{

    private object option;
    private EchartsEventArgs? callbackArgs;

    // 添加一个点击事件、渲染完成事件
    private List<EventType> EventTypes = new List<EventType> { EventType.click, EventType.finished };

    protected override void OnInitialized()
    {

        option = new
        {
            Title = new { Text = "Basic Line Chart" },
            Tooltip=new {Formatter="function(params){return '星期：'+params.name+',数值：'+params.value;}".ToJsFunction()},
            XAxis = new
            {
                Type = "category",
                Data = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" }
            },
            YAxis = new { Type = "value" },
            Series = new object[] {
                new
                {
                   Data =new double[]{820, 932, 901, 934, 1290, 1330, 1320 },
                   Type = "line"
                }

           }
        };

    }

    private void OnEchartsEvent(EchartsEventArgs args)
    {
        callbackArgs = args;
    }

}
```
## 组件配置选项
|  名称   | 数据类型  | 默认值 | 是否必须 | 说明|
|  ---- |---- | ----  | ----|----|
|Option|object |null |是|是图标配置选项|
| Id | string | guid | 否|div id |
| Width |  double | 800 |否|div 宽度 |
|Height|double |600 |否|div 高度|
|Debug| bool|false|否|开启debug模式，打印option、事件回调参数
|EventTypes| List &lt;EventType&gt;||否|开启监听事件类型.
|OnEventCallback| EventCallback&lt;EchartsEventArgs&gt;||否|监听事件回调函数


