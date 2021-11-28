#include <string>
#include <cmath>

#include "format.h"

using std::string;

// TODO: Complete this helper function  ✔
// INPUT: Long int measuring seconds ✔
// OUTPUT: HH:MM:SS  ✔
// REMOVE: [[maybe_unused]] once you define the function  ✔
string Format::ElapsedTime(long seconds) 
{ 
  int hours;
  
  hours = seconds/3600;
  
  double hoursasfrac = seconds/3600.0;
  
  double minutesfrac = (hoursasfrac - hours)*60;
   
  int minutes = std::trunc(minutesfrac);
  
  int secs = (minutesfrac - minutes)*60;
   
  string stringhrs;
    string stringmin;
    string stringsecs;
  
  
  if (hours < 10)
  {
    stringhrs = "0" +  std::to_string(hours);
  }
  else
  {
     stringhrs = std::to_string(hours);
  }
  
  if (minutes < 10)
  {
    stringmin = "0" +  std::to_string(minutes);
  }
  else
  {
     stringmin = std::to_string(minutes);
  }
  
  
  if (secs < 10)
  {
    stringsecs = "0" +  std::to_string(secs);
  }
  else
  {
     stringsecs = std::to_string(secs);
  }
  
  return stringhrs  + ":" +  stringmin  + ":" +  stringsecs; 
}