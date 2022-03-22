using Entity.BusinessEntity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataAccess
{
    public class EmpleadoDA
    {
        public List<Empleado> ListarTodosDA()
        {
            List<Empleado> lista = new List<Empleado>();

            using (OracleConnection cn = new ConexionDA().GetSqlConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_ListarTodos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("TABLA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataReader dr = cmd.ExecuteReader();
               // OracleParameter oparam1 = cmd.Parameters.Add("resultItems", OracleDbType.RefCursor);
               // oparam1.Direction = ParameterDirection.Output;

                while (dr.Read())
                {
                    Empleado e = new Empleado();
                    e.id_empleado = Convert.ToInt32(dr["id_empleado"]);
                    e.nombres = Convert.ToString(dr["nombres"]);
                    e.ape_paterno = Convert.ToString(dr["ape_paterno"]);
                    e.ape_materno = Convert.ToString(dr["ape_materno"]);
                    e.genero = Convert.ToString(dr["genero"]);
                    e.fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
                    e.fecha_registro = Convert.ToDateTime(dr["fecha_registro"]);
                    e.correo = Convert.ToString(dr["correo"]);
                    e.sueldo = Convert.ToDouble(dr["sueldo"]);
                    lista.Add(e);
                }

                cn.Close();
            }
            return lista;
        }


        public int AgregarDA(Empleado e)
        {
            int res = 0;

            using (OracleConnection cn = new ConexionDA().GetSqlConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("nombres" , e.nombres);
                cmd.Parameters.Add("ape_paterno", e.ape_paterno);
                cmd.Parameters.Add("ape_materno", e.ape_materno);
                cmd.Parameters.Add("genero", e.genero);
                cmd.Parameters.Add("fecha_nacimiento", e.fecha_nacimiento);
                cmd.Parameters.Add("correo", e.correo);
                cmd.Parameters.Add("sueldo", e.sueldo);
                res = cmd.ExecuteNonQuery();
                cn.Close();
            }

            return res;
        }

        public int ActualizarDA(Empleado e)
        {
            int res = 0;

            using (OracleConnection cn = new ConexionDA().GetSqlConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pNombres", e.nombres);
                cmd.Parameters.Add("pApe_paterno", e.ape_paterno);
                cmd.Parameters.Add("pApe_materno", e.ape_materno);
                cmd.Parameters.Add("pGenero", e.genero);
                cmd.Parameters.Add("pFecha_nacimiento", e.fecha_nacimiento);
                cmd.Parameters.Add("pCorreo", e.correo);
                cmd.Parameters.Add("pSueldo", e.sueldo);
                cmd.Parameters.Add("pId_empleado", e.id_empleado);
                res = cmd.ExecuteNonQuery();
                cn.Close();
            }

            return res;
        }

        public Empleado BuscarPorIdDA(int idEmp)
        {
            Empleado e = null;

            using (OracleConnection cn = new ConexionDA().GetSqlConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_BuscarPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("TABLA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("pIdEmp", idEmp);

                OracleDataReader dr = cmd.ExecuteReader();
           
                if (dr.Read())
                {
                    e = new Empleado();
                    e.id_empleado = Convert.ToInt32(dr["id_empleado"]);
                    e.nombres = Convert.ToString(dr["nombres"]);
                    e.ape_paterno = Convert.ToString(dr["ape_paterno"]);
                    e.ape_materno = Convert.ToString(dr["ape_materno"]);
                    e.genero = Convert.ToString(dr["genero"]);
                    e.fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
                    e.fecha_registro = Convert.ToDateTime(dr["fecha_registro"]);
                    e.correo = Convert.ToString(dr["correo"]);
                    e.sueldo = Convert.ToDouble(dr["sueldo"]);
                }

                cn.Close();
            }
            return e;
        }

        public int EliminarPorIdDA(int idEmp)
        {
            int res = 0;

            using (OracleConnection cn = new ConexionDA().GetSqlConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand("SP_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("pId_empleado", idEmp);
                res = cmd.ExecuteNonQuery();
                cn.Close();
            }

            return res;
        }


        public List<Empleado> ListarTodosSNProcDA()
        {
            List<Empleado> lista = new List<Empleado>();

            using (OracleConnection cn = new ConexionDA().GetSqlConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand("select * from Empleado", cn);
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Empleado e = new Empleado();
                    e.id_empleado = Convert.ToInt32(dr["id_empleado"]);
                    e.nombres = Convert.ToString(dr["nombres"]);
                    e.ape_paterno = Convert.ToString(dr["ape_paterno"]);
                    e.ape_materno = Convert.ToString(dr["ape_materno"]);
                    e.genero = Convert.ToString(dr["genero"]);
                    e.fecha_nacimiento = Convert.ToDateTime(dr["fecha_nacimiento"]);
                    e.fecha_registro = Convert.ToDateTime(dr["fecha_registro"]);
                    e.correo = Convert.ToString(dr["correo"]);
                    e.sueldo = Convert.ToDouble(dr["sueldo"]);
                    lista.Add(e);
                }

                cn.Close();
            }
            return lista;
        }
        public DateTime FechaActualDA()
        {
            DateTime fechaActual = new DateTime(1999, 1, 1);
            using (OracleConnection cn = new ConexionDA().GetSqlConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand("select sysdate as fecha from dual", cn);
                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    fechaActual = dr.GetDateTime(0);
                }

                cn.Close();
            }
            return fechaActual;
        }
    }
}
