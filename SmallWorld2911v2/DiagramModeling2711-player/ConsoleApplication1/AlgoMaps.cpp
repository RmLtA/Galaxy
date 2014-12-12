#include "stdafx.h"
#include "AlgoMaps.h"
#include <iostream>
using namespace std;


AlgoMaps::AlgoMaps(){
	tab = new int*[];
}

int** AlgoMaps::tabMap(int Ncases ){
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
void AlgoMaps:: AfficheMatrice(int Ncases){     // fonction qui permet d'afficher une matrice entrée en parametre
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
int** Algo_tabMap(AlgoMaps* algo,int Ncases){ return algo->tabMap(Ncases); };
void algo_affiche(AlgoMaps* algo,int Ncases){ algo->AfficheMatrice(Ncases); };


