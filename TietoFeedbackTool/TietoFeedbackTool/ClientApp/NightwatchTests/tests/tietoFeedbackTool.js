var constants = require('../consts');

module.exports = {
 
    'Should created question be displayed in display page': async function(browser){
        var displayData = browser.page.tietoFeedbackToolDisplayData();
        var questionSite = browser.page.tietoFeedbackToolQuestion();
        var text = 'What could you improve in our site?';

        
        questionSite
            .navigate()
            .waitForElementPresent('@textArea', constants.TIMEOUT)
            .setValue('@textArea',text)
            .pause(500)
            .click('@submit')
            .pause(500);
        
       
        displayData
            .navigate()
            .waitForElementPresent('@lastElement')
            .click('@lastElement')
            .pause(500)
            .waitForElementPresent('@questionItem', constants.TIMEOUT)
            .assert.containsText('@questionItem','What could you improve in our site?')
            .pause(500);
        
     
    },
    'Should created answer be displayed in display page': async function(browser){

        //THIS TEST REQUIRE THAT YOU HAVE FIRST QUESTION ENABLED AND WITH CORRECT DOMAIN

        var displayData = browser.page.tietoFeedbackToolDisplayData();
        var answerSite = browser.page.tietoFeedbackToolMarkingBar();

        var answer = 'Not really';
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
            .click('@seeMore')
            .waitForElementPresent('@answerItem',constants.TIMEOUT)
            .pause(500)
            .assert.containsText('@answerItem',answer)

    },
    'Should error message appear after trying to submit empty answer': async function(browser){
        var homeSite = browser.page.tietoFeedbackToolMarkingBar();

        homeSite
            .navigate()
            .waitForElementPresent('@feedbackTool',constants.TIMEOUT)
            .click('@feedbackTool')
            .pause(500)
            .click('@submitBtn')
            .pause(200)
            .assert.elementPresent('#need')
    },
    
   'Should change content after pressing see more': async function(browser){
    var homeSite = browser.page.tietoFeedbackToolDashboard();

    homeSite
        .navigate()
        .waitForElementPresent('@seeMore',constants.TIMEOUT)
        .click('@seeMore')
        .waitForElementPresent('h1',constants.TIMEOUT)
        .assert.containsText("h1","Mr.Daddy")
        .click('img')
        .pause(500)
   },
   
   'Should change content to tracking code after pressing tracking code button': async function(browser){
    var homeSite = browser.page.tietoFeedbackToolDashboard();

    homeSite
        .navigate()
        .waitForElementPresent('@trackingCode',constants.TIMEOUT)
        .click('@trackingCode')
        .pause(500)
        .assert.containsText("h1","Tracking Code Generator")
        .pause(500)
   }
}