#include "SmMainFrame.h"
#include <wx/wx.h>

class MyApp : public wxApp
{
  public:
    virtual bool OnInit();
};

IMPLEMENT_APP(MyApp)

bool MyApp::OnInit()
{
    SmMainFrame *simple = new SmMainFrame(wxT("Simple"));
    simple->Show(true);

    return true;
}