Create database Acortador
go
use Acortador
go

create table plataforma(
Id int identity primary key,
Nombre nvarchar (50) not null,
Descripcion nvarchar (70),
);
create table enlace(
Codigo nvarchar(30) primary key,
Titulo nvarchar (20) not null,
Descripcion nvarchar (100),
url text not null,
Estado bit not null,
PlataformaId int,
FuncionarioId int not null,
CONSTRAINT fk_enlace FOREIGN KEY (IdPlataforma) REFERENCES plataforma (Id)
);