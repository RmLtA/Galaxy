#ifndef COMMON_H
#define COMMON_H

#define NB_TILE_TYPES 5

enum CaseType
{
	Desert = 0,
	Forest,
	Plain,
};


enum UnitType
{
	None,
	Elf,
	Orc,
	Nain
};

struct Point {
	int x;
	int y;
};

#endif