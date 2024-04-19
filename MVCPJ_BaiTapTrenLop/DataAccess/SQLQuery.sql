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



CREATE TABLE LegalDocument (
    DocumentID INT PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    LastModifiedDate DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE PROC SP_GetDocument
AS
BEGIN
	SELECT * FROM dbo.LegalDocument    
END


CREATE PROC SP_GetDocumentById
@id int
AS
BEGIN
	SELECT * FROM dbo.LegalDocument
	WHERE DocumentID = @id
END

INSERT INTO LegalDocument (Title, Content) 
VALUES 
    (N'Quy định về bảo mật thông tin', N'Nội dung về quy định bảo mật thông tin, bao gồm các quy định về việc thu thập, sử dụng và bảo vệ thông tin cá nhân của khách hàng và người dùng.'),
    (N'Chính sách về quyền riêng tư', N'Chính sách này mô tả cách chúng tôi thu thập, sử dụng và chia sẻ thông tin của bạn trong các sản phẩm, dịch vụ, quy trình và hàm của chúng tôi. Điều này bao gồm thông tin về quyền riêng tư của bạn và cách bạn có thể kiểm soát thông tin của mình.'),
    (N'Biên bản họp đồng cổ đông', N'Biên bản này ghi lại các quyết định và thỏa thuận của cổ đông trong cuộc họp cổ đông về các vấn đề quan trọng như quản lý và hoạt động của công ty.'),
    (N'Thỏa thuận dịch vụ', N'Thỏa thuận này mô tả các điều khoản và điều kiện mà người dùng phải tuân thủ khi sử dụng sản phẩm hoặc dịch vụ của chúng tôi, bao gồm cả trách nhiệm và hạn chế của chúng tôi.'),
    (N'Quy chế hoạt động của công ty', N'Quy chế này mô tả cách tổ chức và hoạt động của công ty, bao gồm cơ cấu quản trị, quyền lợi và trách nhiệm của các thành viên.'),
    (N'Quy định về bảo mật mạng', N'Nội dung này bao gồm các quy định và biện pháp bảo mật mạng để đảm bảo an toàn cho dữ liệu và hệ thống thông tin của công ty.'),
    (N'Hợp đồng lao động', N'Hợp đồng này mô tả các điều khoản và điều kiện của mối quan hệ lao động giữa nhà tuyển dụng và nhân viên, bao gồm cả lương, chế độ làm việc và điều khoản chấm dứt.'),
    (N'Biên bản kiểm kê tài sản', N'Biên bản này ghi lại kết quả của quá trình kiểm kê tài sản của công ty, bao gồm danh sách tài sản và thông tin chi tiết về chúng.'),
    (N'Bản sao chứng thực hợp đồng', N'Bản sao này là bản sao chứng thực hợp đồng, được sử dụng để chứng minh tính hiệu lực và hợp pháp của một hợp đồng.'),
    (N'Quy định về bảo vệ môi trường', N'Nội dung này mô tả các quy định và biện pháp để bảo vệ môi trường và giảm thiểu tác động tiêu cực đến môi trường của hoạt động kinh doanh của công ty.');

Create Table User(
    UserID iden
)