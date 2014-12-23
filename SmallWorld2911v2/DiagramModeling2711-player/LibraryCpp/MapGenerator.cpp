#include "stdafx.h"
#include "MapGenerator.h"
#include "Common.h"
#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <time.h> 
using namespace std;


MapGenerator::MapGenerator(){

}

int* MapGenerator::fillMap(int Ncases){
	int i;
	int * tab = new int[Ncases*Ncases];                     // l'allocation de la matrice

	srand((unsigned int)time(NULL));
	int type;
	for (i = 0; i < Ncases*Ncases; i++){
		type = rand() % 3;
		tab[i] = type;
	}								// remplissage  de la matrice avec des entiers : 0->foret ,1->plaine,2->deser
	return tab;
}


MapGenerator::~MapGenerator()
{
	for (int i = 0; i < _mapSize; i++) {
		delete[] _map[i];
		delete[] _sugg[i];
	}

	delete[] _map;
	delete[] _sugg;
}

vector<tuple<int, int, int>> MapGenerator::suggestion(UnitType** units, int x, int y, double movePoints, UnitType currentNation)
{
	// Vector of results, composed of 2-int arrays
	vector<tuple<int, int, int>> tilesSuggested;

	// Get other nation type
	UnitType otherNation;
	for (int i = 0; i < _mapSize; i++) {
		for (int j = 0; j < _mapSize; j++) {
			if (units[i][j] != None && units[i][j] != currentNation) {
				otherNation = units[i][j];
				break;
			}
		}
	}

	// Init a suggestion grid empty
	for (int i = 0; i < _mapSize; i++)
	for (int j = 0; j < _mapSize; j++)
		_sugg[i][j] = Impossible;


	// Init local member
	this->_units = units;

	this->_currentX = x;
	this->_currentY = y;
	this->_movePoints = movePoints;
	this->_nation = currentNation;

	// If the unit can't move anymore, return an empty vector
	// of cases
	if (movePoints == 0)
		return tilesSuggested;

	// Check every tiles around the current player
	this->moveAround(_currentX, _currentY, movePoints);

	// Returns coordinates possibles
	int* coords;
	for (int i = 0; i < _mapSize; i++) {
		for (int j = 0; j < _mapSize; j++) {
			if (_sugg[i][j] != Impossible)
				tilesSuggested.push_back(make_tuple(i, j, _sugg[i][j]));
		}
	}

	return tilesSuggested;
}

void MapGenerator::moveAround(int x, int y, float movePoints)
{
	int offsets[4][2] = { { -1, -1 }, { -1, 1 }, { 0, 1 }, { 0, -1 } };

	for (int i = 0; i < 4; i++) {
		int newX = _currentX - offsets[i][0];
		int newY = _currentY - offsets[i][1];
		_sugg[newX][newY] = Possible;

	}
}

void MapGenerator::fillsuggestMap(CaseType** map, int mapSize)
{
	_map = map;
	_mapSize = mapSize;
	this->_sugg = new int*[_mapSize];
	for (int i = 0; i < _mapSize; i++)
		_sugg[i] = new int[_mapSize];

}

MapGenerator* MapGenerator_new(){ return new MapGenerator(); }
void MapGenerator_delete(MapGenerator* algo){ delete algo; }
int* MapGenerator_fillMap(MapGenerator* algo, int Ncases){ return algo->fillMap(Ncases); };
void init_map_suggestion(MapGenerator* mapgen, CaseType** map, int mapSize){ mapgen->fillsuggestMap(map,mapSize); }
std::vector<std::tuple<int, int, int>> api_get_tiles_suggestion(MapGenerator* mapgen, UnitType** units, 
	int currentX, int currentY, double ptDepl, UnitType currentNation) {
	return mapgen->suggestion(units, currentX, currentY, ptDepl, currentNation);
}








