﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public string Url { get; set; }
        public int IdArticulo { get; set; }

        public override string ToString()
        {
            return Url;
        }
    }
}
