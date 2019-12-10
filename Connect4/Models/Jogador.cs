using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public abstract class Jogador
    {
        public int Id { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Jogador)
            {

                if (this.Id ==((Jogador) obj).Id)
                {
                    return true;
                }
            }
            return base.Equals(obj);
        }

        public abstract String Nome { get; }
    }
}
