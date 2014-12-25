#include "stdafx.h"
#include "MapGenerator.h"
#include "Common.h"
#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <time.h> 
using namespace std;


MapGenerator::MapGenerator()
{}

int* MapGenerator::fillMap(int Ncases){
	int i;
	int * tab = new int[Ncases*Ncases];                     

	srand((unsigned int)time(NULL));
	int type;
	for (i = 0; i < Ncases*Ncases; i++){
		type = rand() % 3;
		tab[i] = type;
	}								
	return tab;
}





int* MapGenerator::moveAroundX(int x)
{
	int* suggX = new int[4];
	
	int offsets[4]= { -1,  -1,  0,  0 }; //SUD-OUEST, SUD-EST, NORD-EST, NORD-OUEST

	for (int i = 0; i < 4; i++) {
		int newX = x - offsets[i];
		suggX[i] = newX;

	}

	return suggX;
}

int* MapGenerator::moveAroundY(int y)
{
	int* suggY = new int[4];
	int offsets[4]={-1 , 1 ,  1 , -1 } ; //SUD-OUEST, SUD-EST, NORD-EST, NORD-OUEST

	for (int i = 0; i < 4; i++) {
		int newY = y - offsets[i];
		suggY[i] = newY;

	}

	return suggY;
}



MapGenerator* MapGenerator_new(){ return new MapGenerator(); }
void MapGenerator_delete(MapGenerator* algo){ delete algo; }
int* MapGenerator_fillMap(MapGenerator* algo, int Ncases){ return algo->fillMap(Ncases); }
int* MapGenerator_moveAroundX(MapGenerator* algo, int x){ return algo->moveAroundX(x); }
int* MapGenerator_moveAroundY(MapGenerator* algo, int y){ return algo->moveAroundX(y); }









