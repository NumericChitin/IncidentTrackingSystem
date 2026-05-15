-- 1. Създаване на базата данни (опционално, ако вече нямаш такава)
CREATE DATABASE IncidentSystemDB;
GO
USE IncidentSystemDB;
GO

-- 2. Таблица за типовете инциденти
CREATE TABLE IncidentTypes (
    ID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Type NVARCHAR(64) NOT NULL
);

-- 3. Таблица за потребителите
CREATE TABLE Users (
    ID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(32) NOT NULL,
    Password NVARCHAR(16) NOT NULL
);

-- 4. Таблица за отделите
CREATE TABLE Departments (
    ID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(64) NOT NULL
);

-- 5. Таблица за техниците
CREATE TABLE Technicians (
    ID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(32) NOT NULL,
    TypeSpecialised INT NULL,
    CONSTRAINT FK_Technicians_TypeSpecialised FOREIGN KEY (TypeSpecialised) 
        REFERENCES IncidentTypes(ID)
);

-- 6. Таблица за инцидентите
CREATE TABLE Incidents (
    ID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(64) NOT NULL,
    Type INT NOT NULL,
    DateCreated DATE NOT NULL DEFAULT GETDATE(),
    DateResolved DATE NULL,
    Description NVARCHAR(128) NOT NULL,
    CONSTRAINT FK_Incidents_Type FOREIGN KEY (Type) 
        REFERENCES IncidentTypes(ID)
);

-- 7. Свързваща таблица между техници и отдели (Many-to-Many)
CREATE TABLE DepartmentTechnicians (
    ID INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    TechnicianID INT NOT NULL,
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_TechnicianID FOREIGN KEY (TechnicianID) 
        REFERENCES Technicians(ID),
    CONSTRAINT FK_DepartmentID FOREIGN KEY (DepartmentID) 
        REFERENCES Departments(ID)
);