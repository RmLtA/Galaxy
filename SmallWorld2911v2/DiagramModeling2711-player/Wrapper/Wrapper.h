#pragma once
#ifndef __WRAPPER__
#define __WRAPPER__

#include "C:\Users\Romdhane\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\ConsoleApplication1\AlgoMaps.h"
//#include "E:\4INFO\POO\DiagramModeling2711\Debug\ConsoleApplication1.lib"
#pragma comment(lib, "ConsoleApplication1.lib")

using namespace System;

namespace Wrapper{
	public ref class WrapperAlgo
	{
	private:
		AlgoMaps* algo;

	public:
		WrapperAlgo(){ algo = Algo_new(); }
		~WrapperAlgo(){ Algo_deletee(algo); }
		int** tabMap(){ return algo->tabMap(); }
		void affiche(){ algo->AfficheMatrice(); }
	};
}


#endif

