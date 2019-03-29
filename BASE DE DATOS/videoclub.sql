/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     23/1/2017 22:37:22                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ALQUILER') and o.name = 'FK_ALQUILER_ADMINISTR_ADMINIST')
alter table ALQUILER
   drop constraint FK_ALQUILER_ADMINISTR_ADMINIST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ALQUILER') and o.name = 'FK_ALQUILER_ALQUILADO_CLIENTE')
alter table ALQUILER
   drop constraint FK_ALQUILER_ALQUILADO_CLIENTE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CLIENTE') and o.name = 'FK_CLIENTE_CREA_ADMINIST')
alter table CLIENTE
   drop constraint FK_CLIENTE_CREA_ADMINIST
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PELICULA') and o.name = 'FK_PELICULA_ALQUILADO_ALQUILER')
alter table PELICULA
   drop constraint FK_PELICULA_ALQUILADO_ALQUILER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PELICULA') and o.name = 'FK_PELICULA_ANADE_ADMINIST')
alter table PELICULA
   drop constraint FK_PELICULA_ANADE_ADMINIST
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRADOR')
            and   type = 'U')
   drop table ADMINISTRADOR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ALQUILER')
            and   name  = 'ADMINISTRA_FK'
            and   indid > 0
            and   indid < 255)
   drop index ALQUILER.ADMINISTRA_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ALQUILER')
            and   name  = 'ALQUILADORES_FK'
            and   indid > 0
            and   indid < 255)
   drop index ALQUILER.ALQUILADORES_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ALQUILER')
            and   type = 'U')
   drop table ALQUILER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CLIENTE')
            and   name  = 'CREA_FK'
            and   indid > 0
            and   indid < 255)
   drop index CLIENTE.CREA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PELICULA')
            and   name  = 'ANADE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PELICULA.ANADE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PELICULA')
            and   name  = 'ALQUILADOS_FK'
            and   indid > 0
            and   indid < 255)
   drop index PELICULA.ALQUILADOS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PELICULA')
            and   type = 'U')
   drop table PELICULA
go

/*==============================================================*/
/* Table: ADMINISTRADOR                                         */
/*==============================================================*/
create table ADMINISTRADOR (
   CEDULA_ADMINISTRADOR varchar(100)         not null,
   NOMBRE_ADMINISTRADOR varchar(100)         not null,
   APELLIDO_ADMINISTRADOR varchar(100)         not null,
   DIRECCION_ADMINISTRADOR varchar(100)         not null,
   TELEFONO_ADMINISTRADOR varchar(100)         not null,
   CORREO_ADMINISTRADOR varchar(100)         not null,
   CONTRASENA_ADMINISTRADOR varchar(100)         not null,
   ESTADO_USUARIO       varchar(100)         not null,
   IMAGEN_ADMINISTRADOR image                null,
   constraint PK_ADMINISTRADOR primary key nonclustered (CEDULA_ADMINISTRADOR)
)
go

/*==============================================================*/
/* Table: ALQUILER                                              */
/*==============================================================*/
create table ALQUILER (
   ID_ALQUILER          bigint               not null,
   CEDULA_CLIENTE       varchar(100)         null,
   CEDULA_ADMINISTRADOR varchar(100)         null,
   FECHAALQUILER_PELICULA datetime             not null,
   FECHADEVOLUCION_PELICULA datetime             null,
   MULTA                float                null,
   constraint PK_ALQUILER primary key nonclustered (ID_ALQUILER)
)
go

/*==============================================================*/
/* Index: ALQUILADORES_FK                                       */
/*==============================================================*/
create index ALQUILADORES_FK on ALQUILER (
CEDULA_CLIENTE ASC
)
go

/*==============================================================*/
/* Index: ADMINISTRA_FK                                         */
/*==============================================================*/
create index ADMINISTRA_FK on ALQUILER (
CEDULA_ADMINISTRADOR ASC
)
go

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   CEDULA_CLIENTE       varchar(100)         not null,
   CEDULA_ADMINISTRADOR varchar(100)         null,
   NOMBRE_CLIENTE       varchar(100)         not null,
   APELLIDO_CLIENTE     varchar(100)         not null,
   DIRECCION_CLIENTE    varchar(100)         not null,
   TELEFONO_CLIENTE     varchar(100)         not null,
   CORREO_CLIENTE       varchar(100)         not null,
   CONTRASENA_CLIENTE   varchar(100)         not null,
   ESTADO_USUARIO       varchar(100)         not null,
   IMAGEN_CLIENTE       image                null,
   constraint PK_CLIENTE primary key nonclustered (CEDULA_CLIENTE)
)
go

/*==============================================================*/
/* Index: CREA_FK                                               */
/*==============================================================*/
create index CREA_FK on CLIENTE (
CEDULA_ADMINISTRADOR ASC
)
go

/*==============================================================*/
/* Table: PELICULA                                              */
/*==============================================================*/
create table PELICULA (
   TITULO_PELICULA      varchar(100)         not null,
   ID_ALQUILER          bigint               null,
   CEDULA_ADMINISTRADOR varchar(100)         null,
   DIRECTOR_PELICULA    varchar(100)         not null,
   ANIOESTRENO_PELICULA datetime             not null,
   GENERO_PELICULA      varchar(100)         not null,
   ACTORES_PELICULA     varchar(100)         not null,
   SINOPSIS_PELICULA    varchar(100)         not null,
   COPIA_PELICULA       int                  not null,
   IMAGEN_PELICULA      image                null,
   PRECIO_PELICULA      float                not null,
   constraint PK_PELICULA primary key nonclustered (TITULO_PELICULA)
)
go

/*==============================================================*/
/* Index: ALQUILADOS_FK                                         */
/*==============================================================*/
create index ALQUILADOS_FK on PELICULA (
ID_ALQUILER ASC
)
go

/*==============================================================*/
/* Index: ANADE_FK                                              */
/*==============================================================*/
create index ANADE_FK on PELICULA (
CEDULA_ADMINISTRADOR ASC
)
go

alter table ALQUILER
   add constraint FK_ALQUILER_ADMINISTR_ADMINIST foreign key (CEDULA_ADMINISTRADOR)
      references ADMINISTRADOR (CEDULA_ADMINISTRADOR)
go

alter table ALQUILER
   add constraint FK_ALQUILER_ALQUILADO_CLIENTE foreign key (CEDULA_CLIENTE)
      references CLIENTE (CEDULA_CLIENTE)
go

alter table CLIENTE
   add constraint FK_CLIENTE_CREA_ADMINIST foreign key (CEDULA_ADMINISTRADOR)
      references ADMINISTRADOR (CEDULA_ADMINISTRADOR)
go

alter table PELICULA
   add constraint FK_PELICULA_ALQUILADO_ALQUILER foreign key (ID_ALQUILER)
      references ALQUILER (ID_ALQUILER)
go

alter table PELICULA
   add constraint FK_PELICULA_ANADE_ADMINIST foreign key (CEDULA_ADMINISTRADOR)
      references ADMINISTRADOR (CEDULA_ADMINISTRADOR)
go

