#include "Interface.h"
#include "Common.h"
#include "Algo.h"
#include "stdafx.h"
#include "Algo_suggest.h"
#include <vector>

Algo* algo_map;

int* interface_generate_map(int size){
	algo_map = new Algo();
	return algo_map.fillMap(size);
}
Algo_suggest* gen;

void init_map_suggestion(CaseType** map, int mapSize) {
	gen = new Algo_suggest(map, mapSize);
}

std::vector<std::tuple<int, int, int>> api_get_tiles_suggestion(UnitType** units, int currentX, int currentY, double ptDepl, UnitType currentNation) {
	return gen->suggestion(units, currentX, currentY, ptDepl, currentNation);
}