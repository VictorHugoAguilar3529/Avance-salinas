Create Database InvertarioVentaDB;
go

CREATE TABLE Productos
(
Id INT PRIMARY KEY IDENTITY(1,1),
NumeroFactura nvarchar(50) NOT NULL,
Codigo nvarchar(50),
Nombre nvarchar(50),
Existencias int not null,
Precio decimal(18,2)
);
Go

CREATE TABLE Facturas
(
Id INT PRIMARY KEY IDENTITY(1,1),
NumeroFactura nvarchar(50) NOT NULL,
Fecha DATETIME NOT NULL,
Total DECIMAL(18,2),
);
Go

CREATE TABLE ProductoFacturas
(
ProductoId INT not null,
FacturaId INT not null,
Cantidad INT not null,
PRIMARY KEY (ProductoId, FacturaId),
FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
FOREIGN KEY (FacturaId) REFERENCES Facturas(Id),
);
Go