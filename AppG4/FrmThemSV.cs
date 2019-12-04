using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace AppG4
{
    public partial class FrmThemSV : Form
    {
        public FrmThemSV()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            int idSV = Form1.idToiDa + 1;
            InsertSV(txtTenSV.Text.ToString(), checkBox1.Checked, dateTimePicker1.Value, idSV);
            InsertQuanLyKhoa(Form1.nh, idSV);
            this.Close();
        }

        public void InsertSV(String tenSV, Boolean gioiTinh, DateTime ngaySinh, int idSV)
        {
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                string sql = "insert into SinhVien (idSinhVien, HoTen, GioiTinh, NgaySinh) "
                                                 + " values (@idSV,@HoTen,@GioiTinh, @NgaySinh) ";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                
                SqlParameter gradeParam = new SqlParameter("@idSV", SqlDbType.Int);
                gradeParam.Value = idSV;
                cmd.Parameters.Add(gradeParam);

                
                SqlParameter highSalaryParam = cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                highSalaryParam.Value = tenSV;

               
                cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = gioiTinh;

                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = ngaySinh;

                
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
                MessageBox.Show("Thêm sinh viên thành công");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Thêm sinh viên thất bại");
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }

            Console.Read();
        }

        
        public void InsertQuanLyKhoa(int idNhomMonHoc, int idSV)
        {
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                string sql = "insert into QuanLyKhoa (idNhomMonHoc, idSinhVien) " + " values (@idNhomMonHoc,@idSV)";

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

               
                SqlParameter gradeParam = new SqlParameter("@idSV", SqlDbType.Int);
                gradeParam.Value = idSV;
                cmd.Parameters.Add(gradeParam);

                cmd.Parameters.Add("@idNhomMonHoc", SqlDbType.Int).Value = idNhomMonHoc;

                
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
                MessageBox.Show("Thêm sinh viên vào khoa thành công");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Thêm sinh viên vào khoa thất bại");
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }

            Console.Read();
        }
    }
}
