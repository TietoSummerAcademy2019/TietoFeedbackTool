var constants = require('../consts');

module.exports = {
 
    /*
       
    'Should created question be displayed in display page': async function(browser){
        var displayData = browser.page.tietoFeedbackToolDisplayData();
        var questionSite = browser.page.tietoFeedbackToolQuestion();
        var text = 'NewQuestion';

        
        questionSite
            .navigate()
            .waitForElementPresent('@textArea', constants.TIMEOUT)
            .setValue('@textArea',text)
            .pause(500)
            .click('@submit')
            .pause(500);
        
       
        displayData
            .navigate()
            .waitForElementPresent('@questionItem', constants.TIMEOUT)
            .assert.containsText('@questionItem',text)
            .pause(500);
        
     
    },

    'Should created answer be displayed in display page': async function(browser){
        var displayData = browser.page.tietoFeedbackToolDisplayData();
        var answerSite = browser.page.tietoFeedbackToolMarkingBar();

        var answer = 'New answer';
        answerSite 
            .navigate()
            .waitForElementPresent('@feedbackTool',constants.TIMEOUT)
            .pause(500)
            .click('@feedbackTool')
            .pause(500)
            .setValue('@answerInput',answer)
            .pause(500)
            .click('@submitBtn');
        displayData
            .navigate()
            .waitForElementPresent('@answerItem',constants.TIMEOUT)
            .pause(500)
            .assert.containsText('@answerItem',answer)

    },
    'Should change language after switching flag': async function(browser){
        var homeSite = browser.page.tietoFeedbackToolHome();

        homeSite
            .navigate()
            .waitForElementPresent('@languageBtn',constants.TIMEOUT)
            .pause(500)
            .assert.containsText('@title','Welcome to TietoFeedbackTool!')
            .click('@languageBtn')
            .pause(200)
            .click('@suomiBtn')
            .assert.containsText('@title','Tervetuloa TietoFeedbackTool!')
    },

    */
    'Should error message appear after subitting empty answer': async function(browser){
        var homeSite = browser.page.tietoFeedbackToolMarkingBar();

        homeSite
            .navigate()
            .waitForElementPresent('@feedbackTool',constants.TIMEOUT)
            .click('@feedbackTool')
            .pause(500)
            .click('@submitBtn')
            .pause(200)
            .assert.elementPresent('#need')
    }
}