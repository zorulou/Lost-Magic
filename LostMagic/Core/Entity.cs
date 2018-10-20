using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostMagic.Core
{
    public class Entity : GameObject
    {
        //Toute entité dérive de GameObject
        //Toute entité possède un élément principal et des statistiques de sante, d'attaque, de vitesse d'attaque,
        //de puissance(magie),de défense, de défense magique, d'affinité, d'élément et de résistance
        //Toute entité possède un statut "En vie", "Immobilisé", "Silence"(impossiblité d'attaquer) et "Invulnérable".
        //Toute entité possède une barre de buffs/débuffs.

        public int Sante { get; set; }
        public Elements MainElement { get; set; }
        public int Attaque { get; set; }
        public int Puissance { get; set; }
        public int Defense { get; set; }
        public int DefenseMagique { get; set; }
        public AffiniteEntity Affinite { get; set; }
        public ElementEntity Element { get; set; }
        public ResistanceEntity Resistance { get; set; }
        public StatutEntity Statut { get; set; }
        public BuffEntity Buff { get; set; }

        /// <summary>
        /// L'affinité est un multiplicateur d'élément et de résistance
        /// </summary>
        public class AffiniteEntity
        {
            public int Feu;
            public int Eau;
            public int Air;
            public int Terre;
            public int Lumiere;
            public int Tenebre;
        }

        /// <summary>
        /// L'élément est la force élémentaire de l'entité
        /// </summary>
        public class ElementEntity
        {
            public int Feu;
            public int Eau;
            public int Air;
            public int Terre;
            public int Lumiere;
            public int Tenebre;
        }

        /// <summary>
        /// La résistance est la capacité de l'entité à résister aux dégâts élémentaires
        /// </summary>
        public class ResistanceEntity
        {
            public int Feu;
            public int Eau;
            public int Air;
            public int Terre;
            public int Lumiere;
            public int Tenebre;
        }

        public class StatutEntity
        {
            public bool EnVie;
            public bool Immobilise;
            public bool Silence;
            public bool Invulnerable;
        }

        public class BuffEntity
        {
            public List<EffetBuff> Sante;
            public List<EffetBuff> Attaque;
            public List<EffetBuff> Puissance;
            public List<EffetBuff> Defense;
            public List<EffetBuff> DefenseMagique;
            public List<EffetBuff> AffiniteFeu;
            public List<EffetBuff> AffiniteEau;
            public List<EffetBuff> AffiniteAir;
            public List<EffetBuff> AffiniteTerre;
            public List<EffetBuff> AffiniteLumiere;
            public List<EffetBuff> AffiniteTenebre;
            public List<EffetBuff> Feu;
            public List<EffetBuff> Eau;
            public List<EffetBuff> Air;
            public List<EffetBuff> Terre;
            public List<EffetBuff> Lumiere;
            public List<EffetBuff> Tenebre;
        }

        public class EffetBuff
        {
            public bool Actif;
            public int Source;
            public int Valeur;
            public int Duree;
        }

        public enum Elements
        {
            Feu = 0,
            Eau = 1,
            Air = 2,
            Terre = 3,
            Lumiere = 4,
            Tenebre = 5,
            Tout = 6
        }

        public Entity()
        {
        }

        public Entity(int totalAnimationFrames, int frameWidth, int frameHeight) : base(totalAnimationFrames, frameWidth, frameHeight)
        {
        }
    }
}
