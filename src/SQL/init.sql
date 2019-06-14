USE master
IF EXISTS(select * from sys.databases where name='example_db')
DROP DATABASE example_db
GO
CREATE DATABASE example_db
GO
CREATE LOGIN [example_user] WITH password = '+AbUQdN2+Wun8=ypDR*'
GO

EXECUTE sp_configure 'show advanced', 1;  
RECONFIGURE;  

USE example_db
GO
if not exists (select * from sysobjects where name='Property' and xtype='U')
BEGIN
CREATE TABLE Property
(
    PropertyId int NOT NULL IDENTITY(1,1),
    PropertyName varchar(max) NOT NULL,
    PropertyAddressLine1 varchar(max) NOT NULL,
    PropertyAddressLine2 varchar(max) NOT NULL,
    PropertyAddressStateProv varchar(max) NOT NULL,
    PropertyAddressZipPostcode varchar(max) NOT NULL,
    PropertyAddressCountry varchar(max) NOT NULL,
    PropertyImageUrl varchar(max) NOT NULL
)
END