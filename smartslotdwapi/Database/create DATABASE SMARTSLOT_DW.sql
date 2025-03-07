create DATABASE SMARTSLOT_DW
go 
use SMARTSLOT_DW
go 
create table Cliente(
        id int not null,
        codsala int not null,
        tipoDocumento varchar(250) null,
        documento varchar(250) null,
		categoriacliente varchar(250)null,
        categoriaIdCliente int null,
        nombre varchar(250) null,
        apellidoPaterno varchar(250) null,
        apellidoMaterno varchar(250) null,
        fechaNacimiento datetime null,
        correo varchar(250) null,
        celular varchar(250) null,
        fecharegistrodw datetime,
		segmentacionid int null,
        CONSTRAINT PK_Cliente PRIMARY KEY (id, codsala)
    )
go 
create table Sala(
        codSala int not null,
        nombre varchar(250) null,
        uri varchar(250) null,
        estado int DEFAULT 0
    )
insert into sala (codsala, nombre, uri, estado)
values (9, 'MAMBOS', 'http://193.169.4.105:8089', 1)
go 
create table ClienteCategoria(
        codsala int not null,
        id int not null,
        nombre varchar(250) null,
        estado varchar(250) null,
        fecharegistrodw datetime,
		puntos float null,
        CONSTRAINT PK_ClienteCategoria PRIMARY KEY (id, codsala)
    ) 
	go
	create table ClienteCupon(
        codsala int not null,
        id int not null,
        clienteid int not null,
		idSorteo int not null,
		nombreSorteo varchar(250),
		cuponesGenerados int,
		cuponesAsignados int,
		estado varchar(250),
        fecharegistrodw datetime,
        CONSTRAINT PK_ClienteCupon PRIMARY KEY (codsala,clienteid,idSorteo)
    ) 
	go
  create table ClientePromocion (
	codsala int not null,
	clienteid int not null,
	promocionid int not null,
	cliente varchar(250),
	tipodocumento varchar(250),
	dni varchar(250),
	categoria varchar(250),
	promocion varchar(250),
	tipopromocion varchar(250),
	fechagenerado datetime,
	fechacanje datetime,
	premioGanado varchar(250),
	premio int,
	estado varchar(250),
	fecharegistrodw datetime,
	constraint PK_ClientePromocion primary key(codsala,clienteid,promocionid)
  )
	
	go
	create table AfluenciaHora(
        codsala int not null,
		hora int not null,
		cantJuego int,
		fechajuego datetime null,
		produccion float null,
		totalPuntos int null,
	    cantclientes int null,
		maquina varchar(250) null,
        fecharegistrodw datetime,
        CONSTRAINT PK_AfluenciaHora PRIMARY KEY (hora,codsala)
    )
	GO
	create table StatusPlayer(
		codsala int not null,
		idStatus int not null,
		nombreCompleto varchar(250),
		dni varchar(250),
		maquina varchar(250),
		fechaini datetime,
		fechafin datetime,
		token float,
		puntos int,
		coinin int,
		coinout int,
		jackpot int,
		clienteid int,
		bill_ini int,
		bill_fin int,
		fecharegistrodw datetime,
		CONSTRAINT PK_StatusPlayer PRIMARY KEY (idStatus,codsala)
	)
	go
	create table StatusMaquinaCupon(
		codsala int not null,
		idDetalle int not null,
		idCabecera int not null,
		idSorteo int,
		sorteo varchar(250),
		cupon int,
		fecharegistrodw datetime,
		CONSTRAINT PK_StatusMaquinaCupon PRIMARY KEY (idDetalle,codsala)
	)
	go
	create table SorteoConfiguracionMaquina(
		codsala int not null,
		sorteoid int,
		maquina varchar(250),
		marca varchar(250),
		tipomaquina varchar(250),
		fecharegistrodw datetime,
		CONSTRAINT PK_SorteoConfiguracionMaquina PRIMARY KEY (maquina,codsala,sorteoid)
	)
	go
	create table SegmentacionCliente(
		codsala int not null,
		id int not null,
		nombre varchar(250),
		desde int,
		hasta int,
		fecharegistrodw datetime,
		CONSTRAINT PK_SegmentacionCliente PRIMARY KEY (id,codsala)
	)
	go
	create table Promocion(
		codsala int not null,
		id int not null,
		tipoPromocion varchar(250) null,
		nombre varchar(250) null,
		excluyente bit null,
		fechaVigenciainicial datetime null,
		fechaVigenciaFinal datetime null,
		estado varchar(250) null,
		fecharegistrodw datetime,
		CONSTRAINT PK_Promocion PRIMARY KEY (id,codsala)
	)
	go
	create table TipoPromocion(
		codsala int not null,
		id int not null,
		nombre varchar(250),
		descripcion varchar(250),
		estadoDescripcion varchar(250),
		fecharegistrodw datetime,
		CONSTRAINT PK_TipoPromocion PRIMARY KEY (id,codsala)
	)
	go
	create table Sorteo(
		codsala int not null,
		id int not null,
		descripcion varchar(250) null,
		fechaInicioSorteo datetime null,
		fechaFinSorteo datetime null,
		sorteovirtual int null,
		estado varchar(250) null,
		tipo varchar(250) null,
		fecharegistrodw datetime,
		constraint Pk_Sorteo primary key (id,codsala)
	)
	go
	Create table ClientePunto (
		codsala int not null,
		id int not null,
		clienteid int not null,
		totalpuntos int,
		puntos int,
		puntoCortesia int,
		puntoCortesiaNC int ,
		fecharegistrodw datetime,
		constraint PK_ClientePunto primary key (id,codsala)
	)
	go
	Create table ClientePuntoFechas(
		codsala int not null,
		clienteid int not null,
		tipoPunto varchar(250),
		puntos int,
		saldoactual int,
		fecha datetime,
		fechacorta date,
		fecharegistrodw datetime,
		constraint PK_ClientePuntoFechas primary key (codsala,fechacorta,clienteid)
	)
	go
	Create table ClienteCuponHistorial(
		iddw int identity(1,1) not null,
		codsala int not null,
		clienteid int not null,
		cliente varchar(250),
		sorteoid int,
		nombreSorteo varchar(250),
		fecha datetime,
		tipocupon varchar(250),
		cupones int,
		estadoSorteo varchar(250),
		constraint PK_ClienteCuponHistorial primary key (iddw)
	)