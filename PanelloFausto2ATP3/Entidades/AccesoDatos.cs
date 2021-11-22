using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class AccesoDatos
    {
        private static string connectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        //ConnectionString, se conecta con localhost.
        static AccesoDatos()
        {
            AccesoDatos.connectionString = @"Server=localhost;Database=Hangar;Trusted_Connection=True;";
        }

        public AccesoDatos()
        {
            this.connection = new SqlConnection(AccesoDatos.connectionString);
        }

        public bool Conectarse()
        {
            bool ret = true;

            try
            {
                this.connection.Open();
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return ret;
        }

        /// <summary>
        /// TraerDatos selecciona de cada base de datos individual (aviones, helicopteros, globos), las filas de datos, y las
        /// agrega a una Lista<Aeronave>, que luego devuelve. Creé una variable var aux porque tuve problemas con el GetFloat(),
        /// que no me permitía pasar las variables de tipo float.
        /// </summary>
        /// <returns></returns>
        public Lista<Aeronave> TraerDatos()
        {
            Lista<Aeronave> lista = new Lista<Aeronave>(50);

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = "SELECT * FROM dbo.Aviones";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Avion avion = new Avion();
                    float peso = avion.Peso;

                    avion.Marca = reader[0].ToString();
                    avion.Modelo = reader[1].ToString();
                    avion.VelocidadMaxima = reader.GetInt32(2);
                    avion.AlturaMaxima = reader.GetInt32(3);
                    var aux = reader[4];
                    avion.Peso = float.Parse(aux.ToString());
                    aux = reader[5];
                    avion.Largo = float.Parse(aux.ToString());
                    aux = reader[6];
                    avion.Ancho = float.Parse(aux.ToString());
                    avion.Anio = reader.GetInt32(7);
                    int auxTipoAvion = reader.GetInt32(8);
                    int auxMotor = reader.GetInt32(9);

                    switch (auxTipoAvion)
                    {
                        case 0:
                            avion.Tipo = EAvion.Jet;
                            break;
                        case 1:
                            avion.Tipo = EAvion.Ligero;
                            break;
                        case 2:
                            avion.Tipo = EAvion.Comercial;
                            break;
                    }

                    switch (auxMotor)
                    {
                        case 0:
                            avion.Motor = EMotores.Propulsores;
                            break;
                        case 1:
                            avion.Motor = EMotores.DeReaccion;
                            break;
                    }

                    lista.Agregar(avion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = "SELECT * FROM dbo.Helicopteros";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Helicoptero helicoptero = new Helicoptero();

                    helicoptero.Marca = reader.GetString(0);
                    helicoptero.Modelo = reader.GetString(1);
                    helicoptero.VelocidadMaxima = reader.GetInt32(2);
                    helicoptero.AlturaMaxima = reader.GetInt32(3);
                    var aux = reader[4];
                    helicoptero.Peso = float.Parse(aux.ToString());
                    aux = reader[5];
                    helicoptero.Largo = float.Parse(aux.ToString());
                    aux = reader[6];
                    helicoptero.Ancho = float.Parse(aux.ToString());
                    helicoptero.Anio = reader.GetInt32(7);
                    helicoptero.Rotores = reader.GetInt32(8);
                    int auxTipoHelicoptero = reader.GetInt32(9);

                    switch (auxTipoHelicoptero)
                    {
                        case 0:
                            helicoptero.Tipo = EHelicoptero.Militar;
                            break;
                        case 1:
                            helicoptero.Tipo = EHelicoptero.Sanitario;
                            break;
                        case 2:
                            helicoptero.Tipo = EHelicoptero.Civil;
                            break;
                    }

                    lista.Agregar(helicoptero);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            try
            {
                this.command = new SqlCommand();

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = "SELECT * FROM dbo.Globos";
                this.command.Connection = this.connection;

                this.connection.Open();

                this.reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Globo globo = new Globo();

                    globo.Marca = reader.GetString(0);
                    globo.Modelo = reader.GetString(1);
                    globo.VelocidadMaxima = reader.GetInt32(2);
                    globo.AlturaMaxima = reader.GetInt32(3);
                    var aux = reader[4];
                    globo.Peso = float.Parse(aux.ToString());
                    aux = reader[5];
                    globo.Largo = float.Parse(aux.ToString());
                    aux = reader[6];
                    globo.Ancho = float.Parse(aux.ToString());
                    globo.Anio = reader.GetInt32(7);
                    globo.CapacidadAire = reader.GetInt32(8);
                    globo.Pasajeros = reader.GetInt32(9);

                    lista.Agregar(globo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return lista;
        }

        /// <summary>
        /// Agrega un helicoptero a la base de datos.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool AgregarHelicoptero(Helicoptero param)
        {
            bool ret = true;
            int tipo = 0;

            try
            { 
                if(param.Tipo == EHelicoptero.Militar)
                {
                    tipo = 0;
                }
                else if(param.Tipo == EHelicoptero.Sanitario)
                {
                    tipo = 1;
                }
                else
                {
                    tipo = 2;
                }

                string sql = "INSERT INTO dbo.Helicopteros (Marca, Modelo, VelocidadMaxima, AlturaMaxima," +
                    " Peso, Largo, Ancho, Anio, Rotores, Tipo) VALUES (";
                sql = sql + "'" + param.Marca + "','" + param.Modelo + "'," + param.VelocidadMaxima.ToString() +
                    "," + param.AlturaMaxima.ToString() + "," + param.Peso.ToString() + "," + param.Largo.ToString()
                    + "," + param.Ancho.ToString() + "," + param.Anio.ToString() + "," + param.Rotores.ToString() +
                    "," + tipo.ToString() + ")";

                this.command = new SqlCommand();
                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if(hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch(Exception)
            {
                ret = false;
            }
            finally
            {
                if(this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return ret;
        }

        /// <summary>
        /// Agrega un avión a la tabla Aviones.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool AgregarAvion(Avion param)
        {
            bool ret = true;
            int tipo = 0;
            int motor = 0;

            try
            {
                if (param.Tipo == EAvion.Jet)
                {
                    tipo = 0;
                }
                else if (param.Tipo == EAvion.Ligero)
                {
                    tipo = 1;
                }
                else
                {
                    tipo = 2;
                }

                if(param.Motor == EMotores.DeReaccion)
                {
                    motor = 1;
                }

                string sql = "INSERT INTO dbo.Aviones (Marca, Modelo, VelocidadMaxima, AlturaMaxima," +
                    " Peso, Largo, Ancho, Anio, Tipo, Motor) VALUES (";
                sql = sql + "'" + param.Marca + "','" + param.Modelo + "'," + param.VelocidadMaxima.ToString() +
                    "," + param.AlturaMaxima.ToString() + "," + param.Peso.ToString() + "," + param.Largo.ToString()
                    + "," + param.Ancho.ToString() + "," + param.Anio.ToString() + "," + tipo.ToString() +
                    "," + motor.ToString() + ")";

                this.command = new SqlCommand();
                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if (hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return ret;
        }

        /// <summary>
        /// Agrega un globo a la tabla Globos
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool AgregarGlobo(Globo param)
        {
            bool ret = true;

            try
            {
                string sql = "INSERT INTO dbo.Globos (Marca, Modelo, VelocidadMaxima, AlturaMaxima," +
                    " Peso, Largo, Ancho, Anio, CapacidadAire, Pasajeros) VALUES (";
                sql = sql + "'" + param.Marca + "','" + param.Modelo + "'," + param.VelocidadMaxima.ToString() +
                    "," + param.AlturaMaxima.ToString() + "," + param.Peso.ToString() + "," + param.Largo.ToString()
                    + "," + param.Ancho.ToString() + "," + param.Anio.ToString() + "," + param.CapacidadAire.ToString() +
                    "," + param.Pasajeros.ToString() + ")";

                this.command = new SqlCommand();
                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if (hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return ret;
        }

        /// <summary>
        /// Modifica un helicoptero. Si los modelos del helicoptero son iguales, entonces ese es el que va a modificar.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool ModificarHelicoptero(Helicoptero param)
        {
            bool ret = true;
            int tipo = 0;


            try
            {
                if (param.Tipo == EHelicoptero.Militar)
                {
                    tipo = 0;
                }
                else if (param.Tipo == EHelicoptero.Sanitario)
                {
                    tipo = 1;
                }
                else
                {
                    tipo = 2;
                }

                this.command = new SqlCommand();

                this.command.Parameters.AddWithValue("@Marca", param.Marca);
                this.command.Parameters.AddWithValue("@Modelo", param.Modelo);
                this.command.Parameters.AddWithValue("@VelocidadMaxima", param.VelocidadMaxima);
                this.command.Parameters.AddWithValue("@AlturaMaxima", param.AlturaMaxima);
                this.command.Parameters.AddWithValue("@Peso", param.Peso);
                this.command.Parameters.AddWithValue("@Largo", param.Largo);
                this.command.Parameters.AddWithValue("@Ancho", param.Ancho);
                this.command.Parameters.AddWithValue("@Anio", param.Anio);
                this.command.Parameters.AddWithValue("@Rotores", param.Rotores);
                this.command.Parameters.AddWithValue("@Tipo", tipo);

                string sql = "UPDATE dbo.Helicopteros ";
                sql += "SET Marca = @Marca, Modelo = @Modelo, VelocidadMaxima = @VelocidadMaxima," +
                    " AlturaMaxima = @AlturaMaxima, Peso = @Peso, Largo = @Largo, Ancho = @Ancho," +
                    " Anio = @Anio, Rotores = @Rotores, Tipo = @Tipo";
                sql += " WHERE Modelo = @Modelo";

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if(hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch(Exception ex)
            {
                ret = false;
            }
            finally
            {
                if(this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return ret;
        }

        /// <summary>
        /// Modifica un avion. Si los modelos del avion son iguales, entonces ese es el que va a modificar.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool ModificarAvion(Avion param)
        {
            bool ret = true;
            int tipo = 0;
            int motor = 0;

            try
            {
                if (param.Tipo == EAvion.Jet)
                {
                    tipo = 0;
                }
                else if (param.Tipo == EAvion.Ligero)
                {
                    tipo = 1;
                }
                else
                {
                    tipo = 2;
                }

                if (param.Motor == EMotores.DeReaccion)
                {
                    motor = 1;
                }

                this.command = new SqlCommand();

                this.command.Parameters.AddWithValue("@Marca", param.Marca);
                this.command.Parameters.AddWithValue("@Modelo", param.Modelo);
                this.command.Parameters.AddWithValue("@VelocidadMaxima", param.VelocidadMaxima);
                this.command.Parameters.AddWithValue("@AlturaMaxima", param.AlturaMaxima);
                this.command.Parameters.AddWithValue("@Peso", param.Peso);
                this.command.Parameters.AddWithValue("@Largo", param.Largo);
                this.command.Parameters.AddWithValue("@Ancho", param.Ancho);
                this.command.Parameters.AddWithValue("@Anio", param.Anio);
                this.command.Parameters.AddWithValue("@Tipo", tipo);
                this.command.Parameters.AddWithValue("@Motor", motor);

                string sql = "UPDATE dbo.Aviones";
                sql += " SET Marca = @Marca, Modelo = @Modelo, VelocidadMaxima = @VelocidadMaxima," +
                    " AlturaMaxima = @AlturaMaxima, Peso = @Peso, Largo = @Largo, Ancho = @Ancho," +
                    " Anio = @Anio, Tipo = @Tipo, Motor = @Motor";
                sql += " WHERE Modelo = @Modelo";

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if (hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return ret;
        }

        /// <summary>
        /// Modifica un globo. Si los modelos del globo son iguales, entonces ese es el que va a modificar.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool ModificarGlobo(Globo param)
        {
            bool ret = true;

            try
            {

                this.command = new SqlCommand();

                this.command.Parameters.AddWithValue("@Marca", param.Marca);
                this.command.Parameters.AddWithValue("@Modelo", param.Modelo);
                this.command.Parameters.AddWithValue("@VelocidadMaxima", param.VelocidadMaxima);
                this.command.Parameters.AddWithValue("@AlturaMaxima", param.AlturaMaxima);
                this.command.Parameters.AddWithValue("@Peso", param.Peso);
                this.command.Parameters.AddWithValue("@Largo", param.Largo);
                this.command.Parameters.AddWithValue("@Ancho", param.Ancho);
                this.command.Parameters.AddWithValue("@Anio", param.Anio);
                this.command.Parameters.AddWithValue("@CapacidadAire", param.CapacidadAire);
                this.command.Parameters.AddWithValue("@Pasajeros", param.Pasajeros);

                string sql = "UPDATE dbo.Globos";
                sql += " SET Marca = @Marca, Modelo = @Modelo, VelocidadMaxima = @VelocidadMaxima," +
                    " AlturaMaxima = @AlturaMaxima, Peso = @Peso, Largo = @Largo, Ancho = @Ancho," +
                    " Anio = @Anio, CapacidadAire = @CapacidadAire, Pasajeros = @Pasajeros";
                sql += " WHERE Modelo = @Modelo";

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if (hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }

            return ret;
        }

        /// <summary>
        /// Elimina un helicoptero, el modelo del helicoptero es lo que decide si son iguales.
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public bool EliminarHelicoptero(string modelo)
        {
            bool ret = true;

            try
            {
                this.command = new SqlCommand();

                this.command.Parameters.AddWithValue("@Modelo", modelo);

                string sql = "DELETE FROM dbo.Helicopteros ";
                sql += "WHERE Modelo = @Modelo";

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if(hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch(Exception)
            {
                ret = false;
            }
            finally
            {
                if(this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }
            return ret;
        }

        /// <summary>
        /// Elimina un avion, el modelo del avion es lo que decide si son iguales.
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public bool EliminarAvion(string modelo)
        {
            bool ret = true;

            try
            {
                this.command = new SqlCommand();

                this.command.Parameters.AddWithValue("@Modelo", modelo);

                string sql = "DELETE FROM dbo.Aviones ";
                sql += "WHERE Modelo = @Modelo";

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if (hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }
            return ret;
        }

        /// <summary>
        /// Elimina un globo, el modelo del globo es lo que decide si son iguales.
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        public bool EliminarGlobo(string modelo)
        {
            bool ret = true;

            try
            {
                this.command = new SqlCommand();

                this.command.Parameters.AddWithValue("@Modelo", modelo);

                string sql = "DELETE FROM dbo.Globos ";
                sql += "WHERE Modelo = @Modelo";

                this.command.CommandType = CommandType.Text;
                this.command.CommandText = sql;
                this.command.Connection = this.connection;

                this.connection.Open();

                int hayCambios = this.command.ExecuteNonQuery();

                if (hayCambios == 0)
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }
            return ret;
        }
    }
}
