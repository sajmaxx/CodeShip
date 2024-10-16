#include <curses.h>
#include <chrono>
#include <string>
#include <thread>
#include<iostream>

#include "unistd.h"
#include "format.h"
#include "ncurses_display.h"
#include "system.h"
#include "linux_parser.h"

using std::string;
using std::to_string;

std::vector<int> vectorPids;


long SystemUpTime = 0;

// 50 bars uniformly displayed from 0 - 100 %
// 2% is one bar(|)
std::string NCursesDisplay::ProgressBar(float percent) {
  std::string result{"0%"};
  int size{50};
  float bars{percent * size};

  for (int i{0}; i < size; ++i) {
    result += i <= bars ? '|' : ' ';
  }

  string display{to_string(percent * 100).substr(0, 4)};
  if (percent < 0.1 || percent == 1.0)
    display = " " + to_string(percent * 100).substr(0, 3);
  return result + " " + display + "/100%";
}

void NCursesDisplay::DisplaySystem(System& system, WINDOW* window) {
  int row{0};
  mvwprintw(window, ++row, 2, ("OS: " + system.OperatingSystem()).c_str());
  mvwprintw(window, ++row, 2, ("Kernel: " + system.Kernel()).c_str());
  mvwprintw(window, ++row, 2, "CPU: ");
  wattron(window, COLOR_PAIR(1));
  mvwprintw(window, row, 10, "");
  wprintw(window, ProgressBar(system.Cpu().Utilization()).c_str());
  wattroff(window, COLOR_PAIR(1));
  mvwprintw(window, ++row, 2, "Memory: ");
  wattron(window, COLOR_PAIR(1));
  mvwprintw(window, row, 10, "");
  wprintw(window, ProgressBar(system.MemoryUtilization()).c_str());
  wattroff(window, COLOR_PAIR(1));
  mvwprintw(window, ++row, 2,
            ("Total Processes: " + to_string(system.TotalProcesses())).c_str());
  mvwprintw(
      window, ++row, 2,
      ("Running Processes: " + to_string(system.RunningProcesses())).c_str());
  
  SystemUpTime = system.UpTime();
  
  mvwprintw(window, ++row, 2,
            ("Up Time: " + Format::ElapsedTime(SystemUpTime)).c_str());
  wrefresh(window);
}

void NCursesDisplay::DisplayProcesses(std::vector<Process>& processes,
                                      WINDOW* window, int n) {
  int row{0};
  int const pid_column{2};
  int const user_column{9};
  int const cpu_column{16};
  int const ram_column{26};
  int const time_column{35};
  int const command_column{46};
  wattron(window, COLOR_PAIR(2));
  mvwprintw(window, ++row, pid_column, "PID");
  mvwprintw(window, row, user_column, "USER");
  mvwprintw(window, row, cpu_column, "CPU[%%]");
  mvwprintw(window, row, ram_column, "RAM[MB]");
  mvwprintw(window, row, time_column, "TIME+");
  mvwprintw(window, row, command_column, "COMMAND");
  wattroff(window, COLOR_PAIR(2));
  
  
  int processCount = 0, procesPID;
  double cpu, processUpTime;
  string processCommand, processRam;
  for (Process processI : processes) 
  {
    cpu = processI.CpuUtilization();  
    //if (cpu >  0.0001)
    //  continue;

    procesPID = processI.Pid();    
 
    processCommand = processI.Command();
    if (processCommand.length() == 0)
      continue;
    
    processRam = processI.Ram(); 
    if (stof(processRam) < 0.001)
      continue;
    
    processUpTime = processI.UpTime();
    if(processUpTime < 0.001)
     continue;
    
    // Clear the line
    mvwprintw(window, ++row, pid_column, (string(window->_maxx-2, ' ').c_str()));
      
    mvwprintw(window, row, pid_column, to_string(procesPID).c_str());
     
    mvwprintw(window, row, user_column, processI.User().c_str());
    
    
    mvwprintw(window, row, cpu_column, to_string(cpu).substr(0,5).c_str());
        
    mvwprintw(window, row, ram_column, processRam.c_str());       

    mvwprintw(window, row, time_column, Format::ElapsedTime(processUpTime).c_str());
    
    mvwprintw(window, row, command_column, processCommand.substr(0, window->_maxx - 46).c_str());

   processCount++;
    if (processCount == n)
      break;
  }
  
}

void NCursesDisplay::Display(System& system, int n) {
  initscr();      // start ncurses
  noecho();       // do not print input values
  cbreak();       // terminate ncurses on ctrl + c
  start_color();  // enable color
  
  vectorPids =  LinuxParser::Pids();
  n = vectorPids.size();    
  

  int x_max{getmaxx(stdscr)};
  WINDOW* system_window = newwin(9, x_max - 1, 0, 0);
  WINDOW* process_window =
      newwin(3 + n, x_max - 1, system_window->_maxy + 1, 0);

  while (1) {
    init_pair(1, COLOR_BLUE, COLOR_BLACK);
    init_pair(2, COLOR_GREEN, COLOR_BLACK);
    box(system_window, 0, 0);
    box(process_window, 0, 0);
    DisplaySystem(system, system_window);
    
    DisplayProcesses(system.Processes(), process_window, n);

    wrefresh(system_window);
    wrefresh(process_window);
    refresh();
    std::this_thread::sleep_for(std::chrono::seconds(1));
  }
  endwin();
}
