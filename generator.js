const config = require('./swagger.config.json');
const { tppl } = require('./tppl');
const http = require('axios');
const fs = require('fs');
const path = require('path');

function generate(tplFile, datas, outputPath) {
    const resolveType = function(schema) {
        if (schema.type) {
            if (schema.type === 'array') {
                return resolveType(schema.items) + '[]';
            }
            if (schema.format) {
                switch (schema.format) {
                    case 'int32':
                        return 'int';
                    case 'int64':
                        return 'long';
                    case 'date-time':
                        return 'DateTime';
                    default:
                        return schema.format
                }
            }
            switch (schema.type) {
                case 'boolean':
                    return 'bool';
                default:
                    return schema.type;
            }
        }
        if (schema.$ref) {
            return config.modelsNamespace + '.' + schema.$ref.substring(schema.$ref.lastIndexOf('/') + 1);
        }
        if (schema.schema) {
            return resolveType(schema.schema);
        }
        throw new Error(`未能转换类型${schema}`);
    };

    var model = {
        config,
        resolveType,
        ...datas
        // resolveRefSchema: function($ref,) {
        //     return $ref.substring(1).split('/').reduce((total, current) => total[current], this.doc)
        // },
    };
    const outputDir = path.resolve(__dirname, config.outputDir);


    var apiClientTpl = readFile(tplFile);
    const render = tppl(apiClientTpl);
    if (!outputPath) {
        outputPath = path.resolve(outputDir, tplFile.substring(tplFile.lastIndexOf('/') + 1, tplFile.lastIndexOf('.')) + '.cs');
    }
    const content = render(model);
    writeFile(outputPath, content);
}


function readFile(filePath) {
    filePath = path.resolve(__dirname, filePath);
    return fs.readFileSync(filePath).toString();
}

function writeFile(filePath, data) {
    filePath = path.resolve(__dirname, filePath);
    fs.writeFileSync(filePath, data);
}

async function run() {
    try {
        let doc;
        try {
            doc = (await http.get(config.swaggerUrl)).data;
        } catch(ex) {
            console.error(ex);
            return;
        }
        generate('./ApiClient.tppl', { doc });
        for([name, model] of Object.entries(doc.definitions)) {
            const outputPath = path.resolve(__dirname, config.outputDir, config.modelsDir, name + '.cs');
            generate('./Model.tppl', { doc, model, modelName: name }, outputPath);
        }
    } catch(ex) {
        console.error(ex);
    }
}

run();
