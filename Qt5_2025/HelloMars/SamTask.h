#ifndef SAMTASK_H
#define SAMTASK_H

#include <QWidget>

namespace Ui {
class SamTask;
}

class SamTask : public QWidget
{
    Q_OBJECT

public:
     SamTask(const QString& name, QWidget *parent = nullptr);
    ~SamTask();

    void SetName(const QString& name);
    QString GetName() const;
    bool IsCompleted() const;

private:
    Ui::SamTask *ui;
};

#endif // SAMTASK_H
