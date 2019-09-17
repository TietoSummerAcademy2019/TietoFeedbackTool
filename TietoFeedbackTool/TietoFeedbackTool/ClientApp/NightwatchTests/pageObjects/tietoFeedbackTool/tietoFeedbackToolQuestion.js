module.exports = {
  url: 'https://localhost:44350/new-question',
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