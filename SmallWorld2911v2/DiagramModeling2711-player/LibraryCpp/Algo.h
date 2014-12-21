#ifdef WANTDLLEXP
#define DLL_declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
class DLL Algo
{
public:
	Algo();
	int * fillMap(int n);
	~Algo();
};

EXTERNC DLL Algo* Algo_new();
EXTERNC DLL void Algo_delete(Algo* algo);
EXTERNC DLL int* algo_fillMap(Algo* algo, int n);