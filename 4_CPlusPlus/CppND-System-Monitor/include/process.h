#ifndef PROCESS_H
#define PROCESS_H

#include <string>

using namespace std;
/*
Basic class for Process representation
It contains relevant attributes as shown below
*/
class Process {
 public:
  Process() {}
  
  Process (int ipid, string user, string comm, float cputil, string ram, int uptime)
  {
     _pid = ipid;
    _user = user;
    _command = comm;
    _cputilize = cputil;
    _ram = ram;
    _uptime = uptime;
  }
  int Pid() ;                               // TODO: See src/process.cpp
  std::string User();                      // TODO: See src/process.cpp
  std::string Command();                   // TODO: See src/process.cpp
  float CpuUtilization();                  // TODO: See src/process.cpp
  std::string Ram();                       // TODO: See src/process.cpp
  long int UpTime();                       // TODO: See src/process.cpp
  bool operator<(Process const& a) const;  // TODO: See src/process.cpp

 private:
    int _pid = 0;
    string _user = "";
    string _command = " ";
    float _cputilize = 0.0;
    string _ram = " ";
    int _uptime = 0;
};

#endif