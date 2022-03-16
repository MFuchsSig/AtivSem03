
create database BdEmpresa
go

use BdEmpresa
go

create table Setor(
	Codigo int identity (1,1) not null,
	Nome varchar (100),
	Rg varchar(18),
	Sexo varchar(20),
	constraint pk_Setor primary key (Codigo)
)
go

create unique index ix_Nome on Setor (Nome) where Nome is not null
go


insert into Setor (Nome,Rg,Sexo) values ('Matheus','123456789','Masculino')
insert into Setor (Nome,Rg,Sexo) values ('Pedro','133225463','Masculino')
insert into Setor (Nome,Rg,Sexo) values ('Leticia','001396496','Feminino')
insert into Setor (Nome,Rg,Sexo) values ('Julia','990788443','Feminino')
insert into Setor (Nome,Rg,Sexo) values ('Yuri','223344556','Masculino')

select * from Setor


create table Funcionario(
	Codigo int identity (1,1) not null,
	CodigoDepartamento int not null,
	PrimeiroNome varchar (100) not null,
	DataNascimento date not null,
	CPF int not null,
	RG varchar (9) not null,
	Endereço varchar (100),
	CEP int not null,
	Cidade varchar (100),
	Funcao varchar (100) not null,
	Salario decimal (10,2) not null
	constraint pk_Funcionario primary key (Codigo)
)
go

select *from Funcionario
