#include "SamTask.h"
#include "ui_SamTask.h"
#include <QInputDialog>

SamTask::SamTask(const QString& name, QWidget *parent) :
    QWidget(parent),
    ui(new Ui::SamTask)
{
    ui->setupUi(this);
    SetName(name);
    connect(ui->editItemButton, &QPushButton::clicked, this, &SamTask::Rename);
    connect(ui->removeItemButton, &QPushButton::clicked, [this] { emit Removed(this);} );

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

void SamTask::Rename()
{
    bool allOkMan;
    QString nameDaTask = QInputDialog::getText(this, tr("Add Task"), tr("Task Name"),
                                               QLineEdit::Normal, tr("Untitled Task"), &allOkMan);
    if(allOkMan && !nameDaTask.isEmpty())
    {
        SetName(nameDaTask);
    }
}

