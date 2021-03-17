CREATE TABLE Classe(
ID INT NOT NULL UNIQUE IDENTITY(1,1),
Nome VARCHAR(255) NOT NULL,
IsEroe BIT NOT NULL,
CONSTRAINT PK_Classe PRIMARY KEY(ID)
);

INSERT INTO Classe VALUES('Guerriero',1);
INSERT INTO Classe VALUES('Troll',0);
INSERT INTO Classe VALUES('Demone',0);

SELECT * FROM Classe;

CREATE TABLE Arma(
ID INT NOT NULL UNIQUE IDENTITY(1,1),
Nome VARCHAR(255) NOT NULL,
PuntiDanno INT,
ClasseID INT NOT NULL FOREIGN KEY REFERENCES Classe(ID),
CONSTRAINT PK_Arma PRIMARY KEY(ID)
);

INSERT INTO Arma VALUES('Spada',5,1);
INSERT INTO Arma VALUES('Arco',3,1);
INSERT INTO Arma VALUES('Magia del Fuoco',5,2);
INSERT INTO Arma VALUES('Magia del Ghiaccio',4,2);

INSERT INTO Arma VALUES('Ascia',2,3);
INSERT INTO Arma VALUES('Bastone',1,3);
INSERT INTO Arma VALUES('Magia del Fuoco',5,4);

SELECT * FROM Arma;
SELECT * FROM Classe;


/*query per resituire le armi quel tipo di classe*/
SELECT * FROM Arma
INNER JOIN Classe ON ClasseID = Classe.ID
WHERE Classe.ID=1;

SELECT * FROM Arma WHERE ClasseID = 1;

CREATE TABLE Livello(
Livello INT NOT NULL PRIMARY KEY(Livello),
PuntiVita int NOT NULL
);

INSERT INTO Livello VALUES (1,20);
INSERT INTO Livello VALUES (2,40);
INSERT INTO Livello VALUES (3,60);
INSERT INTO Livello VALUES (4,80);
INSERT INTO Livello VALUES (5,100);

SELECT * FROM Livello;

CREATE TABLE PassaggioLivello(
Livello INT NOT NULL PRIMARY KEY(Livello),
PuntiAccumulati int NOT NULL
);

INSERT INTO PassaggioLivello VALUES (1,0);
INSERT INTO PassaggioLivello VALUES (2,30);
INSERT INTO PassaggioLivello VALUES (3,60);
INSERT INTO PassaggioLivello VALUES (4,90);
INSERT INTO PassaggioLivello VALUES (5,120);

SELECT * FROM PassaggioLivello;

DROP TABLE Livello;


CREATE TABLE Giocatore(
ID INT NOT NULL UNIQUE IDENTITY(1,1),
Nome VARCHAR(255) NOT NULL UNIQUE,
Ruolo BIT NOT NULL,
CONSTRAINT PK_Giocatore PRIMARY KEY(ID)
);



SELECT * FROM Giocatore;


CREATE TABLE Eroe(
ID INT NOT NULL UNIQUE IDENTITY(1,1),
Nome VARCHAR(255) NOT NULL UNIQUE,
ClasseID INT NOT NULL FOREIGN KEY REFERENCES Classe(ID),
ArmaID INT NOT NULL FOREIGN KEY REFERENCES Arma(ID),
IsEroe BIT NOT NULL,
PuntiVita INT NOT NULL,
Livello INT NOT NULL,
PuntiAccumulati INT NOT NULL,
GiocatoreID INT NOT NULL FOREIGN KEY REFERENCES Giocatore(ID),
CONSTRAINT PK_Eroe PRIMARY KEY(ID)
);

INSERT INTO Giocatore VALUES('Mery',0);
SELECT * FROM Giocatore;
SELECT * FROM Arma;
SELECT * FROM Classe;

INSERT INTO Eroe VALUES('Steev',2,2,1,20,1,0,1);
SELECT * FROM Eroe;

UPDATE Giocatore SET Nome='Anna', Ruolo=1 WHERE ID=2;