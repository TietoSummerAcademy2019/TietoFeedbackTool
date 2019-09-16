module.exports = {
    url:'https://localhost:44350',
    elements:{
        seeMore:{
            selector: 'see-more',
            locateStrategy: 'class name'
        },
        questions:{
            selector: 'information-question-information',
            locateStrategy: 'class name'
        },
        questionItem:{
            selector :'//div[@class = "information-question-information"]//div[last()]',
            locateStrategy:'xpath'
        },
        userName:{
            selector:'information-question-header',
            locateStrategy: 'class name'
        },
        answerItem:{
            selector:'//tbody//tr[last()]//td[3]',
            locateStrategy:'xpath'
        }

    }

    
}