#ifdef WANTDLLEXP
#define DLL_declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
class DLL AlgoMaps
{private:
	int** tab;
public:
	AlgoMaps();
	int ** tabMap(int n);
	void AfficheMatrice(int n);
	~AlgoMaps();
};

EXTERNC DLL AlgoMaps* Algo_new();
EXTERNC DLL void Algo_deletee(AlgoMaps* algo);
EXTERNC DLL int** algo_tabMap(AlgoMaps* algo);
EXTERNC DLL void algo_affiche(AlgoMaps* algo);



