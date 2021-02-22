/*
USE master
GO

DROP DATABASE TailorITTeste
GO
*/

CREATE DATABASE TailorITTeste
GO

USE TailorITTeste
GO

IF NOT EXISTS (SELECT schema_name 
    FROM information_schema.schemata 
    WHERE schema_name = 'Autenticacao' )
BEGIN
    EXEC sp_executesql N'CREATE SCHEMA Autenticacao;';
END
GO

CREATE TABLE [Autenticacao].[Sexo](
	SexoId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Descricao VARCHAR(15) NOT NULL
)
GO

INSERT INTO [Autenticacao].[Sexo](Descricao)
	Values ('Masculino'), ('Feminino')


CREATE TABLE [Autenticacao].[Usuario] (
	UsuarioId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Nome VARCHAR(200) NOT NULL,
	DataNascimento	DateTime NOT NULL,
	Email VARCHAR(100) NULL,
	Senha VARCHAR(30) NULL,
	Ativo BIT NOT NULL,
	SexoId INT NOT NULL,
)
GO

ALTER TABLE [Autenticacao].[Usuario]  WITH CHECK 
	ADD CONSTRAINT [FK_Usuario_Sexo_SexoId] 
		FOREIGN KEY([SexoId])
			REFERENCES [Autenticacao].[Sexo] ([SexoId])
GO