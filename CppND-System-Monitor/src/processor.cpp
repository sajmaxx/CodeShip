#include "processor.h"
#include "linux_parser.h"

#include <vector>

using namespace std;

// TODO: Return the aggregate CPU utilization
float Processor::Utilization() 
{
  
  vector<string> cpuvector =  LinuxParser::CpuUtilization(); 
  if (cpuvector.size() > 0)
  { 
    string something = cpuvector.at(0);
    return std::stof(something); 
  }
  else
  {
    return 0;
  }
}