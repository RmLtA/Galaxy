#pragma once
#ifndef __WRAPPERCPP__
#define __WRAPPERCPP__

#include "../libraryCpp/Algo.h"
//#include "C:\Users\Romdhane\Desktop\Nouveau dossier (3)\SmallWorldTestMapV3\DiagramModeling2711-player\ConsoleApplication1.lib"
#pragma comment(lib, "../Debug/libraryCpp.lib")

using namespace System;

namespace WrapperCPP{
	public ref class Wrapper
	{
	private:
		Algo* algo;
	public:
		Wrapper(){ algo = Algo_new(); }
		~Wrapper(){ Algo_delete(algo); }
		int* fillMap(int n){ return algo->fillMap(n); }

	};
}


#endif

