--DROPPING CONSTRAINTS
IF (OBJECT_ID('FK_Stage_Course', 'F') IS NOT NULL)
    ALTER TABLE [dbo].[Stage] DROP CONSTRAINT [FK_Stage_Course]
GO

IF (OBJECT_ID('FK_UserCourse_User', 'F') IS NOT NULL)
    ALTER TABLE [dbo].[UserCourse] DROP CONSTRAINT [FK_UserCourse_User]
GO

IF (OBJECT_ID('FK_UserCourse_Course', 'F') IS NOT NULL)
    ALTER TABLE [dbo].[UserCourse] DROP CONSTRAINT [FK_UserCourse_Course]
GO

IF (OBJECT_ID('FK_CourseCategory_Category', 'F') IS NOT NULL)
    ALTER TABLE [dbo].[CourseCategory] DROP CONSTRAINT [FK_CourseCategory_Category]
GO

IF (OBJECT_ID('FK_CourseCategory_Course', 'F') IS NOT NULL)
    ALTER TABLE [dbo].[CourseCategory] DROP CONSTRAINT [FK_CourseCategory_Course]
GO

--DROPPING TABLES
DROP TABLE IF EXISTS [dbo].[Course]
GO

DROP TABLE IF EXISTS [dbo].[CourseCategory]
GO

DROP TABLE IF EXISTS [dbo].[Category]
GO

DROP TABLE IF EXISTS [dbo].[Stage]
GO

DROP TABLE IF EXISTS [dbo].[User]
GO

DROP TABLE IF EXISTS [dbo].[UserCourse]
GO

DROP TABLE IF EXISTS [dbo].[Progress]
GO

--CREATING TABLES
CREATE TABLE [dbo].[Course]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(MAX) NOT NULL
);
GO

CREATE TABLE [dbo].[Category]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(100) NOT NULL,
	[ImageUrl] nvarchar(MAX) NULL, 
);
GO

CREATE TABLE [dbo].[Stage]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Nr] int NOT NULL,
	[Name] nvarchar(MAX) NOT NULL,
	[HtmlContent] nvarchar(MAX) NOT NULL,
	[CourseId] bigint NOT NULL
);
GO

CREATE TABLE [dbo].[User]
(
	[Id] bigint NOT NULL PRIMARY KEY IDENTITY,
	[Username] nvarchar(100) NOT NULL,
	[FirstName] nvarchar(100) NOT NULL,
	[LastName] nvarchar(100) NOT NULL,
	[Email] nvarchar(100) NOT NULL,
	[Password] nvarchar(100) NOT NULL
);
GO

CREATE TABLE [dbo].[UserCourse]
(
	[CourseId] bigint NOT NULL,
	[UserId] bigint NOT NULL
);
GO

CREATE TABLE [dbo].[CourseCategory]
(
	[CourseId] bigint NOT NULL,
	[CategoryId] bigint NOT NULL
);
GO


CREATE TABLE [dbo].[Progress]
(
	[UserId] bigint NOT NULL,
	[CategoryId] bigint NOT NULL,
	[CourseId] bigint NOT NULL,
	[StageId] bigint NOT NULL
);
GO

--CREATING PRIMARY KEYS
ALTER TABLE [dbo].[UserCourse] 
	ADD PRIMARY KEY 
		([CourseId], [UserId])
GO

ALTER TABLE [dbo].[CourseCategory] 
	ADD PRIMARY KEY 
		([CourseId], [CategoryId])
GO

--CREATING FOREIGN KEYS
ALTER TABLE [dbo].[Stage]
ADD CONSTRAINT [FK_Stage_Course]
	FOREIGN KEY ([CourseId]) 
	REFERENCES [dbo].[Course]
		([Id])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

ALTER TABLE [dbo].[UserCourse] 
ADD CONSTRAINT [FK_UserCourse_User]
	FOREIGN KEY ([UserId]) 
	REFERENCES [dbo].[User]
		([Id])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

ALTER TABLE [dbo].[UserCourse] 
ADD CONSTRAINT [FK_UserCourse_Course]
	FOREIGN KEY ([CourseId]) 
	REFERENCES [dbo].Course
		([Id])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

ALTER TABLE [dbo].[CourseCategory] 
ADD CONSTRAINT [CourseCategory_Category]
	FOREIGN KEY ([CategoryId]) 
	REFERENCES [dbo].[Category]
		([Id])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO

ALTER TABLE [dbo].[CourseCategory] 
ADD CONSTRAINT [FK_CourseCategory_Course]
	FOREIGN KEY ([CourseId]) 
	REFERENCES [dbo].Course
		([Id])
	ON DELETE CASCADE ON UPDATE NO ACTION;
GO