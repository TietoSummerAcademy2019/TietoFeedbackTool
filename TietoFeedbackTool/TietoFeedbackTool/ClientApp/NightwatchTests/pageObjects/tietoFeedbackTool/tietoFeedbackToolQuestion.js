module.exports = {
  url: function () {
    return this.api.launchUrl + "/new-question";
  },
  elements: {
    submit: {
      selector: 'submit',
      locateStrategy: 'class name'
    },
    textArea: {
      selector: 'question-text',
      locateStrategy: 'class name'
    }
  }
}