'use strict';
var stringUtils = require("ember-cli-string-utils");

module.exports = {
  description: '\nUsage: ember g sc path::<(dasherized)name>\n\n' + 
               'sc = MICIP special component generator \n' + 
               '     This creates 4 files linked to component generation in specified path locations:\n' +
               '     Path Base                       Name                     Description\n' +
               '     app/components/<path>           <name>.component.css    sass/css/css file\n' +
               '     app/components/<path>           <name>.ts                typescript file\n' +
               '     app/components/<path>           <name>.hbs               handlebars page\n\n' +
               '     tests/integration/components/   <name>-test.ts           integration test.',    
  //description displayed when called at command line:   ember help generate sc

  normalizeEntityName: function(entityName) {
    return entityName || "my-new-component";
  },

  locals: function(options) {
    //set up local variables to use inside the files 
    const pathArray = options.entity.name.split('::');
    const componentName = pathArray[pathArray.length - 1];
    const classyName = stringUtils.classify(componentName.replace(/\//g, '-'));
    const fullLocalFilePathName = options.entity.name.replace(/::/g, '/');
    //replace() only replaces first unless use g (global) flag

    //these variables will be replaced inside the templates inside <%=  ... %>
    //example for styleModule:
    // File Location: /styles/<%= entity.styleModule.moduleName %>    
    //might produce:
    // File Location: /styles/jim-test.component.css  
    //from line below called from cli: ember g sc jim-test
    options.entity.styleModule = { moduleName: componentName + ".component.css" };
    options.entity.typescriptModule = { moduleName: componentName + ".ts" };
    options.entity.pageModule = { moduleName: componentName };
    options.entity.testModule = { moduleName: componentName };
    options.entity.fullPath = { moduleName: fullLocalFilePathName };
    options.entity.classyName = { moduleName: classyName };

    return options;
  },

  fileMapTokens: function(options) {
    const fullFilePathName = options.dasherizedModuleName.replace(/::/g, '/'); 
    const pathArray = options.dasherizedModuleName.split('::');
    const componentName = pathArray[pathArray.length - 1];

    //Return custom tokens to be replaced in your files, returns the files
    //built based on your templates
    return {
      __styleToken__: function(/* options */) {
        console.log("app/componenents/" + fullFilePathName + ".component.css");
        return fullFilePathName + ".component";
      },
      __typescriptToken__: function(/* options */) {
        console.log("app/componenents/" + fullFilePathName + ".ts");
        return fullFilePathName;
      },
      __pageToken__: function(/* options */) {
        console.log("app/componenents/" + fullFilePathName + ".hbs");
        return fullFilePathName;
      },
      __testToken__: function(/* options */) {
        //the test is hard-coded for path below
        console.log("tests/integration/components/" + componentName + "-test.ts");
        return "integration/components/" + componentName + "-test";
      }
    }
  }
};