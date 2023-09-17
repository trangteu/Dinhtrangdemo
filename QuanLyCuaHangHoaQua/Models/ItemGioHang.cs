using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyCuaHangHoaQua.Models;

namespace QuanLyCuaHangHoaQua.Models
{
    public class ItemGioHang
    {
        public int IDSanPham { get; set; }
        public string TenSp { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }

        public decimal ThanhTien { get; set; }
        public ItemGioHang(int IMaSP)
        {
            using (QuanLyCuaHangHoaQuaEntities1 db = new QuanLyCuaHangHoaQuaEntities1())
            {
                this.IDSanPham = IMaSP;
                SanPham sp = db.SanPhams.Single(n => n.ID == IDSanPham);
                this.TenSp = sp.Ten;
                this.HinhAnh = sp.Anh;
                this.Gia = sp.Gia.Value;
                this.SoLuong = 1;
                this.ThanhTien = Gia * SoLuong;
            }
        }
        public ItemGioHang(int IMaSP, int sl)
        {
            using (QuanLyCuaHangHoaQuaEntities1 db = new QuanLyCuaHangHoaQuaEntities1())
            {
                this.IDSanPham = IMaSP;
                SanPham sp = db.SanPhams.Single(n => n.ID == IDSanPham);
                TenSp = sp.Ten;
                HinhAnh = sp.Anh;
                Gia = sp.Gia.Value;
                this.SoLuong = sl;
                ThanhTien = Gia * SoLuong;

            }
        }
        public ItemGioHang()
        {

        }
    }
}