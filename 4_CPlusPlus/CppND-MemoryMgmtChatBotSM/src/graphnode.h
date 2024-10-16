#ifndef GRAPHNODE_H_
#define GRAPHNODE_H_

#include <vector>
#include <string>
#include <memory>
#include "chatbot.h"

using namespace std;

// forward declarations
class GraphEdge;


class GraphNode
{
private:
    //// STUDENT CODE
    // data handles (owned)
	vector<unique_ptr<GraphEdge>> _childEdges;
	
    // data handles (not owned)
    std::vector<GraphEdge *> _parentEdges; // edges to preceding nodes 

    ChatBot *_chatBot = nullptr;

    ////
    //// EOF STUDENT CODE

    // proprietary members
    int _id;
    std::vector<std::string> _answers;

public:
    // constructor / destructor
    GraphNode(int id);
    ~GraphNode();

    // getter / setter
    int GetID() { return _id; }
    int GetNumberOfChildEdges()
    {
	    return _childEdges.size();
    }

    GraphEdge *GetChildEdgeAtIndex(int index);
    vector<string> GetAnswers() { return _answers; }
    int GetNumberOfParents() { return _parentEdges.size(); }

    // proprietary functions
    void AddToken(std::string token); // add answers to list
    void AddEdgeToParentNode(GraphEdge *edge);
    void AddEdgeToChildNode(GraphEdge *edge);

    //// STUDENT CODE
    ////

    void MoveChatbotHere(ChatBot chatbot); //Rev1:4a  SM March 12 2022 //

    ChatBot &GetChatBot()
    {
	    return *_chatBot;
    }

    ////
    //// EOF STUDENT CODE

    void MoveChatbotToNewNode(GraphNode *newNode);
};

#endif /* GRAPHNODE_H_ */