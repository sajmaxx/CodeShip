// JavaScript Document

var xmlhr = new XMLHttpRequest();

xmlhr.open('GET','data.json',true);

xmlhr.responseType = 'text';


xmlhr.onload = function()
{
    if(xmlhr.status === 200)
    {
        var mydata = JSON.parse(xmlhr.responseText);
        console.log(mydata);

        console.log(mydata[1]);
        console.log(mydata[3]);
    }
}



xmlhr.send();