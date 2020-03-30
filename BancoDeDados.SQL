IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Marcas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [UniqueId] uniqueidentifier NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Patrimonios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [MarcaId] int NOT NULL,
    [Descricao] nvarchar(max) NULL,
    [NumeroTombo] int NOT NULL,
    CONSTRAINT [PK_Patrimonios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Patrimonios_Marcas_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [Marcas] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Patrimonios_MarcaId] ON [Patrimonios] ([MarcaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200327034722_VersaoInicial', N'3.1.3');

GO