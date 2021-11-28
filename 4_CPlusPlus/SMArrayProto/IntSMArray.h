#pragma once
class IntSMArray
{
	private:
		int* m_ptr{nullptr};
		int m_size{0};
	public:
		IntSMArray() = default; //synthesizes default constructor

		explicit IntSMArray(int size)
		{
			if (size != 0)
			{
				m_ptr = new int[size]{};
				m_size = size;
			}
		}

		int Size() const
		{
			return m_size;
		}

		bool IsEmpty() const
		{
			return (m_size == 0);
		}

		int& operator [] (int index)
		{
			return m_ptr[index];
		}
		
		~IntSMArray()
		{
			delete [] m_ptr;
		}
};

