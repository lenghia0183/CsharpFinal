using ck5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ck5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLNhanSuContext db = new QLNhanSuContext();
        public MainWindow()
        {
            InitializeComponent();
            CBB();
            HienThi();
        }

        public void HienThi()
        {
            var ht = from x in db.NhanViens
                     join pb in db.PhongBans on x.MaPb equals pb.MaPb
                     select new
                     {
                         x.MaNv,
                         x.HoTen,
                         x.Gioitinh,
                         x.NgaySinh,
                         x.NgoaiNgu,
                         TenPhongBan = pb.TenPb
                     };
            dtgNhanVien.ItemsSource = ht.ToList();
        }

        public void CBB()
        {
            var x = from ht in db.PhongBans
                    select ht.TenPb;
            CbbPhongBan.ItemsSource = x.ToList();
            CbbPhongBan.SelectedIndex = 0;
        }

        public void Clear()
        {
            MaNV.Text = string.Empty;
            HoTen.Text = string.Empty;
            NgaySinh.Text = string.Empty;
            TiengAnh.IsChecked = false;
            TiengPhap.IsChecked = false;
            TiengTrung.IsChecked = false;
        }

        bool IsADD = false;

        public void Check()
        {
            try
            {
                if(MaNV.Text == string.Empty)
                {
                    throw new Exception("Ban chua nhap ma nv");
                } else if(HoTen.Text == "")
                {
                    throw new Exception("Ban chua nhap ho ten");
                }
                else if (NgaySinh.Text == "")
                {
                    throw new Exception("Ban chua nhap Ngay sinh");
                }
                else if (TiengAnh.IsChecked == false && TiengPhap.IsChecked == false && TiengTrung.IsChecked == false)
                {
                    throw new Exception("Ban chua chon ngoai ngu");
                }
                IsADD = true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Loi",MessageBoxButton.OK, MessageBoxImage.Error);
                IsADD = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Check();

            try
            {
                if(db.NhanViens.FirstOrDefault(x=>x.MaNv == MaNV.Text) == null) {
                
                    if(IsADD == true)
                    {
                        NhanVien x = new NhanVien();
                        x.MaNv = MaNV.Text;
                        x.HoTen = HoTen.Text;
                        x.NgaySinh = NgaySinh.SelectedDate;
                        if(Nam.IsChecked == true)
                        {
                            x.Gioitinh = "Nam";
                        } else
                        {
                            x.Gioitinh = "Nu";
                        }
                        string nn = "";

                        bool checknn = false;

                        if (TiengAnh.IsChecked == true)
                        {
                            if(checknn == false)
                            {
                                nn += "Tieng Anh";
                            } else
                            {
                                nn += ", Tieng Anh";
                            }
                        }

                        if (TiengTrung.IsChecked == true)
                        {
                            if (checknn == false)
                            {
                                nn += "Tieng Trung";
                            }
                            else
                            {
                                nn += ", Tieng Trung";
                            }
                        }

                        if (TiengPhap.IsChecked == true)
                        {
                            if (checknn == false)
                            {
                                nn += "Tieng Phap";
                            }
                            else
                            {
                                nn += ", Tieng Phap";
                            }
                        }
                        x.NgoaiNgu = nn;
                        x.MaPb = db.PhongBans.FirstOrDefault(a => a.TenPb == CbbPhongBan.Text)!.MaPb;

                        db.Add(x);
                        db.SaveChanges();

                        Clear();
                        HienThi();


                    }
                } else
                {
                    throw new Exception("Nhan vien da ton tai");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(dtgNhanVien.SelectedItem != null)
            {
                try
                {
                    var xoa = db.NhanViens.FirstOrDefault(x => x.MaNv == (dtgNhanVien.SelectedCells[0].Column.GetCellContent(dtgNhanVien.SelectedItem) as TextBlock)!.Text);
                    db.Remove(xoa);
                    db.SaveChanges();
                    HienThi();
                    Clear();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dtgNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(dtgNhanVien.SelectedItem != null)
                {
                    var ht = db.NhanViens.FirstOrDefault(x => x.MaNv == (dtgNhanVien.SelectedCells[0].Column.GetCellContent(dtgNhanVien.SelectedItem) as TextBlock)!.Text);
                    MaNV.Text = ht.MaNv;
                    HoTen.Text = ht.HoTen;
                    NgaySinh.SelectedDate = ht.NgaySinh;
                    if(ht.Gioitinh == "Nam")
                    {
                        Nam.IsChecked = true;
                    } else
                    {
                        Nu.IsChecked = true;
                    }

                    CbbPhongBan.Text = db.PhongBans.FirstOrDefault(x => x.MaPb == ht.MaPb)!.TenPb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            var ht = from x in db.NhanViens
                    
                     join pb in db.PhongBans on x.MaPb equals pb.MaPb
                     where x.MaPb == "PB01"
                     select new
                     {
                         x.MaNv,
                         x.HoTen,
                         x.Gioitinh,
                         x.NgaySinh,
                         x.NgoaiNgu,
                         TenPhongBan = pb.TenPb
                     };
            window1.dtgNhanVien.ItemsSource = ht.ToList();


            window1.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtgNhanVien.SelectedItem != null)
                {

                    var sua = db.NhanViens.FirstOrDefault(x => x.MaNv == (dtgNhanVien.SelectedCells[0].Column.GetCellContent(dtgNhanVien.SelectedItem) as TextBlock)!.Text);
                    sua.HoTen = HoTen.Text;
                    sua.MaNv = MaNV.Text;

                    db.SaveChanges();
                    HienThi();
                    Clear();

                } else
                {
                    throw new Exception("ban chua chon nhan vien de xoa");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
