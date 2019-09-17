module.exports = {
    url:'https://localhost:44350',
    elements:{
        title:{
            selector :'//h1',
            locateStrategy: 'xpath'
        },
        languageBtn:{
           selector:'dropdown-toggle' ,
           locateStrategy : 'class name'
        },
        suomiBtn:{
            selector:'dropdown-item',
            locateStrategy : 'class name'
        } 
    }
}