/*jslint browser:true */
/* my api key is 5a2d0fe71c6aca0ab128a227aec19c1d user name is   sajmaxx  May 16 2020*/

'use strict';

var weatherConditions = new XMLHttpRequest();
var weatherForecast = new XMLHttpRequest();
var cObj;
var fObj;


//test suite for Covid 19
var covid19data = new XMLHttpRequest();
var coviObj;

covid19data.open('GET','https://api.covid19api.com/countries',true);
covid19data.responseType = 'text';
covid19data.onload = function()
{
   coviObj = JSON.parse(covid19data.responseText);
   console.log(coviObj[0]);
   console.log(coviObj[1]);
   console.log(coviObj[2]);
}
covid19data.send();


//https://api.covid19api.com/summary
//https://api.covid19api.com/live/country/south-africa
//https://api.covid19api.com/live/country/south-africa



// GET THE CONDITIONS
 // api.openweathermap.org/data/2.5/weather?zip=45241,us&appid={5a2d0fe71c6aca0ab128a227aec19c1d}
weatherConditions.open('GET', '//api.openweathermap.org/data/2.5/weather?zip=45241,us&appid=5e6bcd6025ecafb3d47ccc6d7252b320&units=imperial', true);
weatherConditions.responseType = 'text';
weatherConditions.send(null);

weatherConditions.onload = function() 
{
    if (weatherConditions.status === 200){
        cObj = JSON.parse(weatherConditions.responseText);         
        document.getElementById('location').innerHTML = cObj.name;
        document.getElementById('weather').innerHTML = cObj.weather[0].description;
        document.getElementById('temperature').innerHTML = cObj.main.temp;
        document.getElementById('desc').innerHTML = cObj.wind.speed + " Wind Speed in mph";
    } //end if
}; //end function



// GET THE FORECAST
                                   
weatherForecast.open('GET', '//api.openweathermap.org/data/2.5/forecast?zip=45241,us&appid=5e6bcd6025ecafb3d47ccc6d7252b320&units=imperial', true);
weatherForecast.responseType = 'text'; 

weatherForecast.onload = function() 
{ 
  if(weatherForecast.status === 200)
  {    
    fObj  = JSON.parse(weatherForecast.responseText);
    console.log(fObj);
    
    var icon_path = "" + "http://openweathermap.org/img/w/04n.png" +  "";

    var date_raw =  fObj.list[0].dt_txt;    
    date_raw = date_raw.substring(5,11);
    document.getElementById('r1c1').innerHTML = date_raw;
    
    document.getElementById('r1c2').src = icon_path;
    document.getElementById('r1c3').innerHTML = fObj.list[0].main.temp_min + "&deg";
    document.getElementById('r1c4').innerHTML =  fObj.list[0].main.temp_max + "&deg";


    var date_raw =  fObj.list[1].dt_txt;    
    date_raw = date_raw.substring(5,11);
    document.getElementById('r2c1').innerHTML = date_raw;
    icon_path = "" + "http://openweathermap.org/img/w/04n.png" +  "";    
    document.getElementById('r2c2').src = icon_path;
    document.getElementById('r2c3').innerHTML = fObj.list[1].main.temp_min + "&deg";
    document.getElementById('r2c4').innerHTML =  fObj.list[1].main.temp_max + "&deg";


    var date_raw =  fObj.list[2].dt_txt;    
    date_raw = date_raw.substring(5,11);
    document.getElementById('r3c1').innerHTML = date_raw;
    icon_path = "" + "http://openweathermap.org/img/w/04n.png" +  "";    
    document.getElementById('r3c2').src = icon_path;
    document.getElementById('r3c3').innerHTML = fObj.list[2].main.temp_min + "&deg";
    document.getElementById('r3c4').innerHTML =  fObj.list[2].main.temp_max + "&deg";

    //r1c1     r1c2     r1c3 r1c4
  }
  
}; //end function

weatherForecast.send();






