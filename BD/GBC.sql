DROP DATABASE IF EXISTS GestionBuenCosermu;

CREATE DATABASE GestionBuenCosermu;
USE GestionBuenCosermu;

/**
*  Creacion de tablas
*/

CREATE TABLE tbRol(
	IdRol INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NombreRol  VARCHAR(15) NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT AK_IdRol UNIQUE (IdRol)
);

CREATE TABLE tbEmpleado (
    IdEmpleado INT NOT NULL IDENTITY(1,1),
    Cedula VARCHAR(15) NOT NULL,
    Foto image,
    Nombre VARCHAR(60) NOT NULL,
    Apellido1 VARCHAR(60) NOT NULL,
    Apellido2 VARCHAR(60) NOT NULL,
    TelefonoEmpleado VARCHAR(11) NOT NULL,
    CorreoEmpleado VARCHAR(25) NOT NULL,
    Direccion VARCHAR(255) NOT NULL,
    Contrasena VARCHAR(500) NOT NULL,
    NombreContacto VARCHAR(255) NOT NULL,
    TelefonoContacto VARCHAR(11) NOT NULL,
    Activo BIT NOT NULL,
    IdRol INT NOT NULL,
    CONSTRAINT PK_IdEmpleado PRIMARY KEY (IdEmpleado),
    CONSTRAINT AK_Cedula UNIQUE (Cedula),
    CONSTRAINT FK_Empleado_Rol FOREIGN KEY (IdRol) REFERENCES tbRol(IdRol)
 );

CREATE TABLE tbBitacora (
    IdBitacora INT NOT NULL IDENTITY(1,1),
    CodError INT NOT NULL,
    Descripcion VARCHAR(2500) NOT NULL,
    FechaHora DATETIME NOT NULL,
    Origen VARCHAR(500) NOT NULL,
    IdEmpleado INT NOT NULL,
    CONSTRAINT PK_IdBitacora PRIMARY KEY (IdBitacora),
    CONSTRAINT AK_IdBitacora UNIQUE (IdBitacora),
    CONSTRAINT FK_Empleado FOREIGN KEY (IdEmpleado) REFERENCES tbEmpleado(IdEmpleado)
);

CREATE TABLE tbArticulo (
    IdArticulo INT NOT NULL IDENTITY(1,1),
    NombreArticulo  VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,
    Cantidad INT NOT NULL,
    CostoArticulo DECIMAL(12,2) NOT NULL,
    PuntoReorden INT NOT NULL,
    NumPlaca VARCHAR(20),
    NumParte VARCHAR(20) NOT NULL,
    NumSerie VARCHAR(20),
    VidaUtil DATETIME NOT NULL,
    FechaFinGarantia DATETIME NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT PK_IdArticulo PRIMARY KEY (IdArticulo),
    CONSTRAINT AK_Articulo_NumSerie_NumParte UNIQUE (IdArticulo,NumSerie,NumParte)
);

CREATE TABLE tbCliente (
    IdCliente INT NOT NULL IDENTITY(1,1),
    NombreCliente  VARCHAR(70) NOT NULL,
    CorreoCliente VARCHAR(50) NOT NULL,
    PersonaContacto VARCHAR(100) NOT NULL,
    DireccionCliente VARCHAR(100) NOT NULL,
    TelefonoCliente VARCHAR(12) NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT PK_IdCliente PRIMARY KEY (IdCliente),
    CONSTRAINT AK_IdCliente UNIQUE (IdCliente)
);

CREATE TABLE tbProveedor(
    IdProveedor INT NOT NULL IDENTITY(1,1),
    NombreProveedor  VARCHAR(70) NOT NULL,
    CorreoProveedor VARCHAR(50) NOT NULL,
    NombreContacto VARCHAR(100) NOT NULL,
    DireccionProveedor VARCHAR(100) NOT NULL,
    TelefonoProveedor VARCHAR(14) NOT NULL,
    ProductoProveedor VARCHAR(300) NOT NULL,
    Activo BIT NOT NULL,
    CONSTRAINT PK_IdProveedor PRIMARY KEY (IdProveedor),
    CONSTRAINT AK_IdProveedor UNIQUE (IdProveedor)
);

CREATE TABLE tbDatosVenta(
    IdVenta INT NOT NULL IDENTITY(1,1),
    NumFacturaVenta VARCHAR(50) NOT NULL,
    FechaCompra DATETIME,
    Cantidad INT NOT NULL,
    PrecioUnitario Decimal(10,2) NOT NULL,
    ImpuestoVenta Decimal(8,2) NOT NULL,
    SubTotalVenta Decimal(10,2) NOT NULL,
    TotalVenta Decimal(10,2) NOT NULL,
    FechaVenta DATETIME NOT NULL,
    IdArticulo INT NOT NULL,
    IdCliente INT NOT NULL,
    CONSTRAINT PK_IdVenta PRIMARY KEY (IdVenta),
    CONSTRAINT FK_Venta_Articulo FOREIGN KEY (IdArticulo) REFERENCES tbArticulo(IdArticulo),
    CONSTRAINT FK_Venta_Cliente FOREIGN KEY (IdCliente) REFERENCES tbCliente(IdCliente),
    CONSTRAINT AK_IdVenta UNIQUE (IdVenta)
);


CREATE TABLE tbDatosCompra(
    IdCompra INT NOT NULL IDENTITY(1,1),
    NumFacturaCompra VARCHAR(50) NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario Decimal(10,2) NOT NULL,
    ImpuestoCompra Decimal(8,2) NOT NULL,
    SubTotalCompra Decimal(10,2) NOT NULL,
    TotalCompra Decimal(10,2) NOT NULL,
    FechaCompra DATETIME NOT NULL,
    IdProveedor INT NOT NULL,
    IdArticulo INT NOT NULL,
    CONSTRAINT PK_IdCompra PRIMARY KEY (IdCompra),
    CONSTRAINT FK_Compra_Proveedor FOREIGN KEY (IdProveedor) REFERENCES tbProveedor(IdProveedor),
    CONSTRAINT FK_Compra_Articulo FOREIGN KEY (IdArticulo) REFERENCES tbArticulo(IdArticulo),
    CONSTRAINT AK_IdCompra UNIQUE (IdCompra)
);

CREATE TABLE tbTipo(
    IdTipo INT NOT NULL IDENTITY(1,1),
    NombreSoporte  VARCHAR(50) NOT NULL,
    CONSTRAINT PK_IdTipo PRIMARY KEY (IdTipo),
    CONSTRAINT AK_Tipo UNIQUE (IdTipo)
);

CREATE TABLE tbSoporte(
    IdSoporte INT NOT NULL IDENTITY(1,1),
    DescripcionSoporte VARCHAR(5000) NOT NULL,
    FechaAgendada DATETIME NOT NULL,
    FechaCierreSoporte DATETIME NOT NULL,
    Estatus VARCHAR(30) NOT NULL,
    IdCliente INT NOT NULL,
    IdEmpleado INT NOT NULL,
    IdTipo INT NOT NULL,
    CONSTRAINT PK_IdSoporte PRIMARY KEY (IdSoporte),
    CONSTRAINT AK_Soporte UNIQUE (IdSoporte),
    CONSTRAINT FK_Soporte_Cliente FOREIGN KEY (IdCliente) REFERENCES tbCliente(IdCliente),
    CONSTRAINT PK_Soporte_Empleado FOREIGN KEY (IdEmpleado) REFERENCES tbEmpleado(IdEmpleado),
    CONSTRAINT PK_Soporte_Tipo FOREIGN KEY (IdTipo) REFERENCES tbTipo(IdTipo)
);

CREATE TABLE tbEmpleadoSoporte(
    IdEmpleadoSoporte INT NOT NULL IDENTITY(1,1),
    IdEmpleado INT NOT NULL,
    IdSoporte INT NOT NULL,
    PRIMARY KEY (IdEmpleadoSoporte),
    CONSTRAINT AK_IdEmpleadoSoporte UNIQUE (IdEmpleadoSoporte),
    CONSTRAINT PK_EmpleadoSoporte_Empleado FOREIGN KEY (IdEmpleado) REFERENCES tbEmpleado(IdEmpleado),
    CONSTRAINT PK_EmpleadoSoporte_Soporte FOREIGN KEY (IdSoporte) REFERENCES tbSoporte(IdSoporte)
);

CREATE TABLE tbSoporteCliente(
    IdSoporteCliente INT NOT NULL IDENTITY(1,1),
    IdSoporte INT NOT NULL,
    IdCliente INT NOT NULL,
    CONSTRAINT PK_IdSoporteCliente PRIMARY KEY (IdSoporteCliente),
    CONSTRAINT AK_IdSoporteCliente UNIQUE (IdSoporteCliente),
    CONSTRAINT FK_SoporteCliente_Soporte FOREIGN KEY (IdSoporte) REFERENCES tbSoporte(IdSoporte),
    CONSTRAINT FK_SoporteCliente_Cliente FOREIGN KEY (IdCliente) REFERENCES tbCliente(IdCliente)
);


insert into tbArticulo(NombreArticulo,Descripcion,Cantidad,CostoArticulo,PuntoReorden,NumPlaca,NumParte,NumSerie,VidaUtil,FechaFinGarantia,Activo)
values ('Fuente poder','750w 120v',5,70000,3,null,'750RS5TC',null,12/12/2026,18/07/2023,1);

insert into tbProveedor(NombreProveedor,CorreoProveedor,NombreContacto,DireccionProveedor,TelefonoProveedor,ProductoProveedor,Activo)
values ('Samsung','info@samsung.com','Efrain S','Singapore','83160767','Galaxy S21',1);

insert into tbDatosCompra(NumFacturaCompra,Cantidad,PrecioUnitario,ImpuestoCompra,SubTotalCompra,TotalCompra,FechaCompra,IdProveedor,IdArticulo)
values ('50000',10,10000,13,13000,1300000,13/05/2021,1,1);

insert into tbRol(NombreRol,Activo)
values ('Administrador',1);

insert into tbEmpleado(Cedula,Foto,Nombre,Apellido1,Apellido2,TelefonoEmpleado,CorreoEmpleado,Direccion,Contrasena,NombreContacto,TelefonoContacto,Activo,IdRol)
values ('109050203',NULL,'Blondy','Soto','Garita','83160767','blondysg@gmail.com','Cartago','123','Mari','88888888',1,1);

insert into tbEmpleado(Cedula,Foto,Nombre,Apellido1,Apellido2,TelefonoEmpleado,CorreoEmpleado,Direccion,Contrasena,NombreContacto,TelefonoContacto,NombreRol,Activo,IdRol)
values ('109050208',NULL,'Blondy','Soto','Garita','83160767','blondysg@gmail.com','Cartago','123','Mari','88888888',NULL,1,1);

select * from tbArticulo;
select * from tbCliente;
select * from tbDatosCompra;
select * from tbDatosVenta;
select * from tbEmpleado;
select * from tbProveedor;
select * from tbRol;

--Bitacora
--EmpleadoSoporte
--Soporte
--SoporteCliente
--Tipo