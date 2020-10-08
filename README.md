# BlockChainProj
Šioje repozitorijoje bus kuriamas ir versijuojamas BlockChain projektas ISI 2kr.

## Paleidimo instrukcijos
- Atidaryti Developer Command Promt for VS 20**
- Ieiti i Projekto kataloga BlockChainProject per command promt
- Ivesti i terminala komandas paeiliui:
```
csc Program.cs Operations.cs
Program *tekstinio failo pavadinimas*
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

## Hashavimo algoritmas grąžina 144 simbolių ilgio žodį.

## 1. Sukūrtos 4 failų kategorijos:
- 1.1. Du failai sudaryti iš vieno, tačiau skirtingo simbolio  
Failas su simboliu A. **Hash: 4E4DB6721439E4DAA26319FF7869C9679D3049439DFB7B300B6044FDC2217511B8D88CF70C36EB8A12B6DA2DD20BF2374559B147C3DB95FA1F86043325FC1A5F**  
Failas su simboliu B. **Hash: DD66383160DEA77F37CE17A64A3679D5AF8FF30D8C964D039ECD4AA787DA0FB92BF302AD492FE4B5DDA46E34E3F5A4DE146D8D9548B03F3B74F1A0F93FFC002D**  
- 1.2. Du failai sudaryti iš daugiau nei 1000 atsitiktinai sugeneruotų simbolių  
Pirmas failas. **Hash: 190323FB13A184888278E248FFF4E06E297D025A46147F7B81D9D4A332AAF22601C9D08D7AFD86C0A8DA738DBDCCE51C9710BEF0268B377F6BDD1AF819D6C9F5**  
Antras failas. **Hash: 9D1303F313238E880678C240BEF46A0EA96DA2526794E51B05D9F4AB7B28780685D9F085337D9C80ACCAF38DF4CEF51D17301EE8470BBD5E6BD598F859D6C9B4**  
- 1.3. Du failai sudaryti iš daugiau nei 1000 atsitiktinai sugeneruotų simbolių, tačiau tarp jų skiriasi tik vienas simbolis.  
Pirmas failas. **Hash: D92B81F732A11EE84A604054FFDEF23EE175204E06B66D2841E1F6BD1A83E076C1C1F29352721CA2A0EA738FB443F51E53281CE42425252F61D519F819DED9F4**  
Antras failas. **Hash: 4E4DB6721439E4DAA26319FF7869C9679D3049439DFB7B300B6044FDC2217511B8D88CF70C36EB8A12B6DA2DD20BF2374559B147C3DB95FA1F86043325FC1A5F**  
- 1.4 Failas iš 0 simbolių (Tuščias failas).  
**Hash: 4E4DB6721439E4DAA26319FF7869C9679D3049439DFB7B300B6044FDC2217511B8D88CF70C36EB8A12B6DA2DD20BF2374559B147C3DB95FA1F86043325FC1A5F**

## 2. Hashuojamas tekstinis failas konstitucija.txt
![Rezultatai](https://i.imgur.com/9HAdLIp.png)

## 3. Hashuojamas 100 000 atsitiktinių simbolių eilučių failas, kuriame:
- 25 000 porų yra 10 ilgio.
- 25 000 porų yra 100 ilgio.
- 25 000 porų yra 500 ilgio.
- 25 000 porų yra 1000 ilgio.
Rezultatai:
![Rezultatai](https://i.imgur.com/U6eVUOe.png)

## 4. Hashuojamas 100 000 atsitiktinių porų simbolių eilučių failas, tačiau porose skiriasi tik vienas simbolis, kuriame:
- 25 000 porų yra 10 ilgio.
- 25 000 porų yra 100 ilgio.
- 25 000 porų yra 500 ilgio.
- 25 000 porų yra 1000 ilgio.
Rezultatai:
![Rezultatai](https://i.imgur.com/s5XHoC5.png)

## Išvados
- Algoritmas nėra labai greitas
- Pasirinkus C# programavimo kalbą, nebuvo apsvarstyta, jog nėra "pointers", todėl algoritmas gana lėtai veikia
- Kuo panašesni hashuojami žodžiai, tuo panašesnis rezultatas.
- Algoritmas yra dar vis tobulinamas
- Naudojama kompresija, išvedamas 144 simbolių rezultatas.