using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostMagic.Core
{
    public class World : GameObject
    {
        //Le World dérive de la classe GameObject
        //Les données de chaque map sont contenues dans le fichier app.config

        public class ImageTileInfo
        {
            public string Name;
            public int Hauteur;
            public int Largeur;
            public int NbrTilesParLigne;
            public int NbrTilesParColonne;
            public Bitmap Image;
        }

        public class TilesInfo
        {
            public int Hauteur;
            public int Largeur;
            public bool[] IsMur;
        }
        public class MapInfo
        {
            public string Name;
            public string FileTilesName;
            public int Hauteur;
            public int Largeur;
            public bool[] Mur;
            public Bitmap ConstructMap;
        }

        public ImageTileInfo ImageTile;
        public TilesInfo Tiles;
        public MapInfo Map;

        public World()
        {
            //Initialisation
            ImageTile = new ImageTileInfo();
            Tiles = new TilesInfo();
            Map = new MapInfo();
            //Extrait les informations sur l'image
            Hashtable section = (Hashtable)ConfigurationManager.GetSection("InformationsTiles");
            ImageTile.Name = (string)section["fileTilesName"];
            ImageTile.Hauteur = Convert.ToInt32(section["hauteurFile"]);
            ImageTile.Largeur = Convert.ToInt32(section["largeurFile"]);
            ImageTile.NbrTilesParLigne = Convert.ToInt32(section["tilesParLigne"]);
            ImageTile.NbrTilesParColonne = Convert.ToInt32(section["tilesParColonne"]);

            //Extrait les informations sur les tiles
            Tiles.Hauteur = Convert.ToInt32(section["hauteurTiles"]);
            Tiles.Largeur = Convert.ToInt32(section["largeurTiles"]);


            //Extrait les informations sur les propriétés des tiles (mur ou non)
            Tiles.IsMur = new bool[ImageTile.NbrTilesParLigne * ImageTile.NbrTilesParColonne];
            section = (Hashtable)ConfigurationManager.GetSection("InformationMur");
            for (int tile = 0; tile < ImageTile.NbrTilesParLigne; tile++)
            {
                if ((string)section[tile] == "plein")
                {
                    Tiles.IsMur[tile] = true;
                }
                else
                {
                    Tiles.IsMur[tile] = false;
                }
            }

            //Extrait les informations sur la taille de la map
            section = (Hashtable)ConfigurationManager.GetSection("InformationsMap");
            Map.Hauteur = Convert.ToInt32(section["hauteur"]);
            Map.Largeur = Convert.ToInt32(section["largeur"]);


            //Extrait les informations sur la disposition de la map et la dessine
            section = (Hashtable)ConfigurationManager.GetSection("ConfigMap");
            Map.ConstructMap = new Bitmap(Map.Largeur * Tiles.Largeur, Map.Hauteur * Tiles.Hauteur);
            ImageTile.Image = new Bitmap(@"C:\Users\Gigoto\source\repos\Game1\Game1\Content\" + ImageTile.Name);
            for (int bloc_Hauteur = 0; bloc_Hauteur < Map.Hauteur; bloc_Hauteur++)
            {
                for (int bloc_Largeur = 0; bloc_Largeur < Map.Largeur; bloc_Largeur++)
                {
                    for (int pixel_X = 0; pixel_X < Tiles.Hauteur; pixel_X++)
                    {
                        for (int pixel_Y = 0; pixel_Y < Tiles.Largeur; pixel_Y++)
                        {
                            Map.ConstructMap.SetPixel(bloc_Largeur * Tiles.Largeur + pixel_Y, bloc_Hauteur * Tiles.Hauteur + pixel_X, ImageTile.Image.GetPixel(pixel_Y + Convert.ToInt32(section[$"bloc{bloc_Hauteur * Map.Largeur + bloc_Largeur}"]) * Tiles.Largeur, pixel_X));
                        }
                    }
                }
            }
        }


        public void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public Texture2D BitmapToTexture2D(GraphicsDevice GraphicsDevice, Bitmap image)
        {
            int bufferSize = image.Height * image.Width * 4;
            MemoryStream memoryStream = new MemoryStream(bufferSize);
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            Texture2D texture = Texture2D.FromStream(GraphicsDevice, memoryStream);
            return texture;
        }
    }
}
