using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using VideoRent.Domain;

namespace VideoRent.Domain
{
    public class Genero //todo lo publico se escribe con mayusculas
    {

        private int generoId; //siguen camel case
        private String nombreGenero;

        public Genero()
        {
            
        }
        public Genero(string nombreGenero, int generoId)
        {
            this.nombreGenero = nombreGenero;
            this.generoId = generoId;
        }

        public int GeneroId { get => generoId; set => generoId = value; }
        public string NombreGenero { get => nombreGenero; set => nombreGenero = value; }
    }
}
