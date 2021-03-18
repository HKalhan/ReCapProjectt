create database RentalCarDb;

CREATE TABLE Brands (
    BrandId int NOT NULL,
    BrandName varchar(50),
    PRIMARY KEY (BrandId)
);

CREATE TABLE Colors (
    ColorId int NOT NULL,
    ColorName varchar(25),
    PRIMARY KEY (ColorId)
);

CREATE TABLE Cars (
    CarId int NOT NULL,
    BrandId int,
    ColorId int,
    ModelYear int,
    DailyPrice decimal(15),
    Description varchar(150),
    PRIMARY KEY (CarId),
    FOREIGN KEY (BrandId) REFERENCES Brands(BrandId),
    FOREIGN KEY (ColorId) References Colors(ColorId)
);



