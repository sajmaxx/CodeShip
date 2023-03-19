#include "radiostation.h"

RadioStation::RadioStation(QObject *parent, int channel, QString name) : QObject(parent), m_channel(channel), m_name(name)
{
    this->m_channel = channel;
    this->m_name = name;
}

void RadioStation::BroadCast(QString message)
{
    emit Send(m_channel, m_name, message);
}
