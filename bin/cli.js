#!/usr/bin/env node
const program  = require('commander');
const { version } = require('../package.json');

program.version(version)
    .arguments('[swaggerUrl]')
    .option('-n --client-namespace <namespace>', '客户端默认命名空间（完整命名空间），ApiClient类存于此处')
    .option('-m --models-namespace <namespace>', 'models命名空间，')
    .option('-o --output-dir <dir>', '生成的文件输出路径，默认值：outputs')
    .option('-d --models-dir <dir>', 'Models的输出路径，默认值：ClientModels')
    .action((swaggerUrl, options) => {
        var cmdOptions = {};
        if (swaggerUrl) {
            cmdOptions.swaggerUrl = swaggerUrl;
        }
        if (options.clientNamespace) {
            cmdOptions.clientNamespace = options.clientNamespace;
        }
        if (options.modelsNamespace) {
            cmdOptions.modelsNamespace = options.modelsNamespace;
        }
        if (options.outputDir) {
            cmdOptions.outputDir = options.outputDir;
        }
        if (options.modelsDir) {
            cmdOptions.modelsDir = options.modelsDir;
        }

        require('../index')(cmdOptions);
    });

program.parse(process.argv);
