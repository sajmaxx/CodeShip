
// wxWidgets "Hello World" Program, Also using a thread
 
// For compilers that support precompilation, includes "wx/wx.h".
#include <wx/wxprec.h>
#include <thread>


#ifndef WX_PRECOMP
    #include <wx/wx.h>
#endif
 
class MyApp : public wxApp
{
public:
    virtual bool OnInit();
};
 
class MyFrame : public wxFrame
{
public:
    MyFrame();

    void DoARefreshOnStatusBar();
 
private:
    int _calculatedValue;
    void OnHello(wxCommandEvent& event);
    void DoSomeMath(int inputVal);
    void OnDoWork(wxCommandEvent& event);
    void OnExit(wxCommandEvent& event);
    void OnAbout(wxCommandEvent& event);
};
 
enum
{
    ID_Hello = 1,
   ID_DOWORK = 2
};
 
wxIMPLEMENT_APP(MyApp);

using namespace std;
 
bool MyApp::OnInit()
{

    MyFrame *frame = new MyFrame();
    frame->Show(true);
    return true;
}
 
MyFrame::MyFrame()
    : wxFrame(NULL, wxID_ANY, "Hello World")
{
    _calculatedValue = 0;
    wxMenu *menuFile = new wxMenu;
    menuFile->Append(ID_Hello, "&Hello...\tCtrl-H",
                     "Help string shown in status bar for this menu item");
    menuFile->AppendSeparator();

    menuFile->Append(ID_DOWORK, "Do &Work", "Back ground work done here");

    menuFile->Append(wxID_EXIT);
 
    wxMenu *menuHelp = new wxMenu;
    menuHelp->Append(wxID_ABOUT);
 
    wxMenuBar *menuBar = new wxMenuBar;
    menuBar->Append(menuFile, "&File");


    menuBar->Append(menuHelp, "&Help");
 
    SetMenuBar( menuBar );
 
    CreateStatusBar();
    SetStatusText("Welcome to wxWidgets!");
 
    Bind(wxEVT_MENU, &MyFrame::OnHello, this, ID_Hello);
    Bind(wxEVT_MENU, &MyFrame::OnDoWork, this, ID_DOWORK);
    Bind(wxEVT_MENU, &MyFrame::OnAbout, this, wxID_ABOUT);
    Bind(wxEVT_MENU, &MyFrame::OnExit, this, wxID_EXIT);
}

void MyFrame::DoARefreshOnStatusBar()
{
}
 


void MyFrame::OnExit(wxCommandEvent& event)
{
    Close(true);
}
 
void MyFrame::OnAbout(wxCommandEvent& event)
{
    wxMessageBox("This is a wxWidgets Hello World example",
                 "About Hello World", wxOK | wxICON_INFORMATION);
}
 
void MyFrame::OnHello(wxCommandEvent& event)
{
    wxLogMessage("Hello world from wxWidgets!");
}

void MyFrame::DoSomeMath(int inputVal)
{
    this_thread::sleep_for(chrono::milliseconds(3500));
    _calculatedValue = inputVal + rand();
}


void MyFrame::OnDoWork(wxCommandEvent& event)
{
    SetStatusText("Calculating .... ");
    int inputval = 777;
    thread dowork(&MyFrame::DoSomeMath, this, inputval);
    dowork.join();
    SetStatusText("Here is am with new values for you " +  to_string(_calculatedValue));    
}
