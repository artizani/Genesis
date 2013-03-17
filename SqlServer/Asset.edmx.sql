
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/12/2012 11:19:38
-- Generated from EDMX file: C:\Users\Artizani\documents\visual studio 2010\Projects\Genesis\SqlServer\Asset.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DevOnly];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Loan_Loaned]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Loan] DROP CONSTRAINT [FK_Loan_Loaned];
GO
IF OBJECT_ID(N'[dbo].[FK_Loan_Member]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Loan] DROP CONSTRAINT [FK_Loan_Member];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Asset]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Asset];
GO
IF OBJECT_ID(N'[dbo].[Loan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Loan];
GO
IF OBJECT_ID(N'[dbo].[Loaned]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Loaned];
GO
IF OBJECT_ID(N'[dbo].[Member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Member];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Assets'
CREATE TABLE [dbo].[Assets] (
    [Name] nvarchar(50)  NOT NULL,
    [Title] nchar(10)  NULL,
    [ISBN] nchar(10)  NOT NULL,
    [Type] varchar(50)  NULL,
    [AssetId] varchar(50)  NOT NULL,
    [Author] varchar(50)  NOT NULL
);
GO

-- Creating table 'Loans'
CREATE TABLE [dbo].[Loans] (
    [Email] varchar(100)  NOT NULL,
    [LoanId] varchar(100)  NOT NULL,
    [From] datetime  NULL,
    [To] datetime  NULL,
    [LoanedId] uniqueidentifier  NULL,
    [ReturnIds] varchar(100)  NOT NULL,
    [ReturnDate] datetime  NOT NULL,
    [Notes] varchar(2000)  NOT NULL,
    [LinkedLoanId] varchar(100)  NULL
);
GO

-- Creating table 'Loaneds'
CREATE TABLE [dbo].[Loaneds] (
    [LoanedId] uniqueidentifier  NOT NULL,
    [AssetIdList] varchar(100)  NOT NULL
);
GO

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [Role] nvarchar(50)  NOT NULL,
    [Email] varchar(100)  NOT NULL,
    [Secret] nchar(50)  NOT NULL,
    [DOB] varchar(50)  NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [Phone] varchar(50)  NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AssetId] in table 'Assets'
ALTER TABLE [dbo].[Assets]
ADD CONSTRAINT [PK_Assets]
    PRIMARY KEY CLUSTERED ([AssetId] ASC);
GO

-- Creating primary key on [LoanId] in table 'Loans'
ALTER TABLE [dbo].[Loans]
ADD CONSTRAINT [PK_Loans]
    PRIMARY KEY CLUSTERED ([LoanId] ASC);
GO

-- Creating primary key on [LoanedId] in table 'Loaneds'
ALTER TABLE [dbo].[Loaneds]
ADD CONSTRAINT [PK_Loaneds]
    PRIMARY KEY CLUSTERED ([LoanedId] ASC);
GO

-- Creating primary key on [Email] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([Email] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LoanedId] in table 'Loans'
ALTER TABLE [dbo].[Loans]
ADD CONSTRAINT [FK_Loan_Loaned]
    FOREIGN KEY ([LoanedId])
    REFERENCES [dbo].[Loaneds]
        ([LoanedId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Loan_Loaned'
CREATE INDEX [IX_FK_Loan_Loaned]
ON [dbo].[Loans]
    ([LoanedId]);
GO

-- Creating foreign key on [Email] in table 'Loans'
ALTER TABLE [dbo].[Loans]
ADD CONSTRAINT [FK_Loan_Member]
    FOREIGN KEY ([Email])
    REFERENCES [dbo].[Members]
        ([Email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Loan_Member'
CREATE INDEX [IX_FK_Loan_Member]
ON [dbo].[Loans]
    ([Email]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------