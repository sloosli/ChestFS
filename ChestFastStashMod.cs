using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;

namespace MyCoolNewMod
{
    public class ChestFastStashMod : Mod, IDisposable
    {
        private IModHelper _helper;

        public override void Entry(IModHelper helper)
        {
            _helper = helper;
            _helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        public new void Dispose()
        {
            _helper.Events.Input.ButtonPressed -= OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            var isNotMainGamePlaying = Game1.paused || Game1.currentMinigame != null || Game1.eventUp;
            if (isNotMainGamePlaying)
                return;

            if (e.Button != SButton.F7)
                return;

            var testHudMessage = new HUDMessage("You are pressed F7, soon we will be able to check nearby Chests");
            Game1.addHUDMessage(testHudMessage);
        }
    }
}
