#include <unistd.h>
#include <cstddef>
#include <set>
#include <string>
#include <vector>
#include <iostream>

#include "process.h"
#include "processor.h"
#include "system.h"
#include "linux_parser.h"

using std::set;
using std::size_t;
using std::string;
using std::vector;
using namespace LinuxParser;
using namespace std;

// TODO: Return the system's CPU
Processor& System::Cpu() 
{
  
  return cpu_; 
}

// TODO: Return a container composed of the system's processes
vector<Process>& System::Processes() 
{ 
   vector<int> vectorPids =  LinuxParser::Pids();
   for (int currrentPid : vectorPids)
   {
     //int currrentPid = i;// vectorPids[i];

     Process locProc =  Process (currrentPid, "", "", 0.0, "", 0); //currrentPid, usernam, " ", 0.0, " ", 0);
     
     // Process (int ipid, string user, string comm, float cputil, string ram, int uptime)
     processes_.push_back(locProc);
     
   } 
  return processes_; 
}

// Return the system's kernel identifier (string)
std::string System::Kernel() 
{
 	return LinuxParser::Kernel();
}

//Return the system's memory utilization
float System::MemoryUtilization() 
{ 
  return  LinuxParser::MemoryUtilization(); 
}

//  Return the operating system name
std::string System::OperatingSystem() 
{ 
  return LinuxParser::OperatingSystem(); 
}

// Return the number of processes actively running on the system
int System::RunningProcesses() 
{ 
  return LinuxParser::RunningProcesses(); 
}


// TODO: Return the total number of processes on the system
int System::TotalProcesses() 
{ 
  return LinuxParser::TotalProcesses(); 
}

// TODO: Return the number of seconds since the system started running
long int System::UpTime() 
{ 
   return LinuxParser::UpTime();
}