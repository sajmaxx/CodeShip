#include <dirent.h>
#include <unistd.h>
#include <sstream>
#include <string>
#include <vector>
#include <iostream>
#include <cmath>

#include "linux_parser.h"

using std::stof;
using std::string;
using std::to_string;
using std::vector;

double glbCPUTotal = 1; //initialize only

// DONE: An example of how to read data from the filesystemcma
string LinuxParser::OperatingSystem() {
  string line;
  string key;
  string value;
  std::ifstream filestream(kOSPath);
  if (filestream.is_open()) {
    while (std::getline(filestream, line)) {
      std::replace(line.begin(), line.end(), ' ', '_');
      std::replace(line.begin(), line.end(), '=', ' ');
      std::replace(line.begin(), line.end(), '"', ' ');
      std::istringstream linestream(line);
      while (linestream >> key >> value) {
        if (key == "PRETTY_NAME") {
          std::replace(value.begin(), value.end(), '_', ' ');
          return value;
        }
      }
    }
  }
  return value;
}

// DONE: An example of how to read data from the filesystem
string LinuxParser::Kernel() {
  string os, kernel, version;
  string line;
  std::ifstream stream(kProcDirectory + kVersionFilename);
  if (stream.is_open()) {
    std::getline(stream, line);
    std::istringstream linestream(line);
    linestream >> os >> version >> kernel;
  }
  return kernel;
}

// BONUS: Update this to use std::filesystem
vector<int> LinuxParser::Pids() {
  vector<int> pids;
  DIR* directory = opendir(kProcDirectory.c_str());
  struct dirent* file;
  while ((file = readdir(directory)) != nullptr) {
    // Is this a directory?
    if (file->d_type == DT_DIR) {
      // Is every character of the name a digit?
      string filename(file->d_name);
      if (all_of(filename.begin(), filename.end(), isdigit)) {
        int pid = stoi(filename);
        pids.push_back(pid);
      }
    }
  }
  closedir(directory);
  return pids;
}


float LinuxParser::CPUPercentage()
{
  double PrevIdle, PrevIoWait, PrevUser, PrevNice, PrevSystem, PrevIrq, PrevSoftIrq, PrevSteal;
  string dataLine, data;
  std::ifstream stream(kProcDirectory + kStatFilename);
  if (stream.is_open())
  {
        
    std::getline(stream, dataLine);
    std::istringstream linestream(dataLine); 
    
    linestream >> data >> PrevUser >> PrevNice >> PrevSystem >> PrevIdle >> PrevIoWait >> PrevIrq >> PrevSoftIrq >> PrevSteal;
  }
  
  sleep(1);
  
  
  double Idle, IoWait, User, Nice, System, Irq, SoftIrq, Steal;
  std::ifstream stream2(kProcDirectory + kStatFilename);
  if (stream2.is_open())
  {
    std::getline(stream2, dataLine);
    std::istringstream linestream2(dataLine);
    
      linestream2 >> data >> User >> Nice >> System >> Idle >> IoWait >> Irq >> SoftIrq >> Steal;
  }
  
  
   PrevIdle = PrevIdle + PrevIoWait;
   Idle = Idle + IoWait;

   double PrevNonIdle = PrevUser + PrevNice + PrevSystem + PrevIrq + PrevSoftIrq + PrevSteal;
   double NonIdle = User + Nice + System + Irq + SoftIrq + Steal;
  
  double PrevTotal = PrevIdle + PrevNonIdle;
  double Total = Idle + NonIdle;
  

  
  double totald = Total - PrevTotal;
  glbCPUTotal = totald;
  
  double idled = Idle - PrevIdle;

  
  return(totald - idled)/totald;    
}



template <typename T> T findValueByKey(std::string const &keyFilter, std::string const &filename) 
{
  std::string line, key;
  T value;

  std::ifstream stream(LinuxParser::kProcDirectory + filename);
  if (stream.is_open()) {
    while (std::getline(stream, line)) {
      std::istringstream linestream(line);
      while (linestream >> key >> value) {
        if (key == keyFilter) {
          return value;
        }
      }
    }
  }
  return value;
};



//Read and return the system memory utilization ✔
float LinuxParser::MemoryUtilization() 
{ 
  	string memTotalKey = "MemTotal:";
  	string memFreeKey = "MemFree:";
    float memTotal = findValueByKey<float>(memTotalKey, LinuxParser::kMeminfoFilename);
    float memFree = findValueByKey<float>(memFreeKey, LinuxParser::kMeminfoFilename);
    return (memTotal - memFree)/memTotal;

}



//  Read and return the system uptime ✔
long LinuxParser::UpTime() 
{
   string dataline;
  double value1, value2;
  std::ifstream stream(kProcDirectory + kUptimeFilename);
  if(stream.is_open())
  { 
    std::getline(stream, dataline);
    std::istringstream linestream(dataline);
    linestream >> value1 >> value2;
    return value1;
  }
  return 0; 
}


//Read and return CPU utilization   
vector<string> LinuxParser::CpuUtilization() 
{ 
  string dataline;
  std::ifstream stream(kProcDirectory + kStatFilename);

  if(stream.is_open())
  {
    vector<string> datavec;
    std::getline(stream, dataline);
    
    std::istringstream linestream(dataline);
    string something;
    string value1, value2, value3, value4;
    linestream >> something >> value1 >> value2 >> value3 >> value4; 
    datavec.push_back(value1);
     datavec.push_back(value2);
     datavec.push_back(value3);
     datavec.push_back(value4);
    return datavec;
  }

  return {}; 
}

// Read and return the total number of processes ✔
int LinuxParser::TotalProcesses() 
{
  return findValueByKey<int>("processes", LinuxParser::kStatFilename);
}

// Read and return the number of running processes ✔
int LinuxParser::RunningProcesses() 
{    
  return findValueByKey<int>("procs_running", LinuxParser::kStatFilename);
}


template <typename T> T getValueFromFile(std::string const &filename)
{
  std::string line;
  T value;
  
  std::ifstream stream(LinuxParser::kProcDirectory + filename);
  if (stream.is_open()) 
  {
    std::getline(stream, line);
    std::istringstream linestream(line);
    linestream >> value;
  }
  return value;
  
}


//Read and return the command associated with a process
string LinuxParser::Command(int pid)
{ 

  return  std::string(getValueFromFile<std::string>(std::to_string(pid) + kCmdlineFilename));
 
}


void LinuxParser::GetProcessTime(const int pid,  double &csTime, double &cuTime)
{
  string line;
  std::ifstream stream(kProcDirectory + std::to_string(pid) + kStatFilename );
  int count = 1;
  if(stream.is_open())
  {
    std::getline(stream, line);
    std::istringstream ss(line);
    string word;
    while (ss >> word) 
    {

      if (count == 16)
      {
          csTime = stol(word); 
      }
      
      if (count == 17)
      {
          cuTime = stol(word); 
      }
      
      count++;

      if (count > 17)
      {
        break;
      }
    }
  } 
  
}



double  LinuxParser::CPUPercentageByProcess(const int pid)
{
  string line;
  double cstimeBefore, cutimeBefore, cstimeAfter, cutimeAfter; 
  
  GetProcessTime(pid,  cstimeBefore, cutimeBefore);

  sleep(0.75);

  GetProcessTime(pid,  cstimeAfter, cutimeAfter); 
    
  double user_util = 100 * (cutimeAfter - cutimeBefore) / (glbCPUTotal);
  double sys_util =  100 * (cstimeAfter - cstimeBefore) / (glbCPUTotal);
  return  0.5*(user_util + sys_util);  
}
 
  

// Read and return the memory used by a process ✔
string LinuxParser::Ram(int pid)
{  
  
  double kbRam = double(findValueByKey<double>("VmSize", std::to_string(pid) + kStatusFilename));
  
  double mbRam = round((kbRam/1024.0)*10)/10;
  
  return std::to_string(mbRam);
}




//  Read and return the user associated with a process ✔
string LinuxParser::User(int pid) 
{ 
  
   string line; 

  std::ifstream stream(kProcDirectory + std::to_string(pid) + kStatusFilename );
  if(stream.is_open())
  {
     int userrowIndex = 0;
    do 
    {
     std::getline(stream, line);
      userrowIndex++;
    }
    while (userrowIndex < 9);
    
    std::istringstream linestream(line);
    string whathe, userid;
    
    
    linestream >> whathe >> userid;
    
    std::ifstream passfile(kPasswordPath);
    string username = " ";
    string currName, xval;
    
    if (passfile.is_open())
    {
       string currID;
      string passUserline;
      while (! passfile.eof() )
      {   
   //     std::istringstream linestream(passUserline);
        std::getline(passfile, passUserline);
        
        std::stringstream ss(passUserline);
        std::getline(ss, currName, ':');
       // std::cout << "current name is " << currName << std::endl ;
        std::getline(ss, xval, ':');
        std::getline(ss, currID, ':');
        if(stoi(currID) == stoi(userid) )
        {
          username = currName;
          return username;
          break;
        }
      }
      passfile.close();
      
    }
    return  string();          
  }
  return string(); 
}




//kUptimeFilename{"/uptime"};
//kStatFilename{"/stat"};
long LinuxParser::UpTime(int pid) 
{ 

   double SystemUpTime =  UpTime();   
  
  string line;
  std::ifstream stream(kProcDirectory + std::to_string(pid) + "/" + kStatFilename );
  int count = 1;
  if(stream.is_open())
  {
    std::getline(stream, line);
    std::istringstream ss(line);
    string word;
    double  starttime;
    while (ss >> word) 
    {
      if (count == 22)
      {
          starttime = stol(word)/sysconf(_SC_CLK_TCK); 
      }
      count++;
      if (count > 22) 
      {
        return  SystemUpTime - starttime;
      }
    }
  }
  return -1; 
}



/*
// Paths
const std::string kProcDirectory{"/proc/"};
const std::string kCmdlineFilename{"/cmdline"};
const std::string kCpuinfoFilename{"/cpuinfo"};
const std::string kStatusFilename{"/status"};
const std::string kStatFilename{"/stat"};
const std::string kUptimeFilename{"/uptime"};
const std::string kMeminfoFilename{"/meminfo"};
const std::string kVersionFilename{"/version"};
const std::string kOSPath{"/etc/os-release"};
const std::string kPasswordPath{"/etc/passwd"};
  */