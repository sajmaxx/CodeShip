#include <fstream>
#include <sstream>
#include <iostream>
#include <vector>
#include <iterator>
#include <tuple>
#include <algorithm>

#include "graphedge.h"
#include "graphnode.h"
#include "chatbot.h"
#include "chatlogic.h"

using namespace std;

ChatLogic::ChatLogic()
{
    //// STUDENT CODE
    ////

    //// EOF STUDENT CODE
}

ChatLogic::~ChatLogic()
{
    //// STUDENT CODE
    ////
    //// EOF STUDENT CODE
}

template <typename T>
void ChatLogic::AddAllTokensToElement(std::string tokenID, tokenlist &tokens, T &element)
{
    // find all occurences for current node
    auto token = tokens.begin();
    while (true)
    {
        token = std::find_if(token, tokens.end(), [&tokenID](const std::pair<std::string, std::string> &pair) { return pair.first == tokenID;; });
        if (token != tokens.end())
        {
            element.AddToken(token->second); // add new keyword to edge
            token++;                         // increment iterator to next element
        }
        else
        {
            break; // quit infinite while-loop
        }
    }
}



void ChatLogic::ProcessNodes(ChatLogic::tokenlist tokens, int id)
{

	// check if node with this ID exists already                   
	GraphNode *newNode = nullptr;
	for (auto it = begin(_nodes); it != end(_nodes); ++it)
	{
		if(it->get()->GetID() == id)
		{
			newNode = it->get();
			break;
		}
	}


	// create new element if ID does not yet exist
	if (newNode == nullptr)
	{
		_nodes.emplace_back(new GraphNode(id));              
		newNode = (_nodes[_nodes.size()-1]).get(); // get last element
		// add all answers to current node
		AddAllTokensToElement("ANSWER", tokens, *newNode);
	}
	//// EOF STUDENT CODE
}


//SM 2/21/22 Task4
void ChatLogic::ProcessGraphEdges(ChatLogic::tokenlist tokens, int id)
{
     // find tokens for incoming (parent) and outgoing (child) node
	auto parentToken = std::find_if(tokens.begin(), tokens.end(), [](const std::pair<std::string, std::string> &pair) { return pair.first == "PARENT"; });
	auto childToken = std::find_if(tokens.begin(), tokens.end(), [](const std::pair<std::string, std::string> &pair) { return pair.first == "CHILD"; });

	if (parentToken != tokens.end() && childToken != tokens.end())
	{
		// get iterator on incoming and outgoing node via ID search
		// auto parentNode = find_if(_nodes.begin(), _nodes.end(), [&parentToken](unique_ptr<GraphNode> node) { return node->GetID() == std::stoi(parentToken->second); });
		GraphNode *parentNode = nullptr;
		for (auto it = begin(_nodes); it != end(_nodes); ++it)
		{
			if(it->get()->GetID() ==  std::stoi(parentToken->second))
			{
				parentNode = it->get();
			}
		}


		// auto childNode = find_if(_nodes.begin(), _nodes.end(), [&childToken](unique_ptr<GraphNode> node) { return node->GetID() == std::stoi(childToken->second); });
		GraphNode *childNode = nullptr;
		for (auto it = begin(_nodes); it != end(_nodes); ++it)
		{
			if(it->get()->GetID() ==  std::stoi(childToken->second))
			{
				childNode = it->get();
			}
		}

		//// create new edge
		GraphEdge *edge = new GraphEdge(id);

        edge->SetParentNode(parentNode);
		edge->SetChildNode(childNode);
		

		//_edges.push_back(edge);

		//// find all keywords for current node
		AddAllTokensToElement("KEYWORD", tokens, *edge);

		//// store reference in  parent node AND child node
		parentNode->AddEdgeToChildNode(edge);
		childNode->AddEdgeToParentNode(move(edge));  //Rev1:1 SM March 12 2022
	
	}
}

void ChatLogic::LoadAnswerGraphFromFile(std::string filename)
{
    // load file with answer graph elements
    std::ifstream file(filename);

    // check for file availability and process it line by line
    if (file)
    {
        // loop over all lines in the file
        std::string lineStr;
        while (getline(file, lineStr))
        {
            // extract all tokens from current line
            tokenlist tokens;
            while (lineStr.size() > 0)
            {
                // extract next token
                int posTokenFront = lineStr.find("<");
                int posTokenBack = lineStr.find(">");
                if (posTokenFront < 0 || posTokenBack < 0)
                    break; // quit loop if no complete token has been found
                std::string tokenStr = lineStr.substr(posTokenFront + 1, posTokenBack - 1);

                // extract token type and info
                int posTokenInfo = tokenStr.find(":");
                if (posTokenInfo != std::string::npos)
                {
                    std::string tokenType = tokenStr.substr(0, posTokenInfo);
                    std::string tokenInfo = tokenStr.substr(posTokenInfo + 1, tokenStr.size() - 1);

                    // add token to vector
                    tokens.push_back(std::make_pair(tokenType, tokenInfo));
                }

                // remove token from current line
                lineStr = lineStr.substr(posTokenBack+1, lineStr.size());
            }

            // process tokens for current line
            auto type = std::find_if(tokens.begin(), tokens.end(), [](const std::pair<std::string, std::string> &pair) { return pair.first == "TYPE"; });
            if (type != tokens.end())
            {
                // check for id
                auto idToken = std::find_if(tokens.begin(), tokens.end(), [](const std::pair<std::string, std::string> &pair) { return pair.first == "ID"; });
                if (idToken != tokens.end())
                {
                    // extract id from token
                    int id = std::stoi(idToken->second);

                    // node-based processing
                    if (type->second == "NODE")
                    {	//// STUDENT CODE
                        ProcessNodes(tokens, id);
                    	//// EOF STUDENT CODE
                    }

                    // edge-based processing
                    if (type->second == "EDGE")
                    {
                        //// STUDENT CODE
                        ProcessGraphEdges(tokens, id);
                        //// EOF STUDENT CODE
                    }
                }
                else
                {
                    std::cout << "Error: ID missing. Line is ignored!" << std::endl;
                }
            }
        } // eof loop over all lines in the file

        file.close();

    } // eof check for file availability
    else
    {
        std::cout << "File could not be opened!" << std::endl;
        return;
    }

    //// STUDENT CODE
    ////

    // identify root node
    GraphNode *rootNode = nullptr;
    for (auto it = std::begin(_nodes); it != std::end(_nodes); ++it)
    {
        // search for nodes which have no incoming edges
        if ((*it)->GetNumberOfParents() == 0)
        {

            if (rootNode == nullptr)
            {
                rootNode = it->get(); // assign current node to root
            }
            else
            {
                std::cout << "ERROR : Multiple root nodes detected" << std::endl;
            }
        }
    }

    // add chatbot to graph root node
    ChatBot locChatBot("images/chatbot.png");
    locChatBot.SetChatLogicHandle(this);
	locChatBot.SetRootNode(rootNode);
    rootNode->MoveChatbotHere(move(locChatBot)); //Rev1:2 SM March 12 2022
    //// EOF STUDENT CODE
}


void ChatLogic::SetPanelDialogHandle(ChatBotPanelDialog *panelDialog)
{
    _panelDialog = panelDialog;
}

void ChatLogic::SetChatbotHandle(ChatBot *chatbot)
{
    _chatBot = chatbot;
}


void ChatLogic::SendMessageToChatbot(std::string message)
{
    _chatBot->ReceiveMessageFromUser(message);
}

void ChatLogic::SendMessageToUser(std::string message)
{
    _panelDialog->PrintChatbotResponse(message);
}

wxBitmap *ChatLogic::GetImageFromChatbot()
{
    return _chatBot->GetImageHandle();
}
