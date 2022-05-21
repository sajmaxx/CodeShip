#include "SMCustomFrame.h"
#include<wx/wx.h>

class MainStartApp : public wxApp
{
public:
	virtual bool OnInit();
};


IMPLEMENT_APP(MainStartApp)

bool MainStartApp::OnInit()
{
	SMCustomFrame *mainwin = new SMCustomFrame("6th Time");
	mainwin->Show(true);
	return true;
}
