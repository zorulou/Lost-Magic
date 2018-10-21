using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostMagic.Core
{
    public class NPC : Entity
    {
        //Les NPC (non playable caracters) dérivent de la classe Entity
        //Les NPC, contrairement aux joueurs, ne possèdent pas de mana et leurs déplacements
        //sont gérés automatiquement.
        //Les NPC ont une gamme de sorts limitée voire nulle.
    }
}
