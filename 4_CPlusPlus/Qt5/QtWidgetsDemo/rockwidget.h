#ifndef ROCKWIDGET_H
#define ROCKWIDGET_H

#include <QObject>
#include <QWidget>

class RockWidget : public QWidget
{
    Q_OBJECT
public:
    explicit RockWidget(QWidget *parent = nullptr);

signals:

private slots:
     void mahButtonClick();

};

#endif // ROCKWIDGET_H
