#include "processor.h"
#include "linux_parser.h"

#include <vector>

using namespace std;

// TODO: Return the aggregate CPU utilization
float Processor::Utilization() 
{
  
  vector<string> cpuvector =  LinuxParser::CpuUtilization(); 
  
  
   return LinuxParser::CPUPercentage();
  

}