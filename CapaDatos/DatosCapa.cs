using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class ContactoDatos
{
    private readonly string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=AGENDA;Integrated Security=True";

    public void Insertar(Contacto contacto)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertarContacto", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", contacto.Id);
            cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
            cmd.Parameters.AddWithValue("@Email", contacto.Email);
            

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void Modificar(Contacto contacto)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("ModificarContacto", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", contacto.Id);
            cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            cmd.Parameters.AddWithValue("@Telefono", contacto.Telefono);
            cmd.Parameters.AddWithValue("@Email", contacto.Email);
            

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void Eliminar(int id)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("EliminarContacto", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public List<Contacto> Buscar(int Id)
    {
        List<Contacto> contactos = new List<Contacto>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("BuscarContacto", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contactos.Add(new Contacto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    Email = reader["Email"].ToString(),
                    
                });
            }
        }
        return contactos;
    }
}
