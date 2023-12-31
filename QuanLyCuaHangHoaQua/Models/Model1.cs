﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class ChiTietHoaDon
{
    public long ID { get; set; }
    public Nullable<long> IDHoaDon { get; set; }
    public Nullable<long> IDSanPham { get; set; }
    public Nullable<double> Gia { get; set; }
    public Nullable<double> SoLuong { get; set; }
    public string TenSp { get; set; }

    public virtual HoaDon HoaDon { get; set; }
    public virtual SanPham SanPham { get; set; }
}

public partial class HoaDon
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public HoaDon()
    {
        this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
    }

    public long ID { get; set; }
    public Nullable<long> IDKhachHang { get; set; }
    public Nullable<System.DateTime> NgayDat { get; set; }
    public string DiaChi { get; set; }
    public Nullable<double> SoLuong { get; set; }
    public string MoTa { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    public virtual NguoiDung NguoiDung { get; set; }
}

public partial class NguoiDung
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public NguoiDung()
    {
        this.HoaDons = new HashSet<HoaDon>();
    }

    public string TaiKhoan { get; set; }
    public string MatKhau { get; set; }
    public long ID { get; set; }
    public string Ten { get; set; }
    public string Email { get; set; }
    public string DiaChi { get; set; }
    public string SoDienThoai { get; set; }
    public Nullable<long> PhanQuyenID { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<HoaDon> HoaDons { get; set; }
    public virtual PhanQuyen PhanQuyen { get; set; }
}

public partial class PhanQuyen
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PhanQuyen()
    {
        this.NguoiDungs = new HashSet<NguoiDung>();
    }

    public long ID { get; set; }
    public string Name { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
}

public partial class SanPham
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public SanPham()
    {
        this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
    }

    public long ID { get; set; }
    public string Ten { get; set; }
    public Nullable<System.DateTime> NgaySanXuat { get; set; }
    public Nullable<bool> CoSan { get; set; }
    public Nullable<long> IDLoaiSanPham { get; set; }
    public string MoTa { get; set; }
    public string Anh { get; set; }
    public Nullable<decimal> Gia { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    public virtual TheLoai TheLoai { get; set; }
}

public partial class sysdiagram
{
    public string name { get; set; }
    public int principal_id { get; set; }
    public int diagram_id { get; set; }
    public Nullable<int> version { get; set; }
    public byte[] definition { get; set; }
}

public partial class TheLoai
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TheLoai()
    {
        this.SanPhams = new HashSet<SanPham>();
    }

    public long ID { get; set; }
    public string Ten { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<SanPham> SanPhams { get; set; }
}
