#include "WXMainApp.h"

MainWin::MainWin(const wxString& titleOfApp)
	: wxFrame(NULL, wxID_ANY, titleOfApp, wxDefaultPosition, wxSize(300,100))
{
	 Centre();
}

