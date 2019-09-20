module.exports = {
  url: function () {
    return this.api.launchUrl + "/new-question";
  },
  elements: {
    submit: {
      selector: 'submit',
      locateStrategy: 'class name'
    },
    domainArea: {
      selector: 'domain-input',
      locateStrategy: 'class name'
    },
    textArea: {
      selector: 'question-input',
      locateStrategy: 'class name'
    },
    radioButtonRight: {
      selector: 'position-right-label',
      locateStrategy: 'id'
    },
    radioButtonBottom: {
      selector: 'position-bottom-label',
      locateStrategy: 'id'
    },
    errorMessage: {
      selector: 'validation-error',
      locateStrategy: 'id'
    }
  }
}