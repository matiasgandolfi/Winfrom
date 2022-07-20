using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace TpFinal
{
    class ListaConexion
    {
        //public ListaEmpleados GetNombre()
        //{
            
        //}
        public List<ListaEmpleados> listarEmpleados()
        {
            List<ListaEmpleados> lista = new List<ListaEmpleados>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            conexion.ConnectionString = "data source=DESKTOP-TDVIM8E; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select * from Empleados";
            comando.Connection = conexion;
            conexion.Open();

            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ListaEmpleados aux = new ListaEmpleados();
                //aux.Id = lector.GetInt32(0);
                aux.NombreCompleto = lector.GetString(1);
                aux.DNI = lector.GetString(2);
                aux.Edad = lector.GetInt32(3);
                aux.Casado = lector.GetBoolean(4);
                aux.Salario = lector.GetDecimal(5);

                lista.Add(aux);
            }
            conexion.Close();
            return lista;
        }

        internal void agregar(ListaEmpleados a)
        {
            //throw new NotImplementedException();
            SqlConnection conexion = new SqlConnection("");
            SqlCommand comando = new SqlCommand();

            conexion.ConnectionString = "data source=DESKTOP-TDVIM8E; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
            comando.CommandText = "insert into Empleados values (@nombre, @dni, @edad, @casado, @salario) ";
            comando.Parameters.AddWithValue("@nombre", a.NombreCompleto);
            comando.Parameters.AddWithValue("@dni", a.DNI);
            comando.Parameters.AddWithValue("@edad", a.Edad);
            comando.Parameters.AddWithValue("@casado", a.Casado);
            comando.Parameters.AddWithValue("@salario", a.Salario);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        internal void update(ListaEmpleados a)
        {
            SqlConnection conexion = new SqlConnection("");
            SqlCommand comando = new SqlCommand();

            conexion.ConnectionString = "data source=DESKTOP-TDVIM8E; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
            comando.CommandText = "Update Empleados set NombreCompleto = @Nombre, DNI = @Dni, Edad = @Edad, Casado = @Casado, Salario = @Salario where NombreCompleto = @nombreViejo";
            comando.Parameters.AddWithValue("@nombreViejo", a.NombreViejo);
            comando.Parameters.AddWithValue("@nombre", a.NombreCompleto);
            comando.Parameters.AddWithValue("@dni", a.DNI);
            comando.Parameters.AddWithValue("@edad", a.Edad);
            comando.Parameters.AddWithValue("@casado", a.Casado);
            comando.Parameters.AddWithValue("@salario", a.Salario);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        internal void delete(ListaEmpleados a)
        {
            SqlConnection conexion = new SqlConnection("");
            SqlCommand comando = new SqlCommand();

            conexion.ConnectionString = "data source=DESKTOP-TDVIM8E; initial catalog=EMPLEADOS_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
            comando.CommandText = "Delete Empleados where NombreCompleto = @nombreViejo";
            comando.Parameters.AddWithValue("@nombreViejo", a.NombreViejo);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();

        }



    }


}
