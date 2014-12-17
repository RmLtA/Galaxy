#include "stdafx.h"
#include "AlgoMaps.h"
#include <iostream>
using namespace std;


AlgoMaps::AlgoMaps(){
	
}

int* AlgoMaps::tabMap(int Ncases ){
	int i;
	int * tab = new int[Ncases*Ncases];                     // l'allocation de la matrice


	for (i = 0; i < Ncases*Ncases; i++){

		tab[i] = 0;
	}								// remplissage  de la matrice avec des entiers : 0->foret ,1->plaine,2->deser
	return tab;
}


AlgoMaps::~AlgoMaps()
{
}

AlgoMaps* Algo_new(){ return new AlgoMaps(); }
void Algo_deletee(AlgoMaps* algo){ delete algo; }
int* Algo_tabMap(AlgoMaps* algo,int Ncases){ return algo->tabMap(Ncases); };


