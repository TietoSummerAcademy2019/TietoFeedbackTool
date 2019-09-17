module.exports = {
  url: 'https://localhost:44350',
  elements: {
    feedbackTool: {
      selector: 'marking-bar',
      locateStrategy: 'id'
    },
    answerInput: {
      selector: 'answer-input',
      locateStrategy: 'class name'
    },
    submitBtn: {
      selector: 'survey-submit',
      locateStrategy: 'id'
    },
    errorMsg: {
      selector: 'error-label',
      locateStrategy: 'class name'
    }
  }
}