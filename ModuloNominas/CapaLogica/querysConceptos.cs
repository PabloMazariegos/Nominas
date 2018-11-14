using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using CapaDatosNominas;



namespace CapaLogicaNominas
{
    public class querysConceptos
    {
        ConexionCapaDatos cnx = new ConexionCapaDatos();

        // devuelve una tabla con todos los conceptos que tiene asignado un empleado en especifico.
        public DataTable ConceptosdeEmpleados (int id_empleado)
        {
            DataTable conceptosEmpleados = new DataTable();
            OdbcDataAdapter emp = new OdbcDataAdapter("SELECT tbl_conceptosretributivos.ID_ConceptosR as 'Codigo'," +
                                                             "tbl_conceptosretributivos.nombre," +
                                                             "tbl_conceptosretributivos.descripcion," +
                                                             "tbl_conceptosretributivos.importe," +
                                                             "tbl_conceptosretributivos.tipo " +
                                                             "FROM tbl_empleados " +
                                                             "INNER JOIN tbl_empleadoconcepto ON tbl_empleadoconcepto.ID_Empleado= tbl_empleados.ID_Empleado " +
                                                             "INNER JOIN tbl_conceptosretributivos ON tbl_empleadoconcepto.ID_ConceptosR= tbl_conceptosretributivos.ID_ConceptosR " +
                                                             "WHERE tbl_empleados.ID_Empleado=" + id_empleado + ";", cnx.cnxOpen());
            conceptosEmpleados.Columns.Add("Seleccion", typeof(bool)); //agrega una columna de checkboxs
            conceptosEmpleados.Columns["Seleccion"].DefaultValue = true;
            emp.Fill(conceptosEmpleados);
            cnx.cnxClose();
            return conceptosEmpleados;
        }
        


        //Devuelve un query para eliminar los conceptos de un empleado en especifico
        public string GetQueryDelete(int id_empleado, List<int> conceptos)
        {
            string query = "";
            string query2 = "";
            foreach (var concepto in conceptos)
            {
                query += "(" + id_empleado + "," + concepto + "),"; //concatena a un string el ID del empleado con los conceptos que se seleccionaron para eliminarlos
            }
            string queryFix = query.Remove(query.Length - 1, 1);
            query2 = "DELETE FROM tbl_empleadoconcepto WHERE (tbl_empleadoconcepto.ID_Empleado, tbl_empleadoconcepto.ID_ConceptosR) IN (" + queryFix+")";            
            return query2;
        }

        public string GetQueryDeleteMultiple(List<int> empleados, List<int> conceptos)
        {
            string query = "";
            string query2 = "";
            foreach (var emp in empleados)
            {
                foreach(var concp in conceptos)
                {
                    query += "(" + emp + "," + concp + "),"; //concatena a un string el ID del empleado con los conceptos que se seleccionaron para eliminarlos
                }
            }
            string queryFix = query.Remove(query.Length - 1, 1);
            query2 = "DELETE FROM tbl_empleadoconcepto WHERE (tbl_empleadoconcepto.ID_Empleado, tbl_empleadoconcepto.ID_ConceptosR) IN (" + queryFix + ")";
            return query2;
        }





        //Devuelve un query de todos los empleados, se utilizo una vista para
        //mostrar el nombre del area, puesto y contrato en lugar de solo mostrar el ID
        public string GetQueryEmpSelected(List<int> id_empleados)
        {
            string query = "";            
            foreach (var DPI in id_empleados)
            {
                query += "SELECT * FROM empleadoConceptoVW WHERE DPI=" + DPI + " UNION ";
            }
            string queryFix = query.Remove(query.Length - 6, 6);
            return queryFix;
        }






        //devuelve un query para insertar conceptos a los empleados que se seleccionaron
        // 1- Primero busca si el empleado que se selecciono tiene conceptos asignados
        // 2- Guarda los conceptos que tiene asignado el empleado
        // 3- Valida si el concepto que se selecciono no lo tiene asignado el usuario, si ya lo tiene asignado no lo agrega al query
        public string GetQueryInsertEmpConcepto(List<int> id_empleados, List<int> id_conceptos)
        {
            int repeticiones = 0;
            string querybefore = "";
            string queryafter = "";
            string queryFix = "";
            string queryInsert = "";
            List<string> comb_Exist = new List<string>();
            OdbcDataReader dtr;

            //encontrando los empleados que ya tienen conceptos asignados para no volver a insertar los mismos datos
            foreach(var empleado in id_empleados)
            {
                OdbcCommand cmd = new OdbcCommand("SELECT tbl_empleadoconcepto.ID_Empleado, tbl_empleadoconcepto.ID_ConceptosR " +
                                                    "FROM tbl_empleadoconcepto WHERE tbl_empleadoconcepto.ID_Empleado=" + empleado + ";", cnx.cnxOpen());
                dtr = cmd.ExecuteReader();
                while (dtr.Read())
                {
                    comb_Exist.Add("(" + dtr.GetString(0) + "," + dtr.GetString(1) + "),"); //lista de todos los conceptos que tienen asignados los empleados seleccionados
                }
                cnx.cnxClose();
            }            

            foreach (var concepto in id_conceptos)
            {
                foreach (var empleado in id_empleados)
                {
                    querybefore = "(" + empleado + "," + concepto + "),";
                    repeticiones = 0;
                    foreach(var combexistente in comb_Exist) //se valida si el empleado ya tiene asignado el concepto que se selecciono
                    {
                        if (querybefore == combexistente)
                        {
                            repeticiones++;
                        }
                    }
                    if (repeticiones == 0)
                    {
                        queryafter += querybefore;
                    }
                }
                if (queryafter!="")
                {
                    queryFix = queryafter.Remove(queryafter.Length - 1, 1);
                }
                
            }
            if (queryFix != "")
            {
                 queryInsert= "INSERT INTO tbl_empleadoconcepto VALUES" + queryFix;
            }
            
            return queryInsert;
        }
        
    }
}
