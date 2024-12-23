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
        ui->tasksLayout->addWidget(task);
    }

}

MainWindow::~MainWindow()
{
    delete ui;
}

