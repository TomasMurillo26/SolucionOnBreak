﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.BC
{
    public class CoffeeBreak
    {
        public string Numero { get; set; }
        public bool Vegetariana { get; set; }

        public CoffeeBreak()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = string.Empty;
            Vegetariana = false;
        }
        public bool Create()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            BD.CoffeeBreak coffee = new BD.CoffeeBreak();
            try
            {
                //sincronizo el contenido de las propiedades a la BD
                CommonBC.Syncronize(this, coffee);
                bd.CoffeeBreak.Add(coffee);
                bd.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                bd.CoffeeBreak.Remove(coffee);
                return false;
            }
        }

        public bool Read()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();
            try
            {
                //busco por el id el contenido de la entidad
                BD.CoffeeBreak coffee =
                    bd.CoffeeBreak.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(coffee, this);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();

            try
            {
                //busco por el id el contenido de la entidad a modificar
                BD.CoffeeBreak coffee =
                    bd.CoffeeBreak.First(e => e.Numero.Equals(this.Numero));
                CommonBC.Syncronize(this, coffee);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete()
        {
            //Crear una conexión al Entities
            BD.OnbreakEntities bd = new BD.OnbreakEntities();

            try
            {
                //busco por el id el contenido de la entidad a eliminar
                BD.CoffeeBreak coffee =
                    bd.CoffeeBreak.First(e => e.Numero.Equals(this.Numero));
                bd.CoffeeBreak.Remove(coffee);
                bd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
