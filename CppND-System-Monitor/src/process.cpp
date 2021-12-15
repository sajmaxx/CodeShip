#include <unistd.h>
#include <cctype>
#include <sstream>
#include <string>
#include <vector>

#include "process.h"
#include "linux_parser.h"

using std::string;
using std::to_string;
using std::vector;

// TODO: Return this process's ID
int Process::Pid() 
{
     return _pid; 
}


//Return this process's CPU utilization ✔
float Process::CpuUtilization() 
{ 

  _cputilize = LinuxParser::CPUPercentageByProcess(_pid);
  return _cputilize;
}


//Return the command that generated this process ✔
string Process::Command() 
{ 
  if (_command.length() == 0)
  {
    _command =  LinuxParser::Command(_pid);
    if (_command.length() == 0)
      _command = " "; //optmize
  }
  return _command; 
}

// TODO: Return this process's memory utilization
string Process::Ram() 
{   
  _ram =  LinuxParser::Ram(_pid);   
  return _ram; 
}

// TODO: Return the user (name) that generated this process
string Process::User() 
{ 
    if (_user.length() == 0)
    {
      _user = LinuxParser::User(_pid); 
    }
  
    return _user; 
}


// TODO: Return the age of this process (in seconds)
long int Process::UpTime() 
{ 
    _uptime  =  LinuxParser::UpTime(_pid); 
    return _uptime; 
}

//Overload the "less than" comparison operator for Process objects ✔
bool Process::operator<(Process const& a) const 
{ 
  return _pid < a._pid; 
}
