'use strict';

(function() 
{
     //display('Hello World');

    document.getElementById('output').innerHTML = 'Hello World!!!';

    let firstName = 'Joe';
    let lastName = 'Dunlop';

    let person = { firstComp: 'Dunlop', secondComp: 'Goodyear' };

    person.age = 44;

    person.isYoung = function() { return this.age <= 55; }

   



   let spock = {
       firstName : 'Leo',
       lastName : 'Nimoy',
       age : 54,
       isVulcan() { return this.firstName = 'Leo';}
   };
   
   document.getElementById('output').innerHTML = person.firstComp +  '\t\t' + person.secondComp
                                                 +  '\t' + person.age + '\t' + person.isYoung() + '\t'
                                                 + spock.firstName + '\t' + spock.isVulcan();

  console.log(Object.keys(spock)); 


  let spock2 = {};

  Object.assign(spock2,spock);  

  console.log(spock2);


  let spock3 = {  planet : 'mars'} ;

  let spock4 = Object.assign({},spock,spock3);

  console.log(spock);
  console.log(spock4);

   /*
    dynamically created objects! available in javascript!
    you can completely change the shape of an object as you go along in your code!

    can you do that
   */


  /// Use Constructor functions or classes to make objects of the same type

  function Car( brand, model, yearmfg)
  {
      this.Brand = brand;
      this.Model = model;
      this.YearMfg = yearmfg;
  }

  let ferrari = new Car('Ferrari', 'Testarossa', 1994);

  console.log(ferrari);

})();