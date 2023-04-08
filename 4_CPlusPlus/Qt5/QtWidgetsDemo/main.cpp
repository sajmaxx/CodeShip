#include "rockwidget.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);

    RockWidget rockWidg;

    rockWidg.show();

    return a.exec();
}
