
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/12/2020 12:58:08
-- Generated from EDMX file: G:\Documents\JONATHAN\Proyectos\ModelFirst\ModelFirst\Models\PeliculasModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Peliculas];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DirectorPeliculas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PeliculasSet] DROP CONSTRAINT [FK_DirectorPeliculas];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PeliculasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeliculasSet];
GO
IF OBJECT_ID(N'[dbo].[DirectorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DirectorSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PeliculasSet'
CREATE TABLE [dbo].[PeliculasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Anio] nvarchar(max)  NOT NULL,
    [DirectorId] int  NOT NULL
);
GO

-- Creating table 'DirectorSet'
CREATE TABLE [dbo].[DirectorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PeliculasSet'
ALTER TABLE [dbo].[PeliculasSet]
ADD CONSTRAINT [PK_PeliculasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DirectorSet'
ALTER TABLE [dbo].[DirectorSet]
ADD CONSTRAINT [PK_DirectorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DirectorId] in table 'PeliculasSet'
ALTER TABLE [dbo].[PeliculasSet]
ADD CONSTRAINT [FK_DirectorPeliculas]
    FOREIGN KEY ([DirectorId])
    REFERENCES [dbo].[DirectorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DirectorPeliculas'
CREATE INDEX [IX_FK_DirectorPeliculas]
ON [dbo].[PeliculasSet]
    ([DirectorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------