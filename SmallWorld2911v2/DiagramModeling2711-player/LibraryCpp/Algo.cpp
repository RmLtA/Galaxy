
#include "Algo.h"
#include <iostream>
using namespace std;

/**
* \brief    Constructor of the board of the game which is a matrix[nbsquare,nbsquare]
* \return   bool winned
*/
AlgoMap::AlgoMap(int nbsquare)
{
	int i;
	_nbsquare = nbsquare;
	// l'allocation de la matrice
	tab = new int*[_nbsquare]; 

	//allocation d'un tableau 
	for (i = 0; i<_nbsquare; i++){
		tab[i] = new int[_nbsquare];
	}
}

AlgoMap::AlgoMap(){}

/**
* \brief    Fill the Map with an integer which indicates the nature of the square (0 : forest, 1 : Plain, 2 : Desert)
* \return   int[row][column] the board game filled
*/
int** AlgoMap::fillMap(){
	int i;
	int j;
	for (i = 0; i<_nbsquare; i++){
		for (j = 0; j<_nbsquare; j++){
			if (i % 2 == 0){ tab[i][j] = 0; }
			else {
				if (i % 3 == 0)
					tab[i][j] = 1;
				else
					tab[i][j] = 2;
			}
		}
	}									
	return tab;
}

void AlgoMap::displayMatrix(){     
	int i, j;
	for (i = 0; i<_nbsquare; i++){
		for (j = 0; j<_nbsquare; j++){ cout << tab[i][j] << "   "; }
		cout << endl;
	}
}

AlgoMap::~AlgoMap()
{
}

/* attention c'est le constructeur par défaut qui a été appelé*/
AlgoMap* Algo_new(){ 
	return new AlgoMap(); 
}


void Algo_delete(AlgoMap* algo){ 
	delete algo; 
}


int** Algo_tabMap(AlgoMap* algo){ 
	return algo->fillMap(); 
}

void algo_affiche(AlgoMap* algo){ 
	algo->displayMatrix(); 
}