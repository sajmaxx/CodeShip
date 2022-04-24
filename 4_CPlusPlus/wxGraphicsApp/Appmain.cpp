#include "Appmain.h"
#include "simpleFrame.h"

wxIMPLEMENT_APP(MyApp); 
bool MyApp::OnInit()
{
    SimpleFrame *simple = new SimpleFrame(wxString("Simple"));
    simple->Show(true);
    return true;
}