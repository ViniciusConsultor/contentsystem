/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     30/09/2008 12:04:35                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.FORNECEDORES') and o.name = 'FK_FORNECEDORES_STATUS')
alter table dbo.FORNECEDORES
   drop constraint FK_FORNECEDORES_STATUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.FUNCIONARIOS') and o.name = 'FK_FUNCIONARIOS_PERFIS')
alter table dbo.FUNCIONARIOS
   drop constraint FK_FUNCIONARIOS_PERFIS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.FUNCIONARIOS') and o.name = 'FK_FUNCIONARIOS_STATUS')
alter table dbo.FUNCIONARIOS
   drop constraint FK_FUNCIONARIOS_STATUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.ITENS_TRANSACOES') and o.name = 'FK_ITENS_TRANSACOES_TRANSACOES')
alter table dbo.ITENS_TRANSACOES
   drop constraint FK_ITENS_TRANSACOES_TRANSACOES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PEDIDOS_COMPRA') and o.name = 'FK_PEDIDOS_COMPRA_PRODUTOS')
alter table dbo.PEDIDOS_COMPRA
   drop constraint FK_PEDIDOS_COMPRA_PRODUTOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PEDIDOS_COMPRA') and o.name = 'FK_PEDIDOS_COMPRA_STATUS_TRANSACAO')
alter table dbo.PEDIDOS_COMPRA
   drop constraint FK_PEDIDOS_COMPRA_STATUS_TRANSACAO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PRODUTOS') and o.name = 'FK_PRODUTOS_FORNECEDORES')
alter table dbo.PRODUTOS
   drop constraint FK_PRODUTOS_FORNECEDORES
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.PRODUTOS') and o.name = 'FK_PRODUTOS_STATUS')
alter table dbo.PRODUTOS
   drop constraint FK_PRODUTOS_STATUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TRANSACOES') and o.name = 'FK_TRANSACOES_FUNCIONARIOS')
alter table dbo.TRANSACOES
   drop constraint FK_TRANSACOES_FUNCIONARIOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TRANSACOES') and o.name = 'FK_TRANSACOES_MOTIVOS_TROCA')
alter table dbo.TRANSACOES
   drop constraint FK_TRANSACOES_MOTIVOS_TROCA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TRANSACOES') and o.name = 'FK_TRANSACOES_STATUS_TRANSACAO')
alter table dbo.TRANSACOES
   drop constraint FK_TRANSACOES_STATUS_TRANSACAO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TRANSACOES') and o.name = 'FK_TRANSACOES_TIPOS_TRANSACAO')
alter table dbo.TRANSACOES
   drop constraint FK_TRANSACOES_TIPOS_TRANSACAO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.TRANSACOES') and o.name = 'FK_TRANSACOES_TRANSACOES')
alter table dbo.TRANSACOES
   drop constraint FK_TRANSACOES_TRANSACOES
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.PRODUTOS')
            and   name  = 'IX_PRODUTOS'
            and   indid > 0
            and   indid < 255)
   drop index dbo.PRODUTOS.IX_PRODUTOS
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.TRANSACOES')
            and   name  = 'IX_TRANSACOES'
            and   indid > 0
            and   indid < 255)
   drop index dbo.TRANSACOES.IX_TRANSACOES
go

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
execute sp_grantdbaccess dbo
go

/*==============================================================*/
/* Table: FORNECEDORES                                          */
/*==============================================================*/
create table dbo.FORNECEDORES (
   ID_FORNECEDOR        int                  identity(1, 1),
   NOME                 varchar(50)          collate Latin1_General_CI_AS not null,
   RAZAO_SOCIAL         varchar(50)          collate Latin1_General_CI_AS not null,
   CNPJ                 char(21)             collate Latin1_General_CI_AS not null,
   ENDERECO             text                 collate Latin1_General_CI_AS not null,
   TELEFONE             varchar(50)          collate Latin1_General_CI_AS not null,
   EMAIL                varchar(200)         collate Latin1_General_CI_AS null,
   NOME_CONTATO         varchar(100)         collate Latin1_General_CI_AS null,
   ID_STATUS            int                  not null,
   constraint PK_FORNECEDORES primary key (ID_FORNECEDOR)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: FUNCIONARIOS                                          */
/*==============================================================*/
create table dbo.FUNCIONARIOS (
   MATRICULA            int                  identity(1, 1),
   NOME                 varchar(50)          collate Latin1_General_CI_AS not null,
   LOGIN                varchar(50)          collate Latin1_General_CI_AS not null,
   SENHA                text                 collate Latin1_General_CI_AS not null,
   ID_PERFIL            int                  not null,
   CPF                  char(14)             collate Latin1_General_CI_AS not null,
   DATA_ADMISSAO        smalldatetime        not null,
   SALARIO              money                null,
   ID_STATUS            int                  not null,
   constraint PK_FUNCIONARIOS primary key (MATRICULA)
         on "PRIMARY",
   constraint IX_FUNCIONARIOS unique (MATRICULA)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: ITENS_TRANSACOES                                      */
/*==============================================================*/
create table dbo.ITENS_TRANSACOES (
   ID_TRANSACAO         int                  not null,
   SEQUENCIAL           int                  not null,
   ID_PRODUTO           int                  not null,
   QUANTIDADE           nchar(10)            collate Latin1_General_CI_AS not null,
   PRECO_UNITARIO       money                not null,
   constraint PK_ITENS_TRANSACOES primary key (ID_TRANSACAO, SEQUENCIAL)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: MOTIVOS_TROCA                                         */
/*==============================================================*/
create table dbo.MOTIVOS_TROCA (
   ID_MOTIVO            int                  not null,
   DESCRICAO            varchar(50)          collate Latin1_General_CI_AS not null,
   constraint PK_MOTIVOS_TROCA primary key (ID_MOTIVO)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: PEDIDOS_COMPRA                                        */
/*==============================================================*/
create table dbo.PEDIDOS_COMPRA (
   ID_PEDIDO_COMPRA     int                  identity(1, 1),
   DATA_PEDIDO_COMPRA   smalldatetime        not null constraint DF_PEDIDOS_COMPRA_DATA_PEDIDO_COMPRA default getdate(),
   ID_PRODUTO           int                  not null,
   QUANTIDADE           int                  not null,
   ID_COMPRA            int                  null,
   ID_STATUS            int                  not null,
   constraint PK_PEDIDOS_COMPRA primary key (ID_PEDIDO_COMPRA)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: PERFIS                                                */
/*==============================================================*/
create table dbo.PERFIS (
   ID_PERFIL            int                  not null,
   DESCRICAO            varchar(50)          collate Latin1_General_CI_AS not null,
   constraint PK_PERFIS primary key (ID_PERFIL)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: PRODUTOS                                              */
/*==============================================================*/
create table dbo.PRODUTOS (
   CODIGO_INTERNO       int                  identity(1, 1),
   NOME                 varchar(50)          collate Latin1_General_CI_AS not null,
   CODIGO_EXTERNO       char(13)             collate Latin1_General_CI_AS not null,
   ID_FORNECEDOR        int                  null,
   PRECO_VENDA          money                not null,
   QUNTIDADE_MINIMA     int                  not null,
   ID_STATUS            int                  not null,
   constraint PK_PRODUTOS primary key (CODIGO_INTERNO)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_PRODUTOS                                           */
/*==============================================================*/
create unique index IX_PRODUTOS on dbo.PRODUTOS (
ID_FORNECEDOR ASC,
CODIGO_EXTERNO ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: STATUS                                                */
/*==============================================================*/
create table dbo.STATUS (
   ID_STATUS            int                  not null,
   DESCRICAO            varchar(50)          collate Latin1_General_CI_AS not null,
   constraint PK_STATUS primary key (ID_STATUS)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: STATUS_TRANSACAO                                      */
/*==============================================================*/
create table dbo.STATUS_TRANSACAO (
   ID_STATUS            int                  not null,
   DESCRICAO            varchar(50)          collate Latin1_General_CI_AS not null,
   constraint PK_STATUS_TRANSACAO primary key (ID_STATUS)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TIPOS_TRANSACAO                                       */
/*==============================================================*/
create table dbo.TIPOS_TRANSACAO (
   ID_TIPO_TRANSACAO    int                  not null,
   DESCRICAO            varchar(50)          collate Latin1_General_CI_AS not null,
   constraint PK_TIPOS_TRANSACAO primary key (ID_TIPO_TRANSACAO)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: TRANSACOES                                            */
/*==============================================================*/
create table dbo.TRANSACOES (
   ID_TRANSACAO         int                  not null,
   ID_TRANSACAO_PAI     int                  null,
   ID_TIPO_TRANSACAO    int                  not null,
   ID_FORNECEDOR        int                  null,
   ID_RESPONSAVEL       int                  null,
   NUMERO_NOTA_FISCAL   int                  null,
   DATA_TRANSACAO       smalldatetime        not null,
   ID_STATUS            int                  not null,
   VALOR_TOTAL          money                not null,
   ID_MOTIVO_TROCA      int                  null,
   constraint PK_TRANSACOES primary key (ID_TRANSACAO)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_TRANSACOES                                         */
/*==============================================================*/
create index IX_TRANSACOES on dbo.TRANSACOES (
ID_TIPO_TRANSACAO ASC,
DATA_TRANSACAO ASC
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: sysdiagrams                                           */
/*==============================================================*/
create table dbo.sysdiagrams (
   name                 sysname              collate Latin1_General_CI_AS not null,
   principal_id         int                  not null,
   diagram_id           int                  identity(1, 1),
   version              int                  null,
   definition           varbinary(Max)       null,
   constraint PK__sysdiagrams__7D78A4E7 primary key (diagram_id)
         on "PRIMARY",
   constraint UK_principal_name unique (principal_id, name)
         on "PRIMARY"
)
on "PRIMARY"
go

alter table dbo.FORNECEDORES
   add constraint FK_FORNECEDORES_STATUS foreign key (ID_STATUS)
      references dbo.STATUS (ID_STATUS)
go

alter table dbo.FUNCIONARIOS
   add constraint FK_FUNCIONARIOS_PERFIS foreign key (ID_PERFIL)
      references dbo.PERFIS (ID_PERFIL)
go

alter table dbo.FUNCIONARIOS
   add constraint FK_FUNCIONARIOS_STATUS foreign key (ID_STATUS)
      references dbo.STATUS (ID_STATUS)
go

alter table dbo.ITENS_TRANSACOES
   add constraint FK_ITENS_TRANSACOES_TRANSACOES foreign key (ID_TRANSACAO)
      references dbo.TRANSACOES (ID_TRANSACAO)
go

alter table dbo.PEDIDOS_COMPRA
   add constraint FK_PEDIDOS_COMPRA_PRODUTOS foreign key (ID_PRODUTO)
      references dbo.PRODUTOS (CODIGO_INTERNO)
go

alter table dbo.PEDIDOS_COMPRA
   add constraint FK_PEDIDOS_COMPRA_STATUS_TRANSACAO foreign key (ID_STATUS)
      references dbo.STATUS_TRANSACAO (ID_STATUS)
go

alter table dbo.PRODUTOS
   add constraint FK_PRODUTOS_FORNECEDORES foreign key (ID_FORNECEDOR)
      references dbo.FORNECEDORES (ID_FORNECEDOR)
go

alter table dbo.PRODUTOS
   add constraint FK_PRODUTOS_STATUS foreign key (ID_STATUS)
      references dbo.STATUS (ID_STATUS)
go

alter table dbo.TRANSACOES
   add constraint FK_TRANSACOES_FUNCIONARIOS foreign key (ID_RESPONSAVEL)
      references dbo.FUNCIONARIOS (MATRICULA)
go

alter table dbo.TRANSACOES
   add constraint FK_TRANSACOES_MOTIVOS_TROCA foreign key (ID_MOTIVO_TROCA)
      references dbo.MOTIVOS_TROCA (ID_MOTIVO)
go

alter table dbo.TRANSACOES
   add constraint FK_TRANSACOES_STATUS_TRANSACAO foreign key (ID_STATUS)
      references dbo.STATUS_TRANSACAO (ID_STATUS)
go

alter table dbo.TRANSACOES
   add constraint FK_TRANSACOES_TIPOS_TRANSACAO foreign key (ID_TIPO_TRANSACAO)
      references dbo.TIPOS_TRANSACAO (ID_TIPO_TRANSACAO)
go

alter table dbo.TRANSACOES
   add constraint FK_TRANSACOES_TRANSACOES foreign key (ID_TRANSACAO_PAI)
      references dbo.TRANSACOES (ID_TRANSACAO)
go

