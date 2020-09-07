// JavaScript Document
var hotelInfo;
var details;
var xhr = new XMLHttpRequest();
xhr.open('GET', "data.json", true);
xhr.responseType = 'text';
xhr.send();


xhr.onload = function() {
    if(xhr.status === 200) {
        hotelInfo = JSON.parse(xhr.responseText);
        console.log(hotelInfo);
  
    } // end if
} // end function


function display_JSONData(x)
{
    console.log(x);
    document.getElementById('roomName').innerHTML = hotelInfo[x].name;
    document.getElementById('desc').innerHTML = hotelInfo[x].description;
    document.getElementById('photo').src = hotelInfo[x].photo;
    
    document.getElementById('weekday').innerHTML = hotelInfo[x].cost.weekday;
    document.getElementById('weekend').innerText =  hotelInfo[x].cost.weekend;

    details = "";

    for(var i = 0; i < hotelInfo[x].details.length; i++)    
    {
        console.log(hotelInfo[x].details[i]);
        details +=  "<p>" +  hotelInfo[x].details[i] + "</p>";
    }

    document.getElementById('details').innerHTML = details;
    
}


/*
        <button onclick="">Southern Serenade</button>
        <button onclick="">Enchanted Escape</button>
        <button onclick="">Sandy Suite</button>
        */