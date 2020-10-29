# BlockChainProj
Šioje repozitorijoje bus kuriamas ir versijuojamas BlockChain projektas ISI 2kr.

## Paleidimo instrukcijos
- Atidaryti Developer Command Promt for VS 20**
- Ieiti i Projekto kataloga per command promt
- Ivesti i terminala komandas paeiliui:
```
csc Program.cs Operations.cs
Program *pirmojo failo pavadinimas* *antrojo tekstinio failo pavadinimas*
ARBA
Program *vienintelio tekstinio failo pavadinimas
```

## Hashavimo algoritmo pseudo-kodas.
c1-c8 yra atsitiktinės binary reikšmės (konstantos).
```
CREATE T1-T8 empty strings;

FOREACH in SPLIT STRING DO
{
	T1 = ADD SPLIT STRING AND c1;
	T1 = ROTATE T1 BY 10;
	T1 = ROTATE T1 BY 25;
	T1 = SHIFT T1 BY;

	T2 = ADD SPLIT STRING AND c2;
	T2 = ROTATE T2 BY 42;
	T2 = SIGFT T2 BY 5;

	T3 = ADD SPLIT STRING AND c3
	T3 = ROTATE T3 BY 22;
	T3 = SHIFT T3 BY 4;

	T4 = ADD SPLIT STRING AND c4;
	T4 = ROTATE T4 BY 33;
	T4 = SHIFT T4 BY 3;

	T5 = ADD SPLIT STRING AND c5;
	T5 = ROTATE T5 BY 18;
	T5 = SHIFT T5 BY 8;

	T6 = ADD SPLIT STRING AND c6;
	T6 = ROTATE T6 BY 37;
	T6 = SHIFT T6 BY 4;

	T7 = ADD SPLIT STRING AND c7;
	T7 = ROTATE T7 BY 18;
	T7 = SHIFT T7 BY 6;

	T8 = ADD SPLIT STRING AND c8;
	T8 = ROTATE T8 BY 29;
}

FOR FROM 0 TO 32
{
	T8 = T7;
	T7 = T6;
	T6 = T5;
	T5 = T4;
	T4 = T3;
	T3 = T2;
	T2 = T1;
	T1 = ADD T1 AND T8;
	T1 = ADD T1 AND T2;
	T5 = ADD T5 AND T1;
}

CREATE NEW STRING LIST T;

T.ADD(T1+T2);
T.ADD(T1+T3);
T.ADD(T2+T4);
T.ADD(T3+T5);
T.ADD(T4+T7);
T.ADD(T5+T8);
T.ADD(T7+T2);

CREATE NEW STRING Tt;

FOR FROM 8 TO 64 AS i
{
	Tt = ROTATE T1[i-8] BY 14;
	Tt = ADD T[i-8] AND T[i-5];
	Tt = ROTATE Tt BY 6;
	T.ADD(Tt);
}

FOR FROM 0 TO 62 AS i
{
	T8 = T7;
    T7 = T6;
    T6 = T5;
    T5 = T4;
    T4 = T3;
    T3 = T2;
    T2 = T1;
    T1 = ADD T[i] AND T[i+1];
    T5 = ADD T5 AND T[i];
}

ANSWER += T1;
ANSWER += T2;
ANSWER += T3;
ANSWER += T4;
ANSWER += T5;
ANSWER += T6;
ANSWER += T7;
ANSWER += T8;

RETURN ANSWER;
```

## Eksperimentinis tyrimas - analizė

## Hashavimo algoritmas grąžina 32 simbolių ilgio žodį.

## 1. Sukūrtos 4 failų kategorijos:
- 1.1. Du failai sudaryti iš vieno, tačiau skirtingo simbolio  
Failas su simboliu A.  
**Hash: 7FC56270E7A70FA81A5935B72EACBE29**  
Failas su simboliu B.  
**Hash: 3A3EA00CFC35332CEDF6E5E9A32E94DA**  
- 1.2. Du failai sudaryti iš daugiau nei 1000 atsitiktinai sugeneruotų simbolių  
Pirmas failas.  
**Hash: 0A2CFBD452B48991B91272233EF56C32**  
Antras failas.  
**Hash: 68A9C75FDFA3C10251D0486590E1E18B**  
- 1.3. Du failai sudaryti iš daugiau nei 1000 atsitiktinai sugeneruotų simbolių, tačiau tarp jų skiriasi tik vienas simbolis.  
Pirmas failas.  
**Hash: CF0DC0BB8E6D6EA99E03C328563D6F87**  
Antras failas.  
**Hash: 791C00FD665040800D710E4D3AC479D1**  
- 1.4 Failas iš 0 simbolių (Tuščias failas).  
**Hash: D41D8CD98F00B204E9800998ECF8427E**

## 2. Hashuojamas tekstinis failas konstitucija.txt
![Rezultatai](https://i.imgur.com/gAyECAS.png)

## 3. Hashuojamas 100 000 atsitiktinių simbolių eilučių failas, kuriame:
- 25 000 porų yra 10 ilgio.
- 25 000 porų yra 100 ilgio.
- 25 000 porų yra 500 ilgio.
- 25 000 porų yra 1000 ilgio.  
Rezultatai:  
![Rezultatai](https://i.imgur.com/Dxspbdc.png)

## 4. Hashuojamas 100 000 atsitiktinių porų simbolių eilučių failas, tačiau porose skiriasi tik vienas simbolis, kuriame:
- 25 000 porų yra 10 ilgio.
- 25 000 porų yra 100 ilgio.
- 25 000 porų yra 500 ilgio.
- 25 000 porų yra 1000 ilgio.  
Rezultatai:  
![Rezultatai](https://i.imgur.com/uWywANC.png)

## 5. Hashavimo algoritmo palyginimas su populiaru MD5 algoritmu

Testuoti buvo naudojami 3. ir 4. punktuose naudojami duomenų failai.  
Pasirinktas būtent MD5 algoritmas, todėl kad jis yra šiek tiek paprastesnis nei SHA256, išvedamas mažesnis simbolių kiekis bei algoritmas yra visiškai kitokio tipo nei mano sukūrtasis.  
Matuojama tik dviejų po 100 000 žodžių turinčių failų greitaveika, kadangi vieno žodio arba vieno simbolio hashavimas yra visiškai skirtingas, laikai bus panašūs, o išvesto rezultato dydis bus visiškai kitoks.  
Rezultatai:  
### Su 3. punkto duomenų failu:  
![Rezultatai](https://i.imgur.com/i80tfJ2.png)
### Su 4. punkto duomenų failu:  
![Rezultatai](https://i.imgur.com/W9NlHR3.png)

## Išvados
- Algoritmas nėra labai greitas
- Pasirinkus C# programavimo kalbą, nebuvo apsvarstyta, jog nėra "pointers", todėl algoritmas gana lėtai veikia
- Kuo panašesni hashuojami žodžiai, tuo panašesnis rezultatas.
- Algoritmas yra dar vis tobulinamas
- Naudojama kompresija, išvedamas 32 simbolių rezultatas.
