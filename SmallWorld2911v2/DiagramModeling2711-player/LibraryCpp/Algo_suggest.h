#include<vector>
#include<tuple>
#include <stdio.h>      
#include <stdlib.h>
#include "Common.h"
using namespace std;

enum MoveType
{
	Impossible = 0,
	Possible,
	Suggested
};

class Algo_suggest
{
	CaseType** _map;    /*!< Map array, representing each tile type */
	UnitType** _units;  /*!< Units array, representing which unit is on each tile */
	int _mapSize;       /*!< Map width */

	int** _sugg;        /*!< Suggestion array, to indicate where the unit can go */
	int _currentX;      /*!< Current X position of the unit */
	int _currentY;      /*!< Current Y position of the unit */
	int _movePoints;    /*!< Move points available for the unit */
	UnitType _nation;   /*!< Unit type of the current unit */


	/*!
	* \brief Mark every tiles around the unit as "Possible", if
	* it isn't water
	*/
	void moveAround(int x, int y, float moves);

	/*!
	* \brief Check if there's a unit around this case
	*/
	bool unitNearBy(int x, int y, UnitType nation);


public:
	Algo_suggest(CaseType** map, int mapSize);
	~Algo_suggest();

	std::vector<tuple<int, int, int>> suggestion(UnitType** units, int currentX, int currentY, double ptDepl, UnitType currentNation);
	
};

