/********************************************************************************
** Form generated from reading UI file 'SamTask.ui'
**
** Created by: Qt User Interface Compiler version 5.11.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_SAMTASK_H
#define UI_SAMTASK_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QCheckBox>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_SamTask
{
public:
    QWidget *widget;
    QHBoxLayout *horizontalLayout;
    QCheckBox *milkBuyCheckBox;
    QSpacerItem *horizontalSpacer;
    QWidget *widget1;
    QHBoxLayout *horizontalLayout_2;
    QPushButton *editItemButton;
    QPushButton *removeItemButton;

    void setupUi(QWidget *SamTask)
    {
        if (SamTask->objectName().isEmpty())
            SamTask->setObjectName(QStringLiteral("SamTask"));
        SamTask->resize(530, 226);
        widget = new QWidget(SamTask);
        widget->setObjectName(QStringLiteral("widget"));
        widget->setGeometry(QRect(20, 60, 280, 27));
        horizontalLayout = new QHBoxLayout(widget);
        horizontalLayout->setObjectName(QStringLiteral("horizontalLayout"));
        horizontalLayout->setContentsMargins(0, 0, 0, 0);
        milkBuyCheckBox = new QCheckBox(widget);
        milkBuyCheckBox->setObjectName(QStringLiteral("milkBuyCheckBox"));

        horizontalLayout->addWidget(milkBuyCheckBox);

        horizontalSpacer = new QSpacerItem(60, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        horizontalLayout->addItem(horizontalSpacer);

        widget1 = new QWidget(SamTask);
        widget1->setObjectName(QStringLiteral("widget1"));
        widget1->setGeometry(QRect(310, 60, 186, 27));
        horizontalLayout_2 = new QHBoxLayout(widget1);
        horizontalLayout_2->setObjectName(QStringLiteral("horizontalLayout_2"));
        horizontalLayout_2->setContentsMargins(0, 0, 0, 0);
        editItemButton = new QPushButton(widget1);
        editItemButton->setObjectName(QStringLiteral("editItemButton"));

        horizontalLayout_2->addWidget(editItemButton);

        removeItemButton = new QPushButton(widget1);
        removeItemButton->setObjectName(QStringLiteral("removeItemButton"));

        horizontalLayout_2->addWidget(removeItemButton);


        retranslateUi(SamTask);

        QMetaObject::connectSlotsByName(SamTask);
    } // setupUi

    void retranslateUi(QWidget *SamTask)
    {
        SamTask->setWindowTitle(QApplication::translate("SamTask", "Form", nullptr));
        milkBuyCheckBox->setText(QApplication::translate("SamTask", "Buy Milk", nullptr));
        editItemButton->setText(QApplication::translate("SamTask", "Edt Item", nullptr));
        removeItemButton->setText(QApplication::translate("SamTask", "Remove Item", nullptr));
    } // retranslateUi

};

namespace Ui {
    class SamTask: public Ui_SamTask {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_SAMTASK_H
