using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRent.Domain;

namespace VideoRent.Domain
{
    public class Actor
    {
        private int actorId;
        private string nombreActor;
        private string apellidosActor;
        public Actor()
        {

        }
        public Actor(int actorId, string nombreActor = null, string apellidosActor = null)
        {
            this.ActorId = actorId;
            this.NombreActor = nombreActor;
            this.ApellidosActor = apellidosActor;
        }
        public int ActorId { get => actorId; set => actorId = value; }
        public string NombreActor { get => nombreActor; set => nombreActor = value; }
        public string ApellidosActor { get => apellidosActor; set => apellidosActor = value; }

       
        
    }
}
