IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Categoria] (
    [Id] int NOT NULL IDENTITY,
    [Nome] NVARCHAR(80) NOT NULL,
    [Icone] VARCHAR(80) NULL,
    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pedido] (
    [Id] int NOT NULL IDENTITY,
    [Total] DECIMAL NOT NULL,
    [DataPedido] SMALLDATETIME NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_Pedido] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produto] (
    [Id] int NOT NULL IDENTITY,
    [Nome] NVARCHAR(80) NOT NULL,
    [Descricao] NVARCHAR(255) NULL,
    [Image] NVARCHAR(80) NULL,
    [Preco] Decimal NOT NULL,
    [Ingredientes] NVARCHAR(255) NULL,
    [CategoriaId] int NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produto_Categoria] FOREIGN KEY ([CategoriaId]) REFERENCES [Categoria] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PedidoProduto] (
    [PedidoId] int NOT NULL,
    [ProdutoId] int NOT NULL,
    CONSTRAINT [PK_PedidoProduto] PRIMARY KEY ([PedidoId], [ProdutoId]),
    CONSTRAINT [FK_PedidoProduto_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedido] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidosProdutos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Categoria_Name] ON [Categoria] ([Nome]);
GO

CREATE UNIQUE INDEX [IX_Pedido_Id] ON [Pedido] ([Id]);
GO

CREATE INDEX [IX_PedidoProduto_ProdutoId] ON [PedidoProduto] ([ProdutoId]);
GO

CREATE INDEX [IX_Produto_CategoriaId] ON [Produto] ([CategoriaId]);
GO

CREATE INDEX [IX_Produto_Name] ON [Produto] ([Nome]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231027004808_CriacaoInicial', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Produto]') AND [c].[name] = N'Preco');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Produto] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Produto] ALTER COLUMN [Preco] Decimal(4,2) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pedido]') AND [c].[name] = N'Total');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Pedido] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Pedido] ALTER COLUMN [Total] DECIMAL(5,2) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231027011633_AlteracaoNaCasaDecimaldePrecoeTotal', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Produto] ADD [Quantidade] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231027054917_InclusaoDeQuantidadeEmProduto', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Produto]') AND [c].[name] = N'Quantidade');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Produto] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Produto] ALTER COLUMN [Quantidade] INT NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231027055853_ajusteNaQuantidadeDoProduto', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Pedido] ADD [NomeProduto] NVARCHAR(255) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231027135754_InclusaoDeNomeProdutoEmProduto', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Pedido] ADD [Cliente] VARCHAR(80) NOT NULL DEFAULT '';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231030130903_InclusaoDeClienteEmPedido', N'5.0.17');
GO

COMMIT;
GO

