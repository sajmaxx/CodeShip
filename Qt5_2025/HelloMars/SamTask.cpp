#include "SamTask.h"
#include "ui_SamTask.h"

SamTask::SamTask(const QString& name, QWidget *parent) :
    QWidget(parent),
    ui(new Ui::SamTask)
{
    ui->setupUi(this);
    SetName(name);
}

SamTask::~SamTask()
{
    delete ui;
}

void SamTask::SetName(const QString &name)
{
    ui->milkBuyCheckBox->setText(name);
}

QString SamTask::GetName() const
{
    return ui->milkBuyCheckBox->text();
}

bool SamTask::IsCompleted() const
{
    return ui->milkBuyCheckBox->isChecked();
}
