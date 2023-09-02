using System.Data.SqlClient;


namespace MVC_Student.Models
{
    public class StudentCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }
        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> list = new List<Student>();
            string qry = "select * from Student where isActive=1";
           cmd=new SqlCommand(qry, con);
            con.Open();
            dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Student s = new Student();
                    s.Sid = Convert.ToInt32(dr["Sid"]);
                    s.Sname = dr["Sname"].ToString();
                    s.Marks = Convert.ToDouble(dr["Marks"]);
                    list.Add(s);
                }
            }
                con.Close();
                return list;
        }
        //        public Student GetStudentById(int Sid)
        //        {

        //        } 
        public int AddStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "insert into Student values(@Sname,@Marks,@isActive)";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Sname", student.Sname);
            cmd.Parameters.AddWithValue("@Marks", student.Marks);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            con.Open();
            result=cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public Student GetStudentById(int id)
        {
            Student s = new Student();
            string qry = "select * from Student where Sid=@Sid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Sid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    s.Sid = Convert.ToInt32(dr["Sid"]);
                    s.Sname = dr["Sname"].ToString();
                    s.Marks = Convert.ToDouble(dr["Marks"]);
             
                }
            }
            con.Close();
            return s;

        }

        public int  UpdateStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "update Student set Sname=@Sname,Marks=@Marks,isActive=@isActive where Sid=@Sid";
            cmd= new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Sname", student.Sname);
            cmd.Parameters.AddWithValue("Marks", student.Marks);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            cmd.Parameters.AddWithValue("@Sid", student.Sid);
            con.Open();
            result=cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int  DeleteStudent(int id)
        {

            int result = 0;
            string qry = "update Student set isActive=0 where Sid=@Sid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Sid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }

        
    }
}
