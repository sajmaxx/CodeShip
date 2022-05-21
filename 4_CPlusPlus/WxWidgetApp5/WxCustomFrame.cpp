#include "WxCustomFrame.h"

WxCustomFrame::WxCustomFrame(const wxString& title)
	: wxFrame(NULL, wxID_ANY, title, wxDefaultPosition, wxSize(250, 150))
{
	Centre();
}
