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
		type = rand() % 4;
		tab[i] = type;
	}								
	return tab;
}

/*

if (((u.Row == row) && (u.Column == column + 1)) || ((u.Row == row) && (u.Column == column - 1)))
{
return true;
}

if (((u.Column == column) && (u.Row == row + 1)) || ((u.Column== column) && (u.Row == row - 1)))
{
return true;
}

if (((u.Column == column - 1) && (u.Row == row + 1)) || ((u.Column == column - 1) && (u.Row == row - 1)))
{
return true;
}
*/
int* MapGenerator::moveAroundY()
{
	int* suggY = new int[6];
	int offsets[6] = { 1, -1, 0, 0, -1, -1 }; 

	//for (int i = 0; i < 6; i++) {
	//int newY = y - offsets[i];
	suggY = offsets;

	//}

	return suggY;
}
int* MapGenerator::moveAroundX()
{
	int* suggX = new int[6];
	
	int offsets[6]= { 0,  0,  1,  -1, 1 ,-1}; 

	//for (int i = 0; i < 6; i++) {
		//int newX = x - offsets[i];
		suggX = offsets;

	//}

	return suggX;
}





MapGenerator* MapGenerator_new(){ return new MapGenerator(); }
void MapGenerator_delete(MapGenerator* algo){ delete algo; }
int* MapGenerator_fillMap(MapGenerator* algo, int Ncases){ return algo->fillMap(Ncases); }
int* MapGenerator_moveAroundX(MapGenerator* algo){ return algo->moveAroundX(); }
int* MapGenerator_moveAroundY(MapGenerator* algo){ return algo->moveAroundX(); }









