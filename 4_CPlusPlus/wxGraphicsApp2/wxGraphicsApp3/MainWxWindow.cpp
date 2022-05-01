#include<wx/wx.h>
#include "CustomFrame.h"


class SMaxxWinApp : public wxApp
{
public:
	virtual bool OnInit();
	
};

IMPLEMENT_APP(SMaxxWinApp)

bool SMaxxWinApp::OnInit()
{

	CustomFrame *cusFrame = new CustomFrame("Hola 2022");
	cusFrame->SetIcon(wxIcon(wxT("web.xpm")));
	cusFrame->Show(true);
	return true;
		
}
