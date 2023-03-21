#include<stdio.h>

#define SQUARE(x) x*x


int main()
{
	int i;
	i = 27/SQUARE(3);

	printf("\n%d\n", i);
	return 0;
}