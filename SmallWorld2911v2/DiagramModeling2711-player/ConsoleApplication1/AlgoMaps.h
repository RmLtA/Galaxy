#pragma once
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
	int Ncases;
public:
	AlgoMaps(int N);
	AlgoMaps();
	int ** tabMap();
	void AfficheMatrice();
	~AlgoMaps();
};

EXTERNC DLL AlgoMaps* Algo_new();
EXTERNC DLL void Algo_deletee(AlgoMaps* algo);
EXTERNC DLL int** tabMap(AlgoMaps* algo);
EXTERNC DLL void algo_affiche(AlgoMaps* algo)



