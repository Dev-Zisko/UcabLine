-- create database ucabline

use ucabline;

-- CREAR TABLA CLIENTES

-- CREATE TABLE Lineas (
 -- 	idLinea int NOT NULL AUTO_INCREMENT,
   -- Linea VARCHAR(50) NOT NULL,
   -- Estado VARCHAR(50) NOT NULL,
-- 	Trenes int NOT NULL,
  --  Tipo VARCHAR(50) NOT NULL,
   -- PRIMARY KEY (idLinea)
-- )  ENGINE=InnoDB;

-- CREAR TABLA VENTAS

-- CREATE TABLE Estaciones (
	-- idEstacion int NOT NULL AUTO_INCREMENT,
    -- Estacion VARCHAR(50) NOT NULL,
    -- Estado VARCHAR(50) NOT NULL,
	-- idLinea int NOT NULL,
    -- Tiempo VARCHAR(50) NOT NULL,
    -- PRIMARY KEY (idEstacion),
    -- CONSTRAINT idLinea FOREIGN KEY (idLinea)
     --   REFERENCES Lineas (idLinea)
-- )  ENGINE=InnoDB;

-- CREAR TABLA PRODUCTOS

-- CREATE  TABLE TrasbordosDobles
 -- (
  -- idTrasbordoD int NOT NULL auto_increment,
  -- Estacion1 VARCHAR(45) NOT NULL,
  -- Estacion2 VARCHAR(45) NOT NULL,
  -- Linea1 VARCHAR(45) NOT NULL,
  -- Linea2 VARCHAR(45) NOT NULL,
  -- PRIMARY KEY (idTrasbordoD) 
-- )ENGINE=InnoDB;


 CREATE TABLE TrasbordosSimples(
    idTrasbordoS int NOT NULL AUTO_INCREMENT,
 	Estacion VARCHAR(50) NOT NULL,
    idLinea int NOT NULL,
    PRIMARY KEY (idTrasbordoS),
    CONSTRAINT idL FOREIGN KEY (idLinea)
        REFERENCES Lineas (idLinea)
)  ENGINE=InnoDB;


-- CREAR TABLA ADMINISTRADOR

-- CREATE  TABLE Administradores
-- (
 -- idAdministrador int NOT NULL auto_increment,
 -- Usuario VARCHAR(45) NOT NULL,
 -- Contraseña VARCHAR(45) NOT NULL,
 -- PRIMARY KEY (idAdministrador)
-- )ENGINE=InnoDB;
