using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace ColdWeatherHaleySMAPI
{
    /// <summary>The mod entry point.</summary>
    public class ColdWeatherHaleyMAIN : Mod
    {

        /*********
        ** Public methods
        *********/
        /// <param name="helper">Provides methods for interacting with the mod directory, such as read/writing a config file or custom JSON files.</param>
        public override void Entry(IModHelper helper)
        {            
            TimeEvents.SeasonOfYearChanged += this.Event_WinterIsComing;
            SaveEvents.AfterLoad += this.Event_WinterIsAlreadyHere;
        }

        /*********
        ** Private methods
        *********/
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>

        private void changeSprite() {//switch between the sprites

            NPC haley = Game1.getCharacterFromName("Haley", false);

            if (Game1.currentSeason.Equals("winter"))
            {//is winter
                haley.Portrait = Helper.Content.Load<Texture2D>(Path.Combine(Helper.DirectoryPath, "assets", "cold_haley_portrait.xnb"), ContentSource.ModFolder);
                haley.sprite.Texture = Helper.Content.Load<Texture2D>(Path.Combine(Helper.DirectoryPath, "assets", "cold_haley_character.xnb"), ContentSource.ModFolder);
            }
            else
            {//not is winter
                haley.Portrait = Helper.Content.Load<Texture2D>(Path.Combine(Helper.DirectoryPath, "assets", "vanilla_haley_portrait.xnb"), ContentSource.ModFolder);
                haley.sprite.Texture = Helper.Content.Load<Texture2D>(Path.Combine(Helper.DirectoryPath, "assets", "vanilla_haley_character.xnb"), ContentSource.ModFolder);
            }
        }
             
        private void Event_WinterIsComing(object sender, EventArgsStringChanged e)//this change the Haley sprite to winter version when winter comes (or reverse when winter end)
        {
            changeSprite();
        }

        private void Event_WinterIsAlreadyHere(object sender, EventArgs e)//the same, I do not know if the saved game stores the sprites in use, I guess not
        {
            changeSprite();
        }

    }
}

