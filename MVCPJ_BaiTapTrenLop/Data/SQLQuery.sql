CREATE DATABASE MVCPJ_BaiTapTrenLop
GO

USE MVCPJ_BaiTapTrenLop
GO	

CREATE TABLE Link (
    LinkID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100),
    URL NVARCHAR(255)
);

CREATE TABLE Advertisement (
    AdvertisementID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100),
    Description NVARCHAR(255),
    ImageURL NVARCHAR(255),
    LinkID INT,
    FOREIGN KEY (LinkID) REFERENCES Link(LinkID) -- Tạo khóa ngoại
);

CREATE PROC SP_GetAdvertisement
AS
BEGIN
	SELECT * FROM View_Advertisement_Link    
END


CREATE PROC SP_GetAdvertisementById
@id int
AS
BEGIN
	SELECT * FROM View_Advertisement_Link    
	WHERE AdvertisementID = @id
END

