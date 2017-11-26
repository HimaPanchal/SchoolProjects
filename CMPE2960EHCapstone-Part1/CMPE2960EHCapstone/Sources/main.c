/********************************************************************/
// HC12 Program:	CMPE2960 - Capstone Project
// Processor:		MC9S12E128CPV
// Xtal Speed:		16 MHz
// Author:			Elisa Du, Hima Panchal
// Date:			Jan 21, 2016

// Details: Part1 - Interfacing RC car.
/********************************************************************/


#include <hidef.h>      		/* common defines and macros 		*/
#include "derivative.h"      	/* derivative-specific definitions 	*/
/********************************************************************/
//		Library includes
/********************************************************************/

//#include "Your_Lib.h"


/********************************************************************/
//		Prototypes
/********************************************************************/
void PAD_Init(void);
void PU_Init(void);
void PADtoPU(void);
//void PWM_Init(void);
//void PWM_Transfer(void);

/********************************************************************/
//		Variables
/********************************************************************/


/********************************************************************/
//		Lookups
/********************************************************************/


void main(void)
{
// main entry point
_DISABLE_COP();

/********************************************************************/
// initializations
/********************************************************************/
PAD_Init();
PU_Init();


	for (;;)
	{
	//main program loop
	PADtoPU();
	}

}



/********************************************************************/
//		Functions
/********************************************************************/


//initialize PAD signal input
void PAD_Init(void) 
{
	//PAD0 - Front
	//PAD1 - Back
	//PAD2 - Right
	//PAD3 - Left
	//PTAD1: no effect on input bits
	DDRADLo &= 0b11110000;   //PAD0-3 as input
  ATDDIEN1 |= 0b00001111;  //enable pins for signal inputs
}

//initialize PWM (PU pins) as regular signal output
void PU_Init(void)
{
	//PU0 - Front
	//PU1 - Back
	//PU2 - Right
	//PU3 - Left
	PTU &= 0b11110000;	//reset output bits
	DDRU |= 0b00001111;   //PU0-3 as output
  PWME &= 0b11110000;  //enable pins for I/O
}

//transmit signal from PAD to PU
void PADtoPU(void)
{
	//Front
	if((PTADLo & 0b00000001) != 0)  
	{
    	PTU |= 0b00000001;	//set F
    	PTU &= 0b11111101;	//clear B      
	}
	//Back
	else if((PTADLo & 0b00000010) != 0)  
	{
    	PTU |= 0b00000010;	//set B
    	PTU &= 0b11111110;	//clear F
	}
	//No moving
	else
	{
		  PTU &= 0b11111100;	//clear F and B		
	}
	
	//Right
  	if((PTADLo & 0b00000100) != 0)  
	{
    	PTU |= 0b00000100;	//set R
    	PTU &= 0b11110111;	//clear L
	}
	//Left
	else if((PTADLo & 0b00001000) != 0)  
	{
    	PTU |= 0b00001000;	//set L
    	PTU &= 0b11111011;	//clear R
	}
	//No turning
	else
	{
	    PTU &= 0b11110011;	//clear L and R
	}
}


//initialize PWM signal output
void PWM_Init(void)
{
	PWMPOL = 0b00111111; //positive polarity, all channels
	PWMCLK |= 0b00110011;  //
	//1kHz = 8000000/(2^2 x 2 x 4 x 250)
	PWMPRCLK &= 0b11111000;//clear PRE-A
	PWMPRCLK |= 0b00000010;//PRE-A = 2^2
	PWMSCLA = 4;         //Scale A = 2 x 4
     
	//Channel 0 - Left
	//Channel 1 - Right
	//Channel 4 - Front
	//Channel 5 - Back
	//duty cycle to control speed 
	PWMPER0 = PWMPER1 = PWMPER2 = PWMPER3 = 250;
  PWMDTY0 = PWMDTY1 = PWMDTY2 = PWMDTY3 = 0;//0% duty cycle - no signal
     
	PWME |= 0b00110011; 
}

//control PWM signal output:provide half speed
void PWM_Transfer(void) 
{
	//Left
	if((PTADLo & 0b00000001) != 0)  
	{
      PWMDTY0 = 125;          //50% duty cycle
	}
	//Right
	else if((PTADLo & 0b00000010) != 0)  
	{
      PWMDTY1 = 125;          //50% duty cycle
	}
	//Front
  	if((PTADLo & 0b00000100) != 0)  
	{
      PWMDTY4 = 125;          //50% duty cycle
	}
	//Back
	else if((PTADLo & 0b00001000) != 0)  
	{
      PWMDTY5 = 125;          //50% duty cycle
	}
}


/********************************************************************/
//		Interrupt Service Routines
/********************************************************************/

