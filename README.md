> 声明： 该项目已经被功能更强大的 [`rest-api-client-builder`](https://github.com/jovercao/rest-api-client-builder) 替代，请移步至[https://github.com/jovercao/rest-api-client-builder](https://github.com/jovercao/rest-api-client-builder)。

# C# RestApiClient代码生成器

> 用于生成C#，RestApiClient客户端库的代码生成器

该生成器使用nodejs编写，使用前请安装Nodejs。
使用 `jojoin/tppl` 模板引擎生成代码。

## 与VisualStudio自带生成器对比

- 支持net framework 4.0（XP系统应用开发必须）
- 可配置
- 可脱离visual studio环境运行

## 使用方法

**安装：**
```bash

# 安装到全局npm
npm install --global csharp-rest-client-builder

```

**生成：**
```
# 生成 http://your-host.com/swagger/docs/v1 到目录 d:\rest-client\ 下
restapi-build -o "d:\rest-client\" "http://your-host.com/swagger/docs/v1"

```

您还可以使用以下命令查看命令说明
```bash
restapi-build --help
```

生成后的代码依赖以下库运行：

- `RestSharp@105.2.3.0`
- `Newtonsoft.Json@8.0.3`

请为使用代码的项目添加以上Nuget依赖。


## 配置文件

本工具还支持配置文件，配置路径为当前路径下的 `.restapi.json` 文件，  
具体配置参考如下：

```json
{
    // swagger服务器地址
    "swaggerUrl": "http://your-host.com/swagger/docs/v1",
    // 客户端默认命名空间（完整命名空间），ApiClient类存于此处，默认值: RestApiClient
    "clientNamespace": "RestApiClient",
    // Models的子命名空间（仅须填写子命名空间）,默认值：ClientModels
    "modelsNamespace": "ClientModels",
    // 生成的文件输出路径，默认值：outputs
    "outputDir": "../",
    // Models的输出路径，默认值：ClientModels
    "modelsDir": "ClientModels"
}
```
