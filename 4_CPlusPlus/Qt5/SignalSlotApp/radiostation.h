#ifndef RADIOSTATION_H
#define RADIOSTATION_H

#include <QObject>

class RadioStation : public QObject
{
    Q_OBJECT
public:
    explicit RadioStation(QObject *parent = nullptr, int channel = 0, QString name ="unknown");

signals:
    void Send(int channel, QString name, QString message);

public slots:
    void BroadCast(QString message);
private:
    int m_channel;
    QString m_name;
};

#endif // RADIOSTATION_H
