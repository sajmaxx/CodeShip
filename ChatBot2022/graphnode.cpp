#include "graphedge.h"
#include "graphnode.h"

#include "chatlogic.h"

GraphNode::GraphNode(int id)
{
    _id = id;
}

GraphNode::~GraphNode()
{
    //// STUDENT CODE

    //delete _chatBot; 
    //// EOF STUDENT CODE
}


void GraphNode::AddToken(std::string token)
{
    _answers.push_back(token);
}


void GraphNode::AddEdgeToParentNode(GraphEdge *edge)
{
    _parentEdges.push_back(edge);
}

void GraphNode::AddEdgeToChildNode(GraphEdge *edge)
{
    _childEdges.emplace_back(edge);
}

//// STUDENT CODE
////
void GraphNode::MoveChatbotHere(ChatBot chatbot) //Rev1:4b SM March 12 2022 //
{
   _chatBot = &chatbot;
    auto locchatlogic = chatbot.GetChatLogicHandle();
    locchatlogic->SetChatbotHandle(_chatBot);
   _chatBot->SetCurrentNode(this);
}

void GraphNode::MoveChatbotToNewNode(GraphNode *newNode)
{
    newNode->MoveChatbotHere(move(*_chatBot));
}

//// EOF STUDENT CODE


GraphEdge *GraphNode::GetChildEdgeAtIndex(int index)
{
    //// STUDENT CODE
    ////

    return _childEdges[index].get();

    ////
    //// EOF STUDENT CODE
}