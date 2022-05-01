#include "CustomFrame.h"

CustomFrame::CustomFrame(const wxString& title)
	:wxFrame(NULL, wxID_ANY, title, wxDefaultPosition, wxSize(300,200))
{
	Centre();
}
