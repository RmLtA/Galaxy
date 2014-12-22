#include "stdafx.h"
#include "Algo.h"
#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <time.h> 
using namespace std;


Algo::Algo(){
}

int* Algo::fillMap(int Ncases){
	int i;
	int * tab = new int[Ncases*Ncases];                     // l'allocation de la matrice

	srand((unsigned int)time(NULL));
	int type;
	for (i = 0; i < Ncases*Ncases; i++){
		type = rand() % 3;
		tab[i] = type;
	}								// remplissage  de la matrice avec des entiers : 0->foret ,1->plaine,2->deser
	return tab;
}


Algo::~Algo()
{
}

Algo* Algo_new(){ return new Algo(); }
void Algo_delete(Algo* algo){ delete algo; }
int* Algo_fillMap(Algo* algo, int Ncases){ return algo->fillMap(Ncases); };


