/*
PROGRAM TITLE		PROGRAMMING PROJECT 1
DUE DATE				OCT.01.01, @1:30 PM
AUTHOR				CHRIS C
STUDENT ID			
COURSE CODE			COE2SI4
LAST MODIFIED		01/09/14 (YY/MM/DD)
COMPILER				BORLAND C++ 5.0, (c) 1991,1996 BY BORLAND INTERNATIONAL
COMMENTS				TURING MACHINE SIMULATOR
*/
#include <stdio.h>
#include <math.h>
#include <conio.h>
#include <stdlib.h>
#include <string.h>

/* Constants */
#define Q_MAX 10
#define S_MAX 10
#define DEFAULT_TM "TESTTM.TXT"
#define DEFAULT_TAPE "TESTTAPE.TXT"
#define FNAMEMAXCHARS 12
#define COMMLEN 50
/* Data Structures */
struct tmstate
{
	int curstate;
	char insymbol;
	int newstate;
	char outsymbol;
	char move;
};
struct tm
{
	int newstate;
   char outsymbol;
   char move;
};
/* Function Prototypes */
int Readtm(char tmfname[FNAMEMAXCHARS],struct tm tmarray[Q_MAX][S_MAX],char *tmcomment[COMMLEN]);
int Readtape(char tapefname[FNAMEMAXCHARS],char tape[],int *tapelastix);
void Readline(FILE *fp,char mystring[]);
void Pause(void);

/* Main Sub */
int main (void)
{
	/* Local Variables for main program */
	char tmfname[FNAMEMAXCHARS];
	char tapefname[FNAMEMAXCHARS];
   struct tm tmarray[Q_MAX][S_MAX];
   char tmcomment[COMMLEN];
	clrscr();
	printf("2SI4 PP1 - Turing Machine Emulator by Chris Christodoulou.");
	/* Input */

	printf("Enter the tape filename, or type 'D' to use the default (%s):",DEFAULT_TAPE);
	scanf("%s",tapefname);

	if (strcmp(tapefname,"D")==0 || strcmp(tapefname,"d")==0) {
      printf("Hello");
      strcpy(tapefname,DEFAULT_TAPE); }

	printf("Enter the Transition Matrix filename, or type 'D' to use the default (%s):",DEFAULT_TM);
	scanf("%s",tmfname);

	if (tmfname=="D" || tmfname=="d") {
      strcpy(tapefname,DEFAULT_TM); }

	printf("%s , %s",tmfname,tapefname);
/* Processing */

/* Output */
Pause();
return 0;
}

/******************* Subroutines *******************/

int Readtm(char tmfname[FNAMEMAXCHARS],struct tm tmarray[Q_MAX][S_MAX],char *tmcomment[COMMLEN])
{
	FILE *fin;
   int tempcurstate;
   char tempinsymbol;
	if ((fin = fopen(tmfname, "r"))==NULL) {
		printf("Error opening transition matrix file.\n");
		return 0; }
   while (!feof(fin)) {
   	fscanf (fin, "%d%c", &tempcurstate, &tempinsymbol);
      fscanf (fin,"%d%c%c",&tmarray[tempcurstate][tempinsymbol].newstate,&tmarray[tempcurstate][tempinsymbol].outsymbol,&tmarray[tempcurstate][tempinsymbol].move); }
	fclose(fin);
	return 1;
}

int Readtape(char tapefname[FNAMEMAXCHARS],char tape[],int *tapelastix)
{
	return 0;
}

void Readline(FILE *fp,char mystring[])
{
   int ix=0;
   char tempchar;
   do {
		tempchar=fgetc(fp);
      if (!tempchar==10) {
      	mystring[ix]=tempchar;
      	ix++; }
   } while (!tempchar==10);
}

void Pause(void)
{
	getch();
}