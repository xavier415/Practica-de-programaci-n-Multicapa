using CapaEntidad;
using System.Collections.Generic;
using System.Configuration;


namespace NegocioCapa
{
    public class ContactoNegocio 
    {
        private ContactoDatos contactoDatos = new ContactoDatos();
        public void Insertar(Contacto contacto)
        {
            contactoDatos.Insertar(contacto);
        }

        public void Modificar(Contacto contacto)
        {
            contactoDatos.Modificar(contacto);
        }

        public void Eliminar(int id)
        {
            contactoDatos.Eliminar(id);
        }

        public List<Contacto> Buscar(int id)
        {
            return contactoDatos.Buscar(id);
        }
    }
}