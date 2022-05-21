#include "SMCustomFrame.h"


SMCustomFrame::SMCustomFrame(const wxString& title)
	:wxFrame(NULL, wxID_ANY, title, wxDefaultPosition, wxSize(500,250))
{
	Centre();
}
