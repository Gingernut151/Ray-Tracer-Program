#include "MemoryPool.h"

using namespace std;

//-----------------------------------------------------------------------------------------------------------------------
MemoryPool::MemoryPool(size_t NumOfObj, size_t ObjectSize)
{
	_usedCells = 0;
	_allocationAmount = NumOfObj;
	_contentSize = ObjectSize;
	_cellSize = ObjectSize + sizeof(AllocHeader) + sizeof (unsigned int);
	_pool = malloc(_cellSize * _allocationAmount);

	_head.push_back(_pool);
}
//-----------------------------------------------------------------------------------------------------------------------
MemoryPool::~MemoryPool()
{
}
//-----------------------------------------------------------------------------------------------------------------------
void* MemoryPool::Alloc(size_t iSize)
{
	if (iSize != _contentSize)
	{
		// add error message for cmd
		return nullptr;
	}

	if (_allocationAmount == _usedCells)
	{
		std::cout << "Memorypool is Full";
		return nullptr;
	}

	_usedCells += 1;

	void* cellStart = _head.at(_head.size() - 1);
	void* cellContentStart = (void*) (((char*)cellStart) + sizeof(AllocHeader));
	void* cellEnd = (void*)(((char*)cellStart) + sizeof(AllocHeader) + _contentSize);

	AllocHeader* header = (AllocHeader*)cellStart;
	unsigned int* cellEndInt = (unsigned int*)cellEnd; //needed to get value / can't get from a raw pointer

	header->iSignature = MEMSYSTEM_SIGNATURE;
	header->iSize = _contentSize;
	*cellEndInt = MEMSYSTEM_ENDMARKER;

	if (_usedCells >= _allocationAmount)
	{
		_head.clear();
	}
	else
	{
		if (_head.size() == 1)
		{
			_head.at(0) = (void*)((char*)cellStart + _cellSize);
		}
		else
		{
			_head.pop_back();
		}
	}

	return cellContentStart;
}
//-----------------------------------------------------------------------------------------------------------------------
void MemoryPool::Free(void * object)
{
	void* cellStart = (void*)(((char*)object) - sizeof(AllocHeader));
	AllocHeader* headCheck = (AllocHeader*)cellStart;
	unsigned int* EndCheck = (unsigned int*)(((char*)object) + _contentSize);

	assert(headCheck->iSignature == MEMSYSTEM_SIGNATURE);
	assert(*EndCheck == MEMSYSTEM_ENDMARKER);

	_usedCells -= 1;
	_head.push_back(cellStart);

	for (size_t i = 0; i < _cellSize - 1; i++)
	{
		char* pos = ((char*)cellStart) + i;
		*pos = 0;
	}
}
//-----------------------------------------------------------------------------------------------------------------------
size_t MemoryPool::GetPoolSize()
{
	return (_allocationAmount * _cellSize);
}
//-----------------------------------------------------------------------------------------------------------------------
size_t MemoryPool::GetCellSize()
{
	return _cellSize;
}
//-----------------------------------------------------------------------------------------------------------------------
size_t MemoryPool::GetAllocatedCells()
{
	return _usedCells;
}
//-----------------------------------------------------------------------------------------------------------------------
