var constants = require('../consts');
const chromedriver = require("chromedriver");

module.exports = {
  'Should created question be displayed in display page': async function (browser) {
    var displayData = browser.page.tietoFeedbackToolDisplayData();
    var questionSite = browser.page.tietoFeedbackToolQuestion();
    var text = 'What could you improve in our site?';

    questionSite
      .navigate()
      .waitForElementPresent('@textArea', constants.TIMEOUT)
      .setValue('@textArea', text)
      .pause(1000)
      .click('@submit')
      .pause(1000);

    displayData
      .navigate()
      .waitForElementPresent('@lastElement')
      .click('@lastElement')
      .pause(1000)
      .waitForElementPresent('@questionItem', constants.TIMEOUT)
      .assert.containsText('@questionItem', text)
      .pause(1000);
  },
  'Should error message appear after trying to submit empty question': async function (browser) {
    var homeSite = browser.page.tietoFeedbackToolQuestion();

    homeSite
      .navigate()
      .waitForElementPresent('@textArea', constants.TIMEOUT)
      .pause(1000)
      .click('@submit')
      .pause(200)
      .assert.elementPresent('#need')
  },

  'Should change content after pressing see more': async function (browser) {
    var homeSite = browser.page.tietoFeedbackToolDashboard();

    homeSite
      .navigate()
      .waitForElementPresent('@seeMore', constants.TIMEOUT)
      .click('@seeMore')
      .waitForElementPresent('h1', constants.TIMEOUT)
      .assert.containsText("h1", "Mr.Daddy")
      .click('img')
      .pause(1000)
  },

  'Should change content to tracking code after pressing tracking code button': async function (browser) {
    var homeSite = browser.page.tietoFeedbackToolDashboard();

    homeSite
      .navigate()
      .waitForElementPresent('@trackingCode', constants.TIMEOUT)
      .click('@trackingCode')
      .pause(1000)
      .assert.elementPresent("@copyText")
      .pause(1000)
  }
}