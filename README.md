# CrudYuGiOh

--Script:
CREATE TABLE [dbo].[Usuario] (
    [IdUsuario] INT           IDENTITY (1, 1) NOT NULL,
    [Login]     VARCHAR (255) NOT NULL,
    [Senha]     VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);

CREATE TABLE [dbo].[LogUsuario] (
    [IdLog]       INT      IDENTITY (1, 1) NOT NULL,
    [DataEntrada] DATETIME NOT NULL,
    [DataSaida]   DATETIME NULL,
    [IdUsuario]   INT      NULL,
    PRIMARY KEY CLUSTERED ([IdLog] ASC),
    CONSTRAINT [FK_LogUsuario_ToTable] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([IdUsuario])
);

CREATE TABLE [dbo].[Icone]
(
    [IdIcone] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descricao] VARCHAR(255) NOT NULL
);

CREATE TABLE [dbo].[Atributo]
(
    [IdAtributo] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Descricao] VARCHAR(255) NOT NULL,
);

CREATE TABLE [dbo].[TipoCarta]
(
    [IdTipoCarta] INT NOT NULL PRIMARY KEY IDENTITY(1,1)
);

CREATE TABLE [dbo].[Armadilha]
(
    [IdArmadilha] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Descricao] VARCHAR(255) NOT NULL,
    [IdTipoCarta] INT NOT NULL,
    CONSTRAINT FKCARTAIDCARTA FOREIGN KEY(IdTipoCarta) REFERENCES TipoCarta(IdTipoCarta)
);

CREATE TABLE  [dbo].[Magias]
(
    [IdMagias] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Descricao] VARCHAR(255) NOT NULL,
    [IdTipoCarta] INT NOT NULL, 
    CONSTRAINT [FK_Magias_ToTable] FOREIGN KEY (IdTipoCarta) REFERENCES TipoCarta(IdTipoCarta)
);

CREATE TABLE [dbo].[Monstro]
(
    [IdMonstro] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Descricao] varchar not null,
    [IdTipoCarta] int not null,
    constraint [fk_Monstro_TipoCarta] foreign key (IdTipoCarta) references TipoCarta(IdTipoCarta)
)

CREATE TABLE [dbo].[TipoMonstroEfeito]
(
    [IdMonstroEfeito] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Descricao] VARCHAR(255) not null,
    [IdMonstro] int not null,
    Constraint [fk_MonstroEfeito_TipoMonstro] foreign key (IdMonstro) references Monstro(IdMonstro)
);

CREATE TABLE [dbo].[MonstroPendulo]
(
    [IdMonstroPendulo] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Descricao] VARCHAR(255) not null,
    [IdMonstroEfeito] int not null, 
    CONSTRAINT [FK_MonstroPendulo_MonstroEfeito] FOREIGN KEY (IdMonstroEfeito) REFERENCES TipoMonstroEfeito(IdMonstroEfeito)

);

CREATE TABLE [dbo].[Carta]
(
    [IdCarta] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(255) NOT NULL, 
    [Nivel] INT NULL, 
    [NumeroCard] INT NOT NULL, 
    [PontosAtaque] INT NULL, 
    [PontosDefesa] INT NULL, 
    [Descricao] VARCHAR(255) NOT NULL, 
    [IdTipoCarta] INT NOT NULL, 
    [IdAtributo] INT NULL, 
    [IdIcone] INT NULL, 
    CONSTRAINT [FK_Carta_TipoCarta] FOREIGN KEY ([IdTipoCarta]) REFERENCES [TipoCarta]([IdTipoCarta]), 
    CONSTRAINT [FK_Carta_Atributo] FOREIGN KEY ([IdAtributo]) REFERENCES [Atributo]([IdAtributo]), 
    CONSTRAINT [FK_Carta_Icone] FOREIGN KEY ([IdIcone]) REFERENCES [Icone]([IdIcone])
);

