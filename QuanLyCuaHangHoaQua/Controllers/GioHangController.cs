using QuanLyCuaHangHoaQua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCuaHangHoaQua.Models;

namespace QuanLyCuaHangHoaQua.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyCuaHangHoaQuaEntities1 db = new QuanLyCuaHangHoaQuaEntities1();
        // GET: GioHang
        public List<ItemGioHang> LayGioHang()
        {
            /*Giỏ hàng đã tồn tại*/
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                /*Chưa tồn tại giỏ session thì khởi tạo*/
                lstGioHang = new List<ItemGioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        /*Thêm giỏ hàng*/
        public ActionResult ThemGioHang(int MaSp, string strURL)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.ID == MaSp);
            if (sp == null)
            {
                /*Đường dẫn không hợp lệ*/
                Response.StatusCode = 404;
                return null;
            }
            /*Lấy giỏ hàng*/
            List<ItemGioHang> lstGioHang = LayGioHang();
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.IDSanPham == MaSp);

            if (spCheck != null)
            {
                if (sp.CoSan == false)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.Gia * spCheck.SoLuong;
                return Redirect(strURL);
            }
            if (sp.CoSan == false)
            {
                return View("ThongBao");
            }
            ItemGioHang itemGH = new ItemGioHang(MaSp);
            lstGioHang.Add(itemGH);
            return Redirect(strURL);
        }
        //Tính tổng số lượng
        public double TinhTongSoLuong()
        {
            //Lấy giỏ hàng
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.SoLuong);
        }
        //Tính tổng tiền
        public decimal TinhTongTien()
        {
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ThanhTien);
        }
        // GET: GioHang

        public ActionResult GiohangPartial()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;

                return PartialView();

            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView();
        }
        public ActionResult XemGioHang()
        {
            List<ItemGioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang(int MaSp)
        {
            //Kiểm tra session giỏ hàng tồn tại chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.ID == MaSp);
            if (sp == null)
            {
                /*Đường dẫn không hợp lệ*/
                Response.StatusCode = 404;
                return null;
            }
            //Lấy list giỏ hàng từ session
            List<ItemGioHang> lstGioHang = LayGioHang();
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.IDSanPham == MaSp);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Lấy list gio hang bang tao giao dien
            ViewBag.GioHang = lstGioHang;
            return View(spCheck);
        }
        //Cập nhật giỏ hàng
        [HttpPost]
        public ActionResult CapNhatGioHang(ItemGioHang itemGH)
        {
            SanPham spCheck = db.SanPhams.Single(n => n.ID == itemGH.IDSanPham);
            if (spCheck.CoSan == false)
            {
                return View("ThongBao");
            }
            //Cập nhật sô lượng trong giỏ hàng
            List<ItemGioHang> lstGH = LayGioHang();

            ItemGioHang itemGHUpdate = lstGH.Find(n => n.IDSanPham == itemGH.IDSanPham);

            itemGHUpdate.SoLuong = itemGH.SoLuong;
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.Gia;
            return RedirectToAction("XemGioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int MaSp)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.ID == MaSp);
            if (sp == null)
            {
                /*Đường dẫn không hợp lệ*/
                Response.StatusCode = 404;
                return null;
            }
            //Lấy list giỏ hàng từ session
            List<ItemGioHang> lstGioHang = LayGioHang();
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.IDSanPham == MaSp);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            lstGioHang.Remove(spCheck);
            return RedirectToAction("XemGioHang");
        }
        public ActionResult ThemGioHangAjax(int MaSp, string strURL)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.ID == MaSp);
            if (sp == null)
            {
                /*Đường dẫn không hợp lệ*/
                Response.StatusCode = 404;
                return null;
            }
            /*Lấy giỏ hàng*/
            List<ItemGioHang> lstGioHang = LayGioHang();
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.IDSanPham == MaSp);

            if (spCheck != null)
            {
                if (sp.CoSan == false)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.Gia * spCheck.SoLuong;
                ViewBag.TongSoLuong = TinhTongSoLuong();
                ViewBag.TongTien = TinhTongTien();
                return PartialView("GioHangPartial");
            }
            if (sp.CoSan == false)
            {
                return View("ThongBao");
            }
            ItemGioHang itemGH = new ItemGioHang(MaSp);
            lstGioHang.Add(itemGH);
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();
            return PartialView("GioHangPartial");
        }
        public ActionResult DatHang()
        {
            Session["GioHang"] = null;
            return RedirectToAction("XemGioHang");
        }
    
    }
}