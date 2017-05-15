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
    public class ModEntry : Mod
    {

        private Texture2D haleyPortrait;
        private Texture2D haleyCharacter;

        /*********
        ** Public methods
        *********/
        /// <summary>Initialise the mod.</summary>
        /// <param name="helper">Provides methods for interacting with the mod directory, such as read/writing a config file or custom JSON files.</param>
        public override void Entry(IModHelper helper)
        {

            //this preload the vanillas sprites <I do not know if this is necessary or just is good writen>
            haleyPortrait = helper.Content.Load<Texture2D>(Path.Combine(helper.DirectoryPath, "assets", "VanillaHaleyPortrait.xnb"), ContentSource.ModFolder);
            haleyCharacter = helper.Content.Load<Texture2D>(Path.Combine(helper.DirectoryPath, "assets", "VanillaHaleyCharacter.xnb"), ContentSource.ModFolder);


            ControlEvents.KeyPressed += this.ReceiveKeyPress;//ONLY FOR EXAMPLE, DELETE ON RELEASE
            
            TimeEvents.SeasonOfYearChanged += this.Event_WinterIsComing;
            SaveEvents.AfterLoad += this.Event_WinterIsAlreadyHere;
        }

        /*********
        ** Private methods
        *********/
        /// <summary>The method invoked when the player presses a keyboard button.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>

        private void isWinter(Boolean isWinter) {//switch between the sprites
            if (isWinter) {
                haleyPortrait = Helper.Content.Load<Texture2D>(Path.Combine(Helper.DirectoryPath, "assets", "ColdHaleyPortrait.xnb"), ContentSource.ModFolder);
                haleyCharacter = Helper.Content.Load<Texture2D>(Path.Combine(Helper.DirectoryPath, "assets", "ColdHaleyPortrait.xnb"), ContentSource.ModFolder);
            }
            else {
                haleyPortrait = Helper.Content.Load<Texture2D>(Path.Combine(Helper.DirectoryPath, "assets", "VanillaHaleyPortrait.xnb"), ContentSource.ModFolder);
                haleyCharacter = Helper.Content.Load<Texture2D>(Path.Combine(Helper.DirectoryPath, "assets", "VanillaHaleyCharacter.xnb"), ContentSource.ModFolder);
            }
        }
             
        private void Event_WinterIsComing(object sender, EventArgsStringChanged e)//this change the Haley sprite to winter version when winter comes (or reverse when winter end)
        {
            
        }

        private void Event_WinterIsAlreadyHere(object sender, EventArgs e)//the same, but for people who not install this mod before the winter start (this is redundant?)
        {
            
        }


        
        private void ReceiveKeyPress(object sender, EventArgsKeyPressed e)//DELETE ON RELEASE
        {
            this.Monitor.Log($"Player pressed {e.KeyPressed}.");
        }


    }
}

