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

	public:
		AlgoMap();
		int ** fillMap(int nb);
		void displayMatrix(int nb);
		~AlgoMap();
};

EXTERNC DLL AlgoMap* Algo_new();
EXTERNC DLL void Algo_delete(AlgoMap* algo);
EXTERNC DLL int** Algo_fillMap(AlgoMap* algo);
EXTERNC DLL void Algo_display(AlgoMap* algo);