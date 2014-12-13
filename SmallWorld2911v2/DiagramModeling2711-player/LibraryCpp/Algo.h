#pragma once
#ifdef WANTDLLEXP
	#define DLL_declspec(dllexport)
	#define EXTERNC extern "C"
#else
	#define DLL
	#define EXTERNC
#endif

class DLL AlgoMap
{
	private:
		int** tab;
		/*Number of square on one side*/
		int _nbsquare;

	public:
		AlgoMap(int nbsquare);
		AlgoMap();
		int ** fillMap();
		void displayMatrix();
		~AlgoMap();
};

EXTERNC DLL AlgoMap* Algo_new();
EXTERNC DLL void Algo_delete(AlgoMap* algo);
EXTERNC DLL int** fillMap(AlgoMap* algo);
EXTERNC DLL void algo_affiche(AlgoMap* algo);