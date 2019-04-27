const defaultConfig = require('../config/default.config.json');
const { tppl } = require('tppl');
const http = require('axios');
const fs = require('fs');
const path = require('path');

const config = Object.assign({}, defaultConfig);

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
    const outputDir = path.resolve(process.cwd(), config.outputDir);

    if (!fs.existsSync(outputDir)) {
        fs.mkdirSync(outputDir);
    }

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

module.exports = async function run(optionsConfig) {
    var cwdConfigPath = path.resolve(process.cwd(), '.restapi.config');
    let cwdConfig, userConfig;
    if (fs.existsSync(cwdConfigPath)) {
        cwdConfig = require(cwdConfigPath);
    }
    var userConfigPath = path.resolve('~', '.restapi.config');
    if (fs.existsSync(userConfigPath)) {
        userConfig = require(userConfigPath);
    }
    Object.assign(config, cwdConfig, userConfig, optionsConfig);
    try {
        let doc;
        try {
            doc = (await http.get(config.swaggerUrl)).data;
        } catch(ex) {
            console.error(ex);
            return;
        }

        generate('./tpls/ApiClient.tppl', { doc });
        const modelsDir = path.resolve(process.cwd(), config.outputDir, config.modelsDir);
        if (!fs.existsSync(modelsDir)) {
            fs.mkdirSync(modelsDir);
        }

        for([name, model] of Object.entries(doc.definitions)) {
            const outputPath = path.resolve(modelsDir, name + '.cs');
            generate('./tpls/Model.tppl', { doc, model, modelName: name }, outputPath);
        }
    } catch(ex) {
        console.error(ex);
    }
}
