#pragma once
#ifndef __WRAPPER__
#define __WRAPPER__

#include "E:\4INFO\POO\SmallWorld2911v2\DiagramModeling2711-player\ConsoleApplication1\Algo.h"
//#include "E:\4INFO\POO\DiagramModeling2711\Debug\ConsoleApplication1.lib"
#pragma comment(lib, "ConsoleApplication1.lib")

using namespace System;

namespace Wrapper{
	public ref class WrapperAlgo
	{
	private:
		Algo* algo;

	public:
		WrapperAlgo(){ algo = Algo_new(); }
		~WrapperAlgo(){ Algo_delete(algo); }
		int computeFoo(){ return algo->computeFoo(); }
	};
}


#endif

