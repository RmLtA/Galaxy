#ifdef WANTDLLEXP
#define DLL_declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
#include <tuple>
#include <vector>
#include "Common.h"
using namespace std;

class DLL MapGenerator
{
protected:
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

public:
	MapGenerator();
	int * fillMap(int n);
	void fillsuggestMap(CaseType** map, int mapSize);
	std::vector<tuple<int, int, int>> suggestion(UnitType** units, int currentX, 
		int currentY, double ptDepl, UnitType currentNation);
	~MapGenerator();
};

EXTERNC DLL MapGenerator* MapGenerator_new();
EXTERNC DLL void MapGenerator_delete(MapGenerator* algo_map);
EXTERNC DLL int* MapGenerator_fillMap(MapGenerator* algo_map, int n);
EXTERNC DLL void init_map_suggestion(MapGenerator* mapgen, CaseType** map, int mapSize);
EXTERNC DLL std::vector<std::tuple<int, int, int>> api_get_tiles_suggestion(MapGenerator* mapgen, UnitType** units, int currentX, 
	int currentY, double ptDepl, UnitType currentNation);