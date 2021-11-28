#include <dirent.h>
#include <unistd.h>
#include <sstream>
#include <string>
#include <vector>
#include <iostream>

#include "linux_parser.h"

using std::stof;
using std::string;
using std::to_string;
using std::vector;


// DONE: An example of how to read data from the filesystem
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

// TODO: Read and return the system memory utilization
float LinuxParser::MemoryUtilization() { return 0.0; }

// TODO: Read and return the system uptime
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


// TODO: Read and return CPU utilization   - WIP 
vector<string> LinuxParser::CpuUtilization() 
{ 
  string dataline;
  long value1, value2;
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

// TODO: Read and return the total number of processes
int LinuxParser::TotalProcesses() 
{
  string processes;
  int processnumber;
  string line;
 
  std::ifstream stream(kProcDirectory + kMeminfoFilename);
  if(stream.is_open())
  {
    std::getline(stream, line);
    std::istringstream linestream(line);
    linestream >> processes >> processnumber;
    return (processnumber);
  }
  return 0;
}

// TODO: Read and return the number of running processes
int LinuxParser::RunningProcesses() 
{   
  string processes, procs_running;
  int toto, runningprocessnum;
  string line;  
 
  std::ifstream stream(kProcDirectory + kMeminfoFilename);
  if(stream.is_open())
  {
    std::getline(stream, line);
    std::istringstream linestream(line);
    linestream >> processes >> toto;

    std::getline(stream, line);
    std::istringstream linestream2(line);
    linestream2 >> procs_running >> runningprocessnum;

    return (runningprocessnum);
  }
  return 0;
}


//Read and return the command associated with a process
string LinuxParser::Command(int pid)
{ 
  string lineread;
  
  

  
  std::ifstream stream(kProcDirectory + std::to_string(pid) + "/comm" );
  
  if (stream.is_open())
  {
    std::cout << "euerka opened filfe for com\n";
    std::getline(stream, lineread);    
    return lineread;
  }
  
  return string();
    
}


 ////// kStatMFilename = "/statm"; 
     
// Read and return the memory used by a process ✔
string LinuxParser::Ram(int pid)
{ 

 
  string line; 

  std::ifstream stream(kProcDirectory + std::to_string(pid) + "/statm" );
  if(stream.is_open())
  {
    std::getline(stream, line);    
    std::istringstream linestream(line);
    double memsize;    
    linestream >> memsize;
    int Intmemsize = trunc(memsize/1024.0);
    
    return  std::to_string(Intmemsize);
  }
  return string(); 
}



// TODO: Read and return the user ID associated with a process
// REMOVE: [[maybe_unused]] once you define the function
string LinuxParser::Uid(int pid[[maybe_unused]]) 
{
  return string(); 
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


long LinuxParser::UpTime(int pid) 
{ 

  string line;
  std::ifstream stream(kProcDirectory + std::to_string(pid) + kStatFilename );
  int count = 1;
  if(stream.is_open())
  {
    std::getline(stream, line);
    std::istringstream ss(line);
    string word;
    double processTotalTime, utime, stime, cutime, cstime, starttime;
    while (ss >> word) 
    {
      if (count == 14)
      {
          utime = stod(word); 
      }
      else if (count == 15)
      {
          stime = stod(word); 
      } 
      else if (count == 16)
      {
          cutime = stod(word); 
      }
      else if (count == 17)
      {
          cstime = stod(word); 
      }
      if (count == 22)
      {
          starttime = stod(word); 
      }
      count++;

      if (count > 22) 
      {
          break;
      }
    }
    processTotalTime = utime + stime +  cutime +  cstime;
 	if (processTotalTime > 0)
  	{
 	   return processTotalTime;
 	}
  }
  return 10; 
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


/*

// TODO: Read and return the number of jiffies for the system
long LinuxParser::Jiffies() 
{ 
  return 0; 
}

// TODO: Read and return the number of active jiffies for a PID
// REMOVE: [[maybe_unused]] once you define the function
long LinuxParser::ActiveJiffies(int pid[[maybe_unused]]) 
{
  return 0;
}

// TODO: Read and return the number of active jiffies for the system
long LinuxParser::ActiveJiffies() { return 0; }

// TODO: Read and return the number of idle jiffies for the system
long LinuxParser::IdleJiffies() { return 0; }


*/