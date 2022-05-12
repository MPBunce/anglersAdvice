using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace myMod
{

    public class ModEntry : Mod
    {
        /**********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            // event += method to call
            helper.Events.GameLoop.DayStarted += this.OnDayStarted;
        }

        /// <summary>The method called after a new day starts.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {

            //Initalizing variables
            string theSeason;
            string theWeather;

            //Finding Weather
            if (Game1.isRaining)
            {
                theWeather = "rainy";
            }
            else
            {
                theWeather = "sunny";
            }
   
            //Finding Season
            if (Game1.IsSpring)
            {
                theSeason = "spring";
            }
            else if (Game1.IsWinter)
            {
                theSeason = "winter";
            }
            else if (Game1.IsFall)
            {
                theSeason = "fall";
            }
            else
            {
                theSeason = "summer";
            }


            
            Dictionary<int, string> internalFishData = Game1.content.Load<Dictionary<int, string>>("Data\\Fish");


            this.Monitor.Log("\n\nOn a " + theWeather + " " + theSeason + " day the following fish can be caught:\n", LogLevel.Debug);


            foreach (KeyValuePair<int, string> keyValuePair in internalFishData)
            {


                string stringThing = internalFishData[keyValuePair.Key];


                if (stringThing.Contains("both") && stringThing.Contains(theSeason)){


                    this.Monitor.Log( "" + internalFishData[keyValuePair.Key].Split('/')[0], LogLevel.Debug);
                
              
                }
                if (stringThing.Contains(theWeather) && stringThing.Contains(theSeason))
                {
                    this.Monitor.Log("" + internalFishData[keyValuePair.Key].Split('/')[0], LogLevel.Debug);
                }




            }
                this.Monitor.Log("\n", LogLevel.Debug);
        }

    }

}
