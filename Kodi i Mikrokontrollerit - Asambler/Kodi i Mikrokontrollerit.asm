
;============================================================================================================================;
;				  	----------------   F I E K   S C A D A   2 0 1 6    ----------------	             ;
;============================================================================================================================;

			         ; P0.0 ... P0.7   ; 7 - SEGMENTAT
				 ; P1.0 ... P1.3   ; KONTROLLA E 7 - SEGMENTAT
;STOP_PC_PINI         			BIT P1.4   ; Pini qe vepron ne shtypjen e pullave STOP nga PC-ja
SERVO_VENTILLI_SINJALI      		BIT P1.5   ; DQ e servos
WATER_LEVEL_TRIGGER_PULSE   		BIT P1.6   ; Porta nga e cila shkon impusi per shkrepje te HSCR04
NUMRO_LART_PIN 		    		BIT P1.7   ; Porta per tastin qe japim vlerat per temp dhe nivel
WATER_LEVEL_ON_OFF          		BIT P2.0   ; Porta per sinjlizim te arritjes se nivelit te ujit
TEMP_REACHED_ON_OFF 	    		BIT P2.1   ; Porta per sinjlizim te arritjes se temp
STATUSI_START_STOP_PLC	    		BIT P2.2   ; Porta per sinjalizim qe perdoruesi ka shtypur START/STOP nga buttonat fizik (nga dalja Q4 e PLC)
NDRYSHO_GJENDJEN_MONITORIMI_KONTROLLA   BIT P2.3   ; Me kete pine e vendose gjendjen e programit ne PC Monitorim apo Kontrolle		    (prek)
GJENDJA_MONITORIMI_KONTROLLA		BIT P2.4   ; Shfaq ne pinin P2.4 gjendjen e Monitorimit (SET P2.4 = Monitorim dhe Kontrolle, CLR P2.4 Vetem 							   ; Monitorim)										    (shih)
SHFAQ_NIVEL 		    		BIT P2.5   ; Shfaqe nivelin ne display nese shtypet tasti 2.5
SHFAQ_TEMP 		        	BIT P2.6   ; Shfaqe temp ne display nese shtypet tasti 2.6
AUTOMATIK_TREGIM                	BIT P2.7   ; Kalo ne tregim te vlerave ne menyre automatike ashtu siq parashihet
					  ; P3.0   ; RX
					  ; P3.1   ; TX
					  ; P3.2   ; INT0, Porta ky kyqet 'ECHO' i HSCR04
THERM 			        	BIT P3.3   ; Porta e Bus Masterit, porta ku kyqet DQ i DS18B20, poashtu Trego qe vlera eshte gabim, po ashtu 		 					   ; perdoret edhe si : Indiko qe je duke e marre vleren ne 7-segmetesh me ndezjen e led 3.7
KONFIRMO_VLEREN_PINI			BIT P3.4   ; Pini qe trego qe vlera e dhene eshte e sakte, po ashtu NDRYSHO_GJENDJEN_PINI_EMERGJENT (prek)
STOP_PC_PINI				BIT P3.5   ; Pini qe vepron ne shtypjen e pullave STOP dhe EMERGJENT BUTTON nga PC-ja	            (shih)
RIJEP_VLERAT_PINI 			BIT P3.6   ; Pini per ridhenien e vlerave (SET_POINTEVE)
START_PC_PINI 		        	BIT P3.7   ; Pini qe vepron ne shtypjen e pullave START nga PC-ja


VLERA_NIVELI_PLOTE_SET_POINT	EQU 20H	 	; Lexohet nga PC
VLERA_NIVELI_PRESJE_SET_POINT	EQU 21H	 	; Lexohet nga PC
VLERA_TEMP_PLOTE_SET_POINT   	EQU 22H		; Lexohet nga PC
VLERA_TEMP_PRESJE_SET_POINT   	EQU 23H		; Lexohet nga PC
VLERA_DISTANCA_MAX_SET_POINT	EQU 24H		; Lexohet nga PC
KOHA_1Sec		        EQU 25H
KOHA_250Sec		        EQU 26H		; Lexohet nga PC
KOHA_150uSec		        EQU 27H		; Lexohet nga PC
VARIABEL_MONITORIMI_KONTROLLA   EQU 2BH	    ; Kjo regjister perdoret tek rutina MONITORIMI_KONTROLLA_RUTINE
VARIABEL_GJENDJA_EMERGJENT	EQU 2CH	    ; Kjo regjister perdoret tek rutina SHENDRRIMI_EMERGJENT_RUTINA

VLERA_TEMP_REG_0_NGA_PC		EQU 30H		; Shkruhet nga PC
				;   31H   	; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra 
VLERA_TEMP_REG_1_NGA_PC		EQU 32H		; Shkruhet nga PC
				;   33H   	; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra
VLERA_TEMP_REG_2_NGA_PC		EQU 34H		; Shkruhet nga PC
				;   35H   	; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra	
VLERA_TEMP_REG_3_NGA_PC		EQU 36H		; Shkruhet nga PC
				;   37H   	; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra
				
VLERA_NIVELI_REG_0_NGA_PC	EQU 38H		; Shkruhet nga PC
				;   39H		; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra
VLERA_NIVELI_REG_1_NGA_PC	EQU 3AH		; Shkruhet nga PC
				;   3BH		; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra
VLERA_NIVELI_REG_2_NGA_PC	EQU 3CH		; Shkruhet nga PC
				;   3DH		; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra

VLERA_DMAX_REG_0_NGA_PC		EQU 3EH		; Shkruhet nga PC
				;   3FH		; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra
VLERA_DMAX_REG_1_NGA_PC		EQU 40H		; Shkruhet nga PC
				;   41H		; Shkruhet 0 nga PC pasi aty WriteToRegister shkruan ne 2 regjistra

VLERA_TEMP_REG_0		EQU 42H	; 56H	; Lexohet nga PC	
VLERA_TEMP_REG_1		EQU 43H	; 57H	; Lexohet nga PC
VLERA_TEMP_REG_2		EQU 44H	; 58H	; Lexohet nga PC
VLERA_TEMP_REG_3		EQU 45H	; 59H	; Lexohet nga PC
VLERA_TEMP_DISPLAY_0		EQU 46H	; 61H	
VLERA_TEMP_DISPLAY_1		EQU 47H	; 62H	
VLERA_TEMP_DISPLAY_2		EQU 48H	; 63H	
VLERA_TEMP_DISPLAY_3		EQU 49H	; 64H	
VLERA_TEMP_SENSOR_TEST_0	EQU 4AH	; 74H	
VLERA_TEMP_SENSOR_TEST_1	EQU 4BH	; 75H	
VLERA_TEMP_RUAJ			EQU 4CH ; 55H	
	
VLERA_NIVELI_REG_0		EQU 4DH	; 29H	; Lexohet nga PC
VLERA_NIVELI_REG_1		EQU 4EH	; 30H	; Lexohet nga PC
VLERA_NIVELI_REG_2		EQU 4FH	; 31H	; Lexohet nga PC
VLERA_NIVELI_DISPLAY_0		EQU 50H	; 65H	
VLERA_NIVELI_DISPLAY_1		EQU 51H	; 66H	
VLERA_NIVELI_DISPLAY_2		EQU 52H	; 72H	
VLERA_NIVELI_SENSOR_TEST_0	EQU 53H	; 53H	
VLERA_NIVELI_SENSOR_TEST_1	EQU 54H	; 54H	

VLERA_DMAX_REG_0		EQU 55H	; 69H	; Perkunder Nivelit dhe Temperatures VLERA_DMAX_REG_0, nuk ka nevoje te lexohet nga PC
VLERA_DMAX_DISPLAY_0		EQU 56H	; 67H	
VLERA_DMAX_DISPLAY_1		EQU 57H	; 68H
VLERA_DMAX_SENSOR_TEST_0	EQU 58H	; 70H	
VLERA_DMAX_SENSOR_TEST_1	EQU 59H	; 71H	
	
KOHA_KONTROLLA_SERVO_0		EQU 5AH ; 36H	
KOHA_KONTROLLA_SERVO_1		EQU 5BH ; 37H	
KOHA_KONTROLLA_SERVO_2		EQU 5CH ; 38H	
KOHA_KONTROLLA_SERVO_3		EQU 5DH ; 39H	

KOHA_TCONV			EQU 5EH ; 23H	
KOHA_DELAY_250_MSEC		EQU 5FH ; 73H	

VARIABLA_NIVELI_SENS_0		EQU 60H	; Sa shpesh merren vlerat e reja te Nivelit		
VARIABLA_TEMP_SENS_0		EQU 61H ; Sa shpesh merren vlerat e reja te Temperatures	

VARIABLA_SERVO_VENTILI_1	EQU 62H	; 77H	
VARIABLA_SERVO_VENTILI_2	EQU 63H	; 78H	

		
VLERA_E_DALJES_Q4_PLC	        BIT 48H     ; Vlera e P2.2 qe ndikon direkt dalja Q4 e PLC-se, perdoret per percaktimin e gjendjes START/STOP (PC,uC)
VLERA_E_PINIT_NIVELI	        BIT 49H     ; Vlera e P2.0 (WATER_LEVEL_ON_OFF), perdoret per percaktimin e gjendjes se Pompes dhe Nxemjes (PC)
VLERA_E_PINIT_TEMPERATURA	BIT 4AH     ; Vlera e P2.1 (TEMP_REACHED_ON_OFF), perdoret vetem me sinjalizue qe u arrit edhe temp (jo e domosdoshme) 
MONITORIMI_KONTROLLA_BIT        BIT 4BH     ; E percakton se programi ne PC a mundet vetem te Monitoroj apo edhe te Kontrolloj sistemin (PC)
VARIABLA_KONTROLLA_GRAPH_PC	BIT 4CH     ; Perdoret te PC me dite a me fillue me qit vlerat ne Grafe a jo (Perdoret vetem nje here) "Lexohet nga PC"
PINI_EMERGJENT_BIT		BIT 4DH	    ; Vlera e Pinit 'PINI_EMERGJENT', Qite sistemin ne gjendje te sigurt
VARIABLA_RIJEP_VLERAT_NGA_PC    BIT 4EH     ; Kjo perdoret per me dite a me i ndryshue vlerat nga PC apo jo	   "LEXOHET DHE SHKRUHET NGA PC"
VLERA_E_PINIT_START_PC		BIT 4FH	    ; Vlera e P3.7 START_PC_PINI ULN DALJA FIZIKE E NDIUAR NGA PC DHE PLC, "LEXOHET DHE SHKRUHET NGA PC"
VLERA_E_PINIT_STOP_PC		BIT 50H	    ; Vlera e P1.4 STOP_PC_PINI ULN DALJA FIZIKE E NDIUAR NGA PC DHE PLC,  "LEXOHET DHE SHKRUHET NGA PC"
VARIABLA_E_LIRE_1 	        BIT 51H	    ; Kjo varibel perdoret tek rutina LEXOTEMP
VARIABLA_E_LIRE_2 	        BIT 52H	    ; Kjo varibel perdoret tek rutina LEXOTEMP
VARIABLA_E_LIRE_3 	        BIT 53H	    ; Kjo varibel perdoret tek rutina LEXOTEMP, subrutinat SUB1/SUB2
VARIABEL_TE_KOHA1 		BIT 54H	    ; Kjo varibel perdoret tek rutina GJENERIMI_I_KOHES_RUTINA
VARIABLA_RIJEP_VLERAT 		BIT 55H	    ; Perdoret per ridhenien e vlerave te nivelit dhe temperatures
VARIABLA_CARRY			BIT 56H	    ; Perdoret te rutinat per temperature
VARIABLA_KONTROLLO_DISPLAY	BIT 57H	    ; Kjo perdoret per menaxhimin se qfare shfaqet ne display (Roli i P3.5 me heret)
VARIABLA_TEMP_BIT		BIT 58H     ; Kjo perdoret per me kontrollue a eshte arrit kushti me bere matjen e re te Temperatures
NDIHME_EMERGJEBT_BIT     	BIT 59H     ; Kjo perdoret te rutina 'KONTROLLA_PREJ_PLLAKE_MODI_EMERGJENT' qe me ndimue kontrollen stopit kur te hyme 						    ; ne gjendje emergjente




;---------------------------------------------- Modbus deklarimi ---------------------------------------

GjendjaDergimit		EQU	6BH 	; 4FH
GjendjaModbus		EQU	6CH     ; 50H
CounterModbus		EQU	6EH 	; 51H

;A4: MODBUS Slave for 8051
StartAddress	EQU	70H	;60h
ShareMemory	EQU	20H
CRC_ACCUM_LOW	EQU  	0DH 		;bank 1 regjistri R5
CRC_ACCUM_HI	EQU  	0EH 		;bank 1 regjistri R6
CRC_MASK_LSB	EQU  	001H 		;CRC-16 polinomi
CRC_MASK_MSB	EQU  	0A0H
COIL_ADDR  	EQU  	20H
INP_ADDR  	EQU  	20H
HREG_ADDR  	EQU  	20H	
IREG_ADDR  	EQU  	20H	
HREGNUM  	EQU  	40H		;Sa registra mundesh me ju qase (nga applikacioni ne c#) duke filluar prej regjistrit 20H dmth 30H=48 registra 
IREGNUM  	EQU  	40H		;mbi 20H mundemi me ju qase
INPNUM   	EQU  	128
COILNUM  	EQU  	128 		;numri total i coilave

t15   EQU	63817 			;65536-1719 , 11bit/9600*1.5=63817		interupti shkaktohet ne qdo 2578 us = 2.6 ms
t35   EQU 	61526 			;65536-4010 =61526
t20   EQU  	15366 			;63245 diferenca negative t15-t35=2291

 	ORG 0000H
  		LJMP INIT   
  	ORG 03H
  		LJMP EXR0VEC
  	ORG 1BH 		
  		LJMP TMR1VEC 
 	ORG 23H 	
  		LJMP SERVEC 
  	ORG 2BH   	
  		LJMP TMR2VEC
 	ORG 30H
 
INIT:
	CLR START_PC_PINI			; Ndale ne fillim pinin P3.7 (START) pinin 
	CLR STOP_PC_PINI			; Ndale ne fillim pinin P1.4 (STOP) pinin	
	CLR VLERA_E_PINIT_START_PC		; Ndale ne fillim vleren e pinit P3.7 (START) pinin
	CLR VLERA_E_PINIT_STOP_PC		; Ndale ne fillim vleren e pinit P1.4 (STOP) pinin
	

	MOV VLERA_TEMP_REG_0_NGA_PC,#00H
	MOV VLERA_TEMP_REG_1_NGA_PC,#00H
	MOV VLERA_TEMP_REG_2_NGA_PC,#00H
	MOV VLERA_TEMP_REG_3_NGA_PC,#00H
	MOV VLERA_NIVELI_REG_0_NGA_PC,#00H
	MOV VLERA_NIVELI_REG_1_NGA_PC,#00H
	MOV VLERA_NIVELI_REG_2_NGA_PC,#00H
	MOV VLERA_DMAX_REG_0_NGA_PC,#00H
	MOV VLERA_DMAX_REG_1_NGA_PC,#00H
		
	
	MOV VARIABLA_SERVO_VENTILI_2,#0			; Variabel te servo / ventilli
	CLR SERVO_VENTILLI_SINJALI
	CLR WATER_LEVEL_ON_OFF		; Sinjalizo 0 logjike per nivel
	CLR TEMP_REACHED_ON_OFF		; Sinjalizo 0 logjike per temp
	
	SETB RIJEP_VLERAT_PINI
	CLR VARIABLA_RIJEP_VLERAT
	CLR VARIABLA_RIJEP_VLERAT_NGA_PC
	CLR VARIABLA_KONTROLLA_GRAPH_PC	
	SETB NDIHME_EMERGJEBT_BIT		; Perdoret te rutina 'KONTROLLA_PREJ_PLLAKE_MODI_EMERGJENT'
	
	SETB VARIABLA_E_LIRE_1
	SETB VARIABLA_E_LIRE_2
	SETB VARIABLA_E_LIRE_3
	
	MOV VLERA_DMAX_DISPLAY_0,#00H
	MOV VLERA_DMAX_DISPLAY_1,#00H

	CLR VARIABEL_TE_KOHA1		; Duhet ne zvoglue koha eshte me e madhe se 1sec 	
 	MOV KOHA_150uSec,#150
 	MOV KOHA_1SEC,#250
 	MOV KOHA_250SEC,#250

	MOV VARIABEL_MONITORIMI_KONTROLLA,#0
	MOV VARIABEL_GJENDJA_EMERGJENT,#0
	CLR MONITORIMI_KONTROLLA_BIT	; clr dmth PC eshte ne gjendje Monitorimi dhe Kontroller, setb PC eshte vetum ne gjendje Monitorimi
	CLR PINI_EMERGJENT_BIT		; Nuk ka emergjence kur clr PINI_EMERGJENT_BIT 
	SETB GJENDJA_MONITORIMI_KONTROLLA

	

 	MOV GjendjaModbus , #01H
 	MOV countermodbus , #00H
 	MOV SCON,#50H 			   ; Serial port mode 1, TI=0, RI=0, REN=1
 	MOV t2con,#00h			   ; Timer2 autoreload mode
 					; Verejtje : Timer 2 ne autoreload mode vlerat per reload mund te vendosen qoft ne (RCAP2H dhe RCAP2L) apo ne 							   ; (TH2 dhe TL2). Nese vlerat vendosen ne (RCAP2H dhe RCAP2L)(manualisht)), atehere vlerat merren 							   ; prej (RCAP2H dhe RCAP2L) dhe vendosen ne (TH2 dhe TL2)(automatikisht)). Ose nese vlerat vendosen 							   ; ne (TH2 dhe TL2)(manualisht) thjesht mbesin aty ku edhe duhet te jene
 	MOV rcap2h,#HIGH t35
 	MOV rcap2l , #LOW t35			 	 	
 	SETB TR2
 
 	MOV TMOD,#29H		; Timer 1 = gate off, modi 8 bitesh autoreload | Timer 0 = gate on, modi 16 bitesh 
 	MOV TH1,#255		; BaudRate = 20833				*** SHUME ME RENDESI
	SETB TR1 	

	MOV TH0,#0    		; Clear timer 0 per matje
	MOV TL0,#0   	
	
	SETB IP.4		; Jepi ES prioritet me te madhe se T1		*** SHUME ME RENDESI
	SETB IP.5		; Jepi T2 prioritet me te madhe se T1		*** SHUME ME RENDESI
	 			 	 
 	MOV IE,#10111000b	; Interup Enable : Global, Timer2, Serial, Timer1 , jo External0	
 	MOV SP,#90H 

	;-------------------------------- Inicimi i Variablave -------------------------------------------


MAIN_RIJEP:	
	CLR VARIABLA_TEMP_BIT			
	MOV VARIABLA_NIVELI_SENS_0,#40	
	MOV VARIABLA_TEMP_SENS_0,#90
	CLR VARIABLA_KONTROLLO_DISPLAY
	
	MOV R1,#0
	MOV R0,#0
	MOV VLERA_TEMP_DISPLAY_0,#00H
	MOV VLERA_TEMP_DISPLAY_1,#00H
	MOV VLERA_TEMP_DISPLAY_2,#00H
	MOV VLERA_TEMP_DISPLAY_3,#00H
	MOV VLERA_NIVELI_DISPLAY_0,#00H
	MOV VLERA_NIVELI_DISPLAY_1,#00H	
	MOV VLERA_NIVELI_DISPLAY_2,#00H	
	MOV VLERA_DMAX_DISPLAY_0,#00H
	MOV VLERA_DMAX_DISPLAY_1,#00H

	;//////////////////////////////////////////////////////   MERR VLERAT E SENSOREVE PERMES TASTEVE   ////////////////////////////////////////////
	
	;----------------------------------------------------------------------------------------------------
	
	SJMP B2
B1:	
	MOV VLERA_TEMP_DISPLAY_0,#00H
	MOV VLERA_TEMP_DISPLAY_1,#00H
	MOV VLERA_TEMP_DISPLAY_2,#00H
	MOV VLERA_TEMP_DISPLAY_3,#00H
B2:	
	
	LCALL MERRE_VLEREN_E_TEMP_PERMES_ROUTINE
	JB VARIABLA_KONTROLLO_DISPLAY,IKI_DHENIES_VLERAVE	
A1:	JB P3.4,A2			; Mbaje ne ekran vleren e temp, konfirmoje "vlera eshte e sakte" me shtypje e p3.4
	SJMP A3
A2:	JB P3.3,A1			; Nese vlera e dhene eshte gabim, rijepe ate, konfirmoje "vlera eshte gabim" me shtypje e p3.3
	SJMP B1
A3:
	
	INC R0
	
	;----------------------------------------------------------------------------------------------------


	;----------------------------------------------------------------------------------------------------
	SJMP B4
B3:	
	MOV VLERA_NIVELI_DISPLAY_0,#00H
	MOV VLERA_NIVELI_DISPLAY_1,#00H
	MOV VLERA_NIVELI_DISPLAY_2,#00H
B4:	
	
	LCALL MERRE_VLEREN_E_NIVELIT_PERMES_ROUTINE
A4:	JB P3.4,A5			; Mbaje ne ekran vleren e nivelit, konfirmoje "vlera eshte e sakte" me shtypje e p3.4
	SJMP A6
A5:	JB P3.3,A4			; Nese vlera e dhene eshte gabim, rijepe ate, konfirmoje "vlera eshte gabim" me shtypje e p3.3
	SJMP B3
A6:

	INC R0
	
	;----------------------------------------------------------------------------------------------------

	;----------------------------------------------------------------------------------------------------
	JB VARIABLA_RIJEP_VLERAT,A9
	
	SJMP B6
B5:	
	MOV VLERA_DMAX_DISPLAY_0,#00H
	MOV VLERA_DMAX_DISPLAY_1,#00H
B6:	
	
	LCALL MERRE_VLERENE_E_DISTANCES_MAX_PERMES_ROUTINE
A7:	JB P3.4,A8			; Mbaje ne ekran vleren e nivelit, konfirmoje "vlera eshte e sakte" me shtypje e p3.4
	SJMP A9
A8:	JB P3.3,A7			; Nese vlera e dhene eshte gabim, rijepe ate, konfirmoje "vlera eshte gabim" me shtypje e p3.3
	SJMP B5
A9:

	
	
	;----------------------------------------------------------------------------------------------------	
	 
 	
 ;/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	DEC VLERA_TEMP_DISPLAY_0 			; Zvogloje vleren ne regjister pasi qe eshte nje me shume pasi vlera ne fillim u perdor per "-" jo direkt 0, per "0" ne fillim (VLERA_TEMP_DISPLAY_0)=1 e kshtu me radhe
	DEC VLERA_TEMP_DISPLAY_1 			; Zvogloje vleren ne regjister pasi qe eshte nje me shume pasi vlera ne fillim u perdor per "-" jo direkt 0, per "0" ne fillim (VLERA_TEMP_DISPLAY_1)=1 e kshtu me radhe
	DEC VLERA_TEMP_DISPLAY_2 			; Zvogloje vleren ne regjister pasi qe eshte nje me shume pasi vlera ne fillim u perdor per "-" jo direkt 0, per "0" ne fillim (VLERA_TEMP_DISPLAY_2)=1 e kshtu me radhe
	DEC VLERA_TEMP_DISPLAY_3 			; Zvogloje vleren ne regjister pasi qe eshte nje me shume pasi vlera ne fillim u perdor per "-" jo direkt 0, per "0" ne fillim (VLERA_TEMP_DISPLAY_3)=1 e kshtu me radhe
	DEC VLERA_NIVELI_DISPLAY_0 			; Zvogloje vleren ne regjister pasi qe eshte nje me shume pasi vlera ne fillim u perdor per "-" jo direkt 0, per "0" ne fillim (VLERA_NIVELI_DISPLAY_0)=1 e kshtu me radhe
	DEC VLERA_NIVELI_DISPLAY_1 			; Zvogloje vleren ne regjister pasi qe eshte nje me shume pasi vlera ne fillim u perdor per "-" jo direkt 0, per "0" ne fillim (VLERA_NIVELI_DISPLAY_1)=1 e kshtu me radhe
	DEC VLERA_DMAX_DISPLAY_0 			; Zvogloje vleren ne regjister pasi qe eshte nje me shume pasi vlera ne fillim u perdor per "-" jo direkt 0, per "0" ne fillim (VLERA_DMAX_DISPLAY_0)=1 e kshtu me radhe
	DEC VLERA_DMAX_DISPLAY_1 			; Zvogloje vleren ne regjister pasi qe eshte nje me shume pasi vlera ne fillim u perdor per "-" jo direkt 0, per "0" ne fillim (VLERA_DMAX_DISPLAY_1)=1 e kshtu me radhe
	DEC VLERA_NIVELI_DISPLAY_2
	;/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



	;(VLERA_TEMP_DISPLAY_0)=5
	;(VLERA_TEMP_DISPLAY_1)=0
	;(VLERA_TEMP_DISPLAY_2)=2
	;(VLERA_TEMP_DISPLAY_3)=1
		; 120.5 C
	;(VLERA_NIVELI_DISPLAY_0)=0
	;(VLERA_NIVELI_DISPLAY_1)=2
	;(VLERA_NIVELI_DISPLAY_2)=7
		; 20.7 cm

	LCALL SHENDRRIMI_I_TEMP_P_S 		; SHENDRRIMI I NIVELIT NE FORMEN QE E KUPTON SENSORI I TEMP DS18B20
	JB VARIABLA_RIJEP_VLERAT,IKI_KETU
	LCALL SHENDRRIMI_I_DISTANCES_MAX_P_S	; SHENDRRIMI I DISTANCES MAX NE FORMEN QE E KUPTON SENSORI I NIVELIT HCSR04
IKI_KETU:
	LCALL SHENDRRIMI_I_NIVELIT_P_S 	; SHENDRRIMI I NIVELIT NE FORMEN QE E KUPTON SENSORI I NIVELIT HCSR04

IKI_DHENIES_VLERAVE:
	
	SETB VARIABLA_KONTROLLO_DISPLAY		; Perfundoi tregimi i vlerave te marrura, kalo te tregimi i vlereave te matura
	
	SETB IT0
	SETB TR0
 	SETB EX0  
 		
 	CLR VLERA_E_PINIT_START_PC		; Ne fillim e bejme clr kete, kjo pastaj e ben clr START_PC_PINI (Pini P3.7) qe te jete ne gjendje off 
 	CLR VLERA_E_PINIT_STOP_PC		; Ne fillim e bejme clr kete, kjo pastaj e ben clr STOP_PC_PINI (Pini P1.4) qe te jete ne gjendje off
	CLR VARIABLA_RIJEP_VLERAT
	SETB VARIABLA_KONTROLLA_GRAPH_PC	; Trego ne PC qe mund te shfaqish vlerat ne Grafe
	;CLR PINI_EMERGJENT			; Leje ne jo emergjent mode ne fillim
	;//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Programi_main:

	
	JB RIJEP_VLERAT_PINI,IKI_MAIN		; Per te ndryshuar vlerat shtype P3.6
	SETB VARIABLA_RIJEP_VLERAT
	CLR VARIABLA_KONTROLLO_DISPLAY
	
	LJMP MAIN_RIJEP
IKI_MAIN:
	JB PINI_EMERGJENT_BIT,IKITEMP		; Nese setb jemi ne emergjent mode
	JNB VARIABLA_TEMP_BIT,IKITEMP	
	
	CLR EA
	LCALL T_RESET	; Reseto Busin qe te filloj indentifikimi i DS18B20-shit
	MOV A,#0CCH	; Skip ROM
	LCALL DERGO_COM	; Dergo komanden per Skip ROM te DS18B20-shi

	MOV A,#44H  	; Komanda Convert T, Fillo konvertimin e temperatures ne vlere digjitale
	LCALL DERGO_COM	; Dergo komanden per Cnvert T te DS18B20-shi

	LCALL T_RESET	; Reseto Busin qe te filloj indentifikimi i DS18B20-shit
	MOV A,#0CCH	; Skip ROM
	LCALL DERGO_COM	; Dergo komanden per Skip ROM te DS18B20-shi 

	MOV A,#0BEH	; Komanda Read Scratchpad, Inicio leximin e temp nga DS18B20
	LCALL DERGO_COM	; Dergo komanden per Read Scratchpad te DS18B20-shi 	
	
	LCALL LEXOTEMP	; Lexoje temp	
	LCALL SHENDRRIMI_I_TEMP_S_P	; Shendrro vleren e temp prej sensorit ne forme te pershtatshme per lexuesin
	
	SETB EA
	SETB TF1
	SETB TF2	
IKITEMP:	
	
	SJMP Programi_main		

	; --------------------------------------------


	;*****************************************************************************************************************************************************	;*****************************************************************************************************************************************************	;*****************************************************************************************************************************************************
;					------------------------------------	RUTINAT   ------------------------------------   

RIJEP_VLERAT_NGA_PC_RUTINA:

	JNB VARIABLA_RIJEP_VLERAT_NGA_PC,RVNPR1
	LCALL SHENDRRIMI_I_TEMP_P_S_NGA_PC
	LCALL SHENDRRIMI_I_NIVELIT_P_S_NGA_PC
	LCALL SHENDRRIMI_I_DISTANCES_MAX_P_S_NGA_PC
	SETB VARIABLA_KONTROLLO_DISPLAY			; Trego qe jane dhene vlera nga PC dhe ska nevoje te ipen nga uC
RVNPR1:
	CLR VARIABLA_RIJEP_VLERAT_NGA_PC

	RET

KONTROLLA_PREJ_PLLAKE_MODI_EMERGJENT:			; Pushon
						
	JNB PINI_EMERGJENT_BIT,EMERGJENT_LABEL1
	CLR NDIHME_EMERGJEBT_BIT
	SETB STOP_PC_PINI
	SJMP EMERGJENT_LABEL2
EMERGJENT_LABEL1:
	JB NDIHME_EMERGJEBT_BIT,EMERGJENT_LABEL2
	CLR STOP_PC_PINI     
	SETB NDIHME_EMERGJEBT_BIT
EMERGJENT_LABEL2:

	RET
		
SHENDRRIMI_PINI_BIT_TO_P3_5:				; Ku P3.5 = PINI_EMERGJENT, CLR PINI_EMERGJENT_BIT eshte modi joemergjent
							; Pushon
	JB PINI_EMERGJENT_BIT,SPBTP1
	;CLR PINI_EMERGJENT
	SJMP SPBTP2 
SPBTP1:
	;SETB PINI_EMERGJENT
SPBTP2:

	RET	

SHENDRRIMI_EMERGJENT_RUTINA:

	PUSH ACC
	
	JB KONFIRMO_VLEREN_PINI,Aam1			; KONFIRMO_VLEREN_PINI = P3.4 (prek)
	INC VARIABEL_GJENDJA_EMERGJENT
	
	MOV A,#250;
	CJNE A,VARIABEL_GJENDJA_EMERGJENT,Bbm1
	MOV VARIABEL_GJENDJA_EMERGJENT,#2
Bbm1:
	SJMP Aam2
Aam1:
	MOV VARIABEL_GJENDJA_EMERGJENT,#00H
Aam2:
	MOV A,#01H	
	CJNE A,VARIABEL_GJENDJA_EMERGJENT,Aam3
	CPL PINI_EMERGJENT_BIT				
Aam3:
	POP ACC

	RET 	

SHENDRRIMI_START_PC_PINI_RUTINA:			; Vlerat ketu lexohen dhe shkruhet nga PC

	JB VLERA_E_PINIT_START_PC,SSaPPR1		
	CLR START_PC_PINI
	SJMP SSaPPR2
SSaPPR1:
	SETB START_PC_PINI				; setb = P3.4 ON	
SSaPPR2:

	RET

SHENDRRIMI_STOP_PC_PINI_RUTINA:			; Vlerat ketu lexohen dhe shkruhet nga PC

	JB VLERA_E_PINIT_STOP_PC,SSoPPR1	
	CLR STOP_PC_PINI
	SJMP SSoPPR2
SSoPPR1:
	SETB STOP_PC_PINI				; setb = P1.4 ON	
SSoPPR2:

	RET	

SHENDRRIMI_TEMPERATURA_RUTINA:				; Vlerat ketu lexohen nga PC

	JB TEMP_REACHED_ON_OFF,STR1		; Nese pini shenderroje ne BIT
	CLR VLERA_E_PINIT_TEMPERATURA
	SJMP SNR2
STR1:
	SETB VLERA_E_PINIT_TEMPERATURA 
STR2:

	RET

SHENDRRIMI_NIVELI_RUTINA:				; Vlerat ketu lexohen nga PC

	JB WATER_LEVEL_ON_OFF,SNR1		; Nese pini shenderroje ne BIT
	CLR VLERA_E_PINIT_NIVELI
	SJMP SNR2
SNR1:
	SETB VLERA_E_PINIT_NIVELI	
SNR2:

	RET


SHENDRRIMI_Q4_RUTINA:					; Vlerat ketu lexohen nga PC

	JB STATUSI_START_STOP_PLC,SQR1		; Nese pini shenderroje ne BIT
	CLR VLERA_E_DALJES_Q4_PLC		; VLERA_E_DALJES_Q4_PLC
	SJMP SQR2
SQR1:
	SETB VLERA_E_DALJES_Q4_PLC
SQR2:

	RET
	

	; --------------------------------------------

	; --------------------------------------------
		
MONITORIMI_KONTROLLA_RUTINA:	
	
	PUSH ACC
	
	JB NDRYSHO_GJENDJEN_MONITORIMI_KONTROLLA,Am1
	INC VARIABEL_MONITORIMI_KONTROLLA
	
	MOV A,#250;
	CJNE A,VARIABEL_MONITORIMI_KONTROLLA,Bm1
	MOV VARIABEL_MONITORIMI_KONTROLLA,#2
Bm1:
	SJMP Am2
Am1:
	MOV VARIABEL_MONITORIMI_KONTROLLA,#00H
Am2:
	MOV A,#01H	
	CJNE A,VARIABEL_MONITORIMI_KONTROLLA,Am3
	CPL MONITORIMI_KONTROLLA_BIT
	CPL GJENDJA_MONITORIMI_KONTROLLA	
Am3:
	POP ACC

	RET
	; --------------------------------------------

	; --------------------------------------------
GJENERIMI_I_KOHES_RUTINA:
	
	JB VARIABEL_TE_KOHA1,KCE2	; Ne fillim eshte CLR, nese kryhet njehere koha le te mbete ne vleren e funit
	
	DJNZ KOHA_150uSec,KCE2
	MOV KOHA_150uSec,#150			
	DJNZ KOHA_1Sec,KCE2	
	MOV KOHA_1Sec,#250
	DJNZ KOHA_250Sec,KCE2
		
	SETB VARIABEL_TE_KOHA1

KCE2:	

	RET
	; --------------------------------------------

	;------------------------------ SERVO/VENTILLI KONTROLLA RUTINAT ------------------------------
		
		
VENTILLI_HAPET:	
	SETB SERVO_VENTILLI_SINJALI
	LCALL DIRECTION_1_5MS			; Rrotullohet servo CW (hapet ventilli)
	;CLR GJENDJA_E_VENTILLIT				; Indiko qe ventilli eshte hapur me ndezjen e led GJENDJA_E_VENTILLIT
	CLR SERVO_VENTILLI_SINJALI
	
	
	RET
VENTILLI_MBYLLET:
	SETB SERVO_VENTILLI_SINJALI
	LCALL DIRECTION_2MS			; Rrotullohet servo CCW (mbyllet ventilli)
	;SETB GJENDJA_E_VENTILLIT				; Indiko qe ventilli eshte mbyllur me fikjen e led GJENDJA_E_VENTILLIT
	CLR SERVO_VENTILLI_SINJALI


	RET	
	
DIRECTION_2MS: 		
		
	;------------------------------------------------------------------------------------------


	MOV KOHA_KONTROLLA_SERVO_3,#20
	MOV KOHA_KONTROLLA_SERVO_2,#250
	MOV KOHA_KONTROLLA_SERVO_1,#250
	MOV KOHA_KONTROLLA_SERVO_0,#250
	
L1:	DJNZ KOHA_KONTROLLA_SERVO_3,L1
L2:	DJNZ KOHA_KONTROLLA_SERVO_2,L2	; 2C=250uS
L3:	DJNZ KOHA_KONTROLLA_SERVO_1,L3	; 2C=250uS
L4:	DJNZ KOHA_KONTROLLA_SERVO_0,L4	; 2C=250uS

	

	;------------------------------------------------------------------------------------------
	

	RET

DIRECTION_1_5MS:	
		
	;------------------------------------------------------------------------------------------


	mov KOHA_KONTROLLA_SERVO_1,#250
	mov KOHA_KONTROLLA_SERVO_0,#250

L32:	DJNZ KOHA_KONTROLLA_SERVO_1,L32	; 2C=250uS
L42:	DJNZ KOHA_KONTROLLA_SERVO_0,L42	; 2C=250uS
	
	
	
	;------------------------------------------------------------------------------------------
	

	RET		
		
	;--------------------------------------------------------------------------------------
	

	;**************************************************************************************************************************************

TEST_WATER_LEVEL_ROUTINE:
;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
; CLR WATER_LEVEL_ON_OFF = (niveli i ujit eshte 0cm (0 dalje logjike)=> distanca nga sensori d=60cm => kohezgjatja e impulsit t=2280uS=08E8H, marrim nje rezerve prej 2cm pra 58cm=> 2204uS=089CH)
; CHECKPOINT = (niveli i ujit eshte ndermjet 0cm dhe 20cm => distanca nga sensori 60cm>d>40cm => kohezgjatja e impulsit 2280uS=008E8H>t>1520uS=05F0H)
; SETB WATER_LEVEL_ON_OFF = (niveli i ujit eshte 20cm (1 logic output)=> distanca nga sensori d40cm => kohezgjatja e impulsit t=1520uS=05F0H)
;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
;1) R7=08H,R6=9CH => CLR WATER_LEVEL_ON_OFF     /¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯   
;2) R7=08H,R6<9CH => OUT              /   
;3) R7=08H,R6>9CH => CLR WATER_LEVEL_ON_OFF   /    R7=05H,R6=9CH => SETB WATER_LEVEL_ON_OFF 
;    ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ 	   R7=05H,R6<9CH => SETB WATER_LEVEL_ON_OFF		
;4) R7<08H,R6=9CH => TEST		    	   R7=05H,R6>9CH => OUT
;5) R7<08H,R6<9CH => TEST			   
;6) R7<08H,R6>9CH => TEST
;   _________________________________________      05H<R7<08H,R6=9CH => OUT
;7) R7>08H,R6=9CH => CLR WATER_LEVEL_ON_OFF  \     05H<R7<08H,R6<9CH => OUT
;8) R7>08H,R6<9CH => CLR WATER_LEVEL_ON_OFF   \    05H<R7<08H,R6>9CH => OUT
;9) R7>08H,R6>9CH => CLR WATER_LEVEL_ON_OFF    \____________________________________________
;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	; 58 cm = 08C2 H
	; 40 cm = 60 - 20 = 05F0 H  
	;MOV VLERA_DMAX_SENSOR_TEST_1,B = 08H
	;MOV VLERA_DMAX_SENSOR_TEST_0,A = 9CH
	
	
	PUSH ACC
	PUSH B

	MOV A,R7			; Byte i laret (byte_2 i T0) i timer 0 TH0 vendoset ne R7
	CJNE A,VLERA_DMAX_SENSOR_TEST_1,HERE1	
	SJMP HERE2
HERE1:	JC TEST	
		
	SJMP ACTIVATE_PUMP
HERE2:	
	MOV A,R6			; Byte i ulet (byte_1 i T0) i timer 0 TL0 vendoset ne R6
	CJNE A,VLERA_DMAX_SENSOR_TEST_0,HERE3
	
	SJMP ACTIVATE_PUMP

HERE3:	JC TEST3A
	
	SJMP ACTIVATE_PUMP
	
TEST3A:					; Adresa VLERA_NIVELI_SENSOR_TEST_0 permban vleren (VLERA_NIVELI_SENSOR_TEST_0)=05H, A permban R7
	MOV A,R7		
TEST:	CJNE A,VLERA_NIVELI_SENSOR_TEST_1,TEST2A
	MOV A,R6
					; Adresa VLERA_NIVELI_SENSOR_TEST_0 permban vleren (VLERA_NIVELI_SENSOR_TEST_0)=F0H				
	CJNE A,VLERA_NIVELI_SENSOR_TEST_0,HERE4
	SJMP DEACTIVATE_PUMP
	
TEST2A:	JC DEACTIVATE_PUMP
	SJMP OUT
		
HERE4:	JC DEACTIVATE_PUMP 
	SJMP OUT

ACTIVATE_PUMP:
	
	CLR WATER_LEVEL_ON_OFF
	SJMP OUT
	
DEACTIVATE_PUMP:
	SETB WATER_LEVEL_ON_OFF
OUT:
	
	POP B
	POP ACC
	
	
	RET
	
TRIGGER_IMPULSE_ROUTINE:
	CLR WATER_LEVEL_TRIGGER_PULSE
	SETB WATER_LEVEL_TRIGGER_PULSE
	MOV R5,#5      ; 1C
LOOP:	DJNZ R5,LOOP   ; 2C , vonesa totale 11C=16.5 uSec
	CLR WATER_LEVEL_TRIGGER_PULSE
	
	
	RET
	
DELAY_250_MSEC:
	MOV KOHA_DELAY_250_MSEC,#250
L4_250MSEC:	ACALL DELAY_1mS
	DJNZ KOHA_DELAY_250_MSEC,L4_250MSEC
	
	
	RET
	
DELAY_1mS:
	MOV R1,#250
	MOV R2,#250
L1_1mS:	DJNZ R2,L1_1mS
L2_1mS:	DJNZ R1,L2_1mS
	
	
	RET
	
;******************************************************************************************************************************************************
;******************************************************************************************************************************************************
;******************************************************************************************************************************************************
	;************************************************ RUTINAT PER SENSORIN E TEMP ************************************************
	
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////
	;	-------------	PROCEDURA PER RESETIM DHE PREZENCE  ----------------
	
T_RESET:
	MOV A,#4	; Mbush regjistrin
	CLR THERM	; Fillo resetimin 
	MOV B,#160
	DJNZ B,$	; 480 uS pritje (2x160 cikle nga 1.5 =480uS)
	SETB THERM	; 1 Lirohet linja
	MOV B,#6	; 2 Vendoset kohezgjatja
	CLR C		; Fshije flagun qe do te perdoret per prezence
WAIT:
	JB THERM,HERE5	; Dil nga rutina nese linja eshte 1
	DJNZ B,WAIT
	DJNZ ACC,WAIT
	SJMP SHORT
HERE5:
	MOV B,#101	; Vonesa
HERE6:
	ORL C,/THERM 	; Kontrollo pulsin per prezence
	DJNZ B,HERE6
SHORT:


	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////
	;	-------------	DERGIMI I KOMANDAVE   ----------------
	
DERGO_COM:
	PUSH B	; Ruaj regjistrin
	MOV B,#8	; Konfiguroje per 8 bit
LOOP1:
	RRC A 		; Merre bitin ne carry 
	LCALL SHKRUJ_BIT; Shkruje nje bit ne Bus
	DJNZ B,LOOP1	; Merre bitin e ardhshum
	POP B		; Ktheje regjistrin B
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////
	;	-------------	SHKRIMI I NJE BITI NE BUS   ----------------
	
SHKRUJ_BIT:
	CLR THERM 	; Vendose Bus-in ne 0
	MOV KOHA_TCONV,#2	; Thirr vonesen prej 6 uS (2x2 cikle ka 1.5 uS = 6uS)
	LCALL DELAY
	MOV THERM,C	; Vendose vleren e bitit ne bus
	MOV KOHA_TCONV,#20	; Thirr vonesen prej 60 uS (2x20 cikle ka 1.5 uS = 60uS)
	LCALL DELAY
	SETB THERM	; Perfundo shkruarjen
	MOV KOHA_TCONV,#20	; Thirr vonesen prej 60 uS (2x20 cikle ka 1.5 uS = 60uS)
	LCALL DELAY
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////
	;	-------------	PROCEDURA PER VONESE   ----------------


TCONV:
	;PUSH KOHA_DELAY_250_MSEC
	MOV KOHA_DELAY_250_MSEC,#250
L5:	ACALL DELAY_1mS
	ACALL DELAY_1mS
	DJNZ KOHA_DELAY_250_MSEC,L5
	;POP KOHA_DELAY_250_MSEC
	
	RET
		
DELAY:
	DJNZ KOHA_TCONV,DELAY
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;//////////////////////////////   PROCEDURA PER LEXIMIN E TEMP DHE SHTYPJE NE DISPLAY ///////////////////////
	
LEXOTEMP:
	
	LCALL LEXO_BYTE	; Lexo bajtin e pare, merret LSB nga bajti 0 
	MOV VLERA_TEMP_REG_0,A
	
	LCALL LEXO_BYTE	; Lexo bajtin e dyte
	MOV VLERA_TEMP_RUAJ,A
	
	LCALL SUB1	; Testo a oshte byte_2 vlera qe po e lypim
	LCALL SUB2


	JB VARIABLA_E_LIRE_1,SU_PLOTSUE	; Pini P2.2
	JB VARIABLA_E_LIRE_2,SU_PLOTSUE	; Pini P2.3
	SETB TEMP_REACHED_ON_OFF	; Sinjali tregon eshte arritur temp >=25C (LED e fikur por sinjali 1 dergohet ne PLC)
	SJMP U_PLOTSUE
SU_PLOTSUE:
	CLR TEMP_REACHED_ON_OFF 	; Sinjali tregon qe temp<25C (LED e ndezur por sinjali 0 dergohet ne PLC)
U_PLOTSUE:

	
	RET
	;///////////////////////////////////////////////////////////////////////////////////////////////////////////

	;/////////////////////////////////////   LEXIMI I NJE BAJTI NGA BUSI   /////////////////////////////////////
	
LEXO_BYTE:		; Leximi i nje bajti nga busi	
	MOV R0,#8	; Konfiguro per 8 bita
	MOV A,#00H
LABEL:
	LCALL LEXO_BIT	; Merre bitin
	RRC A
	DJNZ R0,LABEL	; Deri te biti i 8
	

	RET
	;///////////////////////////////////////////////////////////////////////////////////////////////////////////

 	;/////////////////////////////////////   LEXIMI I NJE BITI NGA BUSI   /////////////////////////////////////
LEXO_BIT:		
	PUSH ACC
	CLR THERM	; Busi me vlere 0
	NOP 		; Vonese prej 1.5uS
	NOP
	SETB THERM	; Busi me vlere 1
	MOV KOHA_TCONV,#2
	LCALL DELAY 	; Vonese prej 6 uS
	MOV C,THERM	; Lexoje busin
	MOV KOHA_TCONV,#20
	LCALL DELAY	; Vonesa prej 60 uS
	POP ACC


	RET
	;///////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	;/////////////////////////////////////   PROCEDURA PER TESTIMIN E TEMPERATURES   /////////////////////////////////////

	; TESTIMI PER BYTE_2
SUB1:	
	mov VARIABLA_CARRY,C	   ; Ruaj vleren e Carry-it
	MOV A,VLERA_TEMP_RUAJ	   ; Adresa VLERA_TEMP_RUAJ permban P.SH (VLERA_TEMP_RUAJ)=07H , Verejtje vlera 07H eshte marre arbitrare si shembull qe te kuptohet ma leht procedura kjo vlere do te jete mvarsishte si e jep perdoruesi me ane te pllakes
	CJNE A,VLERA_TEMP_SENSOR_TEST_1,TEST1   ; Testo nese A=07H
	CLR VARIABLA_E_LIRE_1 	   ; Po, indiko me ndezjen e LED-it ne 8051
	SETB VARIABLA_E_LIRE_3 
	SJMP FUNDIA
TEST1:			   ; Testo a eshte A<>07H
	JC FUND1	   ; Kce nese C=1, indikim qe A<07H
	CJNE A,#0FH,TEST2B  ; A>07H por a eshte A=0FH            											     					         ***
	CLR VARIABLA_E_LIRE_1	   ; Po A=FFH, indiko me ndezjen e LED-it ne 8051										      						 ***
	CLR VARIABLA_E_LIRE_2	   ; Po ashtu ndeze P2.3 pasi edhe nese BYTE_1 eshte me i vogel se 88H nuk prish pune pasi qe nese BYTE_2 eshte me i madhe se 07H p.sh					 	 ***
	CLR VARIABLA_E_LIRE_3 	   ; nese e kemi BYTE_2=08H dhe BYTE_1=00H, dhe BYTE_2=07H dhe BYTE_1=FFH vlen se 0800H > 07FFH					       						 ***
			   ; pra temp ne rastin e pare eshte 0800H=0000 1000 0000. 0000 =128C (qe e permbush kushtin temp>=120.5C), ndersa ne rastin e dyte temp=07FFH= 0000 0111 1111. 1111=127.9375 C        ***
	SJMP FUNDIA
TEST2B:			   ; Testo nese 07H<=A=<0FH
	JNC FUND1	   ; Kce nese C=0, inkimin qe A>0FH => A=10H,11H,12H,...,1FH,... Vlera negative 
	CLR VARIABLA_E_LIRE_1
	CLR VARIABLA_E_LIRE_2	   
	CLR VARIABLA_E_LIRE_3	   ; ***
	SJMP FUNDIA	   
FUND1:	 
	SETB VARIABLA_E_LIRE_1 
	SETB VARIABLA_E_LIRE_3
FUNDIA:	   
	MOV C,VARIABLA_CARRY	   ; Ktheje vleren e Carry-it
	
	
	RET


	; TESTIMI PER BYTE_1 kjo pjese vlen veten ne rastin kur A=01H
SUB2:	
	MOV VARIABLA_CARRY,C	   ; Ruaj vleren e Carry-it
	JNB VARIABLA_E_LIRE_3, FUNDIB   ; Kce nese P2.3 eshte 0, P.s kjo eshte shkaktuar nga pjesa me ***	   
	MOV A,VLERA_TEMP_REG_0	   ; Adresa VLERA_TEMP_REG_0 permban P.SH (VLERA_TEMP_REG_0)=88H , Verejtje vlera 88H eshte marre arbitrare si shembull qe te kuptohet ma leht procedura kjo vlere do te jete mvarsishte si e jep perdoruesi me ane te pllakes
	CJNE A,VLERA_TEMP_SENSOR_TEST_0,TEST3B  ; Testo nese A=88H
	CLR VARIABLA_E_LIRE_2	   ; Po, indiko me ndezjen e LED-it ne 8051	
	SJMP FUNDIB
TEST3B:			   ; Testo a eshte A<>88H
	JC FUND2
	CLR VARIABLA_E_LIRE_2	   ; A>88H, indiko me ndezjen e LED-it ne 8051
	SJMP FUNDIB	   
FUND2:	 
	SETB VARIABLA_E_LIRE_2  
FUNDIB:	   
	
	MOV C,VARIABLA_CARRY	   ; Ktheje vleren e Carry-it
	
	
	RET
	;///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;**********************************************************************************************************************************************************
	
	
	;//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	; 				---------------------  ZGJEDHJA E TEMP DHE NIVELIT PERMES TASTEVE ---------------------
	
	
	;//////////////////////////////////////////////////////     ZGJEDH VLEREN E TEMP PERMES TASTEVE     //////////////////////////////////////////////////////
MERRE_VLEREN_E_TEMP_PERMES_ROUTINE:
	
	PUSH ACC
	MOV P1,#80H
	MOV A,#0
	MOV R7,#0	
	
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	; --------------
NUMHERE:
	JB VARIABLA_KONTROLLO_DISPLAY,OUTHERE1 ; Tregon qe vlerat veqme jane dhene nga PC (nese setb), ME LCALL kemi bere vetum pasi osht gjate me kcy
	SJMP OUTHERE2	
OUTHERE1:
	LJMP OUT_HERE
OUTHERE2:
	; --------------
	JB NUMRO_LART_PIN,NUMHERE	
	CLR P3.3			; Indiko qe numrimi filloi me dhezjen e led 3.7, Verejtje kjo vlen per te gjitha marrjet/kalimet e vlerave tjera si per temp ashtu edhe per nivel
B1A:	MOV R1,VLERA_TEMP_DISPLAY_0
	CJNE R1,#11,KERCE1A		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_TEMP_DISPLAY_0,#1	
	LCALL DELAY_gjysm_sec
	
KERCE1A:	
	INC VLERA_TEMP_DISPLAY_0	
	
	MOV R1,VLERA_TEMP_DISPLAY_0		
	CJNE R1,#11,KERCE2A		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera	
	MOV VLERA_TEMP_DISPLAY_0,#1
KERCE2A:
	LCALL DELAY_gjysm_sec	
	JNB NUMRO_LART_PIN,B1A	
	SETB P3.3			; Indiko qe mund te kalosh ne segmetin tjeter qe ta marresh vleren me fikjen e led 3.7, Verejtje kjo vlen per te gjitha marrjet/kalimet e vlerave tjera si per temp ashtu edhe per nivel
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	JB NUMRO_LART_PIN,$
	CLR P3.3
B1B:	MOV R1,VLERA_TEMP_DISPLAY_1
	CJNE R1,#11,KERCE1B		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_TEMP_DISPLAY_1,#1	
	LCALL DELAY_gjysm_sec
	
KERCE1B:	
	INC VLERA_TEMP_DISPLAY_1
	
	MOV R1,VLERA_TEMP_DISPLAY_1	
	CJNE R1,#11,KERCE2B		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_TEMP_DISPLAY_1,#1	
KERCE2B:	
	LCALL DELAY_gjysm_sec
	JNB NUMRO_LART_PIN,B1B
	SETB P3.3	
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	JB NUMRO_LART_PIN,$
	CLR P3.3
B1C:	MOV R1,VLERA_TEMP_DISPLAY_2
	CJNE R1,#11,KERCE1C		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_TEMP_DISPLAY_2,#1	
	LCALL DELAY_gjysm_sec
	
KERCE1C:	
	INC VLERA_TEMP_DISPLAY_2
	
	MOV R1,VLERA_TEMP_DISPLAY_2	
	CJNE R1,#11,KERCE2C		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_TEMP_DISPLAY_2,#1	
KERCE2C:	
	LCALL DELAY_gjysm_sec
	JNB NUMRO_LART_PIN,B1C
	SETB P3.3
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	JB NUMRO_LART_PIN,$
	CLR P3.3
B1D:	MOV R1,VLERA_TEMP_DISPLAY_3
	CJNE R1,#11,KERCE1D		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_TEMP_DISPLAY_3,#1	
	LCALL DELAY_gjysm_sec
	
KERCE1D:	
	INC VLERA_TEMP_DISPLAY_3
	
	MOV R1,VLERA_TEMP_DISPLAY_3	
	CJNE R1,#11,KERCE2D		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_TEMP_DISPLAY_3,#1	
KERCE2D:	
	LCALL DELAY_gjysm_sec
	JNB NUMRO_LART_PIN,B1D
	SETB P3.3
	;---------------------------------------------------------------------------------------------------
OUT_HERE:
	POP ACC
	
		
	RET
	
	
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
	;//////////////////////////////////////////////////////     QITE NE DISPLAY VLEREN QE ESHTE RUAJTUR PER TEMP    //////////////////////////////////////////////////////
DISPLAY_VLEREN_E_TEMP_ROUTINE:
	CLR P1.0
	CLR P1.1
	CLR P1.2
	CLR P1.3
	PUSH ACC
	MOV A,VLERA_TEMP_DISPLAY_0		; Vlera e vertet e "xxx.a" eshte ne lokacionin memorik (VLERA_TEMP_DISPLAY_0)
	INC A
	SETB P1.0
	LCALL SUBROUTINE1
	MOV P0,A
	LCALL DELAY_mili_sec

	CLR P1.0
	
	MOV A,VLERA_TEMP_DISPLAY_1		; Vlera e vertet e "xxa.x" eshte ne lokacionin memorik (VLERA_TEMP_DISPLAY_1)
	INC A
	SETB P1.1
	LCALL SUBROUTINE2	
	MOV P0,A
	LCALL DELAY_mili_sec
	CLR P1.1
	
	MOV A,VLERA_TEMP_DISPLAY_2		; Vlera e vertet e "xax.x" eshte ne lokacionin memorik (VLERA_TEMP_DISPLAY_2)
	INC A
	SETB P1.2
	LCALL SUBROUTINE1
	MOV P0,A
	LCALL DELAY_mili_sec
	CLR P1.2
	
	MOV A,VLERA_TEMP_DISPLAY_3		; Vlera e vertet e "axx.x" eshte ne lokacionin memorik (VLERA_TEMP_DISPLAY_3)
	INC A
	SETB P1.3
	LCALL SUBROUTINE1
	MOV P0,A
	LCALL DELAY_mili_sec
	CLR P1.3
	POP ACC
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;/////////////////////////////////////////////////////////////////   ZGJEDH VLEREN E NIVELIT PERMES TASTEVE   //////////////////////////////////////////////////////////////
MERRE_VLEREN_E_NIVELIT_PERMES_ROUTINE:
	
	PUSH ACC
	MOV P1,#80H
	MOV A,#0
	MOV R7,#0	
	
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	JB NUMRO_LART_PIN,$
	CLR P3.3			; P3.3 = P3.7
B10_E:	MOV R1,VLERA_NIVELI_DISPLAY_2
	CJNE R1,#11,KERCE10_E		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_NIVELI_DISPLAY_2,#1	
	LCALL DELAY_gjysm_sec
	
KERCE10_E:	
	INC VLERA_NIVELI_DISPLAY_2
	
	MOV R1,VLERA_NIVELI_DISPLAY_2	
	CJNE R1,#11,KERCE20_E		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_NIVELI_DISPLAY_2,#1	
KERCE20_E:	
	LCALL DELAY_gjysm_sec
	JNB NUMRO_LART_PIN,B10_E
	SETB P3.3
	;---------------------------------------------------------------------------------------------------
	
	
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	JB NUMRO_LART_PIN,$
	CLR P3.3			; P3.3 = P3.3
B1E:	MOV R1,VLERA_NIVELI_DISPLAY_0
	CJNE R1,#11,KERCE1E		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_NIVELI_DISPLAY_0,#1	
	LCALL DELAY_gjysm_sec
	
KERCE1E:	
	INC VLERA_NIVELI_DISPLAY_0
	
	MOV R1,VLERA_NIVELI_DISPLAY_0	
	CJNE R1,#11,KERCE2E		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_NIVELI_DISPLAY_0,#1	
KERCE2E:	
	LCALL DELAY_gjysm_sec
	JNB NUMRO_LART_PIN,B1E
	SETB P3.3
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	JB NUMRO_LART_PIN,$
	CLR P3.3
B1F:	MOV R1,VLERA_NIVELI_DISPLAY_1
	CJNE R1,#11,KERCE1F		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_NIVELI_DISPLAY_1,#1
	LCALL DELAY_gjysm_sec
	
KERCE1F:	
	INC VLERA_NIVELI_DISPLAY_1
	
	MOV R1,VLERA_NIVELI_DISPLAY_1	
	CJNE R1,#11,KERCE2F		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_NIVELI_DISPLAY_1,#1	
KERCE2F:	
	LCALL DELAY_gjysm_sec
	JNB NUMRO_LART_PIN,B1F
	SETB P3.3
	;---------------------------------------------------------------------------------------------------
	
	POP ACC
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;//////////////////////////////////////////////////////      QITE NE DISPLAY VLEREN QE ESHTE RUAJTUR PER NIVEL       /////////////////////////////////////////////////////
DISPLAY_VLEREN_E_NIVELIT_ROUTINE:
	CLR P1.0
	CLR P1.1
	CLR P1.2
	CLR P1.3
	PUSH ACC
		
		
	MOV A,#54H				; Display "n"
	SETB P1.0
	MOV P0,A
	LCALL DELAY_mili_sec

	CLR P1.0
	
	MOV A,VLERA_NIVELI_DISPLAY_2		; Vlera e vertet e "x.a cm" eshte ne lokacionin memorik (VLERA_NIVELI_DISPLAY_2)
	INC A
	SETB P1.1
	LCALL SUBROUTINE1
	MOV P0,A
	LCALL DELAY_mili_sec	
	
	CLR P1.1
	
	MOV A,VLERA_NIVELI_DISPLAY_0		; Vlera e vertet e "xa cm" eshte ne lokacionin memorik (VLERA_NIVELI_DISPLAY_0)
	INC A
	SETB P1.2
	LCALL SUBROUTINE2
	MOV P0,A
	LCALL DELAY_mili_sec
	
	CLR P1.2
	
	MOV A,VLERA_NIVELI_DISPLAY_1		; Vlera e vertet e "ax cm" eshte ne lokacionin memorik (VLERA_NIVELI_DISPLAY_1)
	INC A
	SETB P1.3
	LCALL SUBROUTINE1
	MOV P0,A
	LCALL DELAY_mili_sec
	
	CLR P1.3
		
	POP ACC
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	;/////////////////////////////////////////////////////////////////    MERRE VLERENE E DISTANCES MAX TE SENSORIT TE NIVELIT NGA PODI    //////////////////////////////////////////////////////////////
MERRE_VLERENE_E_DISTANCES_MAX_PERMES_ROUTINE:
	
	PUSH ACC
	MOV P1,#80H
	MOV A,#0
	MOV R7,#0	
	
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	JB NUMRO_LART_PIN,$
	CLR P3.3
B1E1:	MOV R1,VLERA_DMAX_DISPLAY_0
	CJNE R1,#11,KERCE1E1		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_DMAX_DISPLAY_0,#1	
	LCALL DELAY_gjysm_sec
	
KERCE1E1:	
	INC VLERA_DMAX_DISPLAY_0
	
	MOV R1,VLERA_DMAX_DISPLAY_0	
	CJNE R1,#11,KERCE2E1		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_DMAX_DISPLAY_0,#1	
KERCE2E1:	
	LCALL DELAY_gjysm_sec
	JNB NUMRO_LART_PIN,B1E1
	SETB P3.3
	;---------------------------------------------------------------------------------------------------
	
	MOV A,#0
	JB NUMRO_LART_PIN,$
	CLR P3.3
B1F1:	MOV R1,VLERA_DMAX_DISPLAY_1
	CJNE R1,#11,KERCE1F1		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_DMAX_DISPLAY_1,#1
	LCALL DELAY_gjysm_sec
	
KERCE1F1:	
	INC VLERA_DMAX_DISPLAY_1
	
	MOV R1,VLERA_DMAX_DISPLAY_1	
	CJNE R1,#11,KERCE2F1		; Testo nese eshte gabuar gjate numrimit dhe eshte tejkaluar vlera
	MOV VLERA_DMAX_DISPLAY_1,#1	
KERCE2F1:	
	LCALL DELAY_gjysm_sec
	JNB NUMRO_LART_PIN,B1F1
	SETB P3.3
	;---------------------------------------------------------------------------------------------------
	
	POP ACC
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;//////////////////////////////////////////////////////      QITE NE DISPLAY VLEREN QE ESHTE RUAJTUR PER DISTANCES MAX       /////////////////////////////////////////////////////
DISPLAY_VLEREN_E_DISTANCES_MAX:
	CLR P1.0
	CLR P1.1
	CLR P1.2
	CLR P1.3
	
	PUSH ACC
	MOV A,VLERA_DMAX_DISPLAY_0		; Vlera e vertet e "xa" eshte ne lokacionin memorik (VLERA_NIVELI_DISPLAY_0)
	INC A
	SETB P1.0
	LCALL SUBROUTINE1
	MOV P0,A
	LCALL DELAY_mili_sec
	
	CLR P1.0
	
	MOV A,VLERA_DMAX_DISPLAY_1		; Vlera e vertet e "ax" eshte ne lokacionin memorik (VLERA_DMAX_DISPLAY_1)
	INC A
	SETB P1.1
	LCALL SUBROUTINE1
	MOV P0,A
	LCALL DELAY_mili_sec
	
	CLR P1.1
	
	MOV A,#37H				; Display "m"
	SETB P1.2
	MOV P0,A
	LCALL DELAY_mili_sec
	
	CLR P1.2
	
	MOV A,#5EH				; Display "d"
	SETB P1.3
	MOV P0,A
	LCALL DELAY_mili_sec
	
	CLR P1.3
	
	POP ACC
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
DELAY_mili_sec:
	MOV R3,#02H
DEL1:	MOV R2,#250
DEL2:	DJNZ R2,DEL2
	DJNZ R3,DEL1
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	

	
SUBROUTINE1:
	MOVC A,@A+PC
	RET
	DB 40H 		; "-"
	DB 3FH		; "0"
	DB 06H		; "1"
	DB 5BH		; "2"
	DB 4FH		; "3"
	DB 66H		; "4"
	DB 6DH		; "5"
	DB 7DH		; "6"
	DB 07H		; "7"	
	DB 7FH		; "8"
	DB 6FH		; "9"
	
SUBROUTINE2:
	MOVC A,@A+PC
	RET	
	DB 0C0H		; ".-"
	DB 0BFH		; ".0"
	DB 86H		; ".1"
	DB 0DBH		; ".2"
	DB 0CFH		; ".3"
	DB 0E6H		; ".4"
	DB 0EDH		; ".5"
	DB 0FDH		; ".6"
	DB 87H		; ".7"
	DB 0FFH		; ".8"
	DB 0EFH		; ".9"
		
	
DELAY_gjysm_sec:	
	MOV R4,#2
U2:	MOV R5,#2
U1:	MOV R6,#15
	DJNZ R6,$
	DJNZ R5,U1
	DJNZ R4,U2
	
	   
	   RET
	
	;//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	;	------------------------------ SHENDRRIMI I TEMP NE FORMEN QE E KUPTON PERDORUESI, P.S SHENDRRIMI SENSOR => PERDORUES ------------------------------

SHENDRRIMI_I_TEMP_S_P:			;S=>P, Indikacion per shendrrimin e vlerave nga Sensori kah Perdoruesi
	PUSH ACC
	; 123.4 C= 08B6
	; (VLERA_TEMP_RUAJ)=07H		; Vlera 'Pure' nga sensori temp
	; (VLERA_TEMP_REG_0)=B6H

	MOV A,VLERA_TEMP_RUAJ	; A=07H
	SWAP A		; A=VLERA_DMAX_SENSOR_TEST_0
	MOV VLERA_TEMP_REG_1,A	; (VLERA_TEMP_REG_1)=VLERA_DMAX_SENSOR_TEST_0
	PUSH VLERA_TEMP_REG_0
	ANL VLERA_TEMP_REG_0,#00001111b	;   1011 0110
				; * 0000 1111
				;   0000 0110 = 06H , (VLERA_TEMP_REG_0)=06H
	MOV VLERA_TEMP_RUAJ,VLERA_TEMP_REG_0		;   (VLERA_TEMP_RUAJ)=06H
	POP VLERA_TEMP_REG_0
	ANL VLERA_TEMP_REG_0,#11110000b	;   1011 0110
				; * 1111 0000
				;   1011 0000 = B0H , (VLERA_TEMP_REG_0)=B0H
	MOV A,VLERA_TEMP_REG_0
	SWAP A			; A=0BH
	ADD A,VLERA_TEMP_REG_1		; (A)+(VLERA_TEMP_REG_1)=0BH + VLERA_DMAX_SENSOR_TEST_0 = 7BH
	
	MOV B,#10
	DIV AB			; A=12d, B=3d
	MOV VLERA_TEMP_REG_1,B		; (VLERA_TEMP_REG_1)=3d
	MOV B,#10
	DIV AB			; A=1d, B=2d

	MOV VLERA_TEMP_REG_2,B		; (VLERA_TEMP_REG_2)=2d
	MOV VLERA_TEMP_REG_3,A		; (VLERA_TEMP_REG_3)=1d
				; (VLERA_TEMP_REG_3) (VLERA_TEMP_REG_2) (VLERA_TEMP_REG_1)
				;   	1     			2                 3  .  x

	
	; X=Y*10/16
	; x x x. 4,  07B 6
	; X=4
	; Y=6 
	; X=6*10/16=60/16 => A=03d, B=12d

	MOV A,VLERA_TEMP_RUAJ		; (VLERA_TEMP_RUAJ)=06d => (A)=06d
	MOV B,#10	
	MUL AB 			; (B)=00d
	MOV B,#16		
	DIV AB 			; (A)=03d, (B)=12d
	
	;CJNE A,#5,TEMP_SKIP1	; Testo nese vlera ne A=5, Verejtje vetum vlera xxx.5 mund te paraqit taman besnikrisht pasi 0.5 e ka edhe sensori kshtu qe merret ne A=5 tani do te ishte incremetuar dhe kishte me u bere A=6 dhe sdo te kishim vleren e duhur ne display
	;SJMP TEMP_SKIP2 	
;TEMP_SKIP1:INC A		; (A)=04d => "A=4", Verejtje ky hap behet per shkak se vlera e temp ne sensor nuk totalisht xxx.4 por eshte xxx.375 dhe si rezulata i procedurave mesiper merret vetem vlera e pare pra 3 dhe duhet te incremetohet qe ti shfaqet perdoruesit taman si vlera 4, P.s kjo vlen te tegjitha numrat nese eshte .7 ateher eshte 0.6875 pra del 6 kshtuqe e inc dhe ne display shfaqet 7 
;TEMP_SKIP2:	
	MOV VLERA_TEMP_REG_0,A		; (VLERA_TEMP_REG_0)=4d
				; (VLERA_TEMP_REG_3) (VLERA_TEMP_REG_2) (VLERA_TEMP_REG_1) (VLERA_TEMP_REG_0)		; Vlerat per display
				;    1     		2     		3  		.  4 	
	
	POP ACC
	
	
	RET
	
	;///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
	;////////////////////////////////////////// SHENDRRIMI I TEMP NE FORMEN QE E KUPTON DS18B20 //////////////////////////////////////////////

SHENDRRIMI_I_TEMP_P_S:			;P=>S, Indikacion per shendrrimin e vlerave nga Perdoruesi kah Sensori

	;P.SH:
	; (VLERA_TEMP_DISPLAY_3) (VLERA_TEMP_DISPLAY_2) (VLERA_TEMP_DISPLAY_1). (VLERA_TEMP_DISPLAY_0)
	;  1      2     0.     5    =>   125.5 => 0788H, sipas DS18B20 0000 0111 1001. 1000
	; (VLERA_TEMP_DISPLAY_0)/10=5/10=0.5
	; (VLERA_TEMP_DISPLAY_1)x1=0x1=0
	; (VLERA_TEMP_DISPLAY_2)x10=2x10=20
	; (VLERA_TEMP_DISPLAY_3)x100=1x100=100
	PUSH ACC
	PUSH B	
	; -----------------------------------------
	; Kjo llogaritje eshte bere vetem per softwarin ne PC
	
	MOV VLERA_TEMP_PRESJE_SET_POINT,VLERA_TEMP_DISPLAY_0
			
	; -----------------------------------------

	MOV A,VLERA_TEMP_DISPLAY_0	; 0.5*16= (5*16)/10=80d/10d=50H/AH=8d=08H
	MOV B,#16
	MUL AB 		; 0050H => A=50H=80d, B=00H
	MOV B,#10d
	DIV AB 		; 50H/AH=80d/10d => A=08H, B=00H
	MOV VLERA_TEMP_DISPLAY_0,A	; (VLERA_TEMP_DISPLAY_0)=08H

	MOV A,VLERA_TEMP_DISPLAY_2	
	MOV B,#10

	MUL AB 		; 2*10=20 => A=14H=20d (LOW BYTE), B=00H=00d (HIGH BYTE)
	MOV VLERA_TEMP_DISPLAY_2,A	; (VLERA_TEMP_DISPLAY_2)=20d

	MOV A,VLERA_TEMP_DISPLAY_3
	MOV B,#100

	MUL AB 		; 1*100=100 => A=VLERA_TEMP_DISPLAY_3=100d (LOW BYTE), B=00H=00d (HIGH BYTE)
	MOV VLERA_TEMP_DISPLAY_3,A	; (VLERA_TEMP_DISPLAY_0)=100d
	
	MOV A,#0
	
	MOV A,VLERA_TEMP_DISPLAY_1	; A=0
	ADD A,VLERA_TEMP_DISPLAY_2	; A=0+20=20
	ADD A,VLERA_TEMP_DISPLAY_3	; A=0+20+100=120d=VARIABLA_SERVO_VENTILI_2
	
	; -----------------------------------------
	; Kjo llogaritje eshte bere vetem per softwarin ne PC
	
	MOV VLERA_TEMP_PLOTE_SET_POINT,A
			
	; -----------------------------------------
	
	MOV B,#16
	DIV AB 		; A=7, B=8
	MOV R4,B	; R4=08H
	MOV B,#16
	DIV AB 		; A=0, B=7
	MOV R5,B	; R5=07H
	MOV A,R4
	SWAP A		; A=80H
	
			; R5 A =0780H

	ADD A,VLERA_TEMP_DISPLAY_0	; A=80H + (VLERA_TEMP_DISPLAY_0)=08H => A=88H
	MOV R4,A	; R4=88H

	MOV VLERA_TEMP_SENSOR_TEST_1,R5
	MOV VLERA_TEMP_SENSOR_TEST_0,R4
	
			; (VLERA_TEMP_SENSOR_TEST_1)=07H, (VLERA_TEMP_SENSOR_TEST_0)=88H
			; *****(VLERA_TEMP_SENSOR_TEST_1)(VLERA_TEMP_SENSOR_TEST_0)=0788H***** qe eshte vlera e kerkuar sipas DS18B20 0788H=0000 0111 				; 1001. 1000 = 120.5 C
	POP B
	POP ACC		
			
	RET


SHENDRRIMI_I_TEMP_P_S_NGA_PC:			;P=>S, Indikacion per shendrrimin e vlerave nga Perdoruesi kah Sensori

	;P.SH:
	; (VLERA_TEMP_DISPLAY_3) (VLERA_TEMP_DISPLAY_2) (VLERA_TEMP_DISPLAY_1). (VLERA_TEMP_DISPLAY_0)
	;  1      2     0.     5    =>   125.5 => 0788H, sipas DS18B20 0000 0111 1001. 1000
	; (VLERA_TEMP_DISPLAY_0)/10=5/10=0.5
	; (VLERA_TEMP_DISPLAY_1)x1=0x1=0
	; (VLERA_TEMP_DISPLAY_2)x10=2x10=20
	; (VLERA_TEMP_DISPLAY_3)x100=1x100=100
	PUSH ACC
	PUSH B	
	; -----------------------------------------
	; Kjo llogaritje eshte bere vetem per softwarin ne PC
	
	MOV VLERA_TEMP_PRESJE_SET_POINT,VLERA_TEMP_REG_0_NGA_PC
			
	; -----------------------------------------

	MOV A,VLERA_TEMP_REG_0_NGA_PC	; 0.5*16= (5*16)/10=80d/10d=50H/AH=8d=08H
	MOV B,#16
	MUL AB 		; 0050H => A=50H=80d, B=00H
	MOV B,#10d
	DIV AB 		; 50H/AH=80d/10d => A=08H, B=00H
	MOV VLERA_TEMP_REG_0_NGA_PC,A	; (VLERA_TEMP_DISPLAY_0)=08H

	MOV A,VLERA_TEMP_REG_2_NGA_PC	
	MOV B,#10

	MUL AB 		; 2*10=20 => A=14H=20d (LOW BYTE), B=00H=00d (HIGH BYTE)
	MOV VLERA_TEMP_REG_2_NGA_PC,A	; (VLERA_TEMP_DISPLAY_2)=20d

	MOV A,VLERA_TEMP_REG_3_NGA_PC
	MOV B,#100

	MUL AB 		; 1*100=100 => A=VLERA_TEMP_DISPLAY_3=100d (LOW BYTE), B=00H=00d (HIGH BYTE)
	MOV VLERA_TEMP_REG_3_NGA_PC,A	; (VLERA_TEMP_DISPLAY_0)=100d
	
	MOV A,#0
	
	MOV A,VLERA_TEMP_REG_1_NGA_PC	; A=0
	ADD A,VLERA_TEMP_REG_2_NGA_PC	; A=0+20=20
	ADD A,VLERA_TEMP_REG_3_NGA_PC	; A=0+20+100=120d=VARIABLA_SERVO_VENTILI_2
	
	; -----------------------------------------
	; Kjo llogaritje eshte bere vetem per softwarin ne PC
	
	MOV VLERA_TEMP_PLOTE_SET_POINT,A
			
	; -----------------------------------------
	
	MOV B,#16
	DIV AB 		; A=7, B=8
	MOV R4,B	; R4=08H
	MOV B,#16
	DIV AB 		; A=0, B=7
	MOV R5,B	; R5=07H
	MOV A,R4
	SWAP A		; A=80H
	
			; R5 A =0780H

	ADD A,VLERA_TEMP_REG_0_NGA_PC	; A=80H + (VLERA_TEMP_DISPLAY_0)=08H => A=88H
	MOV R4,A	; R4=88H

	MOV VLERA_TEMP_SENSOR_TEST_1,R5
	MOV VLERA_TEMP_SENSOR_TEST_0,R4
	
			; (VLERA_TEMP_SENSOR_TEST_1)=07H, (VLERA_TEMP_SENSOR_TEST_0)=88H
			; *****(VLERA_TEMP_SENSOR_TEST_1)(VLERA_TEMP_SENSOR_TEST_0)=0788H***** qe eshte vlera e kerkuar sipas DS18B20 0788H=0000 0111 				; 1001. 1000 = 120.5 C
	POP B
	POP ACC		
			
	RET


		;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	;		---------------------------------  SHENDRRIMI I NIVELIT NE FORMEN QE E KUPTON HCSR04, P.S SHENDRRIMI PERDORUES => SENSOR ---------------------------------
	
SHENDRRIMI_I_NIVELIT_P_S:		;P=>S, Indikacion per shendrrimin e vlerave nga Perdoruesi kah Sensori

	;P.SH:
	; (VLERA_NIVELI_DISPLAY_1) (VLERA_NIVELI_DISPLAY_0) (VLERA_NIVELI_DISPLAY_2)
	;   		2    			 0  			.7
	; (VLERA_NIVELI_DISPLAY_0)=0
	; (VLERA_NIVELI_DISPLAY_1)x10=2x10=20
	PUSH ACC
	PUSH B
	
	MOV A,VLERA_NIVELI_DISPLAY_1	
	MOV B,#10

	MUL AB 		; 2*10=20 => A=14H=20d (LOW BYTE), B=00H=00d (HIGH BYTE)		
	ADD A,VLERA_NIVELI_DISPLAY_0	; A=20+0=20cm
	
	; -----------------------------------------
	; Kjo llogaritje eshte bere vetem per softwarin ne PC
	MOV VLERA_NIVELI_PLOTE_SET_POINT,A				; 20
	MOV VLERA_NIVELI_PRESJE_SET_POINT,VLERA_NIVELI_DISPLAY_2	; .7	
			
	; -----------------------------------------
	
	MOV VLERA_NIVELI_DISPLAY_1,A	; 20cm
	DEC VLERA_NIVELI_DISPLAY_1
	MOV A,VLERA_DMAX_REG_0	; Verejtje 3CH=60cm kjo eshte distanca maximale prej podit te kofes deri ku eshte i vendosur senzori, Verejtje kete distance e kemi marr fikse pasi pika ku vendoset senzori i nivelit eshte fikse, perndryshe kemi mundur qe ta jepim kete vlere ne fillim permes tasteve siq vepruam me vleren e temp dhe nivel te ujit pa problem por mbasi nuk eshte nevoja po e lem.
	
	;Performojme nje zbritje
	; ------------------------------------ ME LLOGARIT EDHE PRESJEN DHJETORE --------------------------------------
	
	CLR C
	INC VLERA_NIVELI_DISPLAY_1		; 20 + 1 =21cm
	SUBB A,VLERA_NIVELI_DISPLAY_1		; 60 - 21 = 39cm
	MOV VLERA_NIVELI_DISPLAY_1,A		; (66H) = 39cm
	
	MOV A,#9
	SUBB A,VLERA_NIVELI_DISPLAY_2		; 9 - 7 = 2
	MOV B,#38
	MUL AB					; A = 2*38 = 76
	MOV B,#10
	DIV AB					; A = 7 ; pasi 76/10, A = 7, B = 6
	MOV VLERA_NIVELI_DISPLAY_2,A		; (72H) = 7cm
	
	MOV B,#38
	MOV A,VLERA_NIVELI_DISPLAY_1
	MUL AB					; 39 * 38 = 1482d, A = CAH, B = 05H
	
	ADD A,VLERA_NIVELI_DISPLAY_2		; CAH + 07H = D1H
		
	MOV VLERA_NIVELI_SENSOR_TEST_0,A	; (53H)=D1H
	MOV VLERA_NIVELI_SENSOR_TEST_1,B	; (54H)=05H
		
	; -------------------------------------------------------------------------------------------------------------
	
	; ------------------------------------ MOS ME LLOGARIT EDHE PRESJEN DHJETORE ----------------------------------
	
	;CLR C
	;SUBB A,VLERA_NIVELI_DISPLAY_1	; (A)-(VLERA_NIVELI_DISPLAY_1)=3CH-14H=28H,  60cm-20cm=40cm distanca reale e senzorit prej vleres ku shifet si 1sh logjik eshte 60-20=40cm
	;MOV B,#26H	; 26H=38d, 38 eshte konstatja me te cilen shumzohet distanca prej senzorit qe te na jep kohezgjatjen e plusit ku eshte e ruajtur informata per distance	
	;MUL AB		; A*B=28H*26H=40cm*38uS/cm=05F0H=   1520uS
			; ****A=F0H, B=05H****
	;MOV VLERA_NIVELI_SENSOR_TEST_0,A	; (53H)=F0H
	;MOV VLERA_NIVELI_SENSOR_TEST_1,B	; (54H)=05H
	
	; -------------------------------------------------------------------------------------------------------------
	
	POP B
	POP ACC
	
	
	RET

SHENDRRIMI_I_NIVELIT_P_S_NGA_PC:		;P=>S, Indikacion per shendrrimin e vlerave nga Perdoruesi kah Sensori

	;P.SH:
	; (VLERA_NIVELI_DISPLAY_1) (VLERA_NIVELI_DISPLAY_0) (VLERA_NIVELI_DISPLAY_2)
	;   		2    			 0  			.7
	; (VLERA_NIVELI_REG_2_NGA_PC) (VLERA_NIVELI_REG_1_NGA_PC) (VLERA_NIVELI_REG_0_NGA_PC)
	;   		2    			 0  			.7
	; (VLERA_NIVELI_DISPLAY_0)=0
	; (VLERA_NIVELI_DISPLAY_1)x10=2x10=20
	PUSH ACC
	PUSH B
	
	MOV A,VLERA_NIVELI_REG_2_NGA_PC
	MOV B,#10

	MUL AB 		; 2*10=20 => A=14H=20d (LOW BYTE), B=00H=00d (HIGH BYTE)		
	ADD A,VLERA_NIVELI_REG_1_NGA_PC	; A=20+0=20cm
	
	; -----------------------------------------
	; Kjo llogaritje eshte bere vetem per softwarin ne PC
	MOV VLERA_NIVELI_PLOTE_SET_POINT,A				; 20
	MOV VLERA_NIVELI_PRESJE_SET_POINT,VLERA_NIVELI_REG_0_NGA_PC	; .7	
			
	; -----------------------------------------
	
	MOV VLERA_NIVELI_REG_2_NGA_PC,A	; 20cm
	DEC VLERA_NIVELI_REG_2_NGA_PC
	MOV A,VLERA_DMAX_REG_0	; Verejtje 3CH=60cm kjo eshte distanca maximale prej podit te kofes deri ku eshte i vendosur senzori, Verejtje kete distance e kemi marr fikse pasi pika ku vendoset senzori i nivelit eshte fikse, perndryshe kemi mundur qe ta jepim kete vlere ne fillim permes tasteve siq vepruam me vleren e temp dhe nivel te ujit pa problem por mbasi nuk eshte nevoja po e lem.
	
	;Performojme nje zbritje
	; ------------------------------------ ME LLOGARIT EDHE PRESJEN DHJETORE --------------------------------------
	
	CLR C
	INC VLERA_NIVELI_REG_2_NGA_PC		; 20 + 1 =21cm
	SUBB A,VLERA_NIVELI_REG_2_NGA_PC		; 60 - 21 = 39cm
	MOV VLERA_NIVELI_REG_2_NGA_PC,A		; (66H) = 39cm
	
	MOV A,#9
	SUBB A,VLERA_NIVELI_REG_0_NGA_PC		; 9 - 7 = 2
	MOV B,#38
	MUL AB					; A = 2*38 = 76
	MOV B,#10
	DIV AB					; A = 7 ; pasi 76/10, A = 7, B = 6
	MOV VLERA_NIVELI_REG_0_NGA_PC,A		; (72H) = 7cm
	
	MOV B,#38
	MOV A,VLERA_NIVELI_REG_2_NGA_PC
	MUL AB					; 39 * 38 = 1482d, A = CAH, B = 05H
	
	ADD A,VLERA_NIVELI_REG_0_NGA_PC		; CAH + 07H = D1H
		
	MOV VLERA_NIVELI_SENSOR_TEST_0,A	; (53H)=D1H
	MOV VLERA_NIVELI_SENSOR_TEST_1,B	; (54H)=05H
		
	; -------------------------------------------------------------------------------------------------------------
	
	; ------------------------------------ MOS ME LLOGARIT EDHE PRESJEN DHJETORE ----------------------------------
	
	;CLR C
	;SUBB A,VLERA_NIVELI_REG_2_NGA_PC	; (A)-(VLERA_NIVELI_DISPLAY_1)=3CH-14H=28H,  60cm-20cm=40cm distanca reale e senzorit prej vleres ku shifet si 1sh logjik eshte 60-20=40cm
	;MOV B,#26H	; 26H=38d, 38 eshte konstatja me te cilen shumzohet distanca prej senzorit qe te na jep kohezgjatjen e plusit ku eshte e ruajtur informata per distance	
	;MUL AB		; A*B=28H*26H=40cm*38uS/cm=05F0H=   1520uS
			; ****A=F0H, B=05H****
	;MOV VLERA_NIVELI_SENSOR_TEST_0,A	; (53H)=F0H
	;MOV VLERA_NIVELI_SENSOR_TEST_1,B	; (54H)=05H
	
	; -------------------------------------------------------------------------------------------------------------
	
	POP B
	POP ACC
	
	
	RET
		;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	;		---------------------------------  SHENDRRIMI I NIVELIT NE FORMEN QE E KUPTON HCSR04, P.S SHENDRRIMI PERDORUES => SENSOR ---------------------------------
	
SHENDRRIMI_I_DISTANCES_MAX_P_S:		;P=>S, Indikacion per shendrrimin e vlerave nga Perdoruesi kah Sensori

	;P.SH:
	; (VLERA_DMAX_DISPLAY_1) (VLERA_DMAX_DISPLAY_0)
	;   6     0  
	; (VLERA_DMAX_DISPLAY_0)=0
	; (VLERA_NIVELI_DISPLAY_1)x10=6x10=60
	PUSH ACC
	PUSH B	
	
	MOV A,VLERA_DMAX_DISPLAY_1	
	MOV B,#10

	MUL AB 		; 6*10=60 => A=3CH=60d (LOW BYTE), B=00H=00d (HIGH BYTE)
	
	ADD A,VLERA_DMAX_DISPLAY_0	; A=60+0=60cm
	MOV VLERA_DMAX_REG_0,A	; 60cm, distanca max
	
	; -----------------------------------------
	; Kjo llogaritje eshte bere vetem per softwarin ne PC
	
	MOV VLERA_DISTANCA_MAX_SET_POINT,VLERA_DMAX_REG_0
			
	; -----------------------------------------
	
	CLR C	
	MOV A,VLERA_DMAX_REG_0
	SUBB A,#2	; A=3CH=60d, (VLERA_NIVELI_REG_1)=40, 60cm-2cm=58cm => A=3Bd

	MOV B,#26H	; 26H=38d
	MUL AB		; 58*38, A=9CH, B=08H
	
	MOV VLERA_DMAX_SENSOR_TEST_0,A
	MOV VLERA_DMAX_SENSOR_TEST_1,B
		
	POP B
	POP ACC
	
	
	RET

SHENDRRIMI_I_DISTANCES_MAX_P_S_NGA_PC:		;P=>S, Indikacion per shendrrimin e vlerave nga Perdoruesi kah Sensori

	;P.SH:
	; (VLERA_DMAX_DISPLAY_1) (VLERA_DMAX_DISPLAY_0)
	;   6     0  
	; (VLERA_DMAX_DISPLAY_0)=0
	; (VLERA_NIVELI_DISPLAY_1)x10=6x10=60
	PUSH ACC
	PUSH B	
	
	MOV A,VLERA_DMAX_REG_1_NGA_PC	
	MOV B,#10

	MUL AB 		; 6*10=60 => A=3CH=60d (LOW BYTE), B=00H=00d (HIGH BYTE)
	
	ADD A,VLERA_DMAX_REG_0_NGA_PC	; A=60+0=60cm
	MOV VLERA_DMAX_REG_0,A	; 60cm, distanca max
	
	; -----------------------------------------
	; Kjo llogaritje eshte bere vetem per softwarin ne PC
	
	MOV VLERA_DISTANCA_MAX_SET_POINT,VLERA_DMAX_REG_0
			
	; -----------------------------------------
	
	CLR C	
	MOV A,VLERA_DMAX_REG_0
	SUBB A,#2	; A=3CH=60d, (VLERA_NIVELI_REG_1)=40, 60cm-2cm=58cm => A=3Bd

	MOV B,#26H	; 26H=38d
	MUL AB		; 58*38, A=9CH, B=08H
	
	MOV VLERA_DMAX_SENSOR_TEST_0,A
	MOV VLERA_DMAX_SENSOR_TEST_1,B
		
	POP B
	POP ACC
	
	
	RET
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
 	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	;	------------------------------ SHENDRRIMI I NIVELIT NE FORMEN QE E KUPTON PERDORUESI, P.S SHENDRRIMI SENSOR => PERDORUES ------------------------------

SHENDRRIMI_I_NIVELIT_S_P:		;S=>P, Indikacion per shendrrimin e vlerave nga Sensori kah Perdoruesi
	
	;----------------------------------------------------------------------------------------------------------
	; Pjestimi e nje numri 16 bitesh me nje numer 16 bitesh,ne perdorim 16/8 keshtu qe ne R3 = 00H
	
	; 08E8H
	; -----= 3CH
	;   26H
	
	; R0 - LOW BYTE i te pjestueshmit
	; R1 - HIGH BYTE i te pjestueshmit 
	; R2 - LOW BYTE i pjestuesit
	; R1 - HIGH BYTE i pjestuesit
	
	; R1  R0 ...   089CH
	; 08  E8
	
	; R3  R2 ...   0026H= 38d
	; 00  26
	PUSH ACC
	PUSH B
	MOV VARIABLA_CARRY,C	
	
	MOV A,R6
	MOV R0,A
	MOV A,R7
	MOV R1,A
	MOV R2,#26H
	MOV R3,#00H
		
	
div16_16:
  	CLR C       
	MOV R4,#00H 
  	MOV R5,#00H 
	MOV B,#00H  
div1:
  	INC B     
	MOV A,R2  
	RLC A      
  	MOV R2,A   
  	MOV A,R3   
  	RLC A      
  	MOV R3,A   
  	JNC div1   
div2:        
  	MOV A,R3   
	RRC A      
  	MOV R3,A   
  	MOV A,R2   
  	RRC A      
  	MOV R2,A   
  	CLR C      
  	MOV 07H,R1 
  	MOV 06H,R0 
  	MOV A,R0   
  	SUBB A,R2  
  	MOV R0,A   
  	MOV A,R1   
  	SUBB A,R3  
  	MOV R1,A   
  	JNC div3   
  	MOV R1,07H 		; Mbetja high byte
  	MOV R0,06H		; Mbetja low byte
div3:
	CPL C      
  	MOV A,R4 
  	RLC A      
  	MOV R4,A   
  	MOV A,R5
  	RLC A
  	MOV R5,A		
  	DJNZ B,div2 
  	MOV R3,05H  		; Rezultati high byte
  	MOV R2,04H  		; Rezultati low byte 
		
	
	;////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	MOV VLERA_NIVELI_REG_1,R2		; Marrim vetum R2 pasi hrjen 16bit pe pjestojme me numer 8bit dhe rezultati do te jete 8bit (pra R3 = 00H gjithmone)
	MOV VLERA_NIVELI_REG_0,R0
	
	MOV A,R0		;   12	   	120	 120     12
  	MOV B,#4		;  ---- X 10 = ----- ~  ----- = -----	; A = Rez = 3; B = Mbj = 0
	DIV AB			;   38		 38	  40	  4
	MOV VLERA_NIVELI_REG_0,A

  	
  			; VLERA_NIVELI_REG_0 = 3d
  			; VLERA_NIVELI_REG_1 = 51d
  			; -------  
  			; 51.3d	
  			
	  			

	;----------------------------------------------------------------------------------------------------------
	
	; Me kaq perfundon pjestimi 16 bitesh, tani do ta performojme nje zbritje pasi vlera qe kemi marre p.sh eshte 38cm kjo distance eshte prej sensorit deri te niveli i ujit, por nese dojm ta shfaqim ne display duhet qe ta bejme 58cm-38cm=20cm qe eshte distanca na podi i kofes deri ku eshte niveli i ujit
	
	;//////////////////////////////////////////////////////////////////////
	CLR C	
	MOV A,VLERA_DMAX_REG_0
	SUBB A,VLERA_NIVELI_REG_1	; A=3CH=60d, (VLERA_NIVELI_REG_1)=40, 60cm-40cm=20cm => A=20d
	MOV VLERA_NIVELI_REG_1,A	; VLERA_NIVELI_REG_1 = 20d
	
	CLR C
	MOV A,#9
	SUBB A,VLERA_NIVELI_REG_0	; 9 - 3 = 6 zban 10 se mundet 10 - 0 = 10 ska vlere per 10 te SUBROUTINE1/2
	MOV VLERA_NIVELI_REG_0,A	; VLERA_NIVELI_REG_0 = 7d

	MOV A,VLERA_NIVELI_REG_1	; A = 20d
	MOV B,#10
	DIV AB 		; A=2d, B=0d
	MOV VLERA_NIVELI_REG_2,A	; Vendose vleren e vertet prej A ne lokacionin memorik VLERA_NIVELI_REG_1
	MOV VLERA_NIVELI_REG_1,B	; Vendose vleren e vertet prej B ne lokacionin memorik VLERA_NIVELI_REG_2
			; (VLERA_NIVELI_REG_2) (VLERA_NIVELI_REG_1)  (VLERA_NIVELI_REG_0)
			;   	2     			0   		.  7
			
				
	MOV C,VARIABLA_CARRY	
	POP B
	POP ACC
		
	
	RET
	
	;///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	

	;======================================================================
;			INTERAPTI I EXTERNAL 0	
	;======================================================================
EXR0VEC:
	PUSH ACC
	PUSH B
	
	CLR TR0       			; Stop timer

	JB PINI_EMERGJENT_BIT,EMERGJEN_LABEL				; Nese setb EMERGJEN_LABEL ateher jemi ne emergjent mode	
	MOV R7,TH0   		        ; Ruje vleren e timer-it
	MOV R6,TL0    
	LCALL TEST_WATER_LEVEL_ROUTINE	; Testo nivelin e ujit
	
	LCALL SHENDRRIMI_I_NIVELIT_S_P	; Rutina qe shendrron vlerat e sensorit te nivelit ne forme vizuele per perdoruesion 
			
			; (VLERA_NIVELI_REG_2) (VLERA_NIVELI_REG_1)
			;   	2     			0
			
	; Verejtje, pasi e kemi rutinen qe ti paraqesim vlerat e nivelit ne display dhe aty segmentet i kane keto adresa ne memorie prej 			; VLERA_NIVELI_DISPLAY_0 dhe VLERA_NIVELI_DISPLAY_1 atehere i kthejm vlerat e nivelit qe jane matur qe jane ne adresat ne memorie 			; VLERA_NIVELI_REG_1 dhe VLERA_NIVELI_REG_2 i vendosim ne VLERA_NIVELI_DISPLAY_0 dhe VLERA_NIVELI_DISPLAY_1
	
	MOV VLERA_NIVELI_DISPLAY_0,VLERA_NIVELI_REG_1	
	MOV VLERA_NIVELI_DISPLAY_1,VLERA_NIVELI_REG_2	
	MOV VLERA_NIVELI_DISPLAY_2,VLERA_NIVELI_REG_0

	; Pasi te rutina per marrjen e vlerave, pershkak te shejes "-" ne fillim u deshkeqe tabeltat si subroutin1 dhe subroutine2 te ia fillojn nga "-" e jo nga "0" por tash kemi me i paraqit vlerat qe ja nisin natyrisht na 0 dhe si rezultat duhet ta rritm vleren e VLERA_NIVELI_DISPLAY_0 dhe VLERA_NIVELI_DISPLAY_1 per nje qe ti perdorim rutinat e njeta me tabela dhe ti ikim termit te pare te tyre
		
	INC VLERA_NIVELI_DISPLAY_0
	INC VLERA_NIVELI_DISPLAY_1
	INC VLERA_NIVELI_DISPLAY_2

EMERGJEN_LABEL:	

	MOV TH0,#0    			; Clear timer 0 per matje
	MOV TL0,#0

	POP B
	POP ACC
	
	SETB TR0      			; Restart timer0

	RETI

;======================================================================
;			INTERAPTI I TAJMERIT 1	
;======================================================================
TMR1VEC:

	
	LCALL MONITORIMI_KONTROLLA_RUTINA
	;LCALL SHENDRRIMI_EMERGJENT_RUTINA
	LCALL GJENERIMI_I_KOHES_RUTINA	
	
	LCALL SHENDRRIMI_NIVELI_RUTINA
	LCALL SHENDRRIMI_TEMPERATURA_RUTINA
	LCALL RIJEP_VLERAT_NGA_PC_RUTINA	


	PUSH ACC
	PUSH B
	
	
	JB VARIABLA_KONTROLLO_DISPLAY,K2	
	CJNE R0,#0,SKIP1
	LCALL DISPLAY_VLEREN_E_TEMP_ROUTINE
	;CLR INDIKO_VLERAT_NE_DISPLAY 	
	
	SJMP SKIP3
SKIP1:	CJNE R0,#1,SKIP2
	LCALL DISPLAY_VLEREN_E_NIVELIT_ROUTINE
	;SETB INDIKO_VLERAT_NE_DISPLAY

	SJMP SKIP3
SKIP2:	
	LCALL DISPLAY_VLEREN_E_DISTANCES_MAX
	;SETB INDIKO_VLERAT_NE_DISPLAY
	
SKIP3:	
	; --------------------------------------- SHPRAZJA E KOVES NE FILLIM ME SHTYPJEN E TASTIT P2.2----------------------------------
	JB VARIABLA_RIJEP_VLERAT,IKI_KETU1	
	LCALL VENTILLI_HAPET			; Perderisa VARIABLA_KONTROLLO_DISPLAY eshte CLR, (pra sistemi eshte ne modin e pranimit te vlerave) shpraze koven me uje pastaj ktheje kontrollen tek sistemi automatik
	SJMP IKI_KETU2
IKI_KETU1:
	LCALL VENTILLI_MBYLLET
IKI_KETU2:
	;--------------------------------------------------------------------------------------------------------------------------------
	
	JNB VARIABLA_KONTROLLO_DISPLAY,K1_A 	; Roli si 'JNB VARIABLA_KONTROLLO_DISPLAY,K1' por spe mrrin 
	SJMP K2
K1_A:
	LJMP K1		
	
K2:

	
	LCALL SHENDRRIMI_START_PC_PINI_RUTINA
	LCALL SHENDRRIMI_STOP_PC_PINI_RUTINA
	LCALL SHENDRRIMI_Q4_RUTINA
	;LCALL SHENDRRIMI_PINI_BIT_TO_P3_5
	;LCALL KONTROLLA_PREJ_PLLAKE_MODI_EMERGJENT
	
	
	;//////////////////////////////////////////////////////////////// MATJET NIVELI/TEMP KONTROLLA ////////////////////////////////////////////////
	
	; ----------------------------------
	
	DJNZ VARIABLA_NIVELI_SENS_0,DEC0
	MOV VARIABLA_NIVELI_SENS_0,#40		; Me kete vlere kontrollohet shpeshtesia e matjeve te Nivelit (Vlera ma e madhe = Matje me rralle)
	LCALL TRIGGER_IMPULSE_ROUTINE	
DEC0:
		
	
	DJNZ VARIABLA_TEMP_SENS_0,DEC1
	MOV VARIABLA_TEMP_SENS_0,#90		; Me kete vlere kontrollohet shpeshtesia e matjeve te Temperatures (Vlera ma e madhe = Matje me rralle)
	SETB VARIABLA_TEMP_BIT		
	SJMP DEC2
DEC1:	
	CLR VARIABLA_TEMP_BIT
DEC2:
	; ----------------------------------

	;//////////////////////////////////////////////////////////////// SERVO/VENTILLI KONTROLLA /////////////////////////////////////////////////		
	;------------------------------ SERVO/VENTILLI KONTROLLA MANUALE ------------------------------
	
	JNB STATUSI_START_STOP_PLC,SerVenMan_1		; Nese P3.6 (SERVO_VARIABLA_MANUALE) = 0, atehere kjo dmth qe eshte kyqur dalja Q4 ne PLC dhe tegron se perdoruesi ka shtypur tastin STOP dhe deshiron ta nderprej procesin ne cilen do faze qe eshte per momentin sistemi.
							; P3.6 (SERVO_VARIABLA_MANUALE) = 1, atehere kjo dmth qe eshte qkyqur dalja Q4 ne PLC dhe tegron se perdoruesi ka shtypur tastin START dhe deshiron ta vazhdoj procesin ne fazen qe eshte nderprere ma heret nga shtypja e tastit STOP.
	LCALL VENTILLI_MBYLLET
	SJMP SerVenMan_2
	
	;----------------------------------------------------------------------------------------------		
	
SerVenMan_1:
	
	;------------------------------ SERVO/VENTILLI KONTROLLA AUTOMATIKE ---------------------------

	PUSH ACC
	MOV A,R4
	
	JNB WATER_LEVEL_ON_OFF,SerVen_1
	MOV VARIABLA_SERVO_VENTILI_1,R4
	MOV R4,VARIABLA_SERVO_VENTILI_2
	CJNE R4,#0,SerVen_2
	JNB TEMP_REACHED_ON_OFF,SerVen_1
	MOV R4,#1
SerVen_4:
	LCALL VENTILLI_HAPET
	SJMP SerVen_3
SerVen_2:
	JB WATER_LEVEL_ON_OFF,SerVen_4
SerVen_1:
	MOV R4,#0
	LCALL VENTILLI_MBYLLET
SerVen_3:
	MOV VARIABLA_SERVO_VENTILI_2,R4
	MOV R4,VARIABLA_SERVO_VENTILI_1

	MOV R4,A
	POP ACC
	;----------------------------------------------------------------------------------------------
	
SerVenMan_2:
	
	;///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	JNB VARIABLA_TEMP_BIT,IKITEMP_HERE																			   
	MOV VLERA_TEMP_DISPLAY_0,VLERA_TEMP_REG_0
	MOV VLERA_TEMP_DISPLAY_1,VLERA_TEMP_REG_1
	MOV VLERA_TEMP_DISPLAY_2,VLERA_TEMP_REG_2
	MOV VLERA_TEMP_DISPLAY_3,VLERA_TEMP_REG_3
	
	INC VLERA_TEMP_DISPLAY_0
	INC VLERA_TEMP_DISPLAY_1
	INC VLERA_TEMP_DISPLAY_2
	INC VLERA_TEMP_DISPLAY_3	

IKITEMP_HERE:	


	JNB SHFAQ_NIVEL,SHFAQ_N		; Shfaq vlerat per nivel ne display (Force Show) nese shtypet 2.5
	JNB SHFAQ_TEMP,SHFAQ_T		; Shfaq vlerat per temp ne display (Force Show) nese shtypet 2.6
	
	JB WATER_LEVEL_ON_OFF,TEMP1
	SETB NUMRO_LART_PIN			; Mase mbrojtese
	SJMP NIVEL1
NIVEL1A:	CLR NUMRO_LART_PIN
NIVEL1:	
	LCALL DISPLAY_VLEREN_E_NIVELIT_ROUTINE
	;SETB INDIKO_VLERAT_NE_DISPLAY			; Vlerat ne display jane per Nivel
	SJMP K1
TEMP1:
	JNB NUMRO_LART_PIN,NIVEL1
	JB TEMP_REACHED_ON_OFF,NIVEL1A
	LCALL DISPLAY_VLEREN_E_TEMP_ROUTINE	
	;CLR INDIKO_VLERAT_NE_DISPLAY			; Vlerat ne display jane per Temperature
	SJMP K1				
SHFAQ_N:
	SETB SHFAQ_TEMP 
	CLR SHFAQ_NIVEL
	LCALL DISPLAY_VLEREN_E_NIVELIT_ROUTINE
	;SETB INDIKO_VLERAT_NE_DISPLAY
	JNB SHFAQ_TEMP,SHFAQ_T
	SJMP K1
SHFAQ_T:
	CLR SHFAQ_TEMP 
	SETB SHFAQ_NIVEL
	LCALL DISPLAY_VLEREN_E_TEMP_ROUTINE	
	;CLR INDIKO_VLERAT_NE_DISPLAY	
K1:	
	JB AUTOMATIK_TREGIM,K3
	
	SETB SHFAQ_NIVEL
	SETB SHFAQ_TEMP
	
K3:	
	
	POP B
	POP ACC

	RETI
;======================================================================
;			INTERAPTI I TAJMERIT 2	
;======================================================================
	
TMR2VEC:			
	PUSH PSW
	PUSH 03H
		
	
	CLR TR2
	CLR TF2
	
	MOV R3 , GjendjaModbus
	CJNE R3,#01H,TOJO1
 	MOV GjendjaModbus , #02H
 	
 	POP 03H
 	POP PSW
 		RETI
TOJO1:
TOJO2:  
 	CJNE R3,#03H,TOJO3
 	MOV GjendjaModbus , #04H 

 	CLR TR2 
 	CLR TF2	
 	MOV RCAP2H,#HIGH t20
 	MOV RCAP2L,#LOW t20
 	SETB TR2

 	POP 03H
 	POP PSW
		RETI

TOJO3:  
	CJNE R3,#04H,TOJO4
	
	PUSH ACC
	PUSH B
	PUSH 00H
	PUSH 01H
	PUSH 02H
	PUSH 04H
	PUSH 05H
	PUSH 06H
	PUSH 07H
	
	CALL ANALIZA
	
	POP 07H
	POP 06H
	POP 05H
	POP 04H
	POP 02H
	POP 01H
	POP 00H
	POP B
	POP ACC
TOJO4: 
 	POP 03H
 	POP PSW
  		RETI

;======================================================================
;				RX INTERAPTI
;======================================================================
SERVEC: 
	PUSH PSW
	PUSH ACC
	PUSH B
	PUSH 00H
	PUSH 03H
		
	MOV R3 ,  GjendjaModbus
 	JB RI,RX
 	MOV A,CounterModbus			;rutina per dergim
 	CJNE A,GjendjaDergimit,NEXTCH 		;r2=02h
 	MOV GjendjaModbus , #02H
	MOV CounterModbus , #00H
	
 	POP 03H
  	POP 00H
  	POP B
 	POP ACC
	POP PSW
 	CLR TI
  		RETI

NEXTCH:
	MOV R0,#StartAddress
	MOV A , R0
	ADD A , GjendjaDergimit	
 	MOV R0 , A
 	MOV A , @R0
	
 	MOV SBUF,A
 	INC GjendjaDergimit
 	
 	POP 03H
 	POP 00H
 	POP B
 	POP ACC
	POP PSW
 	CLR TI
 		RETI

RX:  
 	CLR RI
	CJNE R3,#01H,RXJO1

 	CLR TR2 
 	CLR TF2
 	MOV RCAP2H,#HIGH t35
 	MOV RCAP2L,#LOW t35
 	SETB TR2
 	
 	POP 03H
 	POP 00H
 	POP B
 	POP ACC
 	POP PSW
 		RETI
  
RXJO1: 
	CJNE R3,#02H,RXJO2
 	MOV CounterModbus , #00H 			;fshihet bufferi duke u pozicionuar ne 0 pas kalimit nga 2-3

RXGJ2:  

	CLR TR2
 	CLR TF2 			;flagu i tajmerit2
 	MOV RCAP2H,#HIGH t15
 	MOV RCAP2L,#LOW t15
 	SETB TR2
 	
 	MOV GjendjaModbus , #03H
 	MOV A,SBUF 			;shkrimi ne buffer
 	
 	mov B , A
 	mov A ,#StartAddress
 	ADD A , CounterModbus
 	mov R0 , A
 	MOV A , B
 	mov @R0, A
 
 	INC CounterModbus
	
	POP 03H
 	POP 00H
 	POP B
 	POP ACC
 	POP PSW
 		RETI
  
RXJO2:  
 	CJNE R3,#03H,RXJO3
 	SJMP RXGJ2
RXJO3:  
 	CJNE R3,#04H,RXJO4

 	CLR TR2 
 	CLR TF2	
 	MOV RCAP2H,#HIGH t35
 	MOV RCAP2L,#LOW t35
 	SETB TR2
 	
 	MOV GjendjaModbus , #01H
;fshirja e bafferit
; MOV R4,#00H
; RETI
RXJO4:
  	POP 03H
 	POP 00H
 	POP B
	POP ACC
	POP PSW
 		RETI
;======================================================================
;				ANALIZA
;======================================================================
ANALIZA:
 	MOV A,CounterModbus
 	MOV R7,A 			;R7=R4 por ndyshon ne 0 gjate kalkulimit teCRC
 	DEC R7 				;zvoglojme per 2(e hjekim crc ngamesazhi)
 	DEC R7
 	CALL CALC_CRC
;krahsimi i crc

 	MOV A,#StartAddress
 	ADD A , R7
 	MOV R0 , A
 	MOV A , @R0
 
 
	CJNE A,CRC_ACCUM_LOW,ANALEND 	;shkon ne analend nese crcgabim
 
 	INC R0
 	MOV A , @R0
 	

 	CJNE A,CRC_ACCUM_HI,ANALEND 	;shkon ne analend nese crc gabim
;fundi i krahasimit (CRC-OK)
;krahasimi i adreses

	MOV R0 , #StartAddress
	MOV A ,@R0

 	CJNE A,#01H,ANALEND
 	JMP FUNKS
ANALEND:
 	JMP ANALEND2
 	
;fundi i krahasimit(AdresaOK)
;======================================================================
;			FUNKSIONI
;======================================================================	
FUNKS:  
	MOV R0 , #StartAddress+1
	MOV A , @R0
 
 	CJNE A,#01,JOFO1
FO1:
 	INC R0
 	MOV A , @R0
 
 	JZ FO1_01
 	JMP STADDERR 
FO1_01: 

	INC R0
 	MOV A , @R0
 
 	MOV R6,A
 	CLR C
 	SUBB A,#COILNUM 		;numri total i coilave=coilnum
 	JC FO1_02
 	JMP STADDERR 
FO1_02: 
 	INC R0
 	MOV A , @R0
 
 	JZ FO1_03
 	JMP VALERR
FO1_03: 

	INC R0
 	MOV A , @R0
 
 	MOV R5,A
 	DEC A
 	ADD A,R6
 	CLR C
 	SUBB A,#COILNUM 		;numri total i coilave=coilnum
 	JC FO1_04
 	JMP VALERR

FO1_04: 
 	MOV R4,#02H
 	CALL READCOIL
 	JMP SENDMSG
JOFO1:  
 	CJNE A,#2,JOFO2
FO2:
 	JMP FO1
JOFO2: 
	CJNE A,#3,JOFO3
FO3:
 	INC R0
 	MOV A , @R0
 
 	JZ FO3_01
 	JMP STADDERR
 
FO3_01: 
 	INC R0
 	MOV A , @R0
 
 	MOV R6,A
 	CLR C
 	SUBB A,#HREGNUM 		;numri total i regjistrave
 	JC FO3_02
 	JMP STADDERR

FO3_02: 
 	INC R0
 	MOV A , @R0
 
 	JZ FO3_03
 	JMP VALERR

FO3_03: 
	INC R0
	MOV A , @R0
  
 	MOV R5,A
 	DEC A
 	ADD A,R6
 	CLR C
 	SUBB A,#HREGNUM 		;numri total i regjistrave
 	JC FO3_04
 	JMP VALERR
 
FO3_04: 
 	MOV CounterModbus,#02H
 	CALL READREG
 	JMP SENDMSG
	
JOFO3:  
 	CJNE A,#4,JOFO4
FO4:
 	JMP FO3

JOFO4:  
	CJNE A,#5,JOFO5
FO5:
 	INC R0
 	MOV A , @R0
 
 	CJNE A,#0,FO5_E1 		;E1 ERROR 1
 
  	INC R0
 	MOV A , @R0
 
 	MOV R6,A
 	CLR C
 	SUBB A,#COILNUM 		;numri total i coilave=coilnum
 	JNC FO5_E1
 
 	INC R0
 	MOV A , @R0
 
 	JZ FO5_00
 	CJNE A,#0FFH,FO5_E2
 
  	INC R0
 	MOV A , @R0
 
 	JNZ FO5_E2
 	CALL SETCOIL
 	JMP SENDMSG1

FO5_00: 
 	INC R0
 	MOV A , @R0
 
 	JNZ FO5_E2
 	CALL RESCOIL
 	JMP SENDMSG1

FO5_E1: 
 	JMP STADDERR

FO5_E2: 
 	JMP VALERR

JOFO5: 
 	CJNE A,#6,JOFO6

FO6:
	INC R0
 	MOV A , @R0
  
 	CJNE A,#0,FO6_E1
 
 	INC R0
 	MOV A , @R0

 	MOV R6,A
 	CLR C
 	SUBB A,#HREGNUM 		;numri total i regjistrave=hregnum
 	JNC FO6_E1
 
 	INC R0
 
 
 	CALL PRESREG
 	JMP SENDMSG1

FO6_E1: 
 	JMP STADDERR

JOFO6: 
 	CJNE A,#15,JOFO15
FO15:
 	INC R0
 	MOV A , @R0
  
 	JZ FO15_01
 	JMP STADDERR

FO15_01:
 	INC R0
 	MOV A , @R0
 
 	MOV R6,A
 	CLR C 
 	SUBB A,#COILNUM 		;numri total i coilave=coilnum
 	JC FO15_02
 	JMP STADDERR

FO15_02:
 	INC R0
 	MOV A , @R0
 
 	JZ FO15_03
 	JMP VALERR

FO15_03:
 	INC R0
 	MOV A , @R0
 
 	MOV R5,A
 	DEC A
 	ADD A,R6
 	CLR C
 	SUBB A,#COILNUM 		;numri total i coilave=coilnum
 	JC FO15_04
 	JMP VALERR

FO15_04:
 	MOV R4,#06H
 	CALL FOMCOIL
 	MOV R4,#06H
 	JMP SENDMSG

JOFO15:
 	CJNE A,#16,JOFO16

FO16:
	INC R0
 	MOV A , @R0
 
 	JZ FO16_01
 	JMP STADDERR

FO16_01:
 	INC R0
 	MOV A , @R0
 
 	MOV R6,A
 	CLR C
 	SUBB A,#HREGNUM 		;numri total i regjistrave
 	JC FO16_02
 	JMP STADDERR

FO16_02:
 	INC R0
 	MOV A , @R0
 
 	JZ FO16_03
 	JMP VALERR

FO16_03:
 	INC R0
 	MOV A , @R0
 
 	MOV R5,A
 	DEC A
 	ADD A,R6
 	CLR C
 	SUBB A,#HREGNUM 		;numri total i regjistrave
 	JC FO16_04
 	JMP VALERR

FO16_04:
 	MOV CounterModbus ,#06H
 	CALL PRESMREG
 	JMP SENDMSG

JOFO16:
;=================================Funksioni i ardhur gabim==============================;FUNCERR:
 	MOV A,#StartAddress
 	ADD A , #01
 	MOV R0 , A
 	MOV A , @R0

 	SETB ACC.7

 	MOV @R0 , A
 	INC R0
  
 	MOV A,#01H
 
 	MOV @R0 , A
 
 	MOV R4,#03H
 	JMP SENDMSG

ANALEND2:
 	RET 				;kthehet ne ANALIZA nga TOJO3

;============================Vlera e ardhur gabim======================================; 
VALERR:
 	MOV A,#StartAddress
 	ADD A , #01
 	MOV R0 , A
 	MOV A , @R0
 
 	SETB ACC.7
 
 	MOV @R0 , A
 	INC R0
 
 	MOV A,#03H
 
 	MOV @R0 , A
 
 	MOV R4,#03H
 	JMP SENDMSG 

;============================Adresa e ardhur gabim==================================;
STADDERR:
 	MOV A,#StartAddress
 	ADD A , #01
 	MOV R0 , A
 	MOV A , @R0
 
 	SETB ACC.7
  
 	MOV @R0 , A
 	INC R0
 	
 	MOV A,#02H
 	
 	MOV @R0 , A
 
 	MOV R4,#03H
 	JMP SENDMSG

SENDMSG:
 	MOV B , A
 	mov A ,#StartAddress
 	ADD A , CounterModbus
 	mov R0 , A
 	MOV A , B
 
 	MOV 07H,CounterModbus
 	CALL CALC_CRC
 	MOV A,0DH
 
 	MOV @R0 , A
 	INC R0
 
 	MOV A,0EH
 	MOV @R0 , A
 
 	INC CounterModbus
 	INC CounterModbus
;==========================Dergo mesazhin e njejt qe ka ardhur ==========================;
SENDMSG1: 				;reply i njejte tx=rx pa llogaritje
 	MOV GjendjaDergimit,#0 			;te CRC-se
 	SETB TI
 
  		RET

CALC_CRC:
;kalkulon crc ne karakteret e shkruar ne memorie extprej4000h dherezulratin
;e vendose ne 0D,0E praR5,R6banka1
;perdore R4=numri char te pranuar,R7=R4=DPL pastaj behet 0 dhe R6=8bitne bajt

 	MOV CRC_ACCUM_LOW,#0FFH 	;fshihet crc accum para fillimit
 	MOV CRC_ACCUM_HI,#0FFH
 
 	MOV R0 ,#StartAddress 
 	MOV B , R7
 	
 ;push 07H ;e ruajm R7=07H direkt
; XOR bajti i pare me bajtin e ulet te CRC
;
CC10:
 	MOV A , @R0
 
 	XRL A,CRC_ACCUM_LOW
 	MOV CRC_ACCUM_LOW,A
 	MOV R6,#8 			;R6 sherben si numrues i 8 bitave ne bajt
CC20:
 	MOV A , CRC_ACCUM_HI 		;merret bajti i larte
 	CLR C 				;mbushet me 0
 	RRC A 				;shiftohet djathtas
 	MOV CRC_ACCUM_HI , A
 	MOV A , CRC_ACCUM_LOW 		;dhe per bajtin e ulet
 	RRC A 				;shiftohet djathtas
 	MOV CRC_ACCUM_LOW,A
 	JNC CC30
 	MOV A , CRC_ACCUM_LOW
 	XRL A , #CRC_MASK_LSB
 	MOV CRC_ACCUM_LOW , A
 	MOV A , CRC_ACCUM_HI
 	XRL A , #CRC_MASK_MSB
 	MOV CRC_ACCUM_HI , A

CC30:
 	DJNZ R6 , CC20 			;perseritet tete here
 	INC R0
 
 	DJNZ R7 , CC10 			;nje bajt me pak per te llogarite
 	;pop 07H
 	MOV R7 , B
 	
 		 RET

;***************************************
;Set coil rutina
;Coili qe setohet ne R6
SETCOIL:
 	MOV A , R6
 	ANL A , #07H
 	INC A
 	MOV R1 , A
 	MOV A , #00H
 	SETB C

SC_001: 
 	RLC A
 
 	DJNZ R1,SC_001
 
 	MOV R1,A
 	MOV A,R6
	ANL A,#0F8H
 	RR A
 	RR A
 	RR A
 	ADD A ,#ShareMemory
 	MOV R0,A
 	MOV A,@R0
 	ORL A,R1
 	MOV @R0,A
	 
 		RET

RESCOIL:
 	MOV A,R6
 	ANL A,#07H
 	INC A
 	MOV R1,A
 	MOV A,#00H
 	SETB C

RC_001: 
 	RLC A
 	
 	DJNZ R1,RC_001
 
 	CPL A
 	MOV R1,A
 	MOV A,R6
 	ANL A,#0F8H
 	RR A
 	RR A
 	RR A
 	ADD A,#ShareMemory
 	MOV R0,A
 	MOV A,@R0
 	ANL A,R1
 	MOV @R0,A
 
 	 	RET
 	 	
;preset i nje regjistri presreg
PRESREG:
	MOV A,R6
 	RL A
 	ADD A,#ShareMemory
 	INC A
 	MOV R1,A  ;******************** R0 eshte bere R1
 
 	MOV A , @R0
  
 	MOV @R1,A
 	DEC R1
 	INC R0
 	MOV A , @R0
 
 	MOV @R1,A
  		
  		RET
;Testbit:
;gjendja e bitit qe testohet bartet ne carry C,
;R6 permban adresen e bitit qe testohet(0-127)

TESTBIT:
 	MOV R0 , #3FH
 
 	MOV A,#72H			;kodi i ORL C,BIT
 
 	MOV @R0 , A
 	INC R0
 
 	MOV A,R6			;parametri BIT i ORL me lart
 
 	MOV @R0 , A
 	INC R0
 
 	MOV A,#22H			;kodi i RET
 
 	MOV @R0 , A
  
 	CLR C
 	LJMP 3FH

;R7 regjistri i rezultatit te perkohshem per nje bajt
;R5 sasia e bitave qe lexohen
;R6 adresa e bitit fillestar

READCOIL:
 	MOV A,R5
 	DEC A
 	ANL A,#0F8H
 	RR A
 	RR A
 	RR A
 	INC A

 	PUSH ACC
 	mov A ,#StartAddress
 	ADD A , R4
 	mov R0 , A
 	POP ACC
 	MOV @R0 , A

	MOV CounterModbus , #3
 	INC R4		;3

	MOV A , R6
	MOV B , #8
	DIV AB		;A - heresi, adresa e byte-it B - mbetja, pozita e bitit brenda byte-it
	ADD A, #ShareMemory

	MOV R0 , ACC
	MOV A , @R0
	RR A
	DJNZ B,$-1
	MOV B , R5
	PUSH ACC
	CLR A

	SETB C
	RLC A
	DJNZ B , $-2
	MOV B , A
	POP ACC
	ANL A , B
	MOV B , A
	MOV A , #StartAddress
	ADD A , R4
	MOV R0 , A
	MOV A , B
	MOV @R0 , A
	INC CounterModbus
; 	CLR C
; 	MOV A,R5
;
;TB_03: 
; 	SUBB A,#9
; 	JNC TB_01
; 	MOV A,#00H
; 	PUSH ACC
; 	SJMP TB_02
;
;TB_01: 
; 	INC A
; 	PUSH ACC
; 	MOV R5,#8
;
;TB_02: 
; 	MOV R7,#00H
; 	MOV A,R5
; 	ADD A,R6
; 	MOV R6,A
; 	PUSH 06H
;
;TB_00: 
; 	DEC R6
; 	LCALL TESTBIT
; 	MOV A,R7
; 	RLC A
; 	MOV R7,A
; 	DJNZ R5,TB_00
; 	POP 06H
;
; 	mov A ,#StartAddress
; 	ADD A , R4
; 	mov R0 , A
; 
; 
; 	MOV A,R7
; 	MOV @R0 , A
; 
; 	INC R4
; 	POP ACC
; 	JNZ TB_03
  		
  		RET

;readreg
;leximi i regjistrave
;R6 start adress,R5 count
;=============================== Lexo regjister =========================================;
READREG:

 	MOV A,R5
 	RL A

 	MOV B , A
 	mov A ,#StartAddress
 	ADD A , CounterModbus
 	mov R0 , A
 	MOV A , B
 	mov @R0, A
 	INC R0
 
 	INC CounterModbus
 	MOV A,R6
 	ADD A,#ShareMemory
 	MOV R1,A			;Ndryshim R0 eshte bere R1

RR_00: 
 	MOV A,#00
 	MOV @R0 , A
 	INC R0
 
 	INC CounterModbus
 	MOV A,@R1

	MOV @R0 , A
 	INC R0
 
 	INC CounterModbus
 	INC 01H
 	DJNZ R5,RR_00

  		RET
  		
;presreg=preset register
;shkruarja e regjistrave
;R6 start adress,R5 count
;=========================== Shkruaj ne disa regjistra ====================================;
PRESMREG:

 	MOV A ,#StartAddress
 	ADD A , CounterModbus
 	mov R0 , A
 	INC R0
 
 	MOV A,R6
 	ADD A,#ShareMemory
 	MOV R1,A

PMR_00: 
 	INC 01H
  	MOV A , @R0
 
 	MOV @R1,A ;****************
 	INC R0
 
 	DEC 01H
 
 	MOV A , @R0
 
 	MOV @R1,A ;****************
 	INC R0
 
 	INC 01H
 	INC 01H
 	DJNZ R5,PMR_00 ;****************

 		RET

;Forcebit:
;carry C bartet ne bitin e adresuar
;R6 permban adresen e bitit qe vendoset(0-127)

FORCEBIT:
 	JC FB_00 
 	MOV R0 , #3FH 
 
 	MOV A,#0C2H			;kodi i CLR BIT 
 	MOV @R0 , A 
 	INC R0
 
 	MOV A,R6			;parametri BIT i ORL me lart
 	MOV R0 , A
 	INC R0
 
 	MOV A,#22H			;kodi i RET 
 	MOV @R0 , A
 
 	LJMP 3FH
 
FB_00: 
 	MOV R0 , #3FH
 
 	MOV A,#0D2H			;kodi i SET BIT
 
 	MOV @R0 , A
 	INC R0
 
 	MOV A,R6			;parametri BIT i ORL me lart
 
 	MOV @R0 , A
 	INC R0
 
 	MOV A,#22H			;kodi i RET
 
 	MOV @R0 , A
 	LJMP 3FH
 	
;R7 regjistri i rezultatit te perkohshem per nje bajt
;R5 sasia e bitave qe lexohen
;R6 adresa e bitit fillestar
FOMCOIL:
 	MOV A,R5

FMC_03: 
 	SUBB A,#9
 	JNC FMC_01
 	MOV A,#00H
 	PUSH ACC
 	SJMP FMC_02

FMC_01: 
 	INC A
 	PUSH ACC
 	MOV R5,#8

FMC_02: 
 	INC R4
	mov A ,#StartAddress
 	ADD A , R4
 	mov R0 , A
 	mov A , @R0 
 
 	MOV R7,A

FMC_00: 
 	MOV A,R7
 	RRC A
 	MOV R7,A
 	CALL FORCEBIT
 	INC R6
 	DJNZ R5,FMC_00
 	POP ACC
 	JNZ FMC_03
 	MOV A,20H
	;CPL A				;Percaktimi i logjikes 1/0, on/off
 	MOV P1,A 			;Bartja e coilave ne portin P1
 	
  		RET		
  		

	END




