module.exports = {
  url: function () {
    return this.api.launchUrl;
  },
  elements: {
    seeMore: {
      selector: 'see-more',
      locateStrategy: 'class name'
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