#include "radio.h"
#include <QDebug>

Radio::Radio(QObject *parent)
    : QObject{parent}
{

}

void Radio::listen(int channel, QString name, QString message)
{
    qInfo() << "Listening Channel is " << channel << " name " << name << " and message is " << message;
}
