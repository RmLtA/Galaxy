#pragma once
#ifndef __WRAPPER__
#define __WRAPPER__

#include "../ConsoleApplication1/AlgoMaps.h"
//#include "E:\4INFO\POO\DiagramModeling2711\Debug\ConsoleApplication1.lib"
#pragma comment(lib, "../Debug/ConsoleApplication1.lib")

using namespace System;

namespace WrapperN{
	public ref class WrapperAlgo
	{
	private:
		AlgoMaps* algo;
	public:
		WrapperAlgo(){ algo = Algo_new(); }
		~WrapperAlgo(){ Algo_deletee(algo); }
		int** tabMap(int n){ return algo->tabMap(n); }
		void affiche(int n){ algo->AfficheMatrice(n); }
	};
}


#endif

