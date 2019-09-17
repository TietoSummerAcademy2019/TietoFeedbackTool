var constants = require('../consts');
const chromedriver = require("chromedriver");

module.exports = {
  'Should display question when created': async function (browser) {
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
  'Should display error message when submit empty question': async function (browser) {
    var homeSite = browser.page.tietoFeedbackToolQuestion();

    homeSite
      .navigate()
      .waitForElementPresent('@textArea', constants.TIMEOUT)
      .pause(1000)
      .click('@submit')
      .pause(500)
  },
  'Should change content when pressed see more': async function (browser) {
    var homeSite = browser.page.tietoFeedbackToolDashboard();

    homeSite
      .navigate()
      .waitForElementPresent('@seeMore', constants.TIMEOUT)
      .click('@seeMore')
      .waitForElementPresent('@userNameText', constants.TIMEOUT)
      .assert.containsText("@userNameText", "Mr.Daddy")
      .click('img')
  },
  'Should display tracking code when clicked tracking code button': async function (browser) {
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