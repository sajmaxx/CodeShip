// JavaScript Document

var xhr = new XMLHttpRequest();
xhr.open('GET', "data.json", true);
xhr.responseType = 'text';



xhr.onload = function() {
    if(xhr.status === 200) {
        var myStuff = JSON.parse(xhr.responseText);
        console.log(myStuff);


        for(i=0; i < myStuff.presidents.length; i++)
        {
            console.log(myStuff.presidents[i].first);
        }
        
        for(i=0; i < myStuff.vicepresidents.length; i++)
        {
            console.log(myStuff.vicepresidents[i].first);
        }


        var mystringy = "";

        for(i=0; i< myStuff.presidents.length; i++)
        {
            var x = i +1;
            mystringy +=  "President " + x + " was ";
            mystringy += myStuff.presidents[i].first + " " +  myStuff.presidents[i].last + "<br>";

        }
        document.getElementById('message').innerHTML = mystringy;

    } // end if
} // end function


xhr.send();

