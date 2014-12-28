#ifndef INTERFACE_H
#define INTERFACE_H
#include "Common.h"
#include "stdafx.h"
#include "Algo.h"
#include <vector>
#include <tuple>

#define EXTERNC extern "C"
#ifdef MAP_DLL_EXPORT
#define DLL __declspec(dllexport)
#else
#define DLL __declspec(dllimport)
#endif

EXTERNC DLL int* interface_generate_map(int size);
EXTERNC DLL void init_map_suggestion(CaseType** map, int mapSize);
EXTERNC DLL std::vector<std::tuple<int, int, int>> api_get_tiles_suggestion(UnitType** units, int currentX, int currentY, double ptDepl, UnitType currentNation);

#endif

