#ifdef WANTDLLEXP
#define DLL_declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

using namespace std;

class DLL MapGenerator
{

public:
	MapGenerator();
	int* fillMap(int n);
	int* moveAroundX();
	int* moveAroundY();
};

EXTERNC DLL MapGenerator* MapGenerator_new();
EXTERNC DLL int* MapGenerator_fillMap(MapGenerator* algo_map, int n);
EXTERNC DLL int* MapGenerator_moveAroundX(MapGenerator* algo_map);
EXTERNC DLL int* MapGenerator_moveAroundY(MapGenerator* algo_map);