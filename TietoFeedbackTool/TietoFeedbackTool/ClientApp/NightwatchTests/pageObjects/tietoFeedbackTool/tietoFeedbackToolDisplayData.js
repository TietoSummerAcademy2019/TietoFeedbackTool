module.exports = {
  url: function () {
    return this.api.launchUrl;
  },
  elements: {
    lastElement: {
      selector: '(//div[@class = "survey-list"]//div[@class ="survey-list-item"])[last()]//img',
      locateStrategy: 'xpath'
    },
    seeMore: {
      selector: 'see-more',
      locateStrategy: 'class name'
    },
    questions: {
      selector: 'information-question-information',
      locateStrategy: 'class name'
    },
    questionItem: {
      selector: '//div[@class = "information-question-information"]//div[last()]',
      locateStrategy: 'xpath'
    },
    userName: {
      selector: 'information-question-header',
      locateStrategy: 'class name'
    },
    answerItem: {
      selector: '//tbody//tr[last()]//td[3]',
      locateStrategy: 'xpath'
    }
  }
}