using arbolsiempre.clases.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace arbolsiempre.clases.Insertar
{
    class buscarArbol
    {
        public buscarArbol()
        {

        }

        public List<InsertarArbol> cargarnodos()
        {
            Conexion cn = new Conexion();
            InsertarArbol nodos = new InsertarArbol();
            List<InsertarArbol> TodosLosNodos = new List<InsertarArbol>();

            DataTable dt = cn.consultaTablaDirecta("SELECT * FROM [nodos]");

            foreach (DataRow dr in dt.Rows)
            {
                nodos.animal = dr["Animal"].ToString();
                nodos.pregunta = dr["Pregunta"].ToString();
                TodosLosNodos.Add(nodos);
                nodos = new InsertarArbol();
            }
            return TodosLosNodos;

        }

    }
}
