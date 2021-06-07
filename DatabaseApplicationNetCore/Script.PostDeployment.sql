/*
Modello di script post-distribuzione							
--------------------------------------------------------------------------------------
 Questo file contiene istruzioni SQL che verranno aggiunte allo script di compilazione		
 Utilizzare la sintassi SQLCMD per includere un file nello script post-distribuzione			
 Esempio:      :r .\myfile.sql								
 Utilizzare la sintassi SQLCMD per fare riferimento a una variabile nello script post-distribuzione		
 Esempio:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
