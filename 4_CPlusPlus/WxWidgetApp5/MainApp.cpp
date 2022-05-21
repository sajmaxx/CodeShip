#include "WxCustomFrame.h"
#include<wx/wx.h>


class MainApp : public wxApp
{
public:
	virtual bool OnInit();
};

IMPLEMENT_APP(MainApp)

bool MainApp::OnInit()
{
	WxCustomFrame *starterFrame = new WxCustomFrame(wxT("Fifth Diemension"));


	starterFrame->Show();
	return true;
}
