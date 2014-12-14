
#include "Algo.h"
#include <iostream>
using namespace std;

/**
* \brief    Constructor of the board of the game which is a matrix[nbsquare,nbsquare]
* \return   bool winned
*/
AlgoMap::AlgoMap()
{
	tab = new int*[];
}


/**
* \brief    Fill the Map with an integer which indicates the nature of the square (0 : forest, 1 : Plain, 2 : Desert)
* \return   int[row][column] the board game filled
*/
int** AlgoMap::fillMap(int nb){
	int i;
	int j;
	for (i = 0; i<nb; i++){
		for (j = 0; j<nb; j++){
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

void AlgoMap::displayMatrix(int nbsquare){     
	int i, j;
	for (i = 0; i<nbsquare; i++){
		for (j = 0; j<nbsquare; j++){ cout << tab[i][j] << "   "; }
		cout << endl;
	}
}

AlgoMap::~AlgoMap()
{
}


AlgoMap* Algo_new(){ 
	return new AlgoMap(); 
}


void Algo_delete(AlgoMap* algo){ 
	delete algo; 
}


int** Algo_fillMap(AlgoMap* algo, int nbsquare){ 
	return algo->fillMap(nbsquare); 
}

void Algo_display(AlgoMap* algo, int nbsquare){ 
	algo->displayMatrix(nbsquare); 
}