#include <QDebug>
#include <QCoreApplication>
#include<iostream>
#include "radio.h"
#include "radiostation.h"
#include<vector>
#include<chrono>
#include<thread>

void broadcastOnSeparateThread(std::vector<RadioStation*> &channels)
{
    for(RadioStation *locStation : channels)
    {
        locStation->BroadCast("Mama Mia #1");
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
    }
}


int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    qInfo() << " Testing the presence and life of main app";

   Radio sonyRadio;

   std::vector<RadioStation*> channels;

   channels.push_back(new RadioStation(&sonyRadio, 94, "Mixed Rock"));
   channels.push_back(new RadioStation(&sonyRadio, 909, "Classical"));
   channels.push_back(new RadioStation(&sonyRadio, 937, "Devotionals"));

   sonyRadio.connect(&sonyRadio, &Radio::quit, &a, &QCoreApplication::quit, Qt::QueuedConnection);


   std::cout << "Starting to Connect all signal slots" << std::endl;
  for(RadioStation *locStation : channels)
  {
      sonyRadio.connect(locStation, &RadioStation::Send, &sonyRadio, &Radio::listen);
  }


   std::thread workerbeeStationsThd(broadcastOnSeparateThread, std::ref(channels));
   workerbeeStationsThd.join();

   std::this_thread::sleep_for(std::chrono::milliseconds(2900));
    std::cout << "Starting to disconnect all signal slots" << std::endl;
   for(RadioStation *locStation : channels)
   {
       sonyRadio.disconnect(locStation, &RadioStation::Send, &sonyRadio, &Radio::listen);
   }


   return a.exec();
}
