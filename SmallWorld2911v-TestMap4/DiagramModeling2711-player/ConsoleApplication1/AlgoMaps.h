#ifdef WANTDLLEXP
#define DLL_declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
class DLL AlgoMaps
{
public:
	AlgoMaps();
	int * tabMap(int n);
	~AlgoMaps();
};

EXTERNC DLL AlgoMaps* Algo_new();
EXTERNC DLL void Algo_deletee(AlgoMaps* algo);
EXTERNC DLL int* algo_tabMap(AlgoMaps* algo,int n);




