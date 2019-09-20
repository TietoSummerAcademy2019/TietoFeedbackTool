var constants = require('../consts');
const chromedriver = require("chromedriver");

module.exports = {
  'Should display question when created': async function (browser) {
    var displayData = browser.page.tietoFeedbackToolDisplayData();
    var questionSite = browser.page.tietoFeedbackToolQuestion();
    var text = 'What could you improve in our site?';
    var domain = "Tieto.com";

    questionSite
      .navigate()
      .waitForElementPresent('@textArea', constants.TIMEOUT)
      .setValue('@domainArea', domain)
      .setValue('@textArea', text)
      .click('@radioButtonRight')
      .pause(2000)
      .click('@submit')
      .pause(2000)

    displayData
      .navigate()
      .waitForElementPresent('@lastElement')
      .click('@lastElement')
      .waitForElementPresent('@questionItem', constants.TIMEOUT)
      .assert.containsText('@questionItem', text)
      .pause(2000)
  },
  'Should display error message when submit empty question': async function (browser) {
    var homeSite = browser.page.tietoFeedbackToolQuestion();
    var text = "Please declare all fields below.";

    homeSite
      .navigate()
      .waitForElementPresent('@textArea', constants.TIMEOUT)
      .click('@submit')
      .waitForElementPresent('@errorMessage', constants.TIMEOUT)
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