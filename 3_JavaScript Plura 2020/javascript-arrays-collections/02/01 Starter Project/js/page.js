
let ctx = document.getElementById('monthlySales').getContext('2d');

let pieCtx = document.getElementById('deptSales').getContext('2d');


let monthylSales = Array.of(14, 34, 24, 44 , 114);
let monthlyLabels = Array.of('Aug','Sep','Oct', 'Nov', 'Dec');


function addYearlyTotal(a,b,c,d,e)
{
    return a+b+c+d+e;
}
//
let yearlytotal = addYearlyTotal(...monthylSales);
alert(yearlytotal);

alert(10101);

var monthSalesChar = new Chart(ctx,
    {
        type: 'bar',
        data: {
                  labels:monthlyLabels,
                datasets:[{ 
                                label : "# of Sales",
                                data:monthylSales,
                                backgroundColor:[                                    
                                    'rgba(238, 184, 104, 1)',
                                    'rgba(75, 166, 223, 1)',
                                    'rgba(239, 118, 122, 1)',
                                    'rgba(75, 166, 123, 1)',
                                    'rgba(75, 166, 63, 1)',

                                ],
                                borderWidth: 0
                        }]
                }
            }
                          
);

let depData = Array.of(13,55,33);
let depLabels = Array.of('Hiking' , 'Running', 'Cycling');

var deptSales = new  Chart( pieCtx, 
    
    {
       type: 'pie',
       data: { 
               labels : depLabels,
               datasets: [{
                   label:'# of Sales',
                   data: depData,
               backgroundColor: [
                                   'rgba(238, 134, 104, 1)',
                                   'rgba(175, 16, 223, 1)',
                                   'rgba(239, 118, 122, 1)',
                                      ],
                                      bordeWidth:0
               
             }]

       },
       options: {}

    });





