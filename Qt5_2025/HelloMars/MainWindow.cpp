#include "MainWindow.h"
#include "ui_MainWindow.h"
#include "SamTask.h"
#include <QDebug>
#include <QInputDialog>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow), m_Tasks()
{
    ui->setupUi(this);
    connect(ui->addTaskButton, &QPushButton::clicked,
            this, &MainWindow::addTaskSlot);
}

void MainWindow::addTaskSlot()
{
    bool allOkMan;
    QString nameDaTask = QInputDialog::getText(this, tr("Add Task"), tr("Task Name"),
                                               QLineEdit::Normal, tr("Untitled Task"), &allOkMan);
    if(allOkMan && !nameDaTask.isEmpty())
    {
        SamTask* task = new SamTask(nameDaTask);
        m_Tasks.append(task);

        connect(task, &SamTask::Removed, this, &MainWindow::RemoveTask);

        ui->tasksLayout->addWidget(task);
    }

}

void MainWindow::RemoveTask(SamTask *task)
{
    m_Tasks.removeOne(task);
    ui->tasksLayout->removeWidget(task);
    delete task;
}

MainWindow::~MainWindow()
{
    delete ui;
}

