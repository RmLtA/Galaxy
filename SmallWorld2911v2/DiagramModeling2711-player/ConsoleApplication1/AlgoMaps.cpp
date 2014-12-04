#include "stdafx.h"
#include "AlgoMaps.h"
#include <iostream>
using namespace std;

AlgoMaps::AlgoMaps(int N)
{
	int i;
	Ncases = N;
	tab = new int*[Ncases];                     // l'allocation de la matrice
	for (i = 0; i<Ncases; i++){
		tab[i] = new int[Ncases];
	}
}


int** AlgoMaps::tabMap(){
	int i;
	int j;
	for (i = 0; i<Ncases; i++){
		for (j = 0; j<Ncases; j++){
			if (i % 2 == 0){ tab[i][j] = 0; }
			else {
				if (i % 3 == 0)
					tab[i][j] = 1;
				else
					tab[i][j] = 2;
			}
		}
	}									// remplissage  de la matrice avec des entiers : 0->foret ,1->plaine,2->deser
	return tab;
}
void AlgoMaps:: AfficheMatrice(){     // fonction qui permet d'afficher une matrice entrée en parametre
	int i, j;
	for (i = 0; i<Ncases; i++){
		for (j = 0; j<Ncases; j++){ cout << tab[i][j] << "   "; }
		cout << endl;
	}
}
AlgoMaps::~AlgoMaps()
{
}
AlgoMaps* Algo_new(){ return new AlgoMaps(); }
void Algo_deletee(AlgoMaps* algo){ delete algo; }
int** Algo_tabMap(AlgoMaps* algo){ return algo->tabMap(); };
void algo_affiche(AlgoMaps* algo){ algo->AfficheMatrice(); };


