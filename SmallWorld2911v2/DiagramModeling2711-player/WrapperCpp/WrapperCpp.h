#pragma once
#ifndef __WRAPPERCPP__
#define __WRAPPERCPP__

#include "../libraryCpp/MapGenerator.h"
//#include "C:\Users\Romdhane\Desktop\Nouveau dossier (3)\SmallWorldTestMapV3\DiagramModeling2711-player\ConsoleApplication1.lib"
#pragma comment(lib, "../Debug/libraryCpp.lib")

using namespace System;

namespace WrapperCPP{
	public ref class Wrapper
	{
	private:
		MapGenerator* algo_map;
	public:
		Wrapper(){ algo_map = MapGenerator_new(); }

		~Wrapper(){ MapGenerator_delete(algo_map); }

		int* fillMap(int n){ return algo_map->fillMap(n); }

		void fillsuggestMap(CaseType** map, int mapSize){ algo_map->fillsuggestMap(map, mapSize); }

		std::vector<tuple<int, int, int>> suggestion(UnitType** units, int currentX,
			int currentY, double ptDepl, UnitType currentNation){
			return algo_map->suggestion(units, currentX, currentY, ptDepl, currentNation);
		}

	};
}


#endif

