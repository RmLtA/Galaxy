#pragma once
#ifndef __WRAPPERCPP__
#define __WRAPPERCPP__

#include "../libraryCpp/MapGenerator.h"
//#include "C:\Users\Romdhane\Desktop\Nouveau dossier (3)\SmallWorldTestMapV3\DiagramModeling2711-player\ConsoleApplication1.lib"
#pragma comment(lib, "../Debug/libraryCpp.lib")


#include <iostream>

using namespace System::Collections::Generic;
using namespace System;

namespace WrapperCPP{
	public ref class Wrapper
	{
	private:
		MapGenerator* algo_map;

	public:
		Wrapper(){ algo_map = MapGenerator_new(); }


		int* fillMap(int n){ return algo_map->fillMap(n); }

		int* moveAroundX(int x){ return algo_map->moveAroundX(x); }
		int* moveAroundY(int y){ return algo_map->moveAroundX(y); }



	};
}


#endif

