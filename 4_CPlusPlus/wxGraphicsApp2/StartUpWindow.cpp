#include <wx/wx.h>
#include "WXMainApp.h"

class SMAxxApp : public wxApp
{
public:
		virtual bool OnInit();
};


IMPLEMENT_APP(SMAxxApp)

bool SMAxxApp::OnInit()
{
	MainWin *mainWinSM = new MainWin(wxT("SuperMax"));
	mainWinSM->Show(true);

	return true;
}
