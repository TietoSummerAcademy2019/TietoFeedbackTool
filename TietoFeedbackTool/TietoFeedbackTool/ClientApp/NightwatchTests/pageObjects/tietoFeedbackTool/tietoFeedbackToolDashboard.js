module.exports = {
  url: function () {
    return this.api.launchUrl;
  },
  elements: {
    seeMore: {
      selector: 'see-more',
      locateStrategy: 'class name'
    },
    title: {
      selector: '//div[@class="col-2 title"]',
      locateStrategy: 'xpath'
    },
    textArea: {
      selector: 'question-text',
      locateStrategy: 'class name'
    },
    trackingCode: {
      selector: 'survey-action',
      locateStrategy: 'id'
    },
    copyText: {
      selector: 'text-copy',
      locateStrategy: 'id'
    },
    userNameText: {
      selector: 'information-question-header',
      locateStrategy: 'class name'
    }
  }
}