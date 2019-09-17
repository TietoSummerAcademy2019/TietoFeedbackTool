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
      .click('@submit')

    displayData
      .navigate()
      .waitForElementPresent('@lastElement')
      .click('@lastElement')
      .waitForElementPresent('@questionItem', constants.TIMEOUT)
      .assert.containsText('@questionItem', text)
  },
  'Should display error message when submit empty question': async function (browser) {
    var homeSite = browser.page.tietoFeedbackToolQuestion();

    homeSite
      .navigate()
      .waitForElementPresent('@textArea', constants.TIMEOUT)
      .click('@submit')
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
      .assert.elementPresent("@copyText")
  }
}