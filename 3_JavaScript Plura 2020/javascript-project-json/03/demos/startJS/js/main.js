// JavaScript Document
var startJsonStr = '{"favColor":"Orange", "favSeason":"Fall"}';

var myObject = JSON.parse(startJsonStr);

console.log(myObject);

var myString = JSON.stringify(myObject);
console.log(myString);


var thedata1 = '{"first":"Paul", "last":"McCartney", "city":"NYC"}';
personObj = JSON.parse(thedata1);
console.log(personObj);

document.getElementById('messager').innerHTML = personObj.last + "\t" + personObj.first;



var thedata2 = '{"Jane":{"age":"29","weight":"160","SN":"4444"}, "Jim":{"age":"32","weight":"180","SN":"7777"}}';
var peopleObj = JSON.parse(thedata2);
console.log(peopleObj);

document.getElementById('peopledata').innerHTML = peopleObj.Jim.age;


var thepeopledegrees = '{"Jane": {"degree":{"BSC":"VMI","MSC":"UofM"}}, "JJ":{"degree":{"BSC":"UofKorea", "MSC":"UofMich", "PHD":"UofT"}} }';
var peopledegreeob = JSON.parse(thepeopledegrees);
console.log(peopledegreeob);




