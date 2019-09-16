var constants = require('../consts');

module.exports = {
 

       
    'Should take elements': async function(browser){
        var displayData = browser.page.tietoFeedbackToolDisplayData();
        var questionSite = browser.page.tietoFeedbackToolQuestion();
        var text = 'NewQuestion';

        
        
        questionSite
            .navigate()
            .waitForElementPresent('@textArea', constants.TIMEOUT)
            .setValue('@textArea',text)
            .click('@submit');
        
       
        displayData
            .navigate()
            .waitForElementPresent('@questionItem', constants.TIMEOUT)
            .assert.containsText('@questionItem',text);

        
        /*function(result){
            result.value.map(function(element,err){
                browser.elementIdAttribute(element.ELEMENT, 'innerText',function(res){
                
                    val+=res.value;
                   
                })
            })
        });*/
    }
}