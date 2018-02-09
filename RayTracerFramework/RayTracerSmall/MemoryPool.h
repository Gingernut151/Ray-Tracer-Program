#pragma once
#include <vector>
#include <cassert>
#include <cstdlib>

#include "Commons.h"

using namespace::std;

class MemoryPool
{
public:
	MemoryPool(size_t NumOfObj, size_t iObjectSize);
	~MemoryPool();

	void * Alloc(size_t iSize);
	void Free(void * p);

	size_t GetPoolSize();
	size_t GetCellSize();
	size_t GetAllocatedCells();

private:
	size_t _usedCells;
	size_t _allocationAmount;
	size_t _contentSize;
	size_t _cellSize;

	void* _pool;
	vector<void*> _head;
};

