#include "rockwidget.h"
#include <QLabel>
#include <QPushButton>
#include <QMessageBox>

RockWidget::RockWidget(QWidget *parent)
    : QWidget{parent}
{

    setWindowTitle("Rock of Ages Widget");
    QLabel* mahLabel = new QLabel("Rambo was here", this);
    mahLabel->move(30,0);
    //Add a style widget and move it around
    QLabel* label1 = new QLabel(this);
    label1->setText("My Colored Label Test");
    label1->move(30,30);

    QFont labelFont("Time", 10, QFont::Bold);
    QLabel* labelBold = new QLabel(this);
    QPalette custPalette;
    custPalette.setColor(QPalette::Window, Qt::yellow);
    custPalette.setColor(QPalette::WindowText, Qt::blue);
    labelBold->move(30, 60);
    labelBold->setFont(labelFont);
    labelBold->setPalette(custPalette);
    labelBold->setAutoFillBackground(true);
    labelBold->setText("Bold Statement");

    QPushButton *launchButton = new QPushButton(this);
    launchButton->setPalette(custPalette);
    launchButton->setAutoFillBackground(true);
    launchButton->setText("Launch ICBM yeah!");
    launchButton->move(30, 90);

    connect(launchButton, SIGNAL(clicked()), this,SLOT(mahButtonClick()));


}

void RockWidget::mahButtonClick()
{
    QMessageBox::information(this, "Mamama Mia ", "What the.. nukeaholic?");
}
