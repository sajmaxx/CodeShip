//test suite for Covid 19
var lastusa, lastswed;
var covid19data = new XMLHttpRequest();
var coviObj;

covid19data.open('GET','https://api.covid19api.com/countries',true);
covid19data.responseType = 'text';
covid19data.onload = function()
{
   coviObj = JSON.parse(covid19data.responseText);
   //console.log(coviObj);
   
}
covid19data.send();



var covSummaryData = new XMLHttpRequest();
var covSummObj;
covSummaryData.open('GET','https://api.covid19api.com/summary',true);
covSummaryData.responseType = 'text';
covSummaryData.onload = function()
{
  //  covSummObj = JSON.parse(covSummaryData.responseText);    

}
covSummaryData.send();


var covUSAData = new XMLHttpRequest();
var covUSAObj;
covUSAData.open('GET', 'https://api.covid19api.com/total/country/united-states', true);
covUSAData.responseType = 'text';

var  usaChartData = new Array(101);
var swedenChartData = new Array(101);


covUSAData.onload = async function asyncUSAfunc()
{
    covUSAObj = JSON.parse(covUSAData.responseText);
    lastusa = covUSAObj[covUSAObj.length-1];
    document.getElementById('country1').innerText = 'Country ' + lastusa.Country;
    document.getElementById('data11').innerText = 'Date ' +lastusa.Date;
    document.getElementById('data12').innerText = 'Deaths ' +lastusa.Deaths;
    document.getElementById('desc1').innerText = 'Confirmed ' +lastusa.Confirmed;
    document.getElementById('calc1').innerText = 'Confirmed ' +lastusa.Confirmed;    
    console.log(lastusa);

     
    for(i = 0; i < 101; i ++) 
    {  
         lastusa = covUSAObj[i];
        let usadata = {x : 0,  value : 0 };     
        usadata.x = i;
        usadata.value = lastusa.Confirmed;         
        usaChartData[i] = usadata;
        // console.log(usaChartData[i] );
    }  

    chart = anychart.line();
    var series = chart.line(usaChartData);
    chart.title('USA Covid 19 2020');   
    chart.container('USAChart');
    chart.draw();

    
}
covUSAData.send();



    var covSwedenData = new XMLHttpRequest();
    var covSwedObj;

    covSwedenData.open('GET','https://api.covid19api.com/total/country/sweden', true);
    covSwedenData.responseType = 'text';
    covSwedenData.onload =  async function asyncSwedfunc()
    {
        covSwedObj = JSON.parse(covSwedenData.responseText);
        lastswed = covSwedObj[covSwedObj.length-1];
        document.getElementById('country2').innerText = 'Country ' +lastswed.Country;
        document.getElementById('data21').innerText = 'Date ' +lastswed.Date;
        document.getElementById('data22').innerText = 'Deaths ' +lastswed.Deaths;
        document.getElementById('desc2').innerText = 'Confirmed ' +lastswed.Confirmed;    
        document.getElementById('calc2').innerText = 'Confirmed ' +lastswed.Confirmed;    
        
    for(i =0; i < 101; i++)
    {
        lastswed = covSwedObj[i];
        let swedData = { x:0, value:0};
        swedData.x = i;
        swedData.value =  lastswed.Confirmed;
        swedenChartData[i] = swedData;
        console.log(swedenChartData[i] );
    }

    Swedenchart = anychart.line();
    var series  = Swedenchart.line(swedenChartData);
    Swedenchart.title('Sweden Covid 19 2020');
    Swedenchart.container('SwedenChartContainer');
    Swedenchart.draw();


    }
    covSwedenData.send();


console.log('*** ' + usaChartData.length);
console.log('*** ' +  swedenChartData.length);
        
var Allchart = anychart.line();
Allchart.animation(true);
         var series1 = Allchart.line(usaChartData);
         series1.name = "USA";
         var series2  = Allchart.line(swedenChartData);
         series2.name = "Sweden";    
          Allchart.title('USA and Sweden Covid 19 2020');
          Allchart.container('AllChartContainer');
          Allchart.draw();
    

      
    


// create first series with mapped data
// var firstSeries = chart.line(firstSeriesData);
// firstSeries.name('Brandy');
// firstSeries.hovered().markers()
//   .enabled(true)
//   .type('circle')
//   .size(4);
// firstSeries.tooltip()
//   .position('right')
//   .anchor('left-center')
//   .offsetX(5)
//   .offsetY(5);

// // create second series with mapped data
// var secondSeries = chart.line(secondSeriesData);
// secondSeries.name('Whiskey');
// secondSeries.hovered().markers()
//   .enabled(true)
//   .type('circle')
//   .size(4);
// secondSeries.tooltip()
//   .position('right')
//   .anchor('left-center')
//   .offsetX(5)
//   .offsetY(5);



///BUILD YOUR FIRST DATA VISUALIZATION USING ANYCHART.JS!
/// WHY USE ANYCHART?


///TODO HOWS TO DO async awaits on 2 the above XMLHttpRequests!  5/17/2020


/*
<div id="country1">Country</div>
<div id="data11">00000</div>
<div id="data12">00</div>
<div id="desc1"> ...awaiting data..</div>       

<div id="country2">Country</div>
<div id="data21">00000</div>
<div id="data22">00</div>
<div id="desc2"> ...awaiting data..</div>  
*/
//
//https://api.covid19api.com/live/country/south-africa