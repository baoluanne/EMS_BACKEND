--
-- Data for Name: HinhThucDaoTao; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."HinhThucDaoTao" VALUES ('b4232509-88e9-4e5f-9510-2a4f2225dcbb', 'CQ', 'Chính Quy', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: BacDaoTao; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."BacDaoTao" VALUES ('6c7522f0-432a-44a3-8ec9-b1414e5b5f6f', 'ĐH', 'Đại học', NULL, 'b4232509-88e9-4e5f-9510-2a4f2225dcbb', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: Khoa; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."Khoa" VALUES ('66b8e26d-fe4c-4519-b12c-6115f30e4cc3', 'CNTT', 'Công nghệ thôngtin', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: KhoiNganh; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."KhoiNganh" VALUES ('83a846ce-705c-4177-b30e-1d2af811598e', 'CN-KT', 'Công nghệ - Kỹ thuật', false, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);
INSERT INTO public."KhoiNganh" VALUES ('1af9f6de-6d2e-4de8-a80d-2b60524566bb', 'KHTN', ' Khoa học Tự nhiên', false, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: NganhHoc; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."NganhHoc" VALUES ('b3724f82-2992-4881-b7fd-4cfc6001d5f2', 'CNTT', 'Công nghệ thông tin', 'Information Technology', 'AA1', '66b8e26d-fe4c-4519-b12c-6115f30e4cc3', '66b8e26d-fe4c-4519-b12c-6115f30e4cc3', NULL, false, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: ChuyenNganh; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."ChuyenNganh" VALUES ('c42ad548-fb40-416b-a1d8-96189e1899da', 'KHMT', 'Khoa học máy tính', 'b3724f82-2992-4881-b7fd-4cfc6001d5f2', NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: CoSoDaoTao; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."CoSoDaoTao" VALUES ('8ea6c465-cfe0-4481-b3ad-279c260f211d', 'DNC1', 'Đại học Nam Cần Thơ 1', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: KhoaHoc; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."KhoaHoc" VALUES ('3d795c1f-cd01-4dff-afa8-189c8965ad0e', '2020-2024', '2024', NULL, NULL, false, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);

--
-- Data for Name: LoaiDaoTao; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."LoaiDaoTao" VALUES ('af05279c-8f4d-491f-ac29-649e021c105f', 'LĐT-CQ', 'Loại đào tạo chính quy', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);

--
-- Data for Name: HinhThucThi; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."HinhThucThi" VALUES ('0dddf8c9-90b7-4235-bba0-74981760fbd8', 'TL', 'Tự luận', NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);
INSERT INTO public."HinhThucThi" VALUES ('b5f4041c-342c-42b8-8e61-225e757b4a98', 'TN', 'Trắc nghiệm', NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);

--
-- Data for Name: LoaiHinhGiangDay; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."LoaiHinhGiangDay" VALUES ('82d4fdfa-15cc-4377-9840-e59096f835e5', 'LT', 'Lý thuyết', NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);
INSERT INTO public."LoaiHinhGiangDay" VALUES ('82d4fdfa-15cc-4377-9840-e59096f835e6', 'TH', 'Thực hành', NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: LoaiMonHoc; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."LoaiMonHoc" VALUES ('e1d4e69d-baa1-496a-87e8-3a46003df9af', 'BB', 'Bắt buộc', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);
INSERT INTO public."LoaiMonHoc" VALUES ('9973ec26-f54c-4a23-8524-ca3b77fe34ba', 'tc', 'Tự chọn', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: LoaiTiet; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."LoaiTiet" VALUES ('ed376e71-6a88-4f07-953b-2df74d7b5299', 'LT', 'Lý Thuyết', NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);
INSERT INTO public."LoaiTiet" VALUES ('ed376e71-6a88-4f07-953b-2df74d7b5300', 'TH', 'Thực Hành', NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);

--
-- Data for Name: ToBoMon; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."ToBoMon" VALUES ('37a44a70-e947-4291-b8d9-4399edd72fe3', 'KTPM', 'Kỹ Thuật Phần Mềm', '66b8e26d-fe4c-4519-b12c-6115f30e4cc3', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: MonHoc; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."MonHoc" VALUES ('0197e90a-00bd-7753-a883-3c8c3cb110ee', 'KTLT', 'Kỹ thuật lập trình', NULL, NULL, NULL, NULL, NULL, 'e1d4e69d-baa1-496a-87e8-3a46003df9af', '66b8e26d-fe4c-4519-b12c-6115f30e4cc3', '37a44a70-e947-4291-b8d9-4399edd72fe3', NULL, NULL, NULL, NULL, NULL, '2025-07-08 14:57:16.379882+07', NULL, NULL, '2025-07-08 14:57:16.379882+07', false);
INSERT INTO public."MonHoc" VALUES ('0197e978-a18d-7388-81d5-5d80dbcdf610', 'PTHTTT', 'Phân tích hệ thống thông tin', NULL, NULL, NULL, NULL, NULL, 'e1d4e69d-baa1-496a-87e8-3a46003df9af', '66b8e26d-fe4c-4519-b12c-6115f30e4cc3', NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-08 16:58:06.478495+07', NULL, NULL, '2025-07-08 16:58:06.478495+07', false);


--
-- Data for Name: MonHocBacDaoTao; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."MonHocBacDaoTao" VALUES ('0197e913-09f2-7c9b-bd54-e1a6896d3db6', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '6c7522f0-432a-44a3-8ec9-b1414e5b5f6f', NULL, NULL, NULL, '0197e90a-00bd-7753-a883-3c8c3cb110ee', NULL, NULL, '2025-07-08 15:07:08.575607+07', NULL, NULL, '2025-07-08 15:07:37.020738+07', true);
INSERT INTO public."MonHocBacDaoTao" VALUES ('0197e979-7e49-7615-af04-004c03400eda', 0, 4, 0, 0, 0, NULL, 0, 0, 0, 0, 0, true, 'Môn học bắt buộc', 0, 0, 0, 0, 0, 0, true, '6c7522f0-432a-44a3-8ec9-b1414e5b5f6f', NULL, NULL, NULL, '0197e978-a18d-7388-81d5-5d80dbcdf610', NULL, NULL, '2025-07-08 16:59:02.985782+07', NULL, NULL, '2025-07-08 17:00:16.047974+07', false);

--
-- Data for Name: LoaiChungChi; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."LoaiChungChi" VALUES ('0197e3fe-53ed-748d-bf00-dbe8e136af8e', 'CC-TH', 'Chứng chỉ tin học', NULL, NULL, NULL, NULL, '2025-07-07 15:26:25.186552+07', NULL, NULL, '2025-07-07 15:26:25.186552+07', false);
INSERT INTO public."LoaiChungChi" VALUES ('0197e97b-4caf-7e0c-8fc1-bdc565a101c8', 'CC-AV', 'Chứng chỉ tiếng anh', NULL, NULL, NULL, NULL, '2025-07-08 17:01:01.363035+07', NULL, NULL, '2025-07-08 17:01:01.363035+07', false);


--
-- Data for Name: ChungChi; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."ChungChi" VALUES ('0197e401-8e65-76cf-8ada-27e806d6f535', 'CCTHCB', NULL, NULL, NULL, NULL, NULL, NULL, 'Chứng chỉ tin học căn bản', '0197e3fe-53ed-748d-bf00-dbe8e136af8e', NULL, NULL, '2025-07-07 15:29:56.754795+07', NULL, NULL, '2025-07-07 15:29:56.754795+07', false);
INSERT INTO public."ChungChi" VALUES ('0197e97b-b590-7d80-9489-f88d8f936e4b', 'CCTA_CB', NULL, NULL, NULL, NULL, NULL, NULL, 'Chứng chỉ tiếng anh cơ bản', '0197e97b-4caf-7e0c-8fc1-bdc565a101c8', NULL, NULL, '2025-07-08 17:01:28.213323+07', NULL, NULL, '2025-07-08 17:01:28.213323+07', false);


--
-- Data for Name: DanhMucPhongBan; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."DanhMucPhongBan" VALUES ('5f2c8804-f1ca-4950-9784-618d6aef9895', 'PĐT', 'Phòng đào tào', false, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);

--
-- Data for Name: HocVi; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."HocVi" VALUES ('5861259d-8865-4c6b-a595-e5e81fc3dd74', 'TS', 'Tiến sĩ', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: LoaiGiangVien; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."LoaiGiangVien" VALUES ('d408c415-cf9d-4ee1-a63f-19249781a155', 'GVC', 'Giảng viên chính', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: GiangVien; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."GiangVien" VALUES ('0197e97c-6629-7759-82f8-fe441c1c2e9b', 'TG_09', 'Nguyễn Xuân', 'An', NULL, NULL, NULL, NULL, 'd408c415-cf9d-4ee1-a63f-19249781a155', '66b8e26d-fe4c-4519-b12c-6115f30e4cc3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, false, false, false, false, NULL, NULL, '2025-07-08 17:02:13.452755+07', NULL, NULL, '2025-07-08 17:02:13.452755+07', false);

--
-- Data for Name: NhomLoaiHanhViViPham; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."NhomLoaiHanhViViPham" VALUES ('32fe0ca3-d57f-4e1f-8a2e-00c7486ee98c', 'VP-HSSV', 'Hành vi vi phạm của học sinh, sinh viên', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: LoaiHanhViViPham; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."LoaiHanhViViPham" VALUES ('825e5d53-7916-4d02-9a2a-1b9f81b50d0f', 'GLTC', 'Gian lận trong thi cử', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: NhomLoaiKhenThuong; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."NhomLoaiKhenThuong" VALUES ('8db3f83e-16a6-43f6-b6e7-c05fce43b5b1', 'CN', 'Khen thưởng cá nhân', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: LoaiKhenThuong; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."LoaiKhenThuong" VALUES ('3b0b8879-1074-419e-9e95-b89b3e9b6154', 'Thành tích học tập', 'TTHT', NULL, NULL, '8db3f83e-16a6-43f6-b6e7-c05fce43b5b1', NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);
INSERT INTO public."LoaiKhenThuong" VALUES ('ee277735-74e0-4a45-9c33-b10b54968ff2', 'Rèn luyện – Đạo đức', 'RLDD', NULL, NULL, '8db3f83e-16a6-43f6-b6e7-c05fce43b5b1', NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: KieuLamTron; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."KieuLamTron" VALUES ('56ba0768-0073-4819-8e71-6437386b0e1c', 'LTL', 'Làm tròn lên', '>= 0.5 lên 1, <0.5 xuống 0', NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: KieuMonHoc; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."KieuMonHoc" VALUES ('378806a4-8de4-48a3-ba5c-ba914df5c607', 'CN', 'Chuyên Nganh', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);
INSERT INTO public."KieuMonHoc" VALUES ('00b2439d-143b-441a-9bf4-f08730af4df8', 'CSN', 'Cơ Sở ngành', NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);


--
-- Data for Name: NamHoc; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public."NamHoc" VALUES ('8fd4f513-1151-4019-95ff-75ec9417c490', '2025', '2021-2025', true, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2025-07-07 15:29:56.754+07', NULL, NULL, '2025-07-07 15:29:56.754+07', false);

-- LoaiChucVu
INSERT INTO public."LoaiChucVu" ("Id","MaLoaiChucVu", "TenLoaiChucVu", "STT", "GhiChu", "NgayTao", "NgayCapNhat", "IsDeleted")
VALUES ('01995b80-5c88-7798-9bdc-94e1fe87dd99', 'CV001', 'Cán sự lớp', 1, 'Seed data', '2025-09-18 13:26:03.086 +0700' , '2025-09-18 13:26:03.086 +0700', false);