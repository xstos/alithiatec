/*
PROGRAM TITLE		PROGRAMMING PROJECT 2
DUE DATE				OCT.29.01, @5:00 PM (ITC-145)
AUTHOR					CHRIS C
STUDENT ID			
COURSE CODE			COE2SI4
COMPILER				BORLAND C++ 5.0, (c) 1991,1996 BY BORLAND INTERNATIONAL
COMMENTS				AIRPORT SIMULATOR
*/
#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <time.h>
#include <stddef.h>


/* Constants */
#define ISFULL(ptr) (!(ptr))
#define ISEMPTY(ptr) (!(ptr))
#define BASEFUEL 4
#define EXTRAFUEL 5
#define ERRMEMFULL 1
#define LANDING 1
#define TAKEOFF 0
#define TRUE 1
#define FALSE 0
#define DANGERFUEL 4
#define NUMQS 7
#define MAXIN 3
#define LANDFUEL 15

/* Data Structures */
typedef struct stuff {
	int id;
  int fuel;
  float wait;
  } planedata;

typedef struct plane_node *nodeptr;

typedef struct plane_node {
	planedata data;
  nodeptr next;
  }mynode;

typedef struct stuff2 {
	nodeptr first;
  nodeptr last;
  int numnodes;
  int runway;
  int type;
  int processed;
  } Qptr;

/* Function Prototypes */
int Qadd(Qptr *Qcurr,planedata inputdata);
void Qdel(Qptr *Qcurr);
void Qtimepass(Qptr *Qcurr);
void Qprintcontents(Qptr *Qcurr);

/* Main Sub */
int main (void)
{
	/* Local Variables for main program */
  static Qptr Q[NUMQS]; /* 7 queues */
  nodeptr currnode;
  int idin=1,idout=0,numplanes;
  int i,j,rwused[3],numcrashed=0,crashtemp,templandingstakeoffs,Qbiggest=0,numdone=0,runway,Qsmallest;
	float avgtakeoffwait=0.0,avglandingwait=0.0,numlandings=0.0,numtakeoffs=0.0;
  time_t t;
  char c='a';
  planedata mydata;
  int timeval=0;
	for (i=0;i<4;i++)
  	{
  	Q[i].first=NULL;
		Q[i].last=NULL;
  	Q[i].numnodes=0; /*# planes in Q*/
    Q[i].type=LANDING;
    Q[i].runway=i%2; /* which runway the queue is assigned to*/
    }
  for (i=4;i<NUMQS;i++)
  	{
  	Q[i].first=NULL;
		Q[i].last=NULL;
  	Q[i].numnodes=0;
    Q[i].runway=i-4;
    Q[i].type=TAKEOFF;
    }
  clrscr();
  srand((unsigned) time(&t)); /* use time as rand num generator seed */
	printf("2SI4 PP2 - Airport Emulator by Chris Christodoulou.\nCommands:\n");
  printf("'u'-Show Status Update\n'q'-Quit the program\nPress any other key for next period\n");
  do {
    if ((c=='u') || (c=='U'))
    	{
      printf("Landing Queue Contents:\n");
			for (i=0;i<4;i++)
      	{ printf("%d:",i);
        Qprintcontents(&Q[i]);
        printf("\n");
        }
			printf("Takeoff Queue Contents:\n");
			for (i=4;i<NUMQS;i++)
      	{ printf("%d:",i);
        Qprintcontents(&Q[i]);
        printf("\n");
        }
      printf("Total crashes: %d Avg Descent Wait %.2f Avg Takeoff Wait %.2f\n",numcrashed,avglandingwait,avgtakeoffwait);
      }
    for (i=0;i<NUMQS;i++)
    	Qtimepass(&Q[i]);
    timeval++;
    printf("Time:%d Crashes:",timeval);
		for (i=0;i<NUMQS;i++)
    	Q[i].processed=FALSE;
		rwused[0]=FALSE;
    rwused[1]=FALSE;
    rwused[2]=FALSE;
    crashtemp=0;
    templandingstakeoffs=0;
		for (i=0;i<4;i++) /* display crashed planes & remove front crashed planes*/
			{
			if (Q[i].numnodes)
 				{
 				currnode=Q[i].first;
  			do
        	{
        	if (!currnode->data.fuel)
          	{
						printf(" #%d",currnode->data.id);
            crashtemp++;
          	numcrashed++;
            }
          currnode=currnode->next;
 					}
        while (!(currnode==NULL));
        if (Q[i].first->data.fuel<1)
        	Qdel(&Q[i]);
        }
      }
    if (!crashtemp)
    	printf(" None");
    printf("\n");
		printf("Emergency descents:");
    i=0;
    do								 /* checks through air holding patterns for planes within the critical range and lands 'em*/
			{
      if (Q[i].numnodes)
      	if (Q[i].first->data.fuel>0 && Q[i].first->data.fuel<DANGERFUEL && (!rwused[Q[i].runway] || !templandingstakeoffs))
        	{
          templandingstakeoffs++;

          if (templandingstakeoffs==1)
            runway=2;
          else
						runway=Q[i].runway;

          printf(" RW%d (#%d/%d)",runway,Q[i].first->data.id,Q[i].first->data.fuel);
          rwused[runway]=TRUE;
          numlandings++;
          avglandingwait=(avglandingwait+Q[i].first->data.wait)/numlandings;
          Qdel(&Q[i]);
          Q[i].processed=TRUE;
          }
      i++;
      }
    while (i<4 && templandingstakeoffs<4);
		if (!templandingstakeoffs)
    	printf(" None");
		printf("\n");
    printf("Regular Arrivals/Departures:");
		if (templandingstakeoffs<3) /* checks through all the rest of the Qs not used and processes planes */
    	{									/* empties the queues based on size and then fuel importance*/
      numdone=0;
			do
      	{
        Qbiggest=-1;
				for (i=0;i<NUMQS;i++)
					{
          if (Q[i].numnodes && !Q[i].processed && !rwused[Q[i].runway])
            {
            if (Qbiggest==-1)
            	{
              Qbiggest=i;
              }
						if (Q[Qbiggest].numnodes<Q[i].numnodes)
          		{
              Qbiggest=i;
            	}
            }
          }
        if (!(Qbiggest==-1))
        	{
					if (Q[Qbiggest].type==TAKEOFF)
          	{
            printf(" Dep RW%d #%d",Q[Qbiggest].runway,Q[Qbiggest].first->data.id);
            Q[Qbiggest].processed=TRUE;
            rwused[Q[Qbiggest].runway]=TRUE;
            numtakeoffs++;
            avgtakeoffwait=(avgtakeoffwait+Q[Qbiggest].first->data.wait)/numtakeoffs;
            Qdel(&Q[Qbiggest]);
            }
          else
          	{
            printf(" Arr RW%d (#%d/%d)",Q[Qbiggest].runway,Q[Qbiggest].first->data.id,Q[Qbiggest].first->data.fuel);
          	Q[Qbiggest].processed=TRUE;
            rwused[Q[Qbiggest].runway]=TRUE;
          	numlandings++;
          	avglandingwait=(avglandingwait+Q[Qbiggest].first->data.wait)/numlandings;
          	Qdel(&Q[Qbiggest]);
            }
          }
        numdone++;
        }
			while (templandingstakeoffs<3 && !(Qbiggest==-1) && numdone<NUMQS);
      }
			if (!templandingstakeoffs)
      	printf(" None");
      printf("\n");
      printf("Incoming Planes:");
      Qsmallest=0;
      numplanes=rand()%(MAXIN+1);
      j=0;
      while (j<numplanes)
        {
				for (i=0;i<4;i++)
          if (Q[i].numnodes < Q[Qsmallest].numnodes)
          	Qsmallest=i;
        mydata.fuel=BASEFUEL+ rand() % EXTRAFUEL;
        mydata.wait=0;
        mydata.id=idin;
        idin=idin+2;
        printf(" HP%d (#%d/%d)",Qsmallest,mydata.id,mydata.fuel);
        if (Qadd(&Q[Qsmallest],mydata))
   	    	exit(1);
        j++;
        };
      if (!numplanes)
      	printf(" None");
      printf("\n");
      printf("Outgoing Planes:");
      Qsmallest=4;
      numplanes=rand() % (MAXIN+1);
      j=0;
      while (j<numplanes)
        {
				for (i=4;i<NUMQS;i++)
          if (Q[i].numnodes < Q[Qsmallest].numnodes)
          	Qsmallest=i;
        mydata.fuel=LANDFUEL;
        mydata.wait=0;
        mydata.id=idout;
        idout=idout+2;
        printf(" Q%d (#%d)",Qsmallest,mydata.id);
        if (Qadd(&Q[Qsmallest],mydata))
   	    	exit(1);
        j++;
        };
      if (!numplanes)
      	printf(" None");
      printf("\n");
    c=getch();
  } while (!(c=='q') && !(c=='Q'));
    return 0;
}

/******************* Subroutines *******************/

int Qadd(Qptr *Qcurr,planedata inputdata)
{
  static nodeptr newnode;
  newnode=(nodeptr)malloc(sizeof(mynode));
  if  (ISFULL(newnode))
  	{
    fprintf(stderr,"Error: Memory Full.\n");
    return ERRMEMFULL;
    }
  newnode->data=inputdata;
  newnode->next=NULL;
  if (Qcurr->numnodes>0)  	/* queue with at least 1 node */
  	{
    Qcurr->last->next=newnode;
  	Qcurr->last=newnode;
    }
  else
  {														/* empty queue */
    Qcurr->first=newnode;
    Qcurr->last=newnode;
  }
  (Qcurr->numnodes)++;
	return 0;
}

void Qdel(Qptr *Qcurr)
{
	static nodeptr temp;
  if (Qcurr->numnodes>1)  	/* queue with at least 2 nodes */
  	{
		temp=Qcurr->first;
    Qcurr->first=Qcurr->first->next;
    free(temp);
    (Qcurr->numnodes)--;
    }
  else
    if (Qcurr->numnodes>0) /* queue with 1 node */
  		{
			free(Qcurr->last);
    	Qcurr->first=NULL;
			Qcurr->last=NULL;
      (Qcurr->numnodes)--;
    	}
}

void Qprintcontents(Qptr *Qcurr)
{
 if (Qcurr->numnodes)
 	{
  nodeptr currnode;
 	currnode=Qcurr->first;
	do
		{
		if (Qcurr->type)
			printf(" (#%d/%d)",currnode->data.id,currnode->data.fuel);
		else
			printf(" (#%d)",currnode->data.id);
		currnode=currnode->next;
		}   
		while (!(currnode==Qcurr->last)&&!(currnode==NULL));
  }
 else
 	printf(" Empty");
}

void Qtimepass(Qptr *Qcurr)
{
 static nodeptr currnode=NULL;
 if (Qcurr->numnodes)
 	{
 	currnode=Qcurr->first;
  do {
  	(currnode->data.fuel)--;
    (currnode->data.wait)++;
    currnode=currnode->next;
 	} while (!(currnode==Qcurr->last)&&!(currnode==NULL));
  }
}
