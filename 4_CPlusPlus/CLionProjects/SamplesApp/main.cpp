#include <iostream>

class IAutoMobile
{
public:
    virtual void SetDriveType(int na) = 0;
    virtual void SetEngineType(int na) = 0;
    virtual int ModelType() = 0;
protected:
    int m_numDrive;
    int m_EngineCylinders;
    int m_modelNo;
};


class FordModel : IAutoMobile
{
public:
    FordModel()
    {
        m_modelNo = 202;
    }
    void SetDriveType(int na) override;
    void SetEngineType(int na ) override;
    int ModelType() override;
};

void FordModel::SetDriveType(int na)
{
    m_numDrive = na;
}

void FordModel::SetEngineType(int na)
{
    m_EngineCylinders = na;
}

int FordModel::ModelType() {
    return 101;
}

int main() {
    std::cout << "Hello, World!" << std::endl;
    return 0;
}
