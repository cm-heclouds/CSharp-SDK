# OneNET_SDK
中移物联网产品OneNET的SDK，目前本Repository仅包含C#版本，如需Java等其他版本以及了解更多，请前往https://open.iot.10086.cn/doc 查看

本程序是中移物联的OneNET公众版C#版本的SDK(完整版本)。.NET版本为4.0。

本SDK包含了OneNET平台的设备、数据流、数据点、触发器和api key的增删改查，以及二进制数据存取、命令执行、历史数据和日志查询功能。

本程序一共包含两个项目：OneNetSDK和APITest，前者为SDK项目，后者为其单元测试项目。SDK使用案例请直接参照单元测试即可。

注意事项：

1. 本程序引用了第三方库Newtonsoft.Json, 所以在使用本SDK DLL时须同时引用Newtonsoft.Json DLL。

2. 为保证Json解析得到正确结果，请保证实体（Entity）的字段命名和OneNET官方文档的字段命名一致（忽略大小写但保持下划线横线等）。

3. data point类型下的value字段由于自定义功能而未设置具体类型。目前转化结果是jRaw类型(json raw)，另含一个GetValue()的string方法，可自定义具体类型并做一次json解析得到。

4. 本SDK凡是含Object类型字段的post请求，若不能正常工作且无特殊说明，都建议使用JRaw包装一次提交，示例：new JRaw("{\"sim\":123456445}")。
