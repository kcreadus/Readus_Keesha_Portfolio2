var data = {
    "location":{
        "city":"Orlando",
        "country": "United States",
        "region": "FL"
          },
    "results": {
           "distance": "mi" ,
        "pressure": "ins",
        "speed": "mph",
        "temperature": "F"
    ,
    "wind":{
        "chill": "76",
    "direction": "360",
    "speed":"5"
    },

    "astronomy":{
        "sunrise": "7:26",
        "sunset": "6:51"
    },
    "condition":[
        {
            "code":"33", "date": "Fri, 17 Oct 2014 5:53 am EST", "temp": "76", "text": "Fair"
        }
    ],
    "forecast":[
        {"code":"30", "date":"17 Oct 2014", "day":"Friday", "high":"80", "low": "62", "text":"Sunny"},
        { "code":"30", "date":"18 Oct 2014", "day":"Saturday", "high":"82", "low":"63", "text":"Partly Cloudy"},
        { "code":"30", "date":"9 Oct 2014", "day":"Sunday", "high":"85", "low":"65", "text":"Partly Cloudy"}
    ]
}}

console.log(data.results.forecast[2].day)
console.log(`Today is ${data.results.forecast[0].day }. The high is ${data.results.forecast[0].high}. The low is ${data.results.forecast[0].low }. It will be ${data.results.forecast[0].text}`)
console.log(`Today is ${data.results.forecast[1].day }. The high is ${data.results.forecast[1].high}. The low is ${data.results.forecast[1].low }. It will be ${data.results.forecast[1].text}`)
console.log(`Today is ${data.results.forecast[2].day }. The high is ${data.results.forecast[2].high}. The low is ${data.results.forecast[2].low }. It will be ${data.results.forecast[2].text}`)