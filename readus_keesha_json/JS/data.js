//JSON Text
var text = '{ "employees" : [' +
    '{ "firstName":"John" , "lastName":"Doe" },' +
    '{ "firstName":"Anna" , "lastName":"Smith" },' +
    '{ "firstName":"Peter" , "lastName":"Jones" } ]}';

//JSON Object

var myJSON = {"people":[
    {"name":"John", "job":"Construction"},
    {"name":"Anna", "job":"Teacher"},
    {"name":"Peter", "job":"Astronaut"}
]}

var obj = JSON.parse(text);
console.log(obj);

console.log(obj.employees[1].firstName + " " + obj.employees[1].lastName);




console.log(myJSON.people[0].job);

console.log(`${obj.employees[0].firstName } ${obj.employees[0].lastName} ${myJSON.people[0].job}`);
console.log(`${obj.employees[1].firstName } ${obj.employees[1].lastName} ${myJSON.people[1].job}`);
console.log(`${obj.employees[2].firstName } ${obj.employees[2].lastName} ${myJSON.people[2].job}`);