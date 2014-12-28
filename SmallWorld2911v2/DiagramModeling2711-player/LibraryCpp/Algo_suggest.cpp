#include "stdafx.h"
#include "Algo_suggest.h"
#include "Common.h"
#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <time.h> 
#include <tuple>
using namespace std;

/*!
* \brief Initialize Suggestion map engine
*
* Copy reference of the map and its size in the engine
*
* \param map Current map with the CaseType Enum
* \param mapSize Size (Width only) of the map given
*/
Algo_suggest::Algo_suggest(CaseType** map, int mapSize) : _map(map), _mapSize(mapSize)  {

	this->_sugg = new int*[_mapSize];
	for (int i = 0; i < _mapSize; i++)
		_sugg[i] = new int[_mapSize];
}

/*!
* \brief Deallocate the map array
*/
Algo_suggest::~Algo_suggest() {
	for (int i = 0; i < _mapSize; i++) {
		delete[] _map[i];
		delete[] _sugg[i];
	}

	delete[] _map;
	delete[] _sugg;
}

/*!
* \brief Suggest tiles where the current unit can go and
* might be interesting
*
* \param units Position of units on the map. Each index represent
*				a tile and its content determine which nation is on it.
* \param x Position X of the current unit
* \param y Position Y of the current unit
* \param movePoints Move points available for the current unit
* \param currentNation Nation of the unit
*/
vector<tuple<int, int, int>> Algo_suggest::suggestion(UnitType** units, int x, int y, double movePoints, UnitType currentNation)
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

	// Choose 3 best choices
	for (int i = 0; i < _mapSize; i++) {
		for (int j = 0; j < _mapSize; j++) {
			if (_sugg[i][j] == Possible) {

				// Suggest tiles which earn points
				if (currentNation == Elf && _map[i][j] == Desert)
					_sugg[i][j] = Suggested;
				if (currentNation == Orc && _map[i][j] == Forest)
					_sugg[i][j] = Suggested;
				if (currentNation == Nain && _map[i][j] == Plain)
					_sugg[i][j] = Suggested;
				/*
				// Suggest tiles to block the ennemy
				if (_map[i][j] == Plain && otherNation == Gallic && this->unitNearBy(i, j, otherNation))
					_sugg[i][j] = Suggested;

				if (_map[i][j] == Forest && otherNation == Dwarf && this->unitNearBy(i, j, otherNation)) {
					_sugg[i][j] = Suggested;
				}

				if (otherNation == Viking && waterNearBy(i, j) && this->unitNearBy(i, j, otherNation)) {
					_sugg[i][j] = Suggested;
				}*/
			}
		}
	}

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

/*!
* \brief Check if there's a unit near the tile given
*/
bool Algo_suggest::unitNearBy(int x, int y, UnitType nation) {
	/*
	int offsets[4][2] = { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

	for (int i = 0; i < 4; i++) {
		int newX = x - offsets[i][0];
		int newY = y - offsets[i][1];

		if (newX >= 0 && newY >= 0 && newX < _mapSize && newY < _mapSize
			&& _units[newX][newY] == nation) {
			return true;
		}
	}*/

	return false;
}



/*!
* \brief Check which cases the user can go around him
*/
void Algo_suggest::moveAround(int x, int y, float movePoints)
{
	int offsets[4][2] = { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

	for (int i = 0; i < 4; i++) {
		int newX = _currentX - offsets[i][0];
		int newY = _currentY - offsets[i][1];
		_sugg[newX][newY] = Possible;
		/*
		if (newX >= 0 && newY >= 0 && newX < _mapSize && newY < _mapSize) {
			if (_map[newX][newY] == Plain && _nation == Gallic) {
				if (movePoints >= 1)
					this->moveAround(newX, newY, movePoints / 2);
				_sugg[newX][newY] = Possible;
			}
			else if (movePoints >= 1 && _map[newX][newY] != Sea || _nation == Viking)
				_sugg[newX][newY] = Possible;
		}*/
	}
}

