#include <iostream>
#include <random>
#include <algorithm>
#include <ctime>
#include<wx/bitmap.h>

#include "chatlogic.h"
#include "graphnode.h"
#include "graphedge.h"
#include "chatbot.h"

class ChatLogic; // forward declaration

// constructor WITHOUT memory allocation
ChatBot::ChatBot()
{
    cout << "ChatBot Constructor" << endl;
    // invalidate data handles
    _image = nullptr;
    _currentNode = nullptr;
    _chatLogic = nullptr;
    _rootNode = nullptr;
}

// constructor WITH memory allocation
ChatBot::ChatBot(std::string filename)
{
    std::cout << "ChatBot Constructor" << std::endl;
    
    // invalidate data handles
	_currentNode = nullptr;
    _chatLogic = nullptr;
    _rootNode = nullptr;
    // load image into heap memory
    _image = new wxBitmap(filename, wxBITMAP_TYPE_PNG);
}

//rule 1 of 5
ChatBot::~ChatBot()
{
    std::cout << "ChatBot Destructor" << std::endl;
    // deallocate heap memory
    if(_image != NULL) // Attention: wxWidgets used NULL and not nullptr
    {
        delete _image;
        _image = NULL;
    }
}

//// STUDENT CODE

// 2 of 5
//Copy Constructor
ChatBot::ChatBot(ChatBot &OrigBot)
{
    cout << "ChatBot Copy Constructor " << endl;
	this->_image =  OrigBot._image; //needs to be copy of image from OrigBot!
    this->_currentNode = OrigBot._currentNode;
	this->_chatLogic = OrigBot._chatLogic;
	this->_rootNode =  OrigBot._rootNode;
}


// 3 of 5
//Copy operator Assignment
ChatBot & ChatBot::operator =(ChatBot &OtherBot)
{
	if(this == &OtherBot)
	{
        cout << "ChatBot Copy Assignment to Self " << endl;
        return *this;
    }

    cout << "ChatBot Copy Assignment " << endl;
	this->_image =  OtherBot._image; //needs to be copy of image from OrigBot!
    this->_currentNode = OtherBot._currentNode;
    this->_chatLogic = OtherBot._chatLogic;
    this->_rootNode =  OtherBot._rootNode; 
    return *this;
}


// 4 of 5 move Constructor
ChatBot::ChatBot(ChatBot&& MoveBot)
{
    cout << " ChatBot Move Constructor " << endl;
	this->_image = move(MoveBot._image);
	MoveBot._image = NULL;
    this->_currentNode = move(MoveBot._currentNode);
     this->_rootNode = MoveBot._rootNode;
    this->_chatLogic = move(MoveBot._chatLogic);
}

//5 of 5 Move operator Assignment
ChatBot& ChatBot::operator=(ChatBot&& MoveBot)
{
    if(this == &MoveBot)
    {
        cout << "ChatBot Move Assignment to Self" << endl;
	    return *this;
    }

    cout << "ChatBot Move Assignment Operator" << endl;
  	this->_image = move(MoveBot._image);
    MoveBot._image = NULL;
    this->_currentNode = move(MoveBot._currentNode);
    this->_rootNode = move(MoveBot._rootNode);
    this->_chatLogic = move(MoveBot._chatLogic);
    return *this;
}


////
//// EOF STUDENT CODE

void ChatBot::ReceiveMessageFromUser(std::string message)
{
    // loop over all edges and keywords and compute Levenshtein distance to query
    typedef std::pair<GraphEdge *, int> EdgeDist;
    std::vector<EdgeDist> levDists; // format is <ptr,levDist>

    if (_currentNode != nullptr) // 2/27/2022 SM
    {
	    for (size_t i = 0; i < _currentNode->GetNumberOfChildEdges(); ++i)
	    {
	        GraphEdge *edge = _currentNode->GetChildEdgeAtIndex(i);
	        for (auto keyword : edge->GetKeywords())
	        {
	            EdgeDist ed{edge, ComputeLevenshteinDistance(keyword, message)};
	            levDists.push_back(ed);
	        }
	    }

	    // select best fitting edge to proceed along
	    GraphNode *newNode;
	    if (levDists.size() > 0)
	    {
	        // sort in ascending order of Levenshtein distance (best fit is at the top)
	        std::sort(levDists.begin(), levDists.end(), [](const EdgeDist &a, const EdgeDist &b) { return a.second < b.second; });
	        newNode = levDists.at(0).first->GetChildNode(); // after sorting the best edge is at first position
	    }
	    else
	    {
	        // go back to root node
	        newNode = _rootNode;
	    }
    	// tell current node to move chatbot to new node
        _currentNode->MoveChatbotToNewNode(newNode);
    }

}

void ChatBot::SetCurrentNode(GraphNode *node)
{
    // update pointer to current node
    _currentNode = node;

    // select a random node answer (if several answers should exist)
    std::vector<std::string> answers = _currentNode->GetAnswers();
    std::mt19937 generator(int(std::time(0)));
    std::uniform_int_distribution<int> dis(0, answers.size() - 1);
    std::string answer = answers.at(dis(generator));

    // send selected node answer to user
    _chatLogic->SendMessageToUser(answer);
}

int ChatBot::ComputeLevenshteinDistance(std::string s1, std::string s2)
{
    // convert both strings to upper-case before comparing
    std::transform(s1.begin(), s1.end(), s1.begin(), ::toupper);
    std::transform(s2.begin(), s2.end(), s2.begin(), ::toupper);

    // compute Levenshtein distance measure between both strings
    const size_t m(s1.size());
    const size_t n(s2.size());

    if (m == 0)
        return n;
    if (n == 0)
        return m;

    size_t *costs = new size_t[n + 1];

    for (size_t k = 0; k <= n; k++)
        costs[k] = k;

    size_t i = 0;
    for (std::string::const_iterator it1 = s1.begin(); it1 != s1.end(); ++it1, ++i)
    {
        costs[0] = i + 1;
        size_t corner = i;

        size_t j = 0;
        for (std::string::const_iterator it2 = s2.begin(); it2 != s2.end(); ++it2, ++j)
        {
            size_t upper = costs[j + 1];
            if (*it1 == *it2)
            {
                costs[j + 1] = corner;
            }
            else
            {
                size_t t(upper < corner ? upper : corner);
                costs[j + 1] = (costs[j] < t ? costs[j] : t) + 1;
            }

            corner = upper;
        }
    }

    int result = costs[n];
    delete[] costs;

    return result;
}