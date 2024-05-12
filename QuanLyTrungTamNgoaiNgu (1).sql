/*** Nguyễn Thị Thu Nguyên - 52000786 ***/
USE MASTER
GO
IF exists(SELECT * FROM SYSDATABASES WHERE NAME ='QuanLyTrungTamNgoaiNgu')
	DROP DATABASE QuanLyTrungTamNgoaiNgu
GO

CREATE DATABASE QuanLyTrungTamNgoaiNgu
GO

USE QuanLyTrungTamNgoaiNgu
GO

CREATE SEQUENCE CommonSequence
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    NO MAXVALUE
    NO CYCLE;
GO
/**** Tạo bảng ****/
/** bảng học viên **/
CREATE TABLE HOCVIEN
(
	MA_HOC_VIEN nvarchar(20) NOT NULL,
	HO nvarchar(10),
	TEN nvarchar(30),
	NGAY_SINH datetime,
	GIOI_TINH int,
	DIA_CHI nvarchar(100),
	EMAIL NVARCHAR(50),
	NGAY_GIA_NHAP date,
	TRANG_THAI int		/*0-chưa học, 1-chưa đk, 2-đanghoc)*/,

	CONSTRAINT MA_HOC_VIEN_PK PRIMARY KEY(MA_HOC_VIEN)
)

/** bảng loại khóa học **/
CREATE TABLE LOAIKHOAHOC
(
	MA_LOAI_KHOA_HOC NVARCHAR(20) NOT NULL,
	TEN_KHOA_HOC NVARCHAR(50),
	TRANG_THAI INT,

	CONSTRAINT MA_LOAI_KHOA_HOC_PK PRIMARY KEY(MA_LOAI_KHOA_HOC)
)

/** BẢNG KHÓA HỌC */
CREATE TABLE KHOAHOC
(
	MA_KHOA_HOC NVARCHAR(20) NOT NULL,
	MA_LOAI_KHOA_HOC NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES LOAIKHOAHOC(MA_LOAI_KHOA_HOC),
	TEN_KHOA_HỌC NVARCHAR(50),
	NGAY_KHAI_GIANG DATE,
	NGAY_KET_THUC DATE,
	SO_LOP INT,
	HOC_PHI INT,
	TRANG_THAI INT,

	CONSTRAINT MA_KHOA_HOC_PK PRIMARY KEY(MA_KHOA_HOC)
)

/** BẢNG LOẠI NHÂN VIÊN **/
CREATE TABLE LOAINHANVIEN
(
	MA_LOAI_NHAN_VIEN NVARCHAR(20) NOT NULL,
	TEN_LOAI NVARCHAR(50),
	TRANG_THAI INT,
	CONSTRAINT MA_LOAI_NHAN_VIEN_PK PRIMARY KEY(MA_LOAI_NHAN_VIEN)
)

/** BẢNG NHÂN VIÊN **/
CREATE TABLE NHANVIEN
(
	MA_NHAN_VIEN NVARCHAR(20)NOT NULL,
	HO NVARCHAR(10),
	TEN NVARCHAR(50),
	NGAY_SINH DATE,
	GIOI_TINH INT,
	DIA_CHI NVARCHAR(100),
	SDT NVARCHAR(15),
	EMAIL NVARCHAR(50),
	MA_LOAI_NHAN_VIEN NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES LOAINHANVIEN(MA_LOAI_NHAN_VIEN),
	TINH_TRANG INT,

	CONSTRAINT MA_NHAN_VIEN_PK PRIMARY KEY(MA_NHAN_VIEN)
)

/** BẢNG LỚP HỌC **/
CREATE TABLE LOPHOC
(
	MA_LOP_HOC NVARCHAR(20) NOT NULL,
	TEN_LOP_HOC NVARCHAR(50),
	MA_KHOA_HOC NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES KHOAHOC(MA_KHOA_HOC),
	MA_NHAN_VIEN NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(MA_NHAN_VIEN),
	NGAY_HOC DATE,
	GIO_BAT_DAU TIME,
	GIO_KET_THUC TIME,
	SO_HOC_VIEN_TOI_DA INT NOT NULL,
	SO_HOC_VIEN_DANG_KY INT,
	TRANG_THAI INT,

	CONSTRAINT MA_LOP_HOC_PK PRIMARY KEY(MA_LOP_HOC)
)

/** BẢNG BẢNG ĐIỂM **/
CREATE TABLE BANGDIEM
(
	MA_HOC_VIEN NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES HOCVIEN(MA_HOC_VIEN),
	MA_LOP_HOC NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES LOPHOC(MA_LOP_HOC),
	DIEM FLOAT,
	TINH_TRANG INT
)

/** BẢNG HÓA ĐƠN **/
CREATE TABLE HOADON
(
	MA_HOA_DON NVARCHAR(20) NOT NULL,
	MA_LOP_HOC NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES LOPHOC(MA_LOP_HOC),
	MA_HOC_VIEN NVARCHAR(20) NOT NULL FOREIGN KEY REFERENCES HOCVIEN(MA_HOC_VIEN),
	NGAY_DANG_KI DATE,
	HOC_PHI INT,
	TINH_TRANG INT,

	CONSTRAINT MA_HOA_DON_PK PRIMARY KEY(MA_HOA_DON)
)
/** BẢNG TÀI KHOẢN**/
CREATE TABLE TAIKHOAN
(
	TAI_KHOAN NVARCHAR(20),
	MAT_KHAU NVARCHAR(20),
	EMAIL NVARCHAR(50),
	TINH_TRANG int,
	CONSTRAINT TAI_KHOAN_PK PRIMARY KEY(TAI_KHOAN)
)

/*** CÀI ĐẶT MÃ TỰ ĐỘNG CHO TỪNG BẢNG ***/
/** BẢNG HỌC VIÊN **/
GO
CREATE OR ALTER TRIGGER Trigger_Generate_MASO_HOCVIEN
ON HOCVIEN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewID nvarchar(20);
    SELECT @NewID = 'HV0' + RIGHT('0000' + CAST(NEXT VALUE FOR CommonSequence AS nvarchar), 4)
    FROM inserted;

    UPDATE HOCVIEN
    SET MA_HOC_VIEN = @NewID
    WHERE MA_HOC_VIEN IS NULL;
END;

/** BẢNG LOẠI KHÓA HỌC **/
GO
CREATE OR ALTER TRIGGER Trigger_Generate_MASO_LOAIKHOAHOC
ON LOAIKHOAHOC
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewID nvarchar(20);
    SELECT @NewID = 'LKH0' + RIGHT('0000' + CAST(NEXT VALUE FOR CommonSequence AS nvarchar), 4)
    FROM inserted;

    UPDATE LOAIKHOAHOC
    SET MA_LOAI_KHOA_HOC = @NewID
    WHERE MA_LOAI_KHOA_HOC IS NULL;
END;

/** BẢNG KHOA HỌC **/
GO
CREATE OR ALTER TRIGGER Trigger_Generate_MASO_KHOAHOC
ON KHOAHOC
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewID nvarchar(20);
    SELECT @NewID = 'KH0' + RIGHT('0000' + CAST(NEXT VALUE FOR CommonSequence AS nvarchar), 4)
    FROM inserted;

    UPDATE KHOAHOC
    SET MA_KHOA_HOC = @NewID
    WHERE MA_KHOA_HOC IS NULL;
END;

/** BẢNG LOẠI NHÂN VIÊN **/
GO
CREATE OR ALTER TRIGGER Trigger_Generate_MASO_LOAINHANVIEN
ON LOAINHANVIEN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewID nvarchar(20);
    SELECT @NewID = 'LNV0' + RIGHT('0000' + CAST(NEXT VALUE FOR CommonSequence AS nvarchar), 4)
    FROM inserted;

    UPDATE LOAINHANVIEN
    SET MA_LOAI_NHAN_VIEN = @NewID
    WHERE MA_LOAI_NHAN_VIEN IS NULL;
END;

/** BẢNG NHÂN VIÊN **/
GO
CREATE OR ALTER TRIGGER Trigger_Generate_MASO_NHANVIEN
ON NHANVIEN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewEmployeeID nvarchar(20);
    DECLARE @InsertedEmployeeType nvarchar(20);
    
    SELECT @InsertedEmployeeType = MA_LOAI_NHAN_VIEN FROM inserted;
    
    IF @InsertedEmployeeType = 'LNV000001'
    BEGIN
        SELECT @NewEmployeeID = 'QL0' + RIGHT('0000' + CAST(NEXT VALUE FOR EmployeeSequence AS nvarchar), 6)
    END
    ELSE IF @InsertedEmployeeType = 'LNV000002'
    BEGIN
        SELECT @NewEmployeeID = 'GVU' + RIGHT('0000' + CAST(NEXT VALUE FOR EmployeeSequence AS nvarchar), 5)
    END
    ELSE IF @InsertedEmployeeType = 'LNV000003'
    BEGIN
        SELECT @NewEmployeeID = 'GV0' + RIGHT('0000' + CAST(NEXT VALUE FOR EmployeeSequence AS nvarchar), 5)
    END
	ELSE IF @InsertedEmployeeType = 'LNV000004'
    BEGIN
        SELECT @NewEmployeeID = 'QT0' + RIGHT('0000' + CAST(NEXT VALUE FOR EmployeeSequence AS nvarchar), 5)
    END

    UPDATE NHANVIEN
    SET MA_NHAN_VIEN = @NewEmployeeID
    WHERE MA_NHAN_VIEN IS NULL;
END;

/** BẢNG LỚP HỌC **/
GO
CREATE OR ALTER TRIGGER Trigger_Generate_MASO_LOPHOC
ON LOPHOC
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewID nvarchar(20);
    SELECT @NewID = 'LH0' + RIGHT('0000' + CAST(NEXT VALUE FOR CommonSequence AS nvarchar), 4)
    FROM inserted;

    UPDATE LOPHOC
    SET MA_LOP_HOC = @NewID
    WHERE MA_LOP_HOC IS NULL;
END;

/** BẢNG HÓA ĐƠN **/
GO
CREATE OR ALTER TRIGGER Trigger_Generate_MASO_HOADON
ON HOADON
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewID nvarchar(20);
    SELECT @NewID = 'HD0' + RIGHT('0000' + CAST(NEXT VALUE FOR CommonSequence AS nvarchar), 4)
    FROM inserted;

    UPDATE HOADON
    SET MA_HOA_DON = @NewID
    WHERE MA_HOA_DON IS NULL;
END;

/*** TẠO DỮ LIỆU CHO TỪNG BẢNG ***/
/** BẢNG HỌC VIÊN **/

INSERT INTO HOCVIEN VALUES
	(N'HV000001', N'Trần Văn', N'Hải ', '2000/01/20', 0, N'1 CMT8, TPHCM', N'abcdef@gmail.com', '2024/04/23', 1),
	(N'HV000002', N'Lê Thủy', N'Triều','1999/03/20', 1, N'1 Nguyễn Thị Thập, TPHCM', N'xyz123@gmail.com', '2024/04/02', 1),
	(N'HV000003', N'Nguyễn Hữu', N'Thắng', '2003/01/15', 0, N'1 Bà Điểm, TPHCM', N'john.doe@gmail.com', '2024/02/28', 1),
	(N'HV000004', N'Phan Minh', N'Sang', '1996/09/12', 0, N'101 Nguyễn Xuyến, TPHCM', N'jane.smith@gmail.com', '2024/03/12', 1),
	(N'HV000005', N'Lê Thị M', N'Ngọc', '1995/07/02', 1, N'20 Trần Xuân Soạn', N'johndoe456@gmail.com', '2024/01/25', 1),
	(N'HV000006', N'Nguyễn T', N'Hiếu', '1998/11/23', 0, N'22 Trần Xuân Soạn, TPHCM', N'sarah.jones@gmail.com', '2024/03/27', 1),
	(N'HV000007', N'Phạm Ngọc', N'Thảo', '2001/05/30', 1, N'30 Tân Phú, TPHCM', N'mike.wilson@gmail.com', '2024/02/16', 1),
	(N'HV000008', N'Nguyễn Q', N'Tấn', '2004/08/04', 0, N'40 Nguyễn Văn Linh, TPHCM', N'alexander.green@gmail.com', '2024/01/07', 1),
	(N'HV000009', N'Hỷ Nguyệt', N'Đức', '1997/10/18', 0, N'42 Đỗ Xuân Hợp, TPHCM', N'olivia.white@gmail.com', '2024/03/31', 1),
	(N'HV000010', N'Nguyễn Tr', N'Danh', '2005/02/08', 0, N'32 Xô Viết Nghệ Tĩnh, TPHCM', N'sophia.martin@gmail.com', '2024/01/17', 1),
	(N'HV000011', N'Nguyễn T', N'Thành', '2000/06/05', 0, N'402 Kinh Dương Vương', N'william.johnson@gmail.com', '2024/04/13', 1),
	(N'HV000012', N'Phan Phạm', N'Khang', '1996/02/22', 0, N'22 Đồng Tháp', N'elizabeth.perez@gmail.com', '2024/03/08', 1),
	(N'HV000013', N'Nguyễn L', N'Trường', '2001/11/11', 0, N'88 Long An', N'michael.brown@gmail.com', '2024/04/26', 1),
	(N'HV000014', N'Nguyễn Tr', N'An', '2003/09/29', 1, N'45 Ngô Thừa Nhận, TPHCM', N'amelia.taylor@gmail.com', '2024/04/30', 1),
	(N'HV000015', N'Nguyễn Th', N'Tuyền', '1999/04/19', 1, N'38 Cần Thơ', N'david.thomas@gmail.com', '2024/01/15', 1),
	(N'HV000016', N'Nguyễn Hải', N'Đăng', '1995/12/13', 0, N'30 Tri Tôn', N'sophie.jackson@gmail.com', '2024/02/25', 1),
	(N'HV000017', N'Bùi Văn P', N'Thi', '2004/07/21', 0, N'36 Lộ Tẻ, TPHCM', N'samuel.martinez@gmail.com', '2024/03/02', 1),
	(N'HV000018', N'Mã Minh', N'Nhật', '1998/05/09', 0, N'111 Trần Hưng Đạo, TPHCM', N'charlotte.anderson@gmail.com', '2024/01/08', 1),
	(N'HV000019', N'Nguyễn Văn', N'Hoàng', '1996/08/28', 0, N'23 Trần Hưng Đạo, TPHCM', N'jacob.rodriguez@gmail.com', '2024/02/01', 1),
	(N'HV000020', N'Trần Hà Mỹ', N'Duyên', '1997/01/26', 1, N'29 Nguyễn Huệ, TPHCM', N'emma.davis@gmail.com', '2024/02/03', 1),
	(N'HV000021', N'Nguyễn Văn', N'B', '2005/03/15', 0, N'454 Cần Thơ', N'daniel.miller@gmail.com', '2024/01/05', 1),
	(N'HV000022', N'Hồ Thị', N'Gấm', '2002/10/08', 1, N'345 Nguyễn Thị Hồng Gấm, TPHCM', N'honggam@gmail.com', '2024/03/01', 1),
	(N'HV000023', N'Nguyễn Thị', N'Linh', '2000/09/27', 1, N'1111CMT8, TPHCM', N'chloe.martinez@gmail.com', '2024/03/13', 1),
	(N'HV000024', N'Trần Xuân', N'Tuấn', '1997/11/06', 0, N'355 Xô Viết Nghệ, TPHCM', N'james.hernandez@gmail.com', '2024/03/10', 1),
	(N'HV000025', N'Nguyễn Văn', N'Hoàng', '1999/10/31', 0, N'566 Trường Sa, TPHCM', N'grace.young@gmail.com', '2024/04/20', 1)

INSERT INTO LOAIKHOAHOC VALUES
	(N'LKH000001', N'Anh Văn Giao Tiếp Căn Bản', 1),
	(N'LKH000002', N'Anh Văn Giao Tiếp Nâng Cao', 1),
	(N'LKH000003', N'Tiếng Anh Dành Cho THCS', 1),
	(N'LKH000004', N'Tiếng Anh Du Học Và Dư Bị Đại Học', 1),
	(N'LKH000005', N'Luyện Thi IELTS', 1),
	(N'LKH000006', N'Tiếng Anh Kĩ Năng Chuyên Biệt', 1),
	(N'LKH000007', N'Tiếng Anh Tiểu Học', 1),
	(N'LKH000008', N'Luyện Thi TOEIC', 1),
	(N'LKH000009', N'Tiếng Anh Dành Cho Tiểu Học', 1),
	(N'LKH000010', N'Luyện Thi TOEFL ', 1)

INSERT INTO KHOAHOC VALUES
	(N'KH000001', N'LKH000001', N'Anh Văn Giao Tiếp Căn Bản', '2024/01/13', '2024/04/13', 1, 1000000, 1),
	(N'KH000002', N'LKH000001', N'Anh Văn Giao Tiếp Căn Bản', '2024/01/17', '2024/04/17', 2, 1000000, 1),
	(N'KH000003', N'LKH000001', N'Anh Văn Giao Tiếp Căn Bản', '2024/01/22','2024/04/22', 3, 1000000, 1),
	(N'KH000004', N'LKH000002', N'Anh Văn Giao Tiếp Nâng Cao','2024/02/06', '2024/05/06', 2, 1300000, 1),
	(N'KH000005', N'LKH000002', N'Anh Văn Giao Tiếp Nâng Cao', '2024/02/10', '2024/05/10', 2, 1300000, 1),
	(N'KH000006', N'LKH000002', N'Anh Văn Giao Tiếp Nâng Cao','2024/02/13', '2024/05/13', 2, 1300000, 1),
	(N'KH000007', N'LKH000003', N'Tiếng Anh Dành Cho THCS' ,'2024/02/15', '2024/05/15', 1, 1100000, 1),
	(N'KH000008', N'LKH000003', N'Tiếng Anh Dành Cho THCS' ,'2024/02/19', '2024/05/19', 1, 1100000, 1),
	(N'KH000009', N'LKH000003', N'Tiếng Anh Dành Cho THCS' ,'2024/02/22', '2024/05/22', 1, 1100000, 1),
	(N'KH000010', N'LKH000004', N'Tiếng Anh Du Học Và Dư Bị Đại Học', '2024/02/25', '2024/05/25', 2, 1350000, 1),
	(N'KH000011', N'LKH000004', N'Tiếng Anh Du Học Và Dư Bị Đại Học','2024/02/29', '2024/05/29', 2, 1350000, 1),
	(N'KH000012', N'LKH000005', N'Luyện Thi IELTS', '2024/03/01', '2024/06/01', 3, 1400000, 1),
	(N'KH000013', N'LKH000005', N'Luyện Thi IELTS', '2024/03/02', '2024/03/02', 3, 1400000, 1),
	(N'KH000014', N'LKH000006', N'Tiếng Anh Kĩ Năng Chuyên Biệt', '2024/03/06', '2024/06/06', 2, 1250000, 1),
	(N'KH000015', N'LKH000007', N'Luyện Thi TOEIC', '2024/03/10', '2024/06/10', 2, 1300000, 1)

INSERT INTO LOAINHANVIEN VALUES
	(N'LNV000001', N'Quản lý', 1),
	(N'LNV000002', N'Giáo vụ', 1),
	(N'LNV000003', N'Giảng viên', 1),
	(N'LNV000004', N'Quản trị', 1)

INSERT INTO NHANVIEN VALUES
	(N'GV000001', N'Lê Thủy', N'Triều','1994/08/21', 1, N'TPHCM',  N'0123456678', N'thuy@gmail.com', N'LNV000003', 1),
	(N'GV000002', N'Trần', N'Anh', '1997/11/03', 0, N'TPHCM', N'0112345678', N'anhtran@gmail.com', N'LNV000003', 1),
	(N'GV000003', N'Nguyễn Thu', N'Thủy', '1998/05/23', 1, N'TPHCM', N'0111234567', N'thuynguyen@gmail.com', N'LNV000003', 1),
	(N'GV000004', N'Trần', N'Cảnh', '1990/11/04', 0, N'TPHCM', N'0111112345', N'canhtran@gmail.com', N'LNV000003', 1),
	(N'GV000005', N'Hồ', N'Thị', '1997/08/12', 1, N'TPHCM',N'0123455556', N'thiho@gmail.com',  N'LNV000003', 1),
	(N'GV000006', N'Lê', N'Nam', '1994/03/20', 0, N'TPHCM',N'0112344566', N'namle@gmail.com',  N'LNV000003', 1),
	(N'GV000007', N'Trần', N'Lễ', '1999/01/31', 0, N'TPHCM', N'0123334555', N'letran@gmail.com', N'LNV000003', 1),
	(N'GV000008', N'Lê', N'Ngọc', '1995/09/09', 1, N'TPHCM', N'1234567890', N'ngocle@gmail.com', N'LNV000003', 1),
	(N'GV000009', N'Trần', N'Hùng', '1993/07/14', 0, N'TPHCM', N'9183268789', N'hungtran@gmail.com', N'LNV000003', 1),
	(N'GV000010', N'Võ ', N'Phụng', '1991/10/18', 1, N'TPHCM', N'3287912301', N'phungvo@gmail.com', N'LNV000003', 1),
	(N'GV000011', N'Trần', N'Tuấn', '1996/02/27', 0, N'TPHCM', N'3213981203', N'tuantran@gmail.com', N'LNV000003', 1),
	(N'GV000012', N'Nguyễn', N'Châu', '1992/12/07', 1, N'TPHCM', N'8932840322', N'chaunguyen@gmail.com', N'LNV000003', 1),
	(N'GV000013', N'Tô', N'Châu', '1998/06/15', 1, N'TPHCM', N'7423894723', N'tochau@gmail.com', N'LNV000003', 1),
	(N'GV000014', N'Bùi Văn', N'Hòa', '1997/04/01', 0, N'TPHCM', N'7409321487', N'hoabui@gmail.com', N'LNV000003', 1),
	(N'GV000015', N'Bùi Ngọc', N'Nhi', '1990/08/26', 1, N'TPHCM',  N'7498321743',N'nhibui@gmail.com', N'LNV000003', 1),
	(N'GV000016', N'Trần Văn', N'Trung', '1994/05/07', 0, N'TPHCM', N'8902520421', N'trungtran@gmail.com', N'LNV000003', 1),
	(N'GV000017', N'Nguyễn V', N'Hoàng', '1991/11/28', 0, N'TPHCM', N'8791321237', N'hoangnguyen@gmail.com', N'LNV000003', 1),
	(N'GV000018', N'Lê Hoàng', N'Phi', '1999/03/09', 0, N'TPHCM', N'1321321312', N'phile@gmail.com', N'LNV000003', 1),
	(N'GV000019', N'Phan Hoàng', N'Khang', '1996/07/22', 0, N'TPHCM',N'5432534643', N'khangphan@gmail.com',  N'LNV000003', 1),
	(N'GV000020', N'Phạm Quốc ', N'Khánh', '1992/09/03', 0, N'TPHCM', N'8594386546', N'khanhpham@gmail.com', N'LNV000003', 1),
	(N'GVU00001', N'Nguyễn Thị', N'Anh', '1995/12/14', 1, N'TPHCM', N'0123456788',  N'anhnguyen@gmail.com', N'LNV000002', 1), 
	(N'GVU00002', N'Lê Văn', N'Cảnh', '1993/02/04', 0, N'TPHCM', N'0123456777', N'canhle@gmail.com', N'LNV000002', 1),
	(N'QL000001', N'Nguyễn Hữu', N'Thắng', '1998/10/29', 0, N'TPHCM', N'0123456789', N'thangnguyen@gmail.com', N'LNV000001', 1),
	(N'QL000002', N'Nguyễn Hạ', N'Lam', '1991/06/17', 1, N'TPHCM', N'0777777777', N'lamlam@gmail.com', N'LNV000001', 1),
	(N'QT000001', N'Phan Minh', N'Sang', '1990/04/11', 0, N'TPHCM', N'0123333345', N'sangphan2gmail.com',  N'LNV000004', 1)

INSERT INTO LOPHOC VALUES
	(N'LH000001', N'Anh Văn Giao Tiếp Căn Bản', N'KH000001', N'GV000001', '2024/01/13', '08:00:00', '09:30:00', 15, 2, 1),
	(N'LH000002', N'Anh Văn Giao Tiếp Căn Bản', N'KH000001', N'GV000001', '2024/01/17', '08:00:00', '09:30:00', 15, 2, 1),
	(N'LH000003', N'Anh Văn Giao Tiếp Căn Bản', N'KH000001', N'GV000002', '2024/01/22', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000004', N'Anh Văn Giao Tiếp Nâng Cao', N'KH000002', N'GV000001', '2024/02/06', '15:00:00', '16:30:00', 15, 2, 1),
	(N'LH000005', N'Anh Văn Giao Tiếp Nâng Cao', N'KH000002', N'GV000001', '2024/02/06', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000006', N'Anh Văn Giao Tiếp Nâng Cao', N'KH000003', N'GV000002', '2024/02/10', '15:00:00', '16:30:00', 15, 2, 1),
	(N'LH000004', N'Anh Văn Giao Tiếp Nâng Cao', N'KH000003', N'GV000002', '2024/02/10', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000005', N'Anh Văn Giao Tiếp Nâng Cao', N'KH000004', N'GV000003', '2024/02/13', '15:00:00', '16:30:00', 15, 2, 1),
	(N'LH000006', N'Anh Văn Giao Tiếp Nâng Cao', N'KH000004', N'GV000003', '2024/02/13', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000007', N'Tiếng Anh Dành Cho THCS', N'KH000005', N'GV000004', '2024/02/15', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000008', N'Tiếng Anh Dành Cho THCS', N'KH000006', N'GV000005', '2024/02/19', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000009', N'Tiếng Anh Dành Cho THCS', N'KH000007', N'GV000004', '2024/02/22', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000010', N'Tiếng Anh Du Học Và Dư Bị Đại Học', N'KH000004', N'GV000006', '2024/02/25', '15:00:00', '16:30:00', 15, 2, 1),
	(N'LH000011', N'Tiếng Anh Du Học Và Dư Bị Đại Học', N'KH000004', N'GV000006', '2024/02/25', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000012', N'Tiếng Anh Du Học Và Dư Bị Đại Học', N'KH000005', N'GV000007', '2024/02/29', '15:00:00', '16:30:00', 15, 2, 1),
	(N'LH000013', N'Tiếng Anh Du Học Và Dư Bị Đại Học', N'KH000005', N'GV000007', '2024/02/29', '19:00:00', '20:30:00', 15, 2, 1),
	(N'LH000014', N'Luyện Thi IELTS', N'KH000006', N'GV000008', '2024/03/01', '15:00:00', '16:30:00', 15, 2, 1),
	(N'LH000015', N'Luyện Thi IELTS', N'KH000006', N'GV000008', '2024/03/01', '19:00:00', '20:30:00', 15, 2, 1)

INSERT INTO BANGDIEM VALUES
	(N'HV000001', N'LH000001', 8, 1),
	(N'HV000001', N'LH000005', 8, 1),
	(N'HV000002', N'LH000008', 8, 1),
	(N'HV000003', N'LH000006', 8, 1),
    (N'HV000003', N'LH000007', 8, 1),
    (N'HV000004', N'LH000008', 8, 1),
    (N'HV000004', N'LH000009', 8, 1),
    (N'HV000005', N'LH000010', 8, 1),
    (N'HV000005', N'LH000011', 8, 1),
    (N'HV000006', N'LH000012', 8, 1),
    (N'HV000006', N'LH000013', 8, 1),
    (N'HV000007', N'LH000014', 8, 1),
    (N'HV000007', N'LH000015', 8, 1),
    (N'HV000008', N'LH000006', 8, 1),
    (N'HV000008', N'LH000007', 8, 1),
    (N'HV000009', N'LH000008', 8, 1),
    (N'HV000009', N'LH000009', 8, 1),
    (N'HV000010', N'LH000010', 8, 1),
    (N'HV000011', N'LH000014', 8, 1),
    (N'HV000012', N'LH000015', 8, 1)

INSERT INTO HOADON VALUES
	(N'HD000001', N'LH000001', N'HV000001', '2024/01/02', 1000000, 1),
	(N'HD000002', N'LH000005', N'HV000001','2024/01/28', 1300000, 1),
	(N'HD000003', N'LH000008', N'HV000002','2024/01/25', 1300000, 1),
	(N'HD000004', N'LH000006', N'HV000003','2024/01/10', 1000000, 1),
	(N'HD000005', N'LH000007', N'HV000003','2024/01/24', 1300000, 1),
	(N'HD000006', N'LH000008', N'HV000004','2024/01/28', 1300000, 1),
	(N'HD000007', N'LH000009', N'HV000004','2024/01/28', 1300000, 1),
	(N'HD000008', N'LH000010', N'HV000004','2024/01/28', 1300000, 1),
	(N'HD000009', N'LH000011', N'HV000005','2024/01/28', 1300000, 1),
	(N'HD000010', N'LH000012', N'HV000005','2024/01/28', 1300000, 1),
	(N'HD000011', N'LH000013', N'HV000006','2024/01/28', 1100000, 1),
	(N'HD000012', N'LH000014', N'HV000006','2024/01/28', 1100000, 1),
	(N'HD000013', N'LH000015', N'HV000007','2024/01/28', 1100000, 1),
	(N'HD000014', N'LH000006', N'HV000007','2024/01/28', 1000000, 1),
	(N'HD000015', N'LH000007', N'HV000008','2024/01/28', 1300000, 1)

INSERT INTO TAIKHOAN VALUES
	(N'abc123', N'abc123', 'abc@gmail.com' , 1)
