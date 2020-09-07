// JavaScript Document
var xmlhr = new XMLHttpRequest();

xmlhr.open('GET','data.json',true);
xmlhr.responseType='text';

xmlhr.onreadystatechange = function()
{
    console.log(xmlhr.readyState);
    console.log(xmlhr.statusText);
}

xmlhr.onload = function()
{
    if(xmlhr.status === 200)
    {
        var mydata = JSON.parse(xmlhr.responseText);
        console.log(mydata);
    }
}

xmlhr.send();



var sajAjaxReq = new XMLHttpRequest();
sajAjaxReq.open('GET','data.json',true/*async*/);
sajAjaxReq.responseType = 'text';

sajAjaxReq.onreadystatechange  = function()
{
    console.log('2nd ajax ' + xmlhr.readyState);
    console.log('2nd ajax ' + xmlhr.statusText);    
}

sajAjaxReq.onload = function()
{
    if(sajAjaxReq.status === 200)
    {
        var sommohdata = JSON.parse(sajAjaxReq.responseText);
        console.log(sommohdata);
        document.getElementById("moma").innerHTML = sommohdata[0].first + ' ' +sommohdata[0].last;  
        document.getElementById("moma1").innerHTML = sommohdata[1].first + ' ' +sommohdata[1].last;  
    }
}
sajAjaxReq.send();