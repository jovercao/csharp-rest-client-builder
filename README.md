# C# RestApiClient代码生成器

> 用于生成C#，RestApiClient客户端库的代码生成器

该生成器使用nodejs编写，使用前请安装Nodejs。

## 与VisualStudio自带生成器对比

- 支持net framework 4.0（XP系统应用开发必须）
- 可配置
- 可脱离visual studio环境运行

## 使用方法

```shell
# 下载生成器
git clone https://github.com/jovercao/csharp-rest-client-builder.git
cd csharp-rest-client-builder

# 安装nodejs依赖
npm install

# 执行生成
node .
```

*注意:执行生成前请修改配置，参考[配置](##配置)*

生成后的代码依赖以下库运行：

- `RestSharp@105.2.3.0`
- `Newtonsoft.Json@8.0.3`

请为使用代码的项目添加以上Nuget依赖。

## 配置
所有配置均在 `swagger.config.json` 文件中，具体配置如下：

```json
{
    // swagger服务器地址
    "swaggerUrl": "http://124.16.7.242:8082/swagger/docs/v1",
    // 客户端命名空间（完整命名空间）
    "clientNamespace": "MeashiftRestApiClient",
    // Models的子命名空间（仅须填写子命名空间）
    "modelsNamespace": "ClientModels",
    // 生成的文件输出路径
    "outputDir": "../",
    // Models的输出路径
    "modelsDir": "ClientModels"
}
```
