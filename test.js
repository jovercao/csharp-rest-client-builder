
const doc = require('./swagger.simple.json');
const config = require('./swagger.config.json');

function test() {
    var $ = '' + '';
    function resolveRefType($ref) { return config.modelsNamespace + '.' + $ref.substring($ref.lastIndexOf('/') + 1); }
    function resolveRefSchema($ref) { return $ref.substring(1).split('/').reduce((total, current) => total[current], this.doc) } function resolveType(schema) {
        if (schema.type) { if (scheam.type === 'array') { return resolveType(schema.items) + '[]'; } if (schema.format) { return schema.format } } if (schema.schema) { return resolveType(schema.schema); } if (schema.$ref) {
            return modelName(resolveRefType(schema.$ref));
        } throw new Error('未能转换类型');
    }
    $ = $ + '\n/*\n* 本文档由swagger客户端生成工具自动生成\n* 作者： Jover\n*/\nusing Newtonsoft.Json;\nusing RestSharp;\n\nnamespace '
        + (this.config.clientNamespace) + '\n{\n    // RestSharp 文档地址 https://github.com/restsharp/RestSharp\n    // \n    public class ApiClient\n    {\n        private RestClient client;\n        public ApiClient(string url)\n        {\n            client = new RestClient(url);\n        }\n\n';
    for (var path in this.doc.paths) {
        var methods = Object.keys(path);
        let methodName = path.substring(path.lastIndexOf('/') + 1);
        for (let hm in methods) {
            const method = path[hm];
            const httpMethod = hm[0].toUpperCase() = hm.substring(1);
            if (methods.length > 1) { methodName = httpMethod + methodName; }
            let returnType = resolveType(method.response['200']);
            $ = $ + '\n        public ' + (returnType) + ' ' + (methodName) + '('
                + (method.parameters.map(parameter => resolveType(parameter) + parameter.name).join(','))
                + ')\n        {\n            var request = new RestRequest("' + (path) + '", RestSharp.Method.'
                + (httpMethod.toUpperCase()) + ');\n            var response = client.Execute' + (httpMethod)
                + '(request);\n            return Newtonsoft.Json.JsonConvert.DeserializeObject<' + (returnType) + '>(response.Content);\n        }\n';
        }
    }
    $ = $ + '\n    }\n}';
    return $;

}

var txt = test.apply({
    doc,
    config
})

console.log(txt);
