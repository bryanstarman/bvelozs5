using bvelozs5.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bvelozs5
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string statusMessage { get; set; }
        public void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre esta vacio");
                Persona persona = new() {Name=name};
                result = conn.Insert(persona);
                statusMessage= string.Format("Dato Agregado",result,name);
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("NO se inserto", ex.Message);
            }
        }
        public List<Persona> GetAlllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Erro al mostrar los datos", ex.Message);
            }
            return new List<Persona>();
        }
        public void DeletePerson(int id)
        {
            int result = 0;
            try
            {
                Init();
                if (id<1)
                    throw new Exception("El id no es correcto");
                Persona persona = new() { Id = id };
                result = conn.Delete(persona);          
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("No se Elimino", ex.Message);
            }
        }

        public void UpdatePerson(int id,string name)
        {
            int result = 0;
            try
            {
                Init();
                if(string.IsNullOrEmpty(name))
                    throw new Exception("El nombre esta vacio");
                Persona persona = new() { Id = id,Name=name };
                result = conn.Update(persona);
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("No se Elimino", ex.Message);
            }
        }
    }
}
