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
void GraphNode::MoveChatbotHere(ChatBot &chatbot)
{
   _chatBot = move(chatbot);
    auto locchatlogic = chatbot.GetChatLogicHandle();
    locchatlogic->SetChatbotHandle(&_chatBot);
   _chatBot.SetCurrentNode(this);
}

void GraphNode::MoveChatbotToNewNode(GraphNode *newNode)
{
    newNode->MoveChatbotHere(_chatBot);
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