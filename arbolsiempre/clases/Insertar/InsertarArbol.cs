using arbolsiempre.clases.BaseDatos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace arbolsiempre.clases.Insertar
{
    class InsertarArbol
    {
        public string animal { get; set; }
        public string pregunta { get; set; }

        public List<InsertarArbol> nodos { get; set; }

        public InsertarArbol()
        {
            nodos = new List<InsertarArbol>();
        }

        public void guardarArbol(InsertarArbol nuevonodo)
        {
            string sql = @"insert into nodos ([animal],[pregunta])
            values ('" + nuevonodo.animal + "','" + nuevonodo.pregunta + "')";
            new Conexion().EjecutaSQLDirecto(sql);
        }

        public List<InsertarArbol> cargatodoslosnodos()
        {
            return new buscarArbol().cargarnodos();
        }

    }
}
