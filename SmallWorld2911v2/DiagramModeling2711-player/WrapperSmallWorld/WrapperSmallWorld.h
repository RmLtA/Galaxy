#pragma once
#ifndef __WRAPPERSMALLWORLD__
#define __WRAPPERSMALLWORLD__

#include "E:\4INFO\POO\GITHUB\Galaxy\SmallWorld2911v2\DiagramModeling2711-player\LibraryCpp\Algo.h"
#pragma comment(lib, "LibraryCpp.lib")

using namespace System;

namespace WrapperSmallWorld{
	public ref class WrapperAlgo
	{
	private:
		AlgoMap* algo;

	public:
		WrapperAlgo(){ algo = Algo_new(); /*attention c'est le constructeur par défaut qui a été appelé */}
		~WrapperAlgo(){ Algo_delete(algo); }
		int** fillMap(){ return algo->fillMap(); }
		void display(){ algo->displayMatrix(); }
	};
}


#endif