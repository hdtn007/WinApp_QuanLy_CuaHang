create DATABASE QL_CUAHANG;
use QL_CUAHANG;


---------------------- by Ngoãn Royal --------------------------------

------------------------------- TAO BANG ---------------------------------
-- bang loai hang hoa
CREATE TABLE LOAIHH ( 
    maloai nchar(5),
    tenloai nvarchar(50)

	PRIMARY KEY (maloai)
);

-- bang nha cung cap
CREATE TABLE NCC (
    mancc nchar(5),
    tenncc nvarchar(50),
	diachi nvarchar(50),
	sdt nchar(10),
	ghichu nvarchar(255)

	PRIMARY KEY (mancc)

);

-- bang su kien
CREATE TABLE SUKIEN (
    mask nchar(5),
    tensk nvarchar(50),
	noidung nvarchar(255),
	giam int

	PRIMARY KEY (mask)
);

-- bang hang hoa
CREATE TABLE HANGHOA (
    mahh nchar(5),
    tenhh nvarchar(50),
	gianhap int,
	dongia int,
	tonkho int,
	donvi nvarchar(20),
	daban int,
	mancc nchar(5),
	maloai nchar(5),
	mask nchar(5),
	ghichu nvarchar(255)

	PRIMARY KEY (mahh),
	CONSTRAINT hh_maloai FOREIGN KEY (maloai)
    REFERENCES LOAIHH(maloai),
	CONSTRAINT hh_mancc FOREIGN KEY (mancc)
    REFERENCES NCC(mancc),
	CONSTRAINT hh_mask FOREIGN KEY (mask)
    REFERENCES SUKIEN(mask)
);

-- bang khach hang
CREATE TABLE KHACHHANG (
    makh nchar(10),
    tenkh nvarchar(50),
	gioitinh nchar(3),
	diachi nvarchar(255),
	sdt nchar(10),
	ghichu nvarchar(255)

	PRIMARY KEY (makh),
);

-- bang nhan vien
CREATE TABLE NHANVIEN (
    manv nchar(5),
    tennv nvarchar(50),
	gioitinh nchar(3),
	ngaysinh date,
	diachi nvarchar(255),
	sdt nchar(10),
	cmnd nvarchar(50),
	email nvarchar(50),
	ghichu nvarchar(255),
	idpq nchar(5)

	PRIMARY KEY (manv),
);

-- bang hoa don
CREATE TABLE HOADON (
    mahd nchar(5),
    manv nchar(5),
	makh nchar(50), -- Lưu theo tên khách hàng
	ngayban date,
	tongtien int

	CONSTRAINT pk_hoadon PRIMARY KEY (mahd)
	CONSTRAINT hd_manv FOREIGN KEY (manv)
    REFERENCES NHANVIEN(manv),
	--CONSTRAINT hd_makh FOREIGN KEY (makh)
  --  REFERENCES KHACHHANG(makh)

);
  
-- bang chi tiet hoa don
CREATE TABLE CTHD (
    mahd nchar(5),
    mahh nchar(5),
	soluong int,
	khuyenmai int,
	dongia int,
	thanhtien int

	CONSTRAINT pk_cthd PRIMARY KEY (mahd,mahh),
	CONSTRAINT cthd_mahh FOREIGN KEY (mahh)
    REFERENCES HANGHOA(mahh),
	CONSTRAINT cthd_mahd FOREIGN KEY (mahd)
    REFERENCES HOADON(mahd)

);

-- bang quan ly
CREATE TABLE QUANLY (
    taikhoan nchar(5),
    matkhau nchar(20),
);

-- bang phan quyen
CREATE TABLE PHANQUYEN (
    idpq nchar(5),
	taikhoan nchar(5),
	matkhau nchar(20),
    phanquyen int,
	ghichu nchar(255)

	CONSTRAINT quanly_manv FOREIGN KEY (manv)
    REFERENCES NHANVIEN(manv),
);

-- bang thong ke hang hoa
CREATE TABLE THONGKE (   -- thống kê số lượng từng sản phẩm bán trong ngày
    mahh nchar(5),
	ngayban date,
	giaban int,  -- giá bán trong ngày đó
	gianhap int,  -- giá nhập trong ngày đó
	soluongban int, -- số đơn hàng đã bán trong ngày
	tongthu int,
	loinhuan int

	CONSTRAINT pk_thongke PRIMARY KEY (mahh,ngayban),

);



select mahh, ngayban, soluongban, tongthu, loinhuan from THONGKE

------------------ cập nhật xử lý --------------------

-- by Ngoãn Royal

select ct.mahd, hh.tenhh, ct.dongia, ct.soluong, hh.donvi, ct.khuyenmai, ct.thanhtien from  CTHD ct, HANGHOA hh where ct.mahh = hh.mahh

select donvi from HANGHOA hh where hh.mahh = 'SP002'

select sk.tensk from HANGHOA hh, SUKIEN sk where hh.mask = sk.mask and hh.mahh = 'SP002'

select hh.giaban*ct.soluong as 'Thành Tiền' from CTHD ct, HANGHOA hh where ct.mahh='SP002' and ct.mahh = hh.mahh

select sum(ct.thanhtien) as 'Tổng Tiền' from CTHD ct where ct.mahd='HD001'

select manv as 'Mã NV', tennv as 'Tên NV', gioitinh as 'Giới Tính', ngaysinh as 'Ngày Sinh', diachi as 'Địa Chỉ', sdt as 'SĐT', cmnd as 'CMND', email as 'Email', ghichu as 'Ghi Chú'  from NHANVIEN

select hd.mahd, hd.makh, nv.tennv, hd.ngayban, hd.tongtien from  HOADON hd, NHANVIEN nv where hd.manv = nv.manv


select ct.mahd, hh.tenhh, hh.dongia, ct.soluong, hh.donvi, sk.giam, (hh.dongia*ct.soluong)-(hh.dongia*ct.soluong*sk.giam)/100 from  CTHD ct, HANGHOA hh, SUKIEN sk where ct.mahh = hh.mahh and hh.mask = sk.mask and mahd = 'HD001'

select hh.donvi from HANGHOA hh, SUKIEN sk where hh.mask = sk.mask and mahh = 'SP001'

select sum((hh.dongia*ct.soluong)-(hh.dongia*ct.soluong*sk.giam)/100) as tongtien from  CTHD ct, HANGHOA hh, SUKIEN sk where ct.mahh = hh.mahh and hh.mask = sk.mask and mahd = 'HD001'

Delete CTHD where mahd = '2'

SELECT * FROM NHANVIEN WHERE manv = (SELECT MAX(manv) FROM NHANVIEN)

SELECT * FROM HANGHOA WHERE mahh = (SELECT mahh='SP001' FROM HANGHOA)
select ct.mahd, hh.mahh , hh.tenhh, hh.dongia, ct.soluong, hh.donvi, sk.giam, (hh.dongia*ct.soluong)-(hh.dongia*ct.soluong*sk.giam)/100 from  CTHD ct, HANGHOA hh, SUKIEN sk where ct.mahh = hh.mahh and hh.mask = sk.mask and mahd = '2'

select hh.dongia,sk.giam from  CTHD ct, HANGHOA hh, SUKIEN sk where ct.mahh = hh.mahh and hh.mask = sk.mask and mahd = '2'

select hh.mahh, hh.tenhh, hh.gianhap, hh.dongia, hh.tonkho, hh.donvi, hh.daban, ncc.tenncc, loai.tenloai, sk.tensk, sk.giam, hh.ghichu  from HANGHOA hh, NCC ncc, SUKIEN sk, LOAIHH loai where hh.mancc=ncc.mancc and hh.maloai=loai.maloai and hh.mask=sk.mask


; select sum(ct.thanhtien) as tongtien from CTHD ct where ct.mahd= '4' 


select ct.mahd, hh.mahh , hh.tenhh, hh.dongia, ct.soluong, hh.donvi, sk.giam, (hh.dongia*ct.soluong)-(hh.dongia*ct.soluong*sk.giam)/100 as thanhtien, hd.tongtien from  CTHD ct, HANGHOA hh, SUKIEN sk, HOADON hd where ct.mahh = hh.mahh and hh.mask = sk.mask  and hd.mahd = ct.mahd and ct.mahd = '4'

group by ct.mahd , hh.mahh, hh.tenhh, hh.dongia, ct.soluong, hh.donvi, sk.giam, thanhtien

Update HOADON set tongtien = (select sum(thanhtien) from CTHD where mahd = '4' ) where mahd = '4'

select sum(thanhtien) as thanhtien from CTHD where mahd = '4'

Update HANGHOA set daban = daban+11, tonkho = tonkho + 11

Update THONGKE set soluongban = soluongban + 11 where mahh = 'SP001'

Update THONGKE set tongthu = giaban*soluongban, loinhuan = giaban*soluongban - gianhap*soluongban 

Insert into THONGKE values ('SP002','01/01/2020','465464','65654','65654','454554','454545')





Update HANGHOA set daban = 10, tonkho = 10
Update THONGKE set soluongban = 10 , tongthu = 0, loinhuan = 0




select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where mahh='SP001' and year(ngayban) = year(CONVERT(DATE,'01/01/2020',103))
select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where mahh='SP001' and month(ngayban) = month(CONVERT(DATE,'01/01/2020',103)) and year(ngayban) = year(CONVERT(DATE,'01/01/2020',103))
select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where mahh='SP001' and day(ngayban) = day(CONVERT(DATE,'01/01/2020',103)) and month(ngayban) = month(CONVERT(DATE,'01/01/2020',103)) and year(ngayban) = year(CONVERT(DATE,'01/01/2020',103))

select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where  year(ngayban) = year(CONVERT(DATE,'01/01/2020',103))
select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where  month(ngayban) = month(CONVERT(DATE,'01/01/2020',103)) and year(ngayban) = year(CONVERT(DATE,'01/01/2020',103))

select sum(tongthu) as tongthu, sum(loinhuan) as loinhuan, sum(soluongban) as soluongban from THONGKE where  day(ngayban) = day(CONVERT(DATE,'01/01/2020',103)) and month(ngayban) = month(CONVERT(DATE,'01/01/2020',103)) and year(ngayban) = year(CONVERT(DATE,'01/01/2020',103))
Delete THONGKE Where mahh = 'SP002'

select * from THONGKE
select * from HANGHOA

select * from CTHD
select * from QUANLY

---------------------- by Ngô Thành An --------------------------------


