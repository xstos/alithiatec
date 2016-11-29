/*
PROGRAM TITLE		PROGRAMMING PROJECT 3
DUE DATE				NOV.22.01, @1:30 PM (ITC-145)
AUTHORS					CHRIS C
                        YUEN C
						TOM T
COURSE CODE			COE2SI4
COMPILER				BORLAND C++ 5.0, (c) 1991,1996 BY BORLAND INTERNATIONAL
COMMENTS				SORTING ALGORITHM TIMER
*/
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <time.h>
#include <stddef.h>
#include <math.h>
#include <string.h>

/* Constants/Defines */
#define SWAP(x, y, t) ((t) = (x), (x) = (y), (y) = (t))
#define TRUE 1
#define FALSE 0
#define NUMREPS 100
#define MAXSIZE 1000

/* Data Structures */
typedef struct heap {
	int key;
	int data;
} element;

/* Function Prototypes */
void opendata(int n,int type,int sortthis[MAXSIZE+1]);
void prepdata1(element list[MAXSIZE+1],int sortthis[MAXSIZE+1]);
void prepdata2(int list[MAXSIZE],int sortthis[MAXSIZE+1]);
void cleardata1(element list[MAXSIZE+1],int sortthis[MAXSIZE+1]);
void iSort(element list[MAXSIZE+1], int n);
void shellsort(int v[MAXSIZE], int n);
void quicksort(element list[MAXSIZE+1], int left, int right);
void heapsort(element list[MAXSIZE+1], int n);
void adjust(element list[MAXSIZE+1], int root, int n);
void bubblesort(int array[MAXSIZE],int n);
void ShakerSort(element list[MAXSIZE+1], int n);


/* Globals */
FILE *fpin,*fpout;


/* Main Sub */
int main (void)
{
	clock_t startt, endt;
  float elapsedt[7];
  int type=0,n[7],nvals,reps;
  int sortthis[MAXSIZE+1];
  element list[MAXSIZE+1][NUMREPS];
  int list2[MAXSIZE];
  n[0]=25;
  n[1]=50;
  n[2]=75;
  n[3]=100;
  n[4]=200;
  n[5]=500;
  n[6]=1000;
					/*   */
	clrscr();
  printf("Welcome to the Sort Timer Program.");
  printf("\n\nTimes in seconds\nn\tinsert\tshell\tquick\tqsort\theap\tbubble\tshaker\n");
  for (nvals=0;nvals<1;nvals++)
    {
		for (type=0;type<1;type++)
    	{
    	opendata(n[nvals],type,sortthis);
  		if (type%2==0)
    		{
					if (type==0)
          	{
            startt=clock();
            for (reps=0;reps<NUMREPS;reps++)
            {
            /*prepdata1(list,sortthis);*/
						iSort(list,n[nvals]);
            /*cleardata1(list,sortthis);*/
            }
            endt=clock();
            elapsedt[type] = (((float)(endt-startt))/CLK_TCK)/NUMREPS;
            }
          if (type==2)
          {
          	startt=clock();
            for (reps=0;reps<NUMREPS;reps++)
            {
            prepdata1(list,sortthis);
						quicksort(list,0,n[nvals]);
            cleardata1(list,sortthis);
            }
            endt=clock();
            elapsedt[type] = (((float)(endt-startt))/CLK_TCK)/NUMREPS;
          }
          if (type==4)
          {
            startt=clock();
            for (reps=0;reps<NUMREPS;reps++)
            {
            prepdata1(list,sortthis);
						heapsort(list,n[nvals]);
            cleardata1(list,sortthis);
            }
            endt=clock();
            elapsedt[type] = (((float)(endt-startt))/CLK_TCK)/NUMREPS;
          }
         if (type==6)
         {
            startt=clock();
            for (reps=0;reps<NUMREPS;reps++)
            {
            prepdata1(list,sortthis);
						ShakerSort(list,n[nvals]);
            cleardata1(list,sortthis);
            }
            endt=clock();
            elapsedt[type] = (((float)(endt-startt))/CLK_TCK)/NUMREPS;
         }
        }
      	if (type%2==1)
      	{
            if (type==1)
            {
            startt=clock();
            for (reps=0;reps<NUMREPS;reps++)
            {
            prepdata2(list2,sortthis);
						ShakerSort(list2,n[nvals]);
            }
            endt=clock();
            elapsedt[type] = (((float)(endt-startt))/CLK_TCK)/NUMREPS;
            }
            if (type==3)
            	{
            	startt=clock();
            	for (reps=0;reps<NUMREPS;reps++)
		            {
    		        prepdata2(list2,sortthis);
            /*qsort((void *)list2, n[nvals], sizeof(list2[0]), sort_function);*/
            		}
            }
            if (type==5)
            	{
            	startt=clock();
            	for (reps=0;reps<NUMREPS;reps++)
	            	{
            		prepdata2(list2,sortthis);
								bubblesort(list2,n[nvals]);
		            }
            	endt=clock();
              elapsedt[type] = (((float)(endt-startt))/CLK_TCK)/NUMREPS;
              }
	      }
	  	}
    printf ("%d\t%0.3f\t%0.3f\t%0.3f\t%0.3f\t%0.3f\t%0.3f\t%0.3f",n[nvals],elapsedt[0],elapsedt[1],elapsedt[2],elapsedt[3],elapsedt[4],elapsedt[5],elapsedt[6],elapsedt[7]);
    }
  getch();
  return 0;
}

/******************* Subroutines *******************/

void prepdata1(element list[MAXSIZE+1],int sortthis[MAXSIZE+1])
{
	int i;
  for (i=1;i<MAXSIZE+1;i++)
    	list[i].key=sortthis[i];
}

void prepdata2(int list[MAXSIZE],int sortthis[MAXSIZE+1])
{
	int i;
  for (i=0;i<MAXSIZE;i++)
    	list[i]=sortthis[i+1];
}

void cleardata1(element list[MAXSIZE+1],int sortthis[MAXSIZE+1])
{
	int i;
  for (i=1;i<MAXSIZE+1;i++)
      {
    	list[i].key=0;
      sortthis[i]=0;
      }
}

void opendata(int n,int type,int sortthis[MAXSIZE+1])
{
  char curline[50];
  int i=0,j=0;
  static int curdata[MAXSIZE];
  char fname[14];
  if (!(type==1) && !(type==4))
  	strcpy(fname,"acdfg.txt");
  if (type==1)
  	strcpy(fname,"b.txt");
  if (type==4)
  	strcpy(fname,"e.txt");

  if ((fpin = fopen(fname, "r"))==NULL)
  {
  	printf("\nError data file %s",fname);
    exit(1);
  }
  i=0;
  while (!feof(fpin))
  {
  	fgets(curline,50,fpin);
    curdata[i]=atoi(curline);
    i++;
  }

  if ((type==0) || (type==5) || (type==6))
  	{
  	j=1;
  	for (i=n-1;i>=0;i--)
  		{
  			sortthis[j]=curdata[i];
  	  	j++;
  		}
  	}

	if ((type==1) || (type==2) || (type==3) || (type==4))
  {
  	for (i=0;i<n;i++)
  		sortthis[i+1]=curdata[i];
  }
}

void iSort(element list[MAXSIZE+1], int n)
/* Performs an insertion sort on the list */
{
	int i, j;
	element next;
	for (i=1; i<n; i++) {
		next = list[i];
		for (j=i-1; j>=0 && next.key < list[j].key; j--) {
			list[j+1] = list[j];
		}
		list[j+1] = next;
	}
}

void shellsort(int v[MAXSIZE], int n)
{
	int gap, i, j, temp;
   for (gap=n/2; gap>0; gap/=2)
   	for (i=gap; i<n; i++)
      	for (j=i-gap; j>=0 && v[j]>v[j+gap]; j-=gap)
         	{
            	temp=v[j];
               v[j]=v[j+gap];
               v[j+gap]=temp;
            }
}

/******************************************** Quicksort recursive ******************/

void quicksort(element list[MAXSIZE+1], int left, int right)
/* sort list[left],...., list[right] into nondecreasing order on the key field.
list[left].key is arbitrarily chosen as the pivot key.  It is assumed that
list[left].key <= list[right+1}.key */
{
	int pivot, i, j;
	element temp;
	if (left < right) {
		i=left;
		j=right +1;
		pivot = list[left].key;
		do {
		/* Search for keys from the left ond right sublists, swapping out-of-order
		elements until the left and right boundries cross or meet */
			do i++;
			while (list[i].key <pivot);
			do j--;
			while (list[j].key >pivot);
			if (i<j) SWAP(list[i], list[j], temp);
		} while (i<j);
		SWAP(list[left], list[j], temp);
		quicksort(list, left, j-1);
		quicksort(list, j+1, right);
	}
}



/****************************** Heap Sort **************************************/

/* call: heapsort(list, 10); */

void heapsort(element list[MAXSIZE+1], int n)
{
	int i;
	element temp;
	for (i=n/2; i>0; i--) adjust(list, i, n);	/* Build: insert into heap */
	for (i=n-1; i>0; i--) {
		SWAP(list[1], list[i+1], temp);			/*sort n-1 passes, each exchanges 1st key with last, */
		adjust(list, 1, i);						/*then decrements heap size and re-adjusts heap. */
	}
}


/*************************** Adjusting a max heap ******************************/

/* call: adjust(list,5,10); */

void adjust(element list[MAXSIZE+1], int root, int n)
{
	int child, rootkey;
	element temp;
	temp = list[root];							/* save root */
	rootkey = list[root].key;
	child = 2*root;								/* locates roots left child */
	while (child <= n) {
		if ((child < n) && (list[child].key < list[child+1].key)) child++;
		if (rootkey > list[child].key)			/* compare root and max child */
			break;
		else {
			list[child/2] = list[child];		/* move to parent */
			child *=2;
		}
	}	/*endwhile */
	list[child/2] = temp;						/*saved root's key put in place */
}

void bubblesort(int array[MAXSIZE],int n)
{
   int x,y,temp;
   	for (x=0; x<n-1;x++)
      for (y=0; y<n-x-1;y++)
      if (array[y]>array[y+1])
      	{
         	temp=array[y];
            array[y]=array[y+1];
            array[y+1]=temp;
         }
}

void ShakerSort(element list[MAXSIZE+1], int n)
{
	int i,flag;
	element temp;
	do
	{
		flag = TRUE;
		for (i=1; i<n; i++)	{			/* Going UP */
			if ((list[i].key) > (list[i+1].key)) {
				flag = FALSE;
				SWAP(list[i], list[i+1], temp);
			}
		}

		for (i=n; i>1; i--)	{			/* Going DOWN */
			if (list[i-1].key > list[i].key) {
				flag = FALSE;
				SWAP(list[i-1], list[i], temp);
			}
		}
	} while (flag == FALSE);
}
